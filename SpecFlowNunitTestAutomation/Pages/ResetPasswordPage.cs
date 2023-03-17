using OpenQA.Selenium;
using SpecFlowNunitTestAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowNunitTestAutomation.Pages
{
    class ResetPasswordPage:CommonActionsUtils
    {
        private static By Username = By.Id("Username");
        private static By ResetPasswordButton = By.XPath("//*[@class='btn btn-primary btn-lg btn-block centered']");
        private static By UsernameRequiredMessage = By.XPath("//*[@class='validation-summary-errors text-danger']/ul/li");


        public void EnterUsername(string _username)
        {
            WaitForElementToBeClickable(Username, 15);
            SendValue(Username, "Username",_username);
        }

        public LoginPage ClickResetPassword()
        {
            WaitForElementToBeClickable(ResetPasswordButton, 15);
            ClickElement(ResetPasswordButton, "Reset Password");
            return new LoginPage();
        }

        public string GetUsernameRequiredMessage()
        {
            WaitForElementToBeVisible(UsernameRequiredMessage, 15);
            return GetTextValue(UsernameRequiredMessage, "Username required message");
        }
    }
}
