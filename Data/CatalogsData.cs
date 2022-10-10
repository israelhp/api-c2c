using api_c2c.DbConnection;
using api_c2c.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_c2c.Data
{
    public class CatalogsData
    {
        public static ICollection<ItemFamily> CatalogsList()
        {
            using (var context = new LibraryContext())
            {
                var ItemFamilies = context.ItemFamilies.ToList();
                return ItemFamilies;
            }
        }

        internal static dynamic Add(ItemFamily value)
        {
            using (var context = new LibraryContext())
            {
                context.ItemFamilies.Add(value);
                context.SaveChanges();
                return true;
            }
        }

        internal static dynamic Update(ItemFamily value)
        {
            using (var context = new LibraryContext())
            {
                context.ItemFamilies.Update(value);
                context.SaveChanges();
                return true;
            }
        }

        internal static dynamic Delete(int value)
        {
            using (var context = new LibraryContext())
            {
                context.ItemFamilies.Remove(context.ItemFamilies.Find(value));
                context.SaveChanges();
                return true;
            }
        }
    }
}