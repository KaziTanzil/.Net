using Project_EComm.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_EComm.DTOs
{
    public class ProductDTO
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string ImageUrl { get; set; }


    }
}