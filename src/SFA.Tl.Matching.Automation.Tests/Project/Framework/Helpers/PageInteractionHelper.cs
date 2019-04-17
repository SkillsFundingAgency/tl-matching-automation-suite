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

        //This is not required
        public static Boolean VerifyLinkIsPresent(By locator, String expected)
        {
            String actual = webDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Value verification failed: "
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

        //This is not required, please use VerifyText method
        public static void AssertText(String expectedText, String actualText)
        {
            Assert.AreEqual(expectedText, actualText);
        }

        //From this point onwards please move all methods to an appropriate place 
        public static Boolean VerifyProviderPostcodeDisplayed(String expectedPostcode)
        {
            if (webDriver.FindElement(By.XPath("//*[@id='main-content']/div[2]/div/form/ol")).Text.Contains(expectedPostcode))
            {
                return true;
            }

            throw new Exception("Provider verification failed:"
                + "\n Cannot find expected provider postcode: " + expectedPostcode);
        }

        public static Boolean VerifyProviderDisplayed(String expectedProvider)
        {
            String actualText = GetText(By.CssSelector(".tl-search-results"));
            return VerifyText(actualText, expectedProvider);
        }

        public static Boolean VerifyProviderDisplayedOnCheckAnswersPage(String expectedProvider)
        {
            return VerifyProviderDisplayed(expectedProvider);
        }

        public static double Radians(double x)
        {
            //Test methods for validating postcode radius
            const double PIx = 3.141592653589793;
            return x * PIx / 180;
        }

        public static double DistanceBetweenPlaces(double lon1, double lat1, double lon2, double lat2)
        {
            //Test methods for validating postcode radius
            const double RADIUS = 6378.16;
            double dlon = Radians(lon2 - lon1);
            double dlat = Radians(lat2 - lat1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance =  angle * RADIUS;
            return distance * 0.62137; //convert to miles by multiplying by 0.62137
        }

        public static void ValidateProvidersDisplayed()
        {
            var skillArea = ScenarioContext.Current["_provisionGapTypeOfPlacement"];
            var radius = ScenarioContext.Current["_provisionGapPostcodeRadius"];
            String postcodeRadius = Convert.ToString(radius);
            postcodeRadius = Regex.Replace(postcodeRadius, "[^.0-9]", "");
            int _postcodeRadius = Convert.ToInt32(postcodeRadius);
          
            String query = ("select DISTINCT(p.Name), pv.Postcode, PV.Latitude, PV.Longitude from ProviderQualification pq, Qualification q, QualificationRoutePathMapping qrpm, provider p, ProviderVenue pv, path, route r where p.Id = pv.ProviderId and pv.Id = pq.ProviderVenueId and pq.QualificationId = q.Id and q.id = qrpm.QualificationId and qrpm.PathId = path.Id and path.RouteId = r.Id and p.[Status] = 1 and r.Name = '" + skillArea + "' and pv.Latitude is not null and pv.Longitude is not null");
                        
            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());

            String Name;
            String Postcode;
            double Latitude;
            double Longitude;
            int providerCount = 0;

            foreach (object[] fieldNo in queryResults)
            {
                //Assign values to variables from the SQL query run
                Name = fieldNo[0].ToString();
                Postcode = (fieldNo[1].ToString());
                Latitude = Convert.ToDouble(fieldNo[2]);
                Longitude = Convert.ToDouble(fieldNo[3]);

                //longitude and latitude values for postcode B43 6JN
                double postcodeLong = -1.93253;
                double postcodelat = 52.54834;
                //Calculate the distance of each postcode from postcode B43 6JN
                double distanceFromPostcode = PageInteractionHelper.DistanceBetweenPlaces(Longitude, Latitude, postcodeLong, postcodelat);
                
                //if the postcode is within 25 miles of B43 6JN, verify the provider name and postcode is displayed on screen               
                if (distanceFromPostcode <= _postcodeRadius)
                {
                    Console.WriteLine("Distance is less than " + _postcodeRadius + " miles. Provider name is " + Name + " " + Postcode + " distance is  " + distanceFromPostcode);
                    providerCount = providerCount +1;

                    VerifyProviderDisplayed(Name);
                    VerifyProviderPostcodeDisplayed(Postcode);
                }            
            }
            ScenarioContext.Current["SearchResultsCount"] = providerCount;
        }

        public static void SetProviderNames(By locator1, By locator2)
        {
            ScenarioContext.Current["_Provider1"] = GetProviderName(locator1);
            ScenarioContext.Current["_Provider2"] = GetProviderName(locator2);

            //IWebElement webElement1 = webDriver.FindElement(locator1);
            //String text1 = webElement1.Text.Split('\r')[0];
            //text1 = text1.TrimEnd();
            //Console.WriteLine("Provider 1" + text1);
            //ScenarioContext.Current["_Provider1"] = text1;
            
            //IWebElement webElement2 = webDriver.FindElement(locator2);
            //String text2 = webElement2.Text.Split('\r')[0];
            //text2 = text2.TrimEnd();
            //Console.WriteLine("Provider 2" + text2);
            //ScenarioContext.Current["_Provider2"] = text2;
        }

        private static String GetProviderName(By locator)
        {
            String text = webDriver.FindElement(locator).Text.Split('\r')[0];
            text = text.TrimEnd();
            return text;
        }
    }
}