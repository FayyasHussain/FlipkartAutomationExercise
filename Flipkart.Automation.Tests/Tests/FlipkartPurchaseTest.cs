using System;
using Flipkart.Automation.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flipkart.Automation.Tests
{
    [TestClass]
    public class FlipkartPurchaseTest : TestBase
    {

        [TestMethod]
        [Description("Test the flipkart aplication - product search functionality.")]
        [TestProperty("Author", "FayyasHussain")]
        public void ProductSearchTest()
        {
            var loginPage = new LoginPage(Driver);
            var homePage = new HomePage(Driver);
            var searchResultsPage = new SearchResultsPage(Driver);

            loginPage.Login(this.TestData.ValidUser.ValidUsername.Value, this.TestData.ValidUser.ValidPassword.Value);
            homePage.Search(this.TestData.ProductName.Value);
            Assert.IsTrue(searchResultsPage.IsVisible(), "Search functionality is failed");
        }

        [TestMethod]
        [Description("Validate the product information page loading functionality.")]
        [TestProperty("Author", "FayyasHussain")]
        public void VerifyProductInformation()
        {
            var loginPage = new LoginPage(Driver);
            var homePage = new HomePage(Driver);
            var searchResultsPage = new SearchResultsPage(Driver);
            var productInformationPage = new ProductInformationPage(Driver);

            loginPage.Login(this.TestData.ValidUser.ValidUsername.Value, this.TestData.ValidUser.ValidPassword.Value);
            homePage.Search(this.TestData.ProductName.Value);
            searchResultsPage.ClickRandomProduct();
            Assert.IsTrue(productInformationPage.IsVisible(), "Product information page loading failed");
        }

        [TestMethod]
        [Description("Validate the product information in Product details and My Cart pages.")]
        [TestProperty("Author", "FayyasHussain")]
        public void AddProductToCartAndVerifyInfoTest()
        {
            var loginPage = new LoginPage(Driver);
            var homePage = new HomePage(Driver);
            var productInformationPage = new ProductInformationPage(Driver);
            var searchResultsPage = new SearchResultsPage(Driver);
            var myCartPage = new MyCartPage(Driver);

            loginPage.Login(this.TestData.ValidUser.ValidUsername.Value, this.TestData.ValidUser.ValidPassword.Value);
            myCartPage.RemoveAllItems();
            homePage.Search(this.TestData.ProductName.Value);
            searchResultsPage.ClickRandomProduct();

            var productDetails = productInformationPage.ProductInformation();
            productInformationPage.AddToCart();
            Assert.IsTrue(myCartPage.IsLoaded(), "Add to Cart functionality is broken");
            var productDetailsInMyCartPage = myCartPage.ProductInformation();

            CollectionAssert.AreEqual(productDetails, productDetailsInMyCartPage);
        }

        [TestMethod]
        [Description("Validate the product information in Product details and My Cart pages.")]
        public void ProductPurchaseTest()
        {
            var loginPage = new LoginPage(Driver);
            var homePage = new HomePage(Driver);
            var productInformationPage = new ProductInformationPage(Driver);
            var searchResultsPage = new SearchResultsPage(Driver);
            var myCartPage = new MyCartPage(Driver);
            var checkoutPage = new CheckoutPage(Driver);

            loginPage.Login(this.TestData.ValidUser.ValidUsername.Value, this.TestData.ValidUser.ValidPassword.Value);
            myCartPage.Goto();
            myCartPage.RemoveAllItems();
            homePage.Search(this.TestData.ProductName.Value);
            searchResultsPage.ClickRandomProduct();
            var productDetails = productInformationPage.ProductInformation();

            productInformationPage.AddToCart();
            myCartPage.PlaceOrder();
            var productDetailsInCheckoutPage = checkoutPage.ProductInformation();
            CollectionAssert.AreEqual(productDetails, productDetailsInCheckoutPage);

            checkoutPage.CompletePurchase();
            Assert.AreEqual(checkoutPage.IsPurchaseCompleted(), "Purchase is failed");
        }
    }
}
 