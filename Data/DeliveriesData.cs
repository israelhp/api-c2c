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

        public static dynamic DeliveriesDefault(int idUser, int statusId)
        {
            using (var context = new LibraryContext())
            {
                var orders = (from d in context.Deliveries
                              join o in context.Orders
                              on d.orderId equals o.id
                              where d.userId == idUser  && d.statusId == statusId
                              select new
                              {
                                  id = o.id,
                                  currency= o.currency,
                                  nit = o.nit,
                                  name = o.name,
                                  observations= o.observations,
                                  date = o.date,
                                  total = o.total,
                                  PaymentId = o.PaymentId,
                                  userId = o.userId,
                                  idDelivery = d.id,
                                  estado = d.statusId
                              }).ToList();
                return orders;
            }
        }

        public static dynamic OrderId(int id)
        {
            using (var context = new LibraryContext())
            {
                var order = context.Deliveries.Where(w => w.orderId == id).Single();
                return order;
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