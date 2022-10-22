using api_c2c.DbConnection;
using api_c2c.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api_c2c.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new System.Net.Http.Formatting.RequestHeaderMapping(
                            "Accept",
                              "text/html",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/json"));
            // InsertData();

            ViewBag.Title = "Home Page";

            return View();
        }

        private static void InsertData()
        {
            using (var context = new LibraryContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                var itemFamily = new ItemFamily
                {
                    name = "Hamburgesas"
                };
                context.ItemFamilies.Add(itemFamily);

                var itemFamily2 = new ItemFamily
                {
                    name = "Pizzas"
                };
                context.ItemFamilies.Add(itemFamily2);

                // Add Product Hamburguesa
                context.Products.Add(new Products
                {
                    name = "Hamburguesa",
                    salePrice = 40.20,
                    available = true,
                    description = "Pan con ajonjoli, tomate, carne, lechuga, ketchup, mostaza, mayonesa y cebolla",
                    itemFamily = itemFamily
                });
                context.Products.Add(new Products
                {
                    name = "Hamburguesa",
                    salePrice = 40.20,
                    available = true,
                    description = "Pan con ajonjoli, tomate, carne, lechuga, ketchup, mostaza, mayonesa y cebolla",
                    itemFamily = itemFamily
                });
                context.Products.Add(new Products
                {
                    name = "Hamburguesa",
                    salePrice = 40.20,
                    available = true,
                    description = "Pan con ajonjoli, tomate, carne, lechuga, ketchup, mostaza, mayonesa y cebolla",
                    itemFamily = itemFamily
                });

                // Add Product Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });
                // Add Product Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });
                // Add Product Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });
                // Add Product Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });
                // Add Product Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });
                context.Products.Add(new Products
                {
                    name = "Pizza Peperoni",
                    salePrice = 40.00,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y peperoni",
                    itemFamily = itemFamily2
                });

                // Add Product Another Pizza
                context.Products.Add(new Products
                {
                    name = "Pizza salami",
                    salePrice = 45.75,
                    available = true,
                    description = "Pan pizza con queso, salsa de tomate y Salami",
                    itemFamily = itemFamily2
                });

                context.Roles.Add(new Roles
                {
                    name = "CLIENTE"
                });
                context.Roles.Add(new Roles
                {
                    name = "REPARTIDOR"
                });

                context.Estados.Add(new Estados
                {
                    description = "INGRESADO"
                });
                context.Estados.Add(new Estados
                {
                    description = "ASIGNADO"
                });
                context.Estados.Add(new Estados
                {
                    description = "PREPARANDO"
                });
                context.Estados.Add(new Estados
                {
                    description = "EN CAMINO"
                });
                context.Estados.Add(new Estados
                {
                    description = "ENTREGADO"
                });

                context.Users.Add(new Users
                {
                    username = "default",
                    password = "24320281",
                    email = "default@gmail.com",
                    dpi = "0000000000000",
                    RolesId = 1
                });
                //// Saves changes
                context.SaveChanges();
            }
        }

    }
}
