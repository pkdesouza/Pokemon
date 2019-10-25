using AcceptanceTests.Pages;
using Lambda3.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using PokemonAPI;
using System;
using System.Threading;

namespace AcceptanceTests
{
    [SetUpFixture]
    public class Setup
    {
        private WebApplicationFactory<Startup> webAppFactory;

        private FrontendServer frontendServer;

        private static int attempts = 0;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            StartApiServer();
            StartFrontend();
            // waiting project frontend start
            Thread.Sleep(10000);
            DriverManager.Start();
            BaseAcceptanceTest.WebAppFactory = webAppFactory;
            Page.BaseUrl = frontendServer.BaseUrl;
            NavigateHome();
        }

        private void StartApiServer()
        {
            webAppFactory = new WebApplicationFactory<Startup>(port: 4972);
            webAppFactory.CreateDefaultClient();            
        }

        private void StartFrontend()
        {
            frontendServer = new FrontendServer(ProjectFinder.FindProjectDir("src/frontend"));
            frontendServer.StartFrontEnd();
        }

        private void NavigateHome()
        {
            try
            {
                new HomePage().Navigate();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not navigate home during test setup.", ex);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            RunAndSwallowException(() => DriverManager.Stop());
            RunAndSwallowException(() => frontendServer?.Dispose());
            RunAndSwallowException(() => webAppFactory?.Dispose());
        }

        private static void RunAndSwallowException(Action action)
        {            
            try
            {
                action();
            }
            catch {
                if (attempts < 2)
                {
                    attempts++;
                    Thread.Sleep(500*attempts);
                    RunAndSwallowException(action);
                }
                attempts = 0;
            }
        }
    }
}
