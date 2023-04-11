using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.XPath;
using System.Security.Policy;
using System.ComponentModel;
using System.Drawing;
using System.Threading;

namespace selenium
{
    [TestFixture]
    [Parallelizable]
    class News
    {

        IWebElement FindE = null;
        IWebElement click = null;
        IWebElement F = null;


        //part 1 

        [SetUp]
        public void OpenBrowser()
        {
            //create Browser
            Drivers.WB.Navigate().GoToUrl("https://www.mehrnews.com/");
            Console.WriteLine("Opened Browser.");
        }

        //part 2 

        [Test]
        public void news()
        {




            //با استفاده از متغیر ساده



            var F = Drivers.WB.FindElements(By.ClassName("news"));

            int x = F.Count();
            Console.WriteLine(x);

            for (int i = 1; i < x; i++)
            {
                
                try
                {
                    F[i].Click();

                    Thread.Sleep(1000);

                    if (Drivers.WB.WindowHandles.Count == 2)
                    {
                        Drivers.WB.SwitchTo().Window(Drivers.WB.WindowHandles[1]);


                        string xDate = Drivers.WB.FindElement(By.ClassName("item-date")).Text;

                        Console.WriteLine(xDate);

                        string Text = Drivers.WB.FindElement(By.XPath("/html/body/main/div/div/div/div/div[1]/article/div[4]")).Text;
                        Console.WriteLine(Text);


                        string Titel = Drivers.WB.FindElement(By.XPath("/html/body/main/div/div/div/div/div[1]/article/div[2]/div[2]/h1")).Text;
                        Console.WriteLine(Titel);

                        string id = Drivers.WB.FindElement(By.XPath("/html/body/main/div/div/div/div/div[1]/article/div[4]/div[2]/span")).Text;
                        Console.WriteLine(id);

                        string Information = $"{Titel}\n\n" + $"{Text}";
                        Console.WriteLine(Information);

                        var args = Environment.GetCommandLineArgs();
                        String root = Path.GetDirectoryName(args[0]);

                        File.WriteAllText($@"{root}\اطلاعات خبر ها\{id}.txt", Information);

                        Drivers.WB.Close();
                        Drivers.WB.SwitchTo().Window(Drivers.WB.WindowHandles[0]);





                        //با استفاده از class

                        /*var FindE = Drivers.WB.FindElements(By.ClassName("news"));

                        int x = FindE.Count();

                        Console.WriteLine(x);

                        for (int i = 1; i < x; i++)
                        {
                            FindE[i].Click();

                            Drivers.WB.SwitchTo().Window(Drivers.WB.WindowHandles[1]);



                            string Time = FindElement("item-date", ElementType.classname);

                            string Text = FindElement("/html/body/main/div/div/div/div/div[1]/article/div[4]", ElementType.xpath);
                            string Title = FindElement("/html/body/main/div/div/div/div/div[1]/article/div[2]/div[2]/h1", ElementType.xpath);

                            string id = FindElement("/html/body/main/div/div/div/div/div[1]/article/div[4]/div[2]/span", ElementType.xpath);

                            string Information = $"{Title}\n\n" + $"{Text}";

                            File.WriteAllText($@"C:\\Users\\ASUS\\source\\repos\\selenium\\اطلاعات خبر ها\\{id}.txt", Information);


                            Drivers.WB.Close();
                            Drivers.WB.SwitchTo().Window(Drivers.WB.WindowHandles[0]);

                        }*/


                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        //part 3

        [TearDown]
        public void closeBrowser()
        {
            Drivers.WB.Quit();
            Console.WriteLine("Browsers IS Closed");
        }



        public string FindElement(string ElementName, ElementType em)
        {
            if (em == ElementType.name)
                FindE = Drivers.WB.FindElement(By.Name(ElementName));
            if (em == ElementType.id)
                FindE = Drivers.WB.FindElement(By.Id(ElementName));
            if (em == ElementType.classname)
                FindE = Drivers.WB.FindElement(By.ClassName(ElementName));
            if (em == ElementType.xpath)
                FindE = Drivers.WB.FindElement(By.XPath(ElementName));
            if (em == ElementType.tagname)
                FindE = Drivers.WB.FindElement(By.TagName(ElementName));

            return FindE.Text;

        }
        public void ClickButton(string ElementName, ElementType em)
        {
            if (em == ElementType.name)
                click = Drivers.WB.FindElement(By.Name(ElementName));
            if (em == ElementType.id)
                click = Drivers.WB.FindElement(By.Id(ElementName));
            if (em == ElementType.classname)
                click = Drivers.WB.FindElement(By.ClassName(ElementName));
            if (em == ElementType.xpath)
                click = Drivers.WB.FindElement(By.XPath(ElementName));

            click.Click();
        }

    }
}
