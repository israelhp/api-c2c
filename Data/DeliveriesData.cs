using api_c2c.DbConnection;
using api_c2c.DbModels;
using System.Linq;

namespace api_c2c.Data
{
    public class DeliveriesData
    {

        public static dynamic DeliveriesList()
        {
            using (var context = new LibraryContext())
            {
                var Deliveries = context.Deliveries.ToList();
                return Deliveries;
            }
        }

        internal static dynamic Add(Deliveries value)
        {
            using (var context = new LibraryContext())
            {
                context.Deliveries.Add(value);
                context.SaveChanges();
                return true;
            }
        }

        internal static dynamic Update(Deliveries value)
        {
            using (var context = new LibraryContext())
            {
                context.Deliveries.Update(value);
                context.SaveChanges();
                return true;
            }
        }

        internal static dynamic Delete(int value)
        {
            using (var context = new LibraryContext())
            {
                context.Deliveries.Remove(context.Deliveries.Find(value));
                context.SaveChanges();
                return true;
            }
        }

        internal static dynamic DeliveriesListFiltered(string field, int quantity, int page)
        {
            using (var context = new LibraryContext())
            {
                var Deliveries = context.Products.OrderBy(id => id.id).Skip((page - 1) * quantity).Take(quantity).ToList();

                switch (field)
                {
                    case "id":
                        Deliveries = context.Products.OrderBy(id => id.id).Skip((page - 1) * quantity).Take(quantity).ToList();
                        break;
                    case "name":
                        Deliveries = context.Products.OrderBy(id => id.name).Skip((page - 1) * quantity).Take(quantity).ToList();
                        break;
                }
                return Deliveries;
            }
        }
    }
}