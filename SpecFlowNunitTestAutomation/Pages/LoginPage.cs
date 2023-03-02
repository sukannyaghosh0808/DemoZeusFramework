using OpenQA.Selenium;
using SpecFlowNunitTestAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SpecFlowNunitTestAutomation.Pages
{
    class LoginPage : CommonActionsUtils
    {
        private static By Username = By.Id("txtUserName");
        private static By Password = By.Id("Password");
        private static By LoginButton = By.Id("loginButton");
        private static By LoginWaitMessage = By.Id("loginSpan");
        private static By LoginErrorMessage = By.XPath("//*[@class='validation-summary-errors']/ul/li");
        private static By ForgotPassword = By.XPath("//*[text()='Forgot Password?']");
        private static By EmailSentToEmailMessage = By.XPath("//*[@class='validation-summary-errors']/ul/li");

        public void LaunchZeusApplication()
        {
            string appUrl = ExcelUtils.ReadDataFromExcel("URL");
            LaunchApplication(appUrl);
        }

        public bool ValidateLoginPage()
        {
            string pageUrl = GetPageURL();
            if (pageUrl.Contains("Login"))
                return true;
            else return false;
        }

        public void EnterUsername(string _username)
        {
            ClearText(Username, "Username");
            SendValue(Username, "Username", _username);            
        }
        public void EnterPassword(string _password)
        {
            ClearText(Password, "Password");
            SendValue(Password, "Password", _password);
        }
        public DashboardPage ClickLogin()
        {
            ClickElement(LoginButton, "Login");
            return new DashboardPage();            
        }

        public bool ValidateLoginWaitMessage(string message)
        {
            //WaitForElementToBeVisible(LoginWaitMessage,1000);
            return GetTextFromPageSource(message);            
        }

        public string GetLoginErrorMessage()
        {
             return GetTextValue(LoginErrorMessage, "Error Message");
        }

        public ResetPasswordPage OpenForgotPasswordPage()
        {
            ClickElement(ForgotPassword, "forgot password ?");
            return new ResetPasswordPage();
        }

        public string GetEmailSentToRegisteredEmailmessage()
        {
            return GetTextValue(EmailSentToEmailMessage, "email sent to email");
        }

        public string getFullPageSource()
        {
            return getPageSource();
        }

        public bool ValidateResetPasswordPage()
        {
            if (GetPageURL().Contains("ForgotPassword"))
                return true;
            else
                return false;
        }
    }
}
