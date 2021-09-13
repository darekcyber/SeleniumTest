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

        public void CheckCorrectLogin(string result)
        {
            try
            {
                    Assert.That(h2.Text, Is.EqualTo("Witaj w WordPressie!"));
                    Assert.That(result, Is.EqualTo("pass"));
                    Console.WriteLine("Data were corect. Expected result was:" + result);
            }
            catch (Exception e)
            {
               if (result == "pass")
                {
                    Console.WriteLine("Data were corect. Expected result was:" + result);
                    Assert.Fail();
                }
                else
                {
                    Console.WriteLine("Data were incorrect. Expected result was: " + result);
                    Assert.Pass();
                }
            }
        }
    }
}
