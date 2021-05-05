using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace DM_WEB_Automation
{ 
    public class Tests
    {
    private IWebDriver driver;
    private string validEmail = "daivan1985@gmail.com";
    private string validPassword = "TUTA2018";
    private string productName = "Blouse";

    [SetUp]

    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url = "http://automationpractice.com/index.php";
    }

    [Test]
    public void TestLogin()
    {
        Login(validEmail, validPassword);

        IWebElement accountInfo = driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div:nth-child(1) > a"));
        Assert.AreEqual("Daiva Merkiene", accountInfo.Text, "Account info is incorrect");
    }

    [Test]
    public void TestSignIn()
    {
        SignIn(validEmail, validPassword);

        IWebElement signIn = driver.FindElement(By.PartialLinkText("account"));
        Assert.AreEqual("My account", signIn.Text, "Sign in is incorrect");
    }

    [Test]
    public void TestSearchItem()
    {
        SearchItem(validEmail, validPassword, productName);

        IWebElement searchName = driver.FindElement(By.LinkText("Blouse"));
        Assert.AreEqual("Blouse", searchName.Text, "Invalid product name is being searched");
    }

    [Test]
    public void TestSearchItemName()
    {
        SearchItemName(validEmail, validPassword, productName);

        IWebElement searchName = driver.FindElement(By.ClassName("lighter"));
        Assert.AreEqual("\"BLOUSE\"", searchName.Text, "Wrong product is found");
    }

    [Test]
    public void TestShoppingCart()
    {
        ShoppingCart(validEmail, validPassword, productName);

        IWebElement shoppingCart = driver.FindElement(By.ClassName("navigation_page"));
        Assert.AreEqual("Your shopping cart", shoppingCart.Text, "Shopping cart is not opened");
    }

    [Test]
    public void TestOrderCompletion()
    {
        OrderCompletion(validEmail, validPassword, productName);

        IWebElement orderComplete = driver.FindElement(By.XPath("//*[@id='center_column']/p[1]"));
        Assert.AreEqual("Your order on My Store is complete.", orderComplete.Text, "Order is not completed");
    }

    public void Login(string email, string password)

    {
        driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a")).Click();
        driver.FindElement(By.Id("email")).SendKeys(email);
        driver.FindElement(By.Id("passwd")).SendKeys(password);
        driver.FindElement(By.Id("SubmitLogin")).Click();
    }

    public void SignIn(string email, string password)

    {
        driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a")).Click();
        driver.FindElement(By.Id("email")).SendKeys(email);
        driver.FindElement(By.Id("passwd")).SendKeys(password);
        driver.FindElement(By.Id("SubmitLogin")).Click();
    }

    public void SearchItem(string email, string password, string productName)

    {
        driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a")).Click();
        driver.FindElement(By.Id("email")).SendKeys(email);
        driver.FindElement(By.Id("passwd")).SendKeys(password);
        driver.FindElement(By.Id("SubmitLogin")).Click();
        driver.FindElement(By.Id("search_query_top")).SendKeys(productName);
        driver.FindElement(By.CssSelector("#searchbox > button")).Click();
    }

    public void SearchItemName(string email, string password, string productName)

    {
        driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a")).Click();
        driver.FindElement(By.Id("email")).SendKeys(email);
        driver.FindElement(By.Id("passwd")).SendKeys(password);
        driver.FindElement(By.Id("SubmitLogin")).Click();
        driver.FindElement(By.Id("search_query_top")).SendKeys(productName);
        driver.FindElement(By.CssSelector("#searchbox > button")).Click();
    }


    public void ShoppingCart(string email, string password, string productName)
    {
        driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a")).Click();
        driver.FindElement(By.Id("email")).SendKeys(email);
        driver.FindElement(By.Id("passwd")).SendKeys(password);
        driver.FindElement(By.Id("SubmitLogin")).Click();
        driver.FindElement(By.Id("search_query_top")).SendKeys(productName);
        driver.FindElement(By.CssSelector("#searchbox > button")).Click();
        Thread.Sleep(2000);
        driver.FindElement(By.CssSelector("[data-id-product='2']")).Click();
        Thread.Sleep(2000);
        driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")).Click();
    }

    public void OrderCompletion(string email, string password, string productName)
    {
        driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a")).Click();
        driver.FindElement(By.Id("email")).SendKeys(email);
        driver.FindElement(By.Id("passwd")).SendKeys(password);
        driver.FindElement(By.Id("SubmitLogin")).Click();
        driver.FindElement(By.Id("search_query_top")).SendKeys(productName);
        driver.FindElement(By.CssSelector("#searchbox > button")).Click();
        Thread.Sleep(2000);
        driver.FindElement(By.CssSelector("[data-id-product='2']")).Click();
        Thread.Sleep(2000);
        driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")).Click();
        driver.FindElement(By.XPath("//*[@id='center_column']/p[2]/a[1]")).Click();
        driver.FindElement(By.XPath("//p/button/span")).Click();
        driver.FindElement(By.XPath("//*[@id='cgv']")).Click();
        driver.FindElement(By.XPath("//*[@id='form']/p/button")).Click();
        driver.FindElement(By.XPath("//*[@id='HOOK_PAYMENT']/div[2]/div/p/a")).Click();
        driver.FindElement(By.XPath("//*[@id='cart_navigation']/button")).Click();
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Close();
    }

}
}

