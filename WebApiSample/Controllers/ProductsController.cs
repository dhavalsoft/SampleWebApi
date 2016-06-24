using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class ProductsController : ApiController
    {
        private Product[] products;


        public ProductsController()
        {
            products = new Product[] {
                new Product { Id=12345, Category = "Fruit", Name= "Apple", Price= 10.25F },
                new Product { Id=12346, Category = "Fruit", Name= "Grapes", Price= 12.00F },
                new Product { Id=12347, Category = "Vegetable", Name= "Tomato", Price= 5.00F },
                new Product { Id=12348, Category = "Vegetable", Name= "Beans", Price= 7.00F }
            };
        }

        public IEnumerable<Product> Get() {

            return products;
        }


        public Product Get(int ID) {

            return products.First<Product>(x => x.Id == ID);
        }

        public Product Put(int ID, Product product) {

            Product updateProduct = products.First<Product>(x => x.Id == ID);

            updateProduct.Name = product.Name;
            updateProduct.Category =  product.Category;
            updateProduct.Price = product.Price;

            return updateProduct;
        
        }

    }
}
