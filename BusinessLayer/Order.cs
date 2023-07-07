using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject1.BusinessLayer
{
    public class Order
    {
        #region Data Members
        private int orderID;
        private string orderDate;
        private string productID;
        private string quantity;
        private string price;
        private string amountDue;
        #endregion

        #region Properties
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public string OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string AmountDue
        {
            get { return amountDue; }
            set { amountDue = value; }
        }
        #endregion
    }
}
