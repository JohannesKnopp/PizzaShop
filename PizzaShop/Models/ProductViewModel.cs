using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaShop.Models
{
    public class ProductViewModel
    {

        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsInSortiment { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount can't be empty")]
        [Range(1, 10, ErrorMessage = "Amount must be between 1 and 10")]
        public int Amount { get; set; } = 1;

        //public virtual Product Toppings { get; set; }

    }
}