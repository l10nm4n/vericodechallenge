using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeuProjeto.Pages
{
    public class CorreiosTracking
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CorreiosTracking(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Elements
        public IWebElement trackerInput => driver.FindElement(By.Id("objeto"));
        public IWebElement trackingResult => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("//*[@id=\"alerta\"]/div[1]")));
        
        
        public void NavigateToTracking()
        {
            driver.Navigate().GoToUrl("https://rastreamento.correios.com.br/app/index.php");
        }
        public void SearchTrackingCode(string tracker)
        {
            trackerInput.Clear();
            trackerInput.SendKeys(tracker);
            trackerInput.Submit();
        }

        public string GetTrackinResult()
        {
            return trackingResult.Text;
        }
    }
}
