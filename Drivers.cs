using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace selenium
{
    enum ElementType
    {
        name,
        id,
        classname,
        xpath,
        tagname
    }

    class Drivers
    {
        public static IWebDriver WB = new ChromeDriver();
    }
}
