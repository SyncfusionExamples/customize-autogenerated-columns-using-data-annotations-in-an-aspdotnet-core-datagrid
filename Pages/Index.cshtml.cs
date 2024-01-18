using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
namespace DataGrid.Pages
{
    public class OrderDetails
    {
        public static List<OrderDetails> order = new List<OrderDetails>();

        public OrderDetails(int OrderID, string CustomerId, double Freight,
            DateTime OrderDate, string ShipCity)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.Freight = Freight;
            this.ShipCity = ShipCity;
            this.OrderDate = OrderDate;
        }

        public static List<OrderDetails> GetAllRecords()
        {
            if (order.Count() == 0)
            {
                int code = 1001;
                for (int i = 1; i < 3; i++)
                {
                    order.Add(new OrderDetails(code + 1, "ALFKI", 2.3 * i, new DateTime(1991, 05, 15), "Berlin"));
                    order.Add(new OrderDetails(code + 2, "ANATR", 3.3 * i, new DateTime(1990, 04, 04), "Madrid"));
                    order.Add(new OrderDetails(code + 3, "JOE", 4.3 * i, new DateTime(1957, 11, 30), "Cholchester"));
                    order.Add(new OrderDetails(code + 4, "BLONP", 5.3 * i, new DateTime(1930, 10, 22), "Marseille"));
                    order.Add(new OrderDetails(code + 5, "BOLID", 6.3 * i, new DateTime(1953, 02, 18), "Tsawassen"));
                    order.Add(new OrderDetails(code + 6, "MICHAEL", 6.3 * i, new DateTime(1953, 02, 18), "Berlin"));
                    code += 5;  
                }
            }
            return order;
        }
        [Key]   
        public long OrderID { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerID { get; set; }
        [Editable(false)]
        [DisplayFormat(DataFormatString ="C2")]
        public double Freight { get; set; }
        
        public string ShipCity { get; set; }
        [DisplayFormat(DataFormatString ="yMd")]
        public DateTime OrderDate { get; set; }
    }
 
    public class IndexModel : PageModel
    {
       
    }
}