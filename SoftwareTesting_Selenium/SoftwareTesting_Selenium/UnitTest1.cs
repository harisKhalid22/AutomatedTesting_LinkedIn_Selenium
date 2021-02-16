using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SoftwareTesting_Selenium
{
	[TestClass]
	public class LinkedInAutomation
	{
		public TestContext instance;

		public TestContext TestContext
		{
			set { instance = value; }
			get { return instance; }
		}

		[TestMethod, TestCategory("LinkedInLogin")]		//KeywordDriven
		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "TestCase", DataAccessMethod.Sequential)]
		public void TestCase()
		{
			string url = TestContext.DataRow["url"].ToString();
			string user = TestContext.DataRow["username"].ToString();
			string pass = TestContext.DataRow["password"].ToString();
			string locator = TestContext.DataRow["locator"].ToString();
			string message = TestContext.DataRow["message"].ToString();

			// var chromeOptions = new ChromeOptions();
			// chromeOptions.AddArguments("--incognito");
			// chromeOptions.AddArguments("--start-maximized");

			IWebDriver driver = new ChromeDriver();
			driver.Url = url;
			driver.Manage().Window.Maximize();

			driver.FindElement(By.ClassName("nav__button-secondary")).Click();
			driver.FindElement(By.Id("username")).SendKeys(user);
			driver.FindElement(By.Id("password")).SendKeys(pass);
			driver.FindElement(By.ClassName("from__button--floating")).Click();

			// string title = driver.Title;
			// Assert.AreEqual(title, "Feed | LinkedIn");

			string errorMessage = driver.FindElement(By.ClassName(locator)).Text;
			Assert.AreEqual(message, errorMessage);

			driver.Close();
		}
	}
}
