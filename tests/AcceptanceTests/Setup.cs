using AcceptanceTests.Pages;
using Bogus;
using Lambda3.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using PokemonAPI;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AcceptanceTests
{
    [SetUpFixture]
    public class Setup
    {
        private WebApplicationFactory<Startup> webAppFactory;

        private FrontendServer frontendServer;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            StartApiServer();
            StartFrontend();
            System.Threading.Thread.Sleep(10000);
            DriverManager.Start();
            BaseAcceptanceTest.WebAppFactory = webAppFactory;
            Page.BaseUrl = frontendServer.BaseUrl;
            NavigateHome();
        }

        private void StartApiServer()
        {
            webAppFactory = new WebApplicationFactory<Startup>(port: 44333);
            webAppFactory.CreateClient();            
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

        private static void RunAndSwallowException(Action a)
        {
            try
            {
                a();
            }
            catch { }
        }
    }
}
