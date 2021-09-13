using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTests
{
    public enum BrowerType
    {
        Chrome,
        Firefox,
        IE
    }

    public class Hooks
    {
        public IWebDriver Driver { get; set; }


        private BrowerType _browserType;

        public Hooks(BrowerType browser)
        {
            _browserType = browser;
        }

        [SetUp]

        public void dInitializeTest()
        {       
            ChooseDriverInstance(_browserType);
        }


        private void ChooseDriverInstance(BrowerType browerType)
        {
            if (browerType == BrowerType.Chrome)
                Driver = new ChromeDriver();
            else if (browerType == BrowerType.Firefox)
                Driver = new FirefoxDriver();
        }
             

    }
}
