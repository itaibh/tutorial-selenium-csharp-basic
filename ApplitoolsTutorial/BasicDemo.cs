using Applitools;
using Applitools.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;


namespace ApplitoolsTutorial
{

    [TestFixture]
    public class BasicDemo
    {
        private EyesRunner runner;
        private Eyes eyes;

        private IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            //Initialize the Runner for your test.
            runner = new ClassicRunner();

            // Initialize the eyes SDK (IMPORTANT: make sure your API key is set in the APPLITOOLS_API_KEY env variable).
            eyes = new Eyes(runner);

            // Use Chrome browser
            driver = new ChromeDriver();
        }


        [Test]
        public void BasicTest()
        {
            // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            eyes.Open(driver, "Demo App", "Smoke Test", new Size(800, 600));

            // Navigate the browser to the "ACME" demo app. To see visual bugs after the first run, use the commented line below instead.
            driver.Url = "https://demo.applitools.com/";
            //driver.Url = "https://demo.applitools.com/index_v2.html";

            // Visual checkpoint #1 - Check the login page.
            eyes.CheckWindow("Login Page");

            // This will create a test with two test steps.
            driver.FindElement(By.Id("log-in")).Click();
            
            // Visual checkpoint #2 - Check the app page.
            eyes.CheckWindow("App Window");

            // End the test.
            eyes.CloseAsync();
        }

        [TearDown]
        public void AfterEach()
        {
            // Close the browser.
            driver.Quit();

            // If the test was aborted before eyes.close was called, ends the test as aborted.
            eyes.AbortIfNotClosed();

            //Wait and collect all test results
            TestResultsSummary allTestResults = runner.GetAllTestResults();
        }

    }
}
