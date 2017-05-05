using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFramework;
using FluentAssertions;
using CodeBasedTestingLibrary;
using SeleniumFramework.BaseClasses;
using System.Collections.Generic;

namespace TestSelenium
{
    [TestClass]
    [CodeBasedTest("RecruiterDesktop", Browser = BrowserType.Firefox, BrowserVersion = "28.0", OperatingSystem = OperatingSystemType.Windows7, UseTunnel = false)]
    [TestOwner("ApplyExperienceMonitoring@careerbuilder.com")]
    public class LoginTesting : BaseTest<ITestBasePage>
    {
        [TestMethod]
        public void LoginUser()
        {
            string UserName = "juan.leon@careerbuilder.com";
            string Password = "thisisatest01";

            /// Selenium Login Process.
            var isLoggedIn = new LoginPage(this).LoginAs(UserName).WithThisKey(Password).Login();

            /// Selenium Test Assertion.
            isLoggedIn.Should().BeTrue("The user could not be logged in!");
        }
    }


}
