using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ParallelTests
{
    [TestFixture]
    [Parallelizable]
    public class ChromeTesting : Hooks
    {

        public ChromeTesting() : base(BrowerType.Chrome){}

        [TestCase("test", "test.local.77!!", "pass")]
        [TestCase("test", "test.local.77!", "fail")]
        public void FirefoxTest(string login, string password, string result)
        {
            Driver.Navigate().GoToUrl("http://192.168.1.133/wp-login.php");
            Driver.Manage().Window.Maximize();
            WordpressLoginPage wordpressLoginPage = new WordpressLoginPage(Driver);
            wordpressLoginPage.EnterUserNamePassword(login, password);
            wordpressLoginPage.SubmitLogin();
            Thread.Sleep(2000);
            wordpressLoginPage.CheckCorrectLogin(result);

            //Assert.Pass();
        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }


    public class FirefoxTesting : Hooks
    {

        public FirefoxTesting() : base(BrowerType.Firefox) { }

        [TestCase("test", "test.local.77!!", "pass")]
        [TestCase("test", "test.local.77!", "fail")]
        public void FirefoxTest(string login, string password, string result)
        {
            Driver.Navigate().GoToUrl("http://192.168.1.133/wp-login.php");
            Driver.Manage().Window.Maximize();
            WordpressLoginPage wordpressLoginPage = new WordpressLoginPage(Driver);
            wordpressLoginPage.EnterUserNamePassword(login, password);
            wordpressLoginPage.SubmitLogin();
            Thread.Sleep(2000);
            wordpressLoginPage.CheckCorrectLogin(result);
        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}