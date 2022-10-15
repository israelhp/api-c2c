using api_c2c.DbConnection;
using api_c2c.DbModels;
using System.Linq;

namespace api_c2c.Data
{
    public class OrdersData
    {

        public static dynamic OrdersList()
        {
            using (var context = new LibraryContext())
            {
                var Orders = context.Orders.ToList();
                return Orders;
            }
        }

        internal static dynamic Add(Order value)
        {
            using (var context = new LibraryContext())
            {
                context.Orders.Add(value);
                context.SaveChanges();
                return value;
            }
        }

        internal static dynamic Update(Order value)
        {
            using (var context = new LibraryContext())
            {
                context.Orders.Update(value);
                context.SaveChanges();
                return context.Orders.Find(value.id);
            }
        }

        internal static dynamic Delete(int value)
        {
            using (var context = new LibraryContext())
            {
                context.Orders.Remove(context.Orders.Find(value));
                context.SaveChanges();
                return true;
            }
        }

        public static dynamic OrdersListpage(string field, int quantity, int page)
        {
            using (var context = new LibraryContext())
            {
                var Orders = context.Orders.OrderBy(id => id.id).Skip((page - 1) * quantity).Take(quantity).ToList();

                switch (field)
                {
                    case "id":
                        Orders = context.Orders.OrderBy(id => id.id).Skip((page - 1) * quantity).Take(quantity).ToList();
                        break;
                    case "name":
                        Orders = context.Orders.OrderBy(id => id.name).Skip((page - 1) * quantity).Take(quantity).ToList();
                        break;
                }
                return Orders;
            }
        }



    }
}