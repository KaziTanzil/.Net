using AutoMapper;
using Project_EComm.DTOs;
using Project_EComm.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_EComm.Controllers
{
    public class ProductController : Controller
    {
        ECommerceDBEntities db= new ECommerceDBEntities();

        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
            });
                return new Mapper(config);
        }

    public ActionResult Index()
        {
            var data = db.Products.ToList();
            var products = GetMapper().Map<List<ProductDTO>>(data);
            return View(products);

        }


        public ActionResult AddToCart(int id)
        {
            var data = db.Products.Find(id);
            var product=GetMapper().Map<ProductDTO>(data);
            List<ProductDTO> cart = null;
            product.Stock = 1;

            if (Session["cart"] == null)
            {
                cart = new List<ProductDTO>();
            }

            else
            {
                cart = (List<ProductDTO>)Session["cart"];
            }

            var x= (from p in cart
                    where p.ProductId==product.ProductId
                    select p).SingleOrDefault();

            if (x == null)
            {
                cart.Add(product);
                Session["cart"] = cart;
            }

            else 
            {
                x.Stock++;
            }

            return RedirectToAction("Index");


        }


        public ActionResult Cart()
        {
            var cart = (List<ProductDTO>)Session["cart"];
            return View(cart);
        }


        public ActionResult Decrease(int id)
        {
            var cart= (List<ProductDTO>)Session["cart"];
            var product=(from p in cart
                         where p.ProductId==id
                         select p).SingleOrDefault();

            if (product != null)
            {
                if (product.Stock > 1)
                {
                    product.Stock--;
                }
                else
                {
                    cart.Remove(product);
                }

            }
            return RedirectToAction("Cart");

        }
        public ActionResult Increase(int id)
        {
            var cart = (List<ProductDTO>)Session["cart"];
            var product = (from p in cart
                           where p.ProductId == id
                           select p).SingleOrDefault();

        
            if (product != null)
            {
                product.Stock++;
            }


            else
            {
                cart.Add(product);
            }

            
            return RedirectToAction("Cart");

        }




    }
}