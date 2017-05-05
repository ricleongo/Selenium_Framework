using CodeBasedTestingLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SecretSauce;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginPage: ITestBasePage
    {
        #region Internal Fields

        public static string URL = "Share/Login.aspx?elui=1";
        public BaseTestSelenium context { get; set; }

        #endregion

        public LoginPage(BaseTestSelenium context)
        {
            this.context = context;
        }

        public LoginAction<BaseTestSelenium> LoginAs(string user) 
        {
            return new LoginAction<BaseTestSelenium>(this.context, user);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface ITestBasePage
    {
        BaseTestSelenium context { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoginAction<T> where T : BaseTestSelenium
    {
        #region Internal Fields

        string user { get; set; }
        string key { get; set; }
        T testContext {get; set;}
        
        #endregion

        public LoginAction(T context, string user)
        {
            this.testContext = context;
            this.user = user;
        }

        public LoginAction<T> WithThisKey(string key)
        {
            this.key = key;
            return this;
        }

        public bool Login()
        {
           return testContext.ExecuteSeleniumTest(() =>
            {
                testContext.GoToURL(LoginPage.URL);
                testContext.WriteConsoleLog("Start Login Page loading");
            });
        }
    }
}
