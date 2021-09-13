using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ParallelTests
{
    
    public class FirefoxTesting : Hooks
    {

        public FirefoxTesting() : base(BrowerType.Chrome){}

        [Test]
        public void FirefoxTest()
        {
            Driver.Navigate().GoToUrl("http://192.168.1.133/wp-login.php");
            Driver.Manage().Window.Maximize();
            WordpressLoginPage wordpressLoginPage = new WordpressLoginPage(Driver);
            wordpressLoginPage.EnterUserNamePassword("test", "test.local.77!!");
            wordpressLoginPage.SubmitLogin();
            Thread.Sleep(2000);
            Assert.Pass();
        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }

    //[TestFixture]
    //[Parallelizable]
    //public class ChromeTesting : Hooks
    //{

    //    public ChromeTesting() : base(BrowerType.Chrome) { }

    //    [Test]
    //    public void FirefoxTest()
    //    {
    //        Driver.Navigate().GoToUrl("http://192.168.1.133/wp-login.php");
    //        Driver.Manage().Window.Maximize();
    //        WordpressLoginPage wordpressLoginPage = new WordpressLoginPage(Driver);
    //        wordpressLoginPage.EnterUserNamePassword("test", "test.local.77!!");
    //        wordpressLoginPage.SubmitLogin();
    //        Thread.Sleep(2000);
    //        Assert.Pass();
    //    }
    //    [TearDown]
    //    public void TearDown()
    //    {
    //        Driver.Quit();
    //    }
    //}
}