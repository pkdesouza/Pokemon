using OpenQA.Selenium;
using System.Linq;
using System;
using System.Diagnostics;

namespace AcceptanceTests.Pages
{
    public class PokemonCreatePage : Page
    {
        public override string Path => "/pokemon/createEdit";

        public void Submit() => Driver.WaitElementEnabled(By.Id("pokemonSaveOrUpdate")).Click();

        public void InputByClassName(string text, string className = "search-input")
        {
            var inputs = Driver.FindElements(By.ClassName(className));
            foreach (var input in inputs)
                input.SendKeys(text);
        }

        public void SeletedCheckBoxByName(string name = "btSelectAll")
        {
            var checkboxs = Driver.FindElements(By.Name(name));
            foreach (var checkbox in checkboxs)
                checkbox.Click();
        }
        public void ClickRemoveButtonById(string id = "remove")
        {
            var button = Driver.FindElement(By.Id(id));
            button.Click();
        }
    }
}
