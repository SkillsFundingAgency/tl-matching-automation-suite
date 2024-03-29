﻿using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Collections.Generic;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;


namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport
{
    [Binding]
    public class BaseTest
    {
        protected static IWebDriver webDriver;

        [Before]
        public static void SetUp()
        {
            String browser = Configurator.GetConfiguratorInstance().GetBrowser();

            switch (browser)
            {
                case "firefox":
                    webDriver = new FirefoxDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(new List<string>()
                        {
                            "--no-sandbox,", "--incognito", "headless",
                        });
                    webDriver = new ChromeDriver(chromeOptions);
                    break;
                    //webDriver = new ChromeDriver();
                    //webDriver.Manage().Window.Maximize();
                    //break;

                case "ie":
                    webDriver = new InternetExplorerDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                //    ---This driver is not supported at this moment.This will be revisited in future-- -
                //case "htmlunit":
                //    webDriver = new RemoteWebDriver(DesiredCapabilities.HtmlUnitWithJavaScript());
                //    break;

                //case "phantomjs":
                //    webDriver = new PhantomJSDriver();
                //    break;

                case "zapProxyChrome":
                    InitialiseZapProxyChrome();
                    break;

                default:
                    throw new Exception(
                        $"Driver name - {browser}does not match OR this framework does not support the webDriver specified");
            }

            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            webDriver.Manage().Cookies.DeleteAllCookies();
            String currentWindow = webDriver.CurrentWindowHandle;
            webDriver.SwitchTo().Window(currentWindow);
            webDriver.Navigate().GoToUrl(Configurator.GetConfiguratorInstance().GetBaseUrl());

            PageInteractionHelper.SetDriver(webDriver);
            ProviderResultsHelper.SetDriver(webDriver);
        }

        [After]
        public static void TearDown()
        {
            try
            {
                TakeScreenshotOnFailure();
            }
            finally
            {
                webDriver.Dispose();
            }
        }

        public static void TakeScreenshotOnFailure()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                try
                {
                    DateTime dateTime = DateTime.Now;
                    String featureTitle = FeatureContext.Current.FeatureInfo.Title;
                    String scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
                    String failureImageName = $"{dateTime:HH-mm-ss}_{scenarioTitle}.png";
                    String screenshotsDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}../../\\Project\\Screenshots\\{dateTime:dd-MM-yyyy}\\";
                    if (!Directory.Exists(screenshotsDirectory))
                    {
                        Directory.CreateDirectory(screenshotsDirectory);
                    }

                    ITakesScreenshot screenshotHandler = webDriver as ITakesScreenshot;
                    Screenshot screenshot = screenshotHandler.GetScreenshot();
                    String screenshotPath = Path.Combine(screenshotsDirectory, failureImageName);
                    screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                    Console.WriteLine(
                        $"{scenarioTitle} -- Sceario failed and the screenshot is available at -- {screenshotPath}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Exception occurred while taking screenshot - {exception}");
                }
            }
        }

        private static void InitialiseZapProxyChrome()
        {
            const string PROXY = "localhost:8080";
            var chromeOptions = new ChromeOptions();
            var proxy = new Proxy();
            proxy.HttpProxy = PROXY;
            proxy.SslProxy = PROXY;
            proxy.FtpProxy = PROXY;
            chromeOptions.Proxy = proxy;

            webDriver = new ChromeDriver(chromeOptions);
        }
    }
}