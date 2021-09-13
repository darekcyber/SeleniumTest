using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTests
{
    class WordpressLoginPage
    {

        public WordpressLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebDriver _driver;

        private IWebElement UserName => _driver.FindElement(By.Id("user_login"));

        private IWebElement UserPassword => _driver.FindElement(By.Id("user_pass"));

        private IWebElement BtnSubmit => _driver.FindElement(By.Id("wp-submit"));

        private IWebElement h2 => _driver.FindElement(By.XPath("//*[@id='welcome-panel']/div/h2"));



        public void EnterUserNamePassword(string login, string password)
        {
            UserName.SendKeys(login);
            UserPassword.SendKeys(password);
        }

        public void SubmitLogin()
        {
            BtnSubmit.Submit();
        }

        public void CHeckCorrectLogin()
        {
            try
            {
                string text = h2.Text;
                Assert.AreEqual("Witaj w WordPressie!!", text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Login Fail " + e);
            }
        }
    }
}
