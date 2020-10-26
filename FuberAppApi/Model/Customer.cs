using System;
using System.Collections.Generic;
using System.Text;

namespace FuberApps.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public Location PickUp { get; set; }
        public Location Drop { get; set; }

       public void RegisterCustomer(Customer customer)
        {

        }

    }
}
