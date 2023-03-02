using NPOI.OpenXmlFormats.Vml.Office;
using NUnit.Framework;
using SpecFlowNunitTestAutomation.Hooks;
using SpecFlowNunitTestAutomation.Pages;
using SpecFlowNunitTestAutomation.TableData;
using SpecFlowNunitTestAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SpecFlowNunitTestAutomation.StepDefinitions
{
    [Binding]
    public sealed class LoginPageSteps
    {
        LoginPage loginPage = new LoginPage();
        ResetPasswordPage resetPasswordPage = new ResetPasswordPage();

        public static string loginPageWithoutAnyAction = "";

        [Given(@"I provide all required fields with valid data")]
        public void GivenIProvideAllRequiredFieldsWithValidData()
        {
            string username = ExcelUtils.ReadDataFromExcel("Username");
            string password = ExcelUtils.ReadDataFromExcel("Password");
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);

            ReporterClass.AddStepLog("Username provided: " + username);
            ReporterClass.AddStepLog("Password provided: " + password);
        }

        [When(@"I click on Login")]
        public void WhenIClickOnLogin()
        {
            loginPage.ClickLogin();
        }
        [Then(@"User should be redirected to Zeus main page after being prompted with message ""([^""]*)""")]
        public void ThenUserShouldBeRedirectedToZeusMainPageAfterBeingPromptedWithMessage(string message)
        {
            bool status = loginPage.ValidateLoginWaitMessage(message);
            Assert.IsTrue(status);
        }
        [Given(@"I provide all required fields with incorrect password")]
        public void GivenIProvideAllRequiredFieldsWithIncorrectPassword()
        {
            string username = ExcelUtils.ReadDataFromExcel("Username", 2);
            string password = ExcelUtils.ReadDataFromExcel("Password", 2);

            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            ReporterClass.AddStepLog("Username provided: " + username);
            ReporterClass.AddStepLog("Password provided: " + password);

        }
        [Then(@"User should be prompted with message ""([^""]*)""")]
        public void ThenUserShouldBePromptedWithMessage(string p0)
        {
            string actual = loginPage.GetLoginErrorMessage();
            Assert.AreEqual(actual, p0,"Wrong Error Message");
        }
        [Given(@"I open Forgot Password Page")]
        public void GivenIOpenForgotPasswordPage()
        {
            loginPage.OpenForgotPasswordPage();
        }

        [Given(@"I provide Valid Username")]
        public void GivenIProvideValidUsername(Table table)
        {
            var data = table.CreateInstance<ResetPasswordPageTableData>();
            resetPasswordPage.EnterUsername(data.ValidUsername);
            ReporterClass.AddStepLog("Valid Username entered : " + data.ValidUsername);
        }

        [When(@"I click Reset Password")]
        public void WhenIClickResetPassword()
        {
            resetPasswordPage.ClickResetPassword();
        }

        [Then(@"User should be redirected to the Login Page and receive ""([^""]*)""")]
        public void ThenUserShouldBeRedirectedToTheLoginPageAndReceive(string p0)
        {
            Assert.IsTrue(loginPage.ValidateLoginPage());
            Assert.AreEqual(p0,loginPage.GetEmailSentToRegisteredEmailmessage(),"Actual message and Expected message are not same");
             ReporterClass.AddStepLog("Message dispalyed : " + loginPage.GetEmailSentToRegisteredEmailmessage());
        }

        [Given(@"I provide all required fields with non existing Username and password")]
        public void GivenIProvideAllRequiredFieldsWithNonExistingUsernameAndPassword()
        {
            string InvalidUsername = ExcelUtils.ReadDataFromExcel("Username", 3);
            string InvalidPassword = ExcelUtils.ReadDataFromExcel("Password", 3);

            loginPage.EnterUsername(InvalidUsername);
            loginPage.EnterPassword(InvalidPassword);
            ReporterClass.AddStepLog("Username provided: " + InvalidUsername);
            ReporterClass.AddStepLog("Password provided: " + InvalidPassword);
        }
        [Given(@"I don't provide any Username or password")]
        public void GivenIDontProvideAnyUsernameOrPassword()
        {
            loginPageWithoutAnyAction = loginPage.getFullPageSource();

            loginPage.EnterUsername(" ");
            loginPage.EnterPassword(" ");
            ReporterClass.AddStepLog("Username provided as blank");
            ReporterClass.AddStepLog("Password provided as blank");
        }
        [Then(@"nothing should happen and user stays on login page only")]
        public void ThenNothingShouldHappenAndUserStaysOnLoginPageOnly()
        {
            //
            //How to Validate Nothing should happen?
            //
            string pgSrc = loginPage.getPageSource();
            //Assert.AreEqual(pgSrc, loginPageWithoutAnyAction,"Before and After page are not same");
            Assert.IsTrue(loginPage.ValidateLoginPage());
        }
        [When(@"I click Forgot Password\?")]
        public void WhenIClickForgotPassword()
        {
            loginPage.OpenForgotPasswordPage();
        }
        [Then(@"User should be redirected to Forgot Password page")]
        public void ThenUserShouldBeRedirectedToForgotPasswordPage()
        {
            bool status = loginPage.ValidateResetPasswordPage();
            Assert.IsTrue(status,"User is not redirected to forgot password page");
        }
        [Then(@"User should receive ""([^""]*)""")]
        public void ThenUserShouldReceive(string expected)
        {
            string actual = resetPasswordPage.GetUsernameRequiredMessage();
            Assert.AreEqual(expected, actual,"Correct waring message is not displaying");
            ReporterClass.AddStepLog("Message shown : " + actual);

        }
        [Given(@"I provide an invalid Username")]
        public void GivenIProvideAnInvalidUsername()
        {
            string InvalidUsername = ExcelUtils.ReadDataFromExcel("Username", 3);
            resetPasswordPage.EnterUsername(InvalidUsername);
            ReporterClass.AddStepLog("Username provided: " + InvalidUsername);
        }

    }
}
