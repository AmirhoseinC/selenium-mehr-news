using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            News news = new News();
            news.OpenBrowser();
            news.news();
        }
    }
}
