using PoppelProject1.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject1.BusinessLayer
{
    public class ProductController
    {
        #region Data Members
        private ProductDB productDB;
        private Collection<Product> products;

        #endregion

        #region Properties
        public Collection<Product> Allproducts
        {
            get { return products; }
        }

        #endregion

        #region Constructor
        public ProductController()
        {
            //***instantiating DB objects to communicate with the database
            productDB = new ProductDB();
            products = productDB.AllProducts;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Product aProduct, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            productDB.DataSetChange(aProduct, operation);//calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    products.Add(aProduct);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aProduct);
                    products[index] = aProduct;  // replace employee at this index with the updated employee
                                                   //  employees.Add(anEmp);
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aProduct);  // find the index of the specific employee in collection
                    products.RemoveAt(index);  // remove that employee form the collection
                    break;
            }
        }
        public bool FinalizeChanges(Product product)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return productDB.UpdateDataSource(product);

        }
        #endregion

        #region Search Methods
        public Product Find(string ID)
        {
            int index = 0;
            bool found = (products[index].ProductID == ID);  //check if it is the first record
            int count = products.Count;
            while (!(found) && (index < products.Count - 1))  //if not "this" record and you are not at the end of the list 
            {
                index = index + 1;
                found = (products[index].ProductID == ID);   // this will be TRUE if found
            }
            return products[index];  // this is the one!  
        }
        public int FindIndex(Product aProduct)
        {
            int counter = 0;
            bool found = false;
            found = (aProduct.ProductID == products[counter].ProductID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < products.Count - 1)
            {
                counter += 1;
                found = (aProduct.ProductID == products[counter].ProductID);
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
