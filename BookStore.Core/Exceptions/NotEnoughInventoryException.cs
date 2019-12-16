using BookStore.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace BookStore.Core.Exceptions
{
    public class NotEnoughInventoryException : Exception
    {
        public IEnumerable<INameQuantity> Missing { get; }


        public NotEnoughInventoryException(IEnumerable<INameQuantity> missing)
            : this(string.Join(", ", missing))
        {
            this.Missing = missing;
        }

        public NotEnoughInventoryException(string message)
            : base(String.Format("NotEnough Inventory for this books : {0}", message))
        {

        }
    }
}
