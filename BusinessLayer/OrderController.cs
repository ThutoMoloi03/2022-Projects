using PoppelProject1.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject1.BusinessLayer
{
    public class OrderController
    {
        #region Data Members
        private OrderDB orderDB;
        private Collection<Order> orders;
        #endregion

        #region Properties
        public Collection<Order> Allorders
        {
            get { return orders; }
        }
        #endregion
        #region Constructor
        public OrderController()
        {
            //***instantiating DB objects to communicate with the database
            
            orderDB = new OrderDB();
            orders = orderDB.AllOrders;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Order anOrder, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            orderDB.DataSetChange(anOrder, operation);//calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    orders.Add(anOrder);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(anOrder);
                    orders[index] = anOrder;  // replace employee at this index with the updated employee
                                              //  employees.Add(anEmp);
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(anOrder);  // find the index of the specific employee in collection
                    orders.RemoveAt(index);  // remove that employee form the collection
                    break;
            }
        }


        public bool FinalizeChanges(Order order)
        {
            //***call the OrderDB method that will commit the changes to the database
            return orderDB.UpdateDataSource(order);

        }
        #endregion

        #region Search Methods
        public Order Find(int ID)
        {
            int index = 0;
            
            bool found = (orders[index].OrderID == ID);  //check if it is the first record
            int count = orders.Count;
            while (!(found) && (index < orders.Count - 1))  //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (orders[index].OrderID == ID);   // this will be TRUE if found
            }
            return orders[index];  // this is the one!  
        }

        public int FindIndex(Order anOrder)
        {
            int counter = 0;
            bool found = false;
            found = (anOrder.OrderID == orders[counter].OrderID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < orders.Count - 1)
            {
                counter += 1;
                found = (anOrder.OrderID == orders[counter].OrderID);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }

}
