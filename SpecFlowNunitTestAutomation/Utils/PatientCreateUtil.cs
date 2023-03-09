using NUnit.Framework;
using SpecFlowNunitTestAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowNunitTestAutomation.Utils
{
    
     class PatientCreateUtil 
    {
        public static string FirstName = RandomItemGenerator.RandomTextGeneration(12);
        public static string LastName = RandomItemGenerator.RandomTextGeneration(14);
        public static string PhoneNumber = RandomItemGenerator.RandomNumberGeneration(1000000000, 10000000000);
        public static string DateOfBirth = "05/05/1995";
        public static string EmailID = RandomItemGenerator.RandomTextGeneration(7) + "@yahoo.com";
        public static string Address1 = RandomItemGenerator.RandomTextGeneration(12);
        public static string Zipcode = RandomItemGenerator.RandomNumberGeneration(67801, 67835);
        public static string gender = "2";
        public static string PhType = "1";
        public static string ISD = "229";
        static string username = ExcelUtils.ReadDataFromExcel("Username");
        static string password = ExcelUtils.ReadDataFromExcel("Password");


        CommonActionsUtils cm = new CommonActionsUtils();
        LoginPage lg = new LoginPage();
        DashboardPage db= new DashboardPage();
        PatientBrowserPage pb = new PatientBrowserPage();

        
        //[BeforeTestRun(Order =2)]
        public static void CreateFirstPatient()
        {
            CommonActionsUtils cm = new CommonActionsUtils();
            LoginPage lg = new LoginPage();
            DashboardPage db = new DashboardPage();
            PatientBrowserPage pb = new PatientBrowserPage();
            string Url = ExcelUtils.ReadDataFromExcel("URL");
            cm.LaunchApplication(Url);

            //login
            lg.EnterUsername(username);
            lg.EnterPassword(password);
            lg.ClickLogin();

            //changeStore
            string store = "5001 | Doctor - Mishawaka";
            db.ClickOnDistributionCenterChangeButton();
            db.SelectAnyStore(store);
            db.selectPatientBrowser();

            //search patient
            pb.EnterDetailsToSearchExistingPatient(FirstName, LastName,PhoneNumber,DateOfBirth,EmailID);
            pb.SearchPatient();

            //create new patient
            pb.ClickCreateNewButton();
            pb.EnterPatientDetailsToCreateNew(FirstName, LastName, EmailID, DateOfBirth, Address1, Zipcode, gender, PhType, ISD, PhoneNumber);
            pb.clickContinueWithoutEmail();
            pb.ClickCreate();
           // Thread.Sleep(3000);
            Console.WriteLine(pb.GetToastMessage());

            //close
            
        }
    }
}
