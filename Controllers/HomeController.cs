using api_c2c.DbConnection;
using api_c2c.DbModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
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

            if (ConfigurationSettings.AppSettings["crearBaseDeDatos"].ToUpper() == "SI")
            {
                DbCreatedYet();
                InsertData();
            }           
            

            ViewBag.Title = "Home Page";
            return View();
        }

        private void DbCreatedYet()
        {
            using (var context = new LibraryContext())
            {
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
            try
            {
                string myConnectionString;
                string server = ConfigurationSettings.AppSettings["server"];
                string user = ConfigurationSettings.AppSettings["user"];
                string database = ConfigurationSettings.AppSettings["database"];
                string password = ConfigurationSettings.AppSettings["password"];

                myConnectionString = "server=" + server + ";uid=" + user + ";" +
                    "pwd=" + password + ";database=" + database + "";

                MySql.Data.MySqlClient.MySqlConnection conn;
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                string sql = "ALTER TABLE products MODIFY Image longblob;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error fatal");
            }
        }
        private static void InsertData()
        {
            using (var context = new LibraryContext())
            {
                string ruta = ConfigurationSettings.AppSettings["rutaImagenes"] + @"\";
                // Creates the database if not exists

                var carne = new ItemFamily
                {
                    name = "CARNE"
                };
                context.ItemFamilies.Add(carne);

                var ensalda = new ItemFamily
                {
                    name = "ENSALADAS"
                };
                context.ItemFamilies.Add(ensalda);

                context.Products.Add(new Products
                {
                    name = "Lechon guisado",
                    Image = GetImageWithLink(ruta + "carrusel_1.jpg"),
                    salePrice = 150.00,
                    available = true,
                    description = "Lechon cocinado a fuego lento con un toque leve a limón y sazón con corazón",
                    itemFamily = carne
                });

                context.Products.Add(new Products
                {
                    name = "Fiambre",
                    Image = GetImageWithLink(ruta + "carrusel_2.jpg"),
                    salePrice = 35.99,
                    available = true,
                    description = "Fiabre de embutidos a base de cerdo con leves toques a chile pimiento",
                    itemFamily = ensalda
                });

                context.Products.Add(new Products
                {
                    name = "Jamon con chorizo",
                    Image = GetImageWithLink(ruta + "carrusel_3.jpg"),
                    salePrice = 69.99,
                    available = true,
                    description = "Variedad de jamones con chorizo para una buena tarde con los amigos acompañado de un vino",
                    itemFamily = carne
                });

                context.Products.Add(new Products
                {
                    name = "Fiambre con huevo",
                    Image = GetImageWithLink(ruta + "carrusel_4.jpg"),
                    salePrice = 35.00,
                    available = true,
                    description = "Fiambre con huevo vegetariano para personas mas centradas en cuidar la linea",
                    itemFamily = ensalda
                });

                context.Products.Add(new Products
                {
                    name = "Pan de carne",
                    Image = GetImageWithLink(ruta + "carrusel_5.jpg"),
                    salePrice = 15.00,
                    available = true,
                    description = "Pan con ajonjoli relleno de carne acompañada de cebolla y aderezos varios",
                    itemFamily = carne
                });

                context.Products.Add(new Products
                {
                    name = "Pollo asado",
                    Image = GetImageWithLink(ruta + "carrusel_6.jpg"),
                    salePrice = 38.99,
                    available = true,
                    description = "Pollo asado relleno de ensaldada conformada de tomates cherry",
                    itemFamily = ensalda
                });

                context.Products.Add(new Products
                {
                    name = "Chorizo argentino",
                    Image = GetImageWithLink(ruta + "carrusel_7.jpg"),
                    salePrice = 30.00,
                    available = true,
                    description = "Libra de chorizo argentido importado de la mejor calidad",
                    itemFamily = carne
                });

                context.Products.Add(new Products
                {
                    name = "Chorizo italiano",
                    Image = GetImageWithLink(ruta + "carrusel_8.jpg"),
                    salePrice = 55.99,
                    available = true,
                    description = "Libra de chorizo italiano importado de la mejor calidad",
                    itemFamily = carne
                });
                context.Products.Add(new Products
                {
                    name = "Tamal",
                    Image = GetImageWithLink(ruta + "carrusel_9.jpg"),
                    salePrice = 40.20,
                    available = true,
                    description = "Uy papá, llegaste al premio grande, unos deliciosos tamalitos de chipilin!",
                    itemFamily = ensalda
                });


                context.Roles.Add(new Roles
                {
                    name = "CLIENTE"
                });
                context.Roles.Add(new Roles
                {
                    name = "REPARTIDOR"
                });

                // Saves changes
                context.SaveChanges();
            }
        }
        private static byte[] GetImageWithLink(string url)
        {
            byte[] fileByes;
            string FilePath = url;
            using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    fileByes = reader.ReadBytes((int)stream.Length);
                }
            }
            return fileByes;
        }

    }
}
