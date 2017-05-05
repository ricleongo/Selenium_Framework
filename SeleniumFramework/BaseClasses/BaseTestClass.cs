using CodeBasedTestingLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.BaseClasses
{
    public class BaseTest<T> : BaseTestSelenium where T :ITestBasePage
    {
        public T MainTestPage { get; set; }

        public void SetTestPage(T TestPage)
        {
            this.MainTestPage = TestPage;
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
        }
    }
}
