using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FastBite.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using XunitOrderer;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace FastBite.Tests
{
  
    [TestCaseOrderer("FastBite.Tests.PriorityOrderer", "FastBite.Tests")]
    public class FastBiteTests :  IClassFixture<WebApplicationFactory<FastBite.Startup>>,IDisposable
    {
        
        private IWebDriver _driver;
        public ApplicationDbContext _db;

        public FastBiteTests(){
        //    // _factory=factory;
             var opts = new ChromeOptions();
        opts.AddArgument("--headless");
            _driver = new ChromeDriver(opts);

        }
      
        [Fact,TestPriority(6)]
      public void addCategory(){
           _driver.Navigate()
        .GoToUrl("http://localhost:8000/Admin/Database/deleteContext");
       _driver.Navigate()
        .GoToUrl("http://localhost:8000/Admin/Category");
           _driver.FindElement(By.XPath("//a[contains(text(),'Create New')]")).Click();
            _driver.FindElement(By.Id("Name"))
        .SendKeys("Apetizer");
        _driver.FindElement(By.XPath("//input[@value='Create']")).Click();
     
        string categoryName = _driver.FindElement(
		By.XPath("//table/tbody/tr[2]/td[1]")).Text;
        Assert.Equal("Apetizer",categoryName);
         _driver.FindElement(By.XPath("//a[contains(text(),'Create New')]")).Click();
            _driver.FindElement(By.Id("Name"))
        .SendKeys("Biryani");
        _driver.FindElement(By.XPath("//input[@value='Create']")).Click();
         string categoryName1 = _driver.FindElement(
		By.XPath("//table/tbody/tr[3]/td[1]")).Text;
        Assert.Equal("Biryani",categoryName1);
       IEnumerable<IWebElement> buttons= _driver.FindElements(By.XPath("//a[contains(text(),'Edit')]"));
       buttons.First().Click();
        _driver.FindElement(By.Id("Name")).Clear();
        _driver.FindElement(By.Id("Name"))
        .SendKeys("Apetizer1");
         _driver.FindElement(By.XPath("//input[@value='Update']")).Click();
          string categoryName3 = _driver.FindElement(
		By.XPath("//table/tbody/tr[2]/td[1]")).Text;
        Assert.Equal("Apetizer1",categoryName3);
      }
     
     
        public void Dispose()
        {
              _driver.Quit();
        _driver.Dispose();
        }
    }
}