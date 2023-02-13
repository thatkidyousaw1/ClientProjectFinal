using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProject.Model
{
    [Table("UserData")]
    public class UserData
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Department { get; set; }
        public string PurchaseOrder { get; set; }
        public string TinNumber { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Quantity { get; set; }
        public string Items { get; set; }
        public string UnitPrice { get; set; }
        public string Amount { get; set; }
        public string CheckAmount { get; set; }
        public string WithTax { get; set; }
        public string OfficeReceiptNumber { get; set; }
        public string DatePaid { get; set; }
        public string Bir2307 { get; set; }
        public string Bir2306 { get; set; }

      /*  public UserData(String clientname, String department)
        {
            clientname = ClientName;
            department = Department;

        } */
    }
}
