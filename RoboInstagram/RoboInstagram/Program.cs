using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace RoboInstagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var driver = new ChromeDriver("C:\\robo-instagram-selenium");
            driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/?hl=pt-br/");
            driver.Manage().Window.Maximize();

            Teste(driver);

            driver.Quit();
        }

        private static void Teste(ChromeDriver driver)
        {
            var email = "usuarioinstagram33@outlook.com";
            var senha = "123123abc";
            var famoso = "spiderandersonsilva";

            var email_login = driver.FindElement(By.Name("username"));
            email_login.SendKeys(email);

            var email_senha = driver.FindElement(By.Name("password"));
            email_senha.SendKeys(senha);

            driver.FindElement(By.ClassName("L3NKy")).Click();

            var popup = driver.FindElement(By.ClassName("bIiDR"));

            if(popup != null)
                popup.Click();

            var buscar = driver.FindElement(By.ClassName("x3qfX"));
            buscar.SendKeys(famoso);

            //esta vindo 2
            driver.FindElement(By.XPath("//span[text()='Anderson \"The Spider\" Silva']")).Click();

            driver.FindElement(By.CssSelector($"a[href='/{famoso}/followers/']")).Click();

            var seguidores = driver.FindElements(By.ClassName("L3NKy"));

            foreach (var seguidor in seguidores)
            {
                seguidor.Click();
            };
        }
    }
}
