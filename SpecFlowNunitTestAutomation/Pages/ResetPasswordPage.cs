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
        public void EnterValidUsername(string _username)
        {
            SendValue(Username, "Username",_username);
        }

        public LoginPage ClickResetPassword()
        {
            ClickElement(ResetPasswordButton, "Reset Password");
            return new LoginPage();
        }
    }
}
