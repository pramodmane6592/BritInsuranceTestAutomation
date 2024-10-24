using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BritInsuranceTestAutomation.Model
{
    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
        public ProductSpecifications data { get; set; }
    }
}
