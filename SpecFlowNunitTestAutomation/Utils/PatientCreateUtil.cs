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
        public static string first_FirstName = RandomItemGenerator.RandomTextGeneration(12);
        public static string first_LastName = RandomItemGenerator.RandomTextGeneration(14);
        public static string first_phNumber = RandomItemGenerator.RandomNumberGeneration(1000000000, 10000000000);
        public static string first_DateOfBirth = "03/09/1997";
        public static string first_Address1 = RandomItemGenerator.RandomTextGeneration(16);

        public static string SecondPersonFName = RandomItemGenerator.RandomTextGeneration(11);
        public static string SecondPersonLName = RandomItemGenerator.RandomTextGeneration(8);
        public static string second_PhoneNumber = RandomItemGenerator.RandomNumberGeneration(1000000000, 10000000000);
        public static string second_DateOfBirth = "07/09/2000";
        public static string EmailID = RandomItemGenerator.RandomTextGeneration(7) + "@yahoo.com";
        public static string second_Address1 = RandomItemGenerator.RandomTextGeneration(12);
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
            pb.EnterDetailsToSearchExistingPatient(first_FirstName, first_LastName,first_phNumber,first_DateOfBirth,EmailID);
            pb.SearchPatient();

            //create new patient
            pb.ClickCreateNewButton();
            pb.EnterPatientDetailsToCreateNew(first_FirstName, first_LastName, EmailID, first_DateOfBirth, first_Address1, Zipcode, gender, PhType, ISD, first_phNumber);
            pb.clickContinueWithoutEmail();
            pb.ClickCreate();
           // Thread.Sleep(3000);
            Console.WriteLine(pb.GetToastMessage());

            //close
            
        }
        public static void CreateSecondPatient()
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
            pb.EnterDetailsToSearchExistingPatient(SecondPersonFName, SecondPersonLName, second_PhoneNumber, second_DateOfBirth, EmailID);
            pb.SearchPatient();

            //create new patient
            pb.ClickCreateNewButton();
            pb.EnterPatientDetailsToCreateNew(SecondPersonFName, SecondPersonLName, EmailID,second_DateOfBirth,second_Address1, Zipcode, gender, PhType, ISD, second_PhoneNumber);
            pb.clickContinueWithoutEmail();
            pb.ClickCreate();
           // Thread.Sleep(3000);
            Console.WriteLine(pb.GetToastMessage());

            //close

        }
    }
}
