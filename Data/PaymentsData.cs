using System;
using api_c2c.DbConnection;
using api_c2c.DbModels;
using System.Linq;

namespace api_c2c.Data
{
    public class PaymentsData
    {
        public static dynamic PaymentsList()
        {
            using (var context = new LibraryContext())
            {
                var Payments = context.Payments.ToList();
                return Payments;
            }
        }

        internal static dynamic Add(Payment value)
        {
            using (var context = new LibraryContext())
            {
                context.Payments.Add(value);
                context.SaveChanges();
                return context.Payments.Find(value.id);
            }
        }

        internal static dynamic Update(Payment value)
        {
            using (var context = new LibraryContext())
            {
                context.Payments.Update(value);
                context.SaveChanges();
                return context.Payments.Find(value.id);
            }
        }

        internal static dynamic Delete(int value)
        {
            using (var context = new LibraryContext())
            {
                context.Payments.Remove(context.Payments.Find(value));
                context.SaveChanges();
                return true;
            }
        }

    }
}