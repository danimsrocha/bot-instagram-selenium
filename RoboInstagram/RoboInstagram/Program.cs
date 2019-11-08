using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace RoboInstagram
{
    class Program
    {
        const string url = "https://www.instagram.com/accounts/login/?source=auth_switcher";
        static void Main(string[] args)
        {
            var driver = new ChromeDriver("C:\\Repositorios\\selenium-instagram\\bot-instagram-selenium");
            driver.Navigate().GoToUrl(url);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LogarInstagramSeguirPessoas(driver);

            driver.Quit();
        }

        private static void LogarInstagramSeguirPessoas(ChromeDriver driver)
        {
            var usuariosBuscar = new string[] { "spiderandersonsilva", "neymarjr", "maisa", "beyonce" };

            var email = "usuarioinstagram33@outlook.com";
            var senha = "123123abc";

            var email_login = driver.FindElement(By.Name("username"));
            email_login.SendKeys(email);

            var email_senha = driver.FindElement(By.Name("password"));
            email_senha.SendKeys(senha);

            driver.FindElement(By.ClassName("L3NKy")).Click();

            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    driver.FindElement(By.ClassName("bIiDR")).Click();
                    staleElement = false;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }

            foreach (var usuario in usuariosBuscar)
                SerguirPessoas(driver, usuario);
        }

        public static void SerguirPessoas(ChromeDriver driver, string famoso)
        {
            var buscar = driver.FindElement(By.ClassName("x3qfX"));
            buscar.SendKeys(famoso);

            //esta vindo 2
            Thread.Sleep(300);
            driver.FindElement(By.XPath($"//span[text()='{famoso}']")).Click();

            driver.FindElement(By.CssSelector($"a[href='/{famoso}/followers/']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // wait.Until(x => x.)

            var staleElement = true;
            while (staleElement)
            {
                try
                {
                    var seguidores = driver.FindElements(By.ClassName("y3zKF")).Take(5);

                    foreach (var seguidor in seguidores)
                    {
                        Thread.Sleep(1000);
                        seguidor.Click();
                    };

                    staleElement = false;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }

           driver.FindElement(By.ClassName("wpO6b")).Click();
           Thread.Sleep(2000);
        }
    }
}
