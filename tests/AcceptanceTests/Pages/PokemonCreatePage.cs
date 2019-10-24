using OpenQA.Selenium;

namespace AcceptanceTests.Pages
{
    public class PokemonCreatePage : Page
    {
        public override string Path => "/pokemon/createEdit";

        public void Submit() => Driver.WaitElementEnabled(By.Id("pokemonSaveOrUpdate")).Click();
    }
}
