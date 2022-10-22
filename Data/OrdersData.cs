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

        public static dynamic OrdersList(int userId)
        {
            using (var context = new LibraryContext())
            {
                var Orders = context.Orders.Where(w => w.userId == userId).ToList();
                return Orders;
            }
        }
        public static dynamic OrderId(int id)
        {
            using (var context = new LibraryContext())
            {
                var order = context.Orders.Where(w => w.id == id).Single();
                return order;
            }
        }

        public static dynamic DetailOrderById(int orderId)
        {
            using (var context = new LibraryContext())
            {
                var orders = (from o in context.OrderDetails
                              join p in context.Products
                              on o.productId equals p.id
                              where o.orderId == orderId
                              select new 
                              { 
                                  name = p.name,
                                  price = o.price,
                                  amount = o.amount,
                                  total = o.lineTotal,
                                  key = o.LineNumber
                              }).ToList();
                return orders;
            }
        }

        public static dynamic OrderByUserId(int userId)
        {
            using (var context = new LibraryContext())
            {
                var orders = (from o in context.Orders
                              join d in context.Deliveries
                              on o.id equals d.orderId
                              where o.userId == userId
                              select new
                              {
                                  id = o.id,
                                  nit = o.nit,
                                  name = o.name,
                                  date = o.date,
                                  estado = d.statusId

                              }).OrderByDescending(x => x.id).ToList();
                return orders;
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