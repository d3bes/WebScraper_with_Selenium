using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraper_with_Selenium.Services
{
    public class Service
    {
        public Item GetAmazonItem (IWebDriver driver){
             Item item = new Item();
           try{

            try{ string vendor = driver.FindElement(By.Id("sellerProfileTriggerId")).Text; item.vendor=vendor; }
            catch{item.vendor="";Console.WriteLine("element sellerProfileTriggerId not found");}

           try{string title =driver.FindElement(By.Id("productTitle")).Text; item.productTitle= title;} 
           catch{item.productTitle="";Console.WriteLine("element productTitle not found");}

            // string brand = driver.FindElement(By.XPath("//*[@id=\"poExpander\"]/div[1]/div/table/tbody/tr[1]/td[2]/span")).Text;
            try{string brand = driver.FindElement(By.Id("bylineInfo")).Text; item.brand = brand;}      
             catch{item.brand="";Console.WriteLine("element bylineInfo not found");}
   
            try { var image = driver.FindElement(By.Id("landingImage"));
                 string imageUrl = image.GetAttribute("src"); item.imageUrl= imageUrl;}
            catch{item.imageUrl="";Console.WriteLine("element landingImage not found");}

            // string model = driver.FindElement(By.XPath("//*[@id=\"poExpander\"]/div[1]/div/table/tbody/tr[2]/td[2]/span")).Text;
            // string color = driver.FindElement(By.XPath("//*[@id=\"poExpander\"]/div[1]/div/table/tbody/tr[3]/td[2]/span")).Text;
            // string material = driver.FindElement(By.XPath("//*[@id=\"poExpander\"]/div[1]/div/table/tbody/tr[10]/td[2]/span")).Text;
           
           try{ string priceWhole= driver.FindElement(By.XPath("//*[@id=\"corePrice_feature_div\"]/div/span[1]/span[2]/span[2]")).Text; item.priceWhole = priceWhole;}
            catch{item.priceWhole="";Console.WriteLine("xpath //*[@id=\"corePrice_feature_div\"]/div/span[1]/span[2]/span[2] not found");}

           try{ string priceFraction = driver.FindElement(By.XPath("//*[@id=\"corePrice_feature_div\"]/div/span[1]/span[2]/span[3]")).Text; item.priceFraction = priceFraction;}
            catch{item.priceFraction="";Console.WriteLine("xpath //*[@id=\"corePrice_feature_div\"]/div/span[1]/span[2]/span[3] not found");}

           try{ string [] extraDetails= driver
                                        .FindElements(By.XPath("//*[@id=\"feature-bullets\"]/ul/li/span"))
                                        .Select(el=>el.Text)
                                        .ToArray();
                        item.extraDetails =extraDetails;
           }
             catch{item.extraDetails= null;Console.WriteLine("Xpath //*[@id=\"feature-bullets\"]/ul/li/span not found");}

        //    string dimensions = driver.FindElement(By.XPath("//*[@id=\"detailBullets_feature_div\"]/ul/li[1]/span/span[2]")).Text;
        //    string region = driver.FindElement(By.XPath("//*[@id=\"detailBullets_feature_div\"]/ul/li[6]/span/span[2]")).Text;

           

            string finalJson= JsonConvert.SerializeObject(item);
            if(File.Exists("data.json"))
            {
            File.AppendAllText("data.json", ", "+ finalJson + "\n");
            }
            else
            {
             File.WriteAllText("data.json",  "[ "+  finalJson + "\n");
            
            }


            return item;
           }
           catch{
           
            string itemUrl =  driver.Url;
            if(File.Exists("failed.json"))
            {
            File.AppendAllText("failed.json", itemUrl+",\n");
            }
            else
            {
            File.WriteAllText("failed.json", itemUrl + ",\n");
            }
        


            return null;
           }
           

        }
    }
}