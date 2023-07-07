using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject1.BusinessLayer
{
    public class Product
    {
        #region DataMembers
        private string productID;
        private string description;
        private int quantityOnHand;
        private decimal price;
        private string producttype;
        
        #endregion

        #region Properties

        public string ProductType
        {
            get { return producttype; }
            set { producttype = value; }
        }

        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int QuantityOnHand
        {
            get { return quantityOnHand; }
            set { quantityOnHand = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion


    }
}
