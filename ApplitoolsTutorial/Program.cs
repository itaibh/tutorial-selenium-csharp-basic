using Applitools.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Configuration = Applitools.Selenium.Configuration;


namespace ApplitoolsTutorial
{

    class Program
    {
        public static void Main()
        {
            // Create a new webdriver
            IWebDriver webDriver = new ChromeDriver();

            // Create Eyes object with the runner, meaning it'll be a Visual Grid eyes.
            Eyes eyes = new Eyes();


            //Set the Applitools API KEY here or as an environment variable "APPLITOOLS_API_KEY"
            eyes.ApiKey = "APPLITOOLS_API_KEY";

            // Navigate to the url we want to test
            webDriver.Url = "https://demo.applitools.com/index_v2.html";


            // ⭐️ Note to see visual bugs, run the test using the above URL for the 1st run.
            //but then change the above URL to https://demo.applitools.com/index_v2.html (for the 2nd run)


            // Create SeleniumConfiguration.
            Configuration conf = new Configuration();


            // Set test name
            conf.TestName = "C# Basic demo";

            // Set app name
            conf.AppName = "Demo app";

            // Set the configuration object to eyes
            eyes.Configuration = conf;



            try
            {

                // Call Open on eyes to initialize a test session
                eyes.Open(webDriver);

                // check the login page
                eyes.Check(Target.Window().Fully().WithName("Login page"));
                webDriver.FindElement(By.Id("log-in")).Click();

                // Check the app page
                eyes.Check(Target.Window().Fully().WithName("App page"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                // Close the browser.
                webDriver.Quit();

                // If the test was aborted before eyes.Close was called, ends the test as aborted.
                eyes.AbortIfNotClosed();
            }

        }       
    }
}
