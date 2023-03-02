using NUnit.Framework;
using SpecFlowNunitTestAutomation.Hooks;
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
    public sealed class CommonActionSteps
    {
        LoginPage loginPage = new LoginPage();

        [Given(@"Launch the Zeus application")]
        public void GivenLaunchTheZeusApplication()
        {
            loginPage.LaunchZeusApplication();            
        }
        [Given(@"User is not logged in")]
        public void GivenUserIsNotLoggedIn()
        {
            bool loginStatus= loginPage.ValidateLoginPage();
            Assert.IsTrue(loginStatus,"User is already logged in. Please log out and try!");
        }

    }
}
