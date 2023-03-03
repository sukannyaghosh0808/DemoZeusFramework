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


        public void ClickOnDistributionCenterChangeButton()
        {
            ClickElement(StoreSelector, "Store selector");
        }

        public void SelectAnyStore(string store)
        {
            WaitForElementToBeClickable(StoreSelectorDownArrow,5);
            ClickElement(StoreSelectorDownArrow,"Down Arrow");
            ClearText(storeSearchBar, " ");
            SendValue(storeSearchBar, " ", store);
            Thread.Sleep(3000);
            PressEnter(storeSearchBar, " ");
            Thread.Sleep(3000);
        }

        public string GetCurrentStoreName()
        {
            return GetTextValue(NavigationBarStoreName, "current store");
        }

        public PatientBrowserPage selectPatientBrowser()
        {
            ClickElement(PatientBrowser, "Patient Browser");
            return new PatientBrowserPage();
        }
    }
}
