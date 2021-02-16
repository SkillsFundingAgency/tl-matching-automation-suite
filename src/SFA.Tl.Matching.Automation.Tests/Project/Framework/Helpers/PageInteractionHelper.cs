using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers
{
    public class PageInteractionHelper
    {
        protected static IWebDriver webDriver;
        private const int implicitWaitTimeInSeconds = 10;

        public static void SetDriver(IWebDriver webDriver)
        {
            PageInteractionHelper.webDriver = webDriver;
        }

        public static Boolean VerifyPageURL(String actual, String expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page URL verification failed:"
                + "\n Expected URL: " + expected 
                + "\n Found URL: " + actual);
        }


        public static Boolean VerifyLinkIsPresent(By locator, String expected)
        {
            String actual = webDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("The following link was not found: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public static Boolean VerifyPageHeading(String actual, String expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected page: " + expected
                + "\n Found page: " + actual);
        }

        public static Boolean VerifyPageHeading(By locator, String expected)
        {
            String actual = webDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected page: " + expected 
                + "\n Found page: " + actual);
        }

        public static Boolean VerifyPageHeading(String actual, String expected1, String expected2)
        {
            if (actual.Contains(expected1) || actual.Contains(expected2))
            {
                return true;
            }

            throw new Exception("Page verification failed: "
                + "\n Expected: " + expected1 + " or " + expected2 + " pages"
                + "\n Found: " + actual + " page");
        }

        public static Boolean VerifyText(String actual, String expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Text verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public static Boolean VerifyText(By locator, int expected)
        {
            String expectedText = Convert.ToString(expected);
            return VerifyText(locator, expectedText);
        }

        public static bool VerifyValue(int actual, int expected)
        {
            if (actual == expected)
            {
                return true;
            }
            throw new Exception("Text verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public static Boolean VerifyText(By locator, String expected)
        {
            String actual = webDriver.FindElement(locator).Text;
            return VerifyText(actual, expected);
        }

        public static Boolean VerifyValueAttributeOfAnElement(By locator, String expected)
        {
            String actual = webDriver.FindElement(locator).GetAttribute("value");
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Value verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public static void WaitForPageToLoad(int implicitWaitTime = implicitWaitTimeInSeconds)
        {
            var waitForDocumentReady = new WebDriverWait(webDriver, TimeSpan.FromSeconds(implicitWaitTime));
            waitForDocumentReady.Until((wdriver) => (webDriver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void WaitForElementToBePresent(By locator)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(implicitWaitTimeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static void WaitForElementToBeDisplayed(By locator, int timeInSeconds = implicitWaitTimeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementToBeClickable(By locator)
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement element = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static Boolean IsElementPresent(By locator)
        {
            TurnOffImplicitWaits();
            try
            {
                webDriver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            finally
            {
                TurnOnImplicitWaits();
            }
        }

        public static Boolean IsElementDisplayed(By locator)
        {
            TurnOffImplicitWaits();
            try
            {
                return webDriver.FindElement(locator).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                TurnOnImplicitWaits();
            }
        }

        public static void FocusTheElement(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            new Actions(webDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public static void FocusTheElement(IWebElement element)
        {
            new Actions(webDriver).MoveToElement(element).Perform();
        }

        public static void UnFocusTheElement(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            new Actions(webDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public static void UnFocusTheElement(IWebElement element)
        {
            new Actions(webDriver).MoveToElement(element).Perform();
        }

        public static void TurnOffImplicitWaits()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        public static void TurnOnImplicitWaits()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTimeInSeconds);
        }

        public static String GetText(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            return webElement.Text;
        }

        public static String GetValueFromField(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            String value = webElement.GetAttribute("value");
            return value;
        }
    }
}