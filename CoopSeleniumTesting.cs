using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


public class CoopSeleniumTesting
{
    [Test]
    public void TestSalary1000()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Minimize();
        driver.Navigate().GoToUrl("https://www.cooppank.ee/kodulaen");
        IWebElement salaryField = driver.FindElement(By.Id("edit-monthly-income"));
        salaryField.Clear();
        salaryField.SendKeys("1000");
        IWebElement anotherFieldToActivateCalculation = driver.FindElement(By.Id("edit-total-blance-existing-loans"));
        anotherFieldToActivateCalculation.Clear();
        IWebElement finalLoanSum = driver.FindElement(By.XPath("//*[@id=\"loan-tab--2\"]/div/div[7]/div[2]/p/span[1]"));
        Assert.That(finalLoanSum.Text, Is.EqualTo("68 768"));
    }


    [Test]
    public void LoanCalculatorSeleniumTestSalary6000Headless()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        IWebDriver driver = new ChromeDriver(options);

        driver.Navigate().GoToUrl("https://www.cooppank.ee/kodulaen");
        IWebElement salaryField = driver.FindElement(By.Id("edit-monthly-income"));
        salaryField.Clear();
        salaryField.SendKeys("5500");
        IWebElement anotherFieldToActivateCalculation = driver.FindElement(By.Id("edit-total-blance-existing-loans"));
        anotherFieldToActivateCalculation.Clear();
        String finalLoanSum1 = driver.FindElement(By.XPath("//*[@id=\"loan-tab--2\"]/div/div[7]/div[2]/p/span[1]")).Text;
       
        salaryField.Clear();
        salaryField.SendKeys("6000");
        anotherFieldToActivateCalculation = driver.FindElement(By.Id("edit-total-blance-existing-loans"));
        anotherFieldToActivateCalculation.Clear();
        String finalLoanSum2 = driver.FindElement(By.XPath("//*[@id=\"loan-tab--2\"]/div/div[7]/div[2]/p/span[1]")).Text;
        
        Assert.That(finalLoanSum1, !Is.EqualTo(finalLoanSum2));
        driver.Close();
        driver.Quit();
    }
}