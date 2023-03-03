using SpecFlowNunitTestAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowNunitTestAutomation.StepDefinitions
{
    [Binding]
    public sealed class DashboardPageSteps
    {
        DashboardPage dashboardPage = new DashboardPage();
        [Given(@"I open patient browser page")]
        public void GivenIOpenPatientBrowserPage()
        {
            dashboardPage.selectPatientBrowser();
        }

    }
}
