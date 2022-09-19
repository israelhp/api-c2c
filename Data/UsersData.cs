using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_c2c.DbConnection;
using api_c2c.DbModels;

namespace api_c2c.Data
{
    public class UsersData
    {
        public static ICollection<Users> UserList()
        {
            using (var context = new LibraryContext())
            {
                var ProductsList = context.Users.ToList();
                return ProductsList;
            }
        }

        public static Users UserList(int id)
        {
            using (var context = new LibraryContext())
            {
                var product = context.Users.Find(id);
                return product;
            }
        }

        internal static void add(Users value)
        {
            using (var context = new LibraryContext())
            {
                // Add Product Hamburguesa
                context.Users.Add(value);
                // Saves changes
                context.SaveChanges();
            }
        }
    }
}