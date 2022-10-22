using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_c2c.DbConnection;
using api_c2c.DbModels;
using Microsoft.EntityFrameworkCore;

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

        public static Users UserByEmail(string email)
        {
            using (var context = new LibraryContext())
            {
                var user = context.Users.Where(x => x.email == email).Single(); 
                return user;
            }
        }

        public static Users UserByToken(string token)
        {
            using (var context = new LibraryContext())
            {
                var user = context.Users.Where(x => x.token == token).Single();
                return user;
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

        public static bool UpdateUser(Users aux)
        {
            using (var context = new LibraryContext())
            {
                try
                {
                    context.Users.Update(aux);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }                
            }
        }
        internal static void add(Users value)
        {
            using (var context = new LibraryContext())
            {
                try
                {
                    // Add Product Hamburguesa
                    context.Users.Add(value);
                    // Saves changes
                    context.SaveChanges();
                }
                catch (DbUpdateException) { }
            }
        }
    }
}