﻿using NUnit.Framework;
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
    public class ProviderResultsHelper
    {
        protected static IWebDriver webDriver;
        private const int implicitWaitTimeInSeconds = 10;

        public static void SetDriver(IWebDriver webDriver)
        {
            ProviderResultsHelper.webDriver = webDriver;
        }

       
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
            String actualText = PageInteractionHelper.GetText(By.CssSelector(".t1-search-results"));
            return PageInteractionHelper.VerifyText(actualText, expectedProvider);
        }

        public static Boolean VerifyProviderDisplayed(String expectedProvider,By providerName)
        {
            String actualText = PageInteractionHelper.GetText(providerName);
            return PageInteractionHelper.VerifyText(actualText, expectedProvider);
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
            var skillArea = Constants.skillArea;
            var radius = Constants.radius;

            String postcodeRadius = Convert.ToString(radius);
            postcodeRadius = Regex.Replace(postcodeRadius, "[^.0-9]", "");
            int _postcodeRadius = Convert.ToInt32(postcodeRadius);

            String query = ("select DISTINCT(p.Name), pv.Postcode, PV.Latitude, PV.Longitude from ProviderQualification pq, Qualification q, QualificationRoutePathMapping qrpm, provider p, ProviderVenue pv, path, route r where p.Id = pv.ProviderId and pv.Id = pq.ProviderVenueId and pq.QualificationId = q.Id and q.id = qrpm.QualificationId and qrpm.RouteId = r.Id and r.Name = '" + skillArea + "'and pv.Latitude is not null and pv.Longitude is not null and pv.isenabledforreferral = 1 and p.iscdfprovider=1 and p.isenabledforreferral=1");

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
                double distanceFromPostcode = DistanceBetweenPlaces(Longitude, Latitude, postcodeLong, postcodelat);
                
                //if the postcode is within 25 miles of B43 6JN, verify the provider name and postcode is displayed on screen               
                if (distanceFromPostcode <= _postcodeRadius)
                {
                    Console.WriteLine("Distance is less than " + _postcodeRadius + " miles. Provider name is " + Name + " " + Postcode + " distance is  " + distanceFromPostcode);
                    providerCount = providerCount +1;

                   // VerifyProviderDisplayed(Name);
                    VerifyProviderPostcodeDisplayed(Postcode);
                }            
            }
            ScenarioContext.Current["SearchResultsCount"] = providerCount;
        }

        public static void SetProviderNames(By locator1, By locator2)
        {
            ScenarioContext.Current["_Provider1"] = GetProviderName(locator1);
        }

        private static String GetProviderName(By locator)
        {
            String text = webDriver.FindElement(locator).Text.Split('\r')[0];
            text = text.TrimEnd();
            return text;
        }
    }
}