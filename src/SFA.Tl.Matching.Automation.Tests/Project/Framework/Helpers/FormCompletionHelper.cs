﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers
{
    public class FormCompletionHelper : PageInteractionHelper
    {
        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public static void ClickElement(By locator)
        {
            webDriver.FindElement(locator).Click();
        }

        public static void ClearText(By locator)
        {
            webDriver.FindElement(locator).Clear();
        }

        public static void EnterText(IWebElement element, String text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void EnterText(By locator, String text)
        {
            webDriver.FindElement(locator).Clear();
            webDriver.FindElement(locator).SendKeys(text);
        }

        public static void EnterText(IWebElement element, int value)
        {
            element.Clear();
            element.SendKeys(value.ToString());
        }

        public static void PressTabKey()
        {
            IWebElement element = webDriver.FindElement(By.TagName("body"));
            element.SendKeys(Keys.Tab);
        }

        public static void SelectFromDropDownByValue(IWebElement element, String value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public static void SelectFromDropDownByValue(By locator, String value)
        {
            IWebElement element = webDriver.FindElement(locator);
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }
        
        public static void SelectFromDropDownByText(By locator, String value)
        {
            IWebElement element = webDriver.FindElement(locator);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(value);
        }

        public static void SelectFromDropDownByText(IWebElement element, String text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public static void SelectCheckBox(IWebElement element)
        {
            if(element.Displayed && !element.Selected)
            {
                element.Click();
            }
        }

        public static void SelectCheckBox(By locator)
        {
            IWebElement element = webDriver.FindElement(locator);
            SelectCheckBox(element);
        }

        public static void SelectRadioOptionByForAttribute(By locator, String forAttribute)
        {
            IList<IWebElement> radios = webDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

            if (radioToSelect != null)
                ClickElement(radioToSelect);
        }
    }
}