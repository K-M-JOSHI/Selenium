using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver driver = new ChromeDriver(@"D:\Kandarp\Testing\", options);
            driver.Url = "http://automationpractice.com/index.php";

      
            //•	Add one product from Popular category to cart.

            Actions action = new Actions(driver); //to hover on imgae, so that add to cart can be visible
            IWebElement image = driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[2]/div/div[1]/div/a[1]/img"));
            action.MoveToElement(image).Perform();

            IWebElement addToCart = driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[2]/div/div[2]/div[2]/a[1]/span"));
            addToCart.Click();

            var continueShopping = driver.FindElement(By.XPath(".//*[@id='layer_cart']/div[1]/div[2]/div[4]/span/span"));
            continueShopping.Click();



            //•	Click more button from one of the Popular category product and go to details page.
            var image2 = driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[3]/div/div[1]/div/a[1]/img"));
            Actions action2 = new Actions(driver);
            action2.MoveToElement(image2).Perform();
            IWebElement more = driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[3]/div/div[2]/div[2]/a[2]/span"));
            more.Click();


            //•	Change quantity to 3 from that page and add that product to cart.
            var qty = driver.FindElement(By.CssSelector("i.icon-plus"));
            qty.Click();
            qty.Click();
            driver.FindElement(By.Name("Submit")).Click();
            continueShopping = driver.FindElement(By.XPath(".//*[@id='layer_cart']/div[1]/div[2]/div[4]/span/span"));
            continueShopping.Click();

            //•	Go to T - shirt category and sort them using “Price: Lowest First” filter.
            var tshirt = driver.FindElement(By.XPath(".//*[@id='block_top_menu']/ul/li[3]/a"));
            tshirt.Click();

            var sortSelect = driver.FindElement(By.Id("selectProductSort"));
            var selectElement = new SelectElement(sortSelect);
            selectElement.SelectByText("Price: Lowest first");

            //•	Add first product to cart after sorting.
           
            var image3 = driver.FindElement(By.XPath(".//*[@id='center_column']/ul/li/div/div[1]/div/a[1]/img"));
            Actions action3 = new Actions(driver);
            action3.MoveToElement(image3).Perform();
            addToCart = driver.FindElement(By.XPath(".//*[@id='center_column']/ul/li/div/div[2]/div[2]/a[1]/span"));
            addToCart.Click();

            continueShopping = driver.FindElement(By.XPath(".//*[@id='layer_cart']/div[1]/div[1]/span"));
            continueShopping.Click();


            //•	Go to Cart page.
            driver.FindElement(By.PartialLinkText("Cart")).Click();

            //•	Change quantity of last product to 5.
            var addQty = driver.FindElement(By.XPath(".//*[@id='cart_quantity_up_1_1_0_0']/span/i"));
            addQty.Click();
            addQty.Click();
            addQty.Click();
            addQty.Click();

            //•	Click proceed to checkout button.
            var checkOut = driver.FindElement(By.PartialLinkText("Proceed to checkout"));
            checkOut.Click();

            //Close the window 
            driver.Close();
        }
    }
}
