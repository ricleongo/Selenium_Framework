using CodeBasedTestingLibrary;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    public interface IBaseSeleniumDriver
    {
        void WriteConsoleLog(string message);
        void ClearCookies();
        void SetInputValue(By locator, string value);
        void BlurInputText(By locator);
        void WaitUntilElement(By locator);
        void WaitUntilTime(int seconds);
        void GoToURL(string URI);

        IWebElement FindElement(By locator);
        IReadOnlyCollection<IWebElement> FindElements(By locator);
    }

    public class BaseTestSelenium : CodeBasedTestingBase, IBaseSeleniumDriver
    {
        private string testWebDomain
        {
            get
            {
                return this.FormatURLByRunMode("http://sourcetest.careerbuilder.com/");
            }
        }

        public virtual void WriteConsoleLog(string message)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("/*" + System.Environment.NewLine + message + System.Environment.NewLine + "*/");
        }

        public virtual void ClearCookies()
        {
            throw new NotImplementedException();
        }

        public virtual void SetInputValue(By locator, string value)
        {
            throw new NotImplementedException();
        }

        public virtual void BlurInputText(By locator)
        {
            throw new NotImplementedException();
        }

        public virtual void WaitUntilElement(By locator)
        {
            throw new NotImplementedException();
        }

        public virtual void WaitUntilTime(int seconds)
        {
            throw new NotImplementedException();
        }

        public virtual IWebElement FindElement(By locator)
        {
            throw new NotImplementedException();
        }

        public virtual IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            throw new NotImplementedException();
        }


        public void GoToURL(string URL)
        {
            Driver.Navigate().GoToCareerBuilderUrl(string.Format("{0}{1}", testWebDomain, URL));
        }

        public bool ExecuteSeleniumTest(Action testCode)
        {
            var passed = false;
            Exception failure = null;
            for (int retries = 0; retries < 2; retries++)
            {
                try
                {
                    Driver.Manage().Cookies.DeleteAllCookies();
                    testCode.Invoke();
                    passed = true;
                    retries = 999;
                }
                catch (Exception ex)
                {
                    passed = false;
                    failure = ex;
                    Thread.Sleep(new Random().Next(300, 3000));
                }
            }

            return passed;
        }



    }
}
