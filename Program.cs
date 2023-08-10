using System;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebScraper_with_Selenium;
using WebScraper_with_Selenium.Services;

namespace webScraper
    {
    public class Program
    {
        public static void Main(string[] args)
        {
             Console.WriteLine("search about:");
             string input = Console.ReadLine();

            IWebDriver driver = new ChromeDriver();
            Service service = new Service();
            List<Item> items = new List<Item>();
            int id= 1 ;
            string language = "ar";
            int loops=10;

//             driver.Navigate().GoToUrl("https://www.facebook.com/");
//             Thread.Sleep(2000);

//            IWebElement email = driver.FindElement(By.Id("email"));
//            IWebElement password = driver.FindElement(By.Id("pass"));
//            IWebElement loginBtn = driver.FindElement(By.Name("login"));

//            email.SendKeys("apdo4@yahoo.com");
//            Thread.Sleep(2000);
//            password.SendKeys("Abdo_mohamed63");
//            Thread.Sleep(2000);
//            loginBtn.Click();
//           Thread.Sleep(2000);
//         //   var search = driver.FindElement(By.XPath("//*[@id=\"mount_0_0_gx\"]/div/div[1]/div/div[2]/div[3]/div/div/div/div/div/label"));
//         // var search = driver.FindElement(By.ClassName("x1i10hfl"));
//      IWebElement search = driver.FindElement(By.CssSelector("input[aria-label='بحث في فيسبوك']"));
// ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", search);
// // search.Click();
// //           Thread.Sleep(2000);
//           search.SendKeys("giza");
//          Thread.Sleep(2000);
//         //   search.Submit();
//         search.SendKeys(Keys.Enter);

//         // Thread.Sleep(2000);
//         //   var r= driver.FindElement(By.XPath("//span")));
//         //     r.Click();
//         var result = driver.FindElements(By.ClassName("x1i10hfl"));

//         foreach(var x in result)
//         Console.WriteLine(x.Text);

  
   

    if(language=="en")
    {
    // var lang = driver.FindElement(By.ClassName("icp-nav-link-inner"));
    //  lang.Click();
    // var en = driver.FindElement(By.XPath("//*[@id=\"icp-language-settings\"]/div[3]/div/label/i"));
    // en.Click();
    //         Thread.Sleep(2000);

    // var save= driver.FindElement(By.ClassName("a-button-input"));
    // save.Click();

    // var re = driver.FindElement(By.Id("nav-logo-sprites"));
    // re.Click();
    driver.Navigate().GoToUrl("https://www.amazon.eg/-/en");

    }
    else{
     driver.Navigate().GoToUrl("https://www.amazon.eg/");
    }

var searchbar= driver.FindElement(By.Id("twotabsearchtextbox"));
// var searchbar= driver.FindElement(By.Id("nav-bb-search")); 
    searchbar.SendKeys(input);
    searchbar.SendKeys(Keys.Enter);
 
int Pages = 1; 
// IWebElement Next =  driver.FindElement(By.ClassName("s-pagination-next"));
// if(Next != null)
// {

// }


for(int i= 0; i<Pages ; i++){
var cards = driver.FindElements(By.XPath("//span[@class='a-size-base-plus a-color-base a-text-normal']"));


    for (int j = 0; j < cards.Count; j++)
        {
            var currentCard = cards[j];
             Thread.Sleep(500);
          ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", currentCard);
            currentCard.Click();
              Thread.Sleep(500);

    
        try{
            // Perform actions on the clicked element
            var item = service.GetAmazonItem(driver);
            items.Add(item);
            string jsonString = JsonConvert.SerializeObject(item);
            Console.WriteLine(jsonString);
            Console.WriteLine("----------------------------------------------------");

            driver.Navigate().Back();

            // Re-locate the elements after navigating back
            cards = driver.FindElements(By.XPath("//span[@class='a-size-base-plus a-color-base a-text-normal']"));
        }
        catch(ElementClickInterceptedException ex) {
            Console.WriteLine( ex.Message );
        }
     

        }
    Thread.Sleep(500);
    try {
  IWebElement  Next =  driver.FindElement(By.ClassName("s-pagination-next"));

    if(Next != null) 
    {
        Pages++;

        Next.Click();
    }
    else
    {
     File.WriteAllText("data.json", "\n ]");
    driver.Close();
    Console.WriteLine("\n\n ---------------------------\n scapping done \n--------------------------- \n\n");
    }
    }
    catch(NotFoundException ex){
        Console.WriteLine(ex.Message);

    }

};
    // Scroll down the page
    // ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");


    }

      }
      
  }


