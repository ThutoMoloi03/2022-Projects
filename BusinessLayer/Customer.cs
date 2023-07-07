using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject1.BusinessLayer
{
    public class Customer:Person
    {
        #region DataMembers
        private int customerID;
        private string surname;
        private string email;
        private string creditScore;

        private string deliveryAddress;
        #endregion

        #region Properties
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string CreditScore
        {
            get { return creditScore; }
            set { creditScore = value; }
        }

        public string DeliveryAddress
        {
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }
        #endregion
    }
}
