using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeuProjeto.Pages
{
    public class CorreiosSearch
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CorreiosSearch(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Elements
        public IWebElement cepInput => driver.FindElement(By.Id("endereco"));
        public IWebElement cepSearchButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='btn_pesquisar']")));
        public IWebElement resultEmpty => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h6")));
        public IWebElement result => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"resultado-DNEC\"]/tbody/tr/td[1]")));

        public void NavigateToSearch()
        {
            driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
        }

        public void SearchCEP(string cep)
        {
            cepInput.Clear();
            cepInput.SendKeys(cep);

            cepSearchButton.Click();
        }

        public string GetEmptyResult()
        {
            return resultEmpty.Text;
        }

        public string GetResult()
        {
            return result.Text;
        }
    }
}
