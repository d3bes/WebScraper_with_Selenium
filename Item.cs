using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper_with_Selenium
{
    public class Item
    {
    public string vendor { get; set; }
     public string productTitle {set; get;} 
     public string brand {set; get;} //*[@id="poExpander"]/div[1]/div/table/tbody/tr[1]/td[2]/span
     public string imageUrl {set; get;}
    //  public string model {set; get;} //*[@id="poExpander"]/div[1]/div/table/tbody/tr[2]/td[2]/span
    //  public string color {set; get;} //*[@id="poExpander"]/div[1]/div/table/tbody/tr[3]/td[2]/span
    //  public string material {set; get;} //*[@id="poExpander"]/div[1]/div/table/tbody/tr[10]/td[2]/span
     public string priceWhole {set;get;} //*[@id="corePrice_feature_div"]/div/span[1]/span[2]/span[2]
     public string priceFraction {set;get;} //*[@id="corePriceDisplay_desktop_feature_div"]/div[1]/span[1]/span[2]/span[3]
   
    //  public string dimensions {set;get;} //*[@id="detailBullets_feature_div"]/ul/li[1]/span/span[2]
    //  public string region {set; get; } //*[@id="detailBullets_feature_div"]/ul/li[6]/span/span[2]

    public string[] extraDetails {set; get; } //*[@id="feature-bullets"]/ul/li/span 
    public string[] details {set; get; } // detailBullets_feature_div
        

      
    }
}