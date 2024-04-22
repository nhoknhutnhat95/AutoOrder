using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private IWebDriver _driver;
        private IJavaScriptExecutor js;
        private void button1_Click(object sender, EventArgs e)
        {
            _driver = InitChrome(false);
            var SONumber = txtUrl.Text;
            _driver.Navigate().GoToUrl("https://www.google.com.vn/");
            _driver.Manage().Window.Maximize();
            var js = (IJavaScriptExecutor) _driver;
            js.ExecuteScript($@"document.getElementsByTagName('textarea')[0].value = '{SONumber}'");
        }
        private static ChromeDriver InitChrome(bool headless = true)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArguments("--incognito", "--disable-web-security");
            options.AddArgument("no-sandbox");
            if (headless)
            {
                options.AddArgument("headless");
            }
            return new ChromeDriver(chromeDriverService, options);
        }
    }
}
