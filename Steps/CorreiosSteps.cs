using TechTalk.SpecFlow;
using SeuProjeto.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeuProjeto.Steps
{
    [Binding]
    public class CorreiosSteps
    {
       
        private IWebDriver driver;
        private CorreiosSearch correiosSearch;
        private CorreiosTracking trackingResult;

        public CorreiosSteps()
        {
            
            // string chromeDriverPath = @".\chromedriver";

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);
            correiosSearch = new CorreiosSearch(driver);
            trackingResult = new CorreiosTracking(driver);
        }

        [Given(@"Entro no site dos Correios - Busca CEP")]
        public void GivenEntronositedosCorreios()
        {
            correiosSearch.NavigateToSearch();
        }

        [When(@"Procuro pelo CEP ""(.*)""")]
        public void WhenProcuropeloCEP(string cep)
        {
            correiosSearch.SearchCEP(cep);
        }

        [Then(@"Deve ser exibida a mensagem ""(.*)""")]
        public void ThenDeveserexibidaamensagem(string message)
        {
            Assert.IsTrue(correiosSearch.GetEmptyResult().Contains(message));
        }

        [Then(@"Deve ser exibido o resultado ""(.*)""")]
        public void ThenDeveserexibidooresultado(string result)
        {
            Assert.IsTrue(correiosSearch.GetResult().Contains(result));
        }

        [Given(@"Entro no site dos Correios - Rastreamento")]
        public void GivenEntronositedosCorreiosRastreamento()
        {
            trackingResult.NavigateToTracking();
        }

        [When(@"Procuro pelo código de rastreamento ""(.*)""")]
        public void WhenProcuropelocdigoderastreamento(string tracker)
        {
            trackingResult.SearchTrackingCode(tracker);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
