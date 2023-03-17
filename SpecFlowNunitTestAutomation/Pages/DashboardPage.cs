using OpenQA.Selenium;
using SpecFlowNunitTestAutomation.Features;
using SpecFlowNunitTestAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowNunitTestAutomation.Pages
{
    class DashboardPage : CommonActionsUtils
    {
        private static By StoreSelector = By.Id("btnStoreSelector");
        private static By StoreSelectorDownArrow = By.XPath("//*[@class='k-icon k-i-arrow-60-down']");
        private static By storeSearchBar = By.XPath("//*[@name='StoreId_input']");
        private static By NavigationBarStoreName= By.XPath("//*[@id='store-quick-selector-content']/span[@class='currentValue']");
        private static By PatientBrowser = By.XPath("//*[@class='fa fa-user']//following-sibling::span[text()='Patient Browser']");
        private static By DashboardpageIcon = By.XPath("//*[text()='Dashboard']");
        private static By Scheduler = By.XPath("//*[@class='sub-menu']/child::a/child::i/following-sibling::span[text()='Scheduler']");       
        private static By POSMenu = By.XPath("//*[text()='POS']");
        
        
        
        public void ClickOnDistributionCenterChangeButton()
        {
            ClickElement(StoreSelector, "Store selector");
        }

        public void SelectAnyStore(string store)
        {
            WaitForElementToBeClickable(StoreSelectorDownArrow,5);
            ClickElement(StoreSelectorDownArrow,"Down Arrow");
            Thread.Sleep(1000);
            ClearText(storeSearchBar, " ");
            SendValue(storeSearchBar, " ", store);
            Thread.Sleep(3000);
            PressEnter(storeSearchBar, " ");
            Thread.Sleep(3000);
        }

        public string GetCurrentStoreName()
        {
            WaitForElementToBeVisible(NavigationBarStoreName, 15);
            return GetTextValue(NavigationBarStoreName, "current store");
        }

        public PatientBrowserPage selectPatientBrowser()
        {
            WaitForElementToBeVisible(PatientBrowser, 15);
            ClickElement(PatientBrowser, "Patient Browser");
            return new PatientBrowserPage();
        }

        public bool validateDashboardPageIcon()
        {
            WaitForElementToBeVisible(DashboardpageIcon, 15);
            string dashboardIcon = GetTextValue(DashboardpageIcon, "dashboard icon");
            if (dashboardIcon == "Dashboard")
                return true;
            else
                return false;
        }

        public void GoToSchedulerMenu()
        {
            WaitForElementToBeClickable(Scheduler, 15);
            ClickElement(Scheduler, "scheduler");
        }
        public void GoToPOSMenu()
        {
            WaitForElementToBeClickable(POSMenu, 15);
            ClickElement(POSMenu, "POS");
        }

    }
}
