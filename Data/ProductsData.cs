using api_c2c.DbConnection;
using api_c2c.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace api_c2c.Data
{
    public class ProductsData
    {

        public static ICollection<Products> ProductsList()
        {
            using (var context = new LibraryContext())
            {
                var ProductsList = context.Products.ToList();
                return ProductsList;
            }
        }
        public static Products ProductsList(int id)
        {
            using (var context = new LibraryContext())
            {
                var product = context.Products.Find(id);
                return product;
            }
        }

        public static ICollection<Products> ProductsListbyid(string field, int quantity, int page)
        {
            using (var context = new LibraryContext())
            {
                var product = context.Products.OrderBy(id => id.id).Skip((page - 1) * quantity).Take(quantity).ToList();

                switch (field)
                {
                    case "id":
                        product = context.Products.OrderBy(id => id.id).Skip((page - 1) * quantity).Take(quantity).ToList();
                        break;
                    case "name":
                        product = context.Products.OrderBy(id => id.name).Skip((page - 1) * quantity).Take(quantity).ToList();
                        break;
                }
                return product;
            }
        }

        internal static void add(Products value)
        {
            using (var context = new LibraryContext())
            {
                // Add Product Hamburguesa
                context.Products.Add(value);         
                // Saves changes
                context.SaveChanges();
            }
        }

        internal static dynamic delete(int id)
        {
            using (var context = new LibraryContext())
            {
                // remove Product Hamburguesa
                context.Products.Remove(context.Products.Find(id));
                // Saves changes
                context.SaveChanges();
                return true;
            }
        }

        internal static dynamic Update(Products value)
        {
            using (var context = new LibraryContext())
            {
                // remove Product Hamburguesa
                context.Products.Update(value);
                // Saves changes
                context.SaveChanges();
                return context.Products.Find(value.id);
            }
        }
    }
}