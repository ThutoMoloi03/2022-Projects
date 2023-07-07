using PoppelProject1.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject1.DatabaseLayer
{
    public class ProductDB:DB
    {
        #region Data Members
        private string table2 = "Product";
        private string sqlLocal2 = "SELECT * FROM Product";
        private Collection<Product> products;
        #endregion

        #region Property Method: Collection
        public Collection<Product> AllProducts
        {
            get
            {
                return products;
            }
        }
        #endregion

        #region Constructor
        public ProductDB() : base()
        {
            products = new Collection<Product>();
            FillDataSet(sqlLocal2, table2);
            Add2Collection(table2);

        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        private void Add2Collection(string table)
        {
            DataRow myRow = null;
            Product aProduct;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Product object
                    aProduct = new Product();
                    //Obtain each customer attribute from the specific field in the row in the table
                    aProduct.ProductID = Convert.ToString(myRow["ProductID"]).TrimEnd();
                    //Do the same for all other attributes
                    aProduct.ProductType = Convert.ToString(myRow["Type"]).TrimEnd();
                    aProduct.Description = Convert.ToString(myRow["Description"]).TrimEnd();
                    aProduct.QuantityOnHand = Convert.ToInt16(myRow["QuantityOnHand"]);
                    aProduct.Price = Convert.ToDecimal(myRow["Price(p/u)"]);
                    
                    products.Add(aProduct);
                }


            }
        }
        private void FillRow(DataRow aRow, Product aProduct, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {
                aRow["ProductID"] = aProduct.ProductID;
                //NOTE square brackets to indicate index of collections of fields in row.

            }
            aRow["Type"] = aProduct.ProductType;
            aRow["Description"] = aProduct.Description;
            aRow["QuantityOnHand"] = aProduct.QuantityOnHand;
            aRow["Price(p/u)"] = aProduct.Price;
            


        }

        private int FindRow(Product aProduct, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //In c# there is no item property (but we use the 2-dim array) it 
                    //is automatically known to the compiler when used as below
                    if (aProduct.ProductID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ProductID"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Product aProduct, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table2;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aProduct, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:

                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aProduct, dataTable)];
                    FillRow(aRow, aProduct, operation);


                    break;
                case DB.DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aProduct, dataTable)];
                    aRow.Delete();


                    break;
            }
        }
        #endregion

        private void Build_INSERT_Parameters(Product aProduct)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 15, "ProductID");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@Type", SqlDbType.NVarChar, 10, "Type");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@Description", SqlDbType.NVarChar, 100, "Description");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@QuantityOnHand", SqlDbType.NVarChar, 15, "QauntityOnHand");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Price(p/u)", SqlDbType.NVarChar, 15, "Price(p/u)");
            daMain.InsertCommand.Parameters.Add(param);

        }
        private void Build_UPDATE_Parameters(Product aProduct)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@Type", SqlDbType.NVarChar, 100, "Type");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do for all fields other than ID and CustomerID as for Insert 
            param = new SqlParameter("@Description", SqlDbType.NVarChar, 15, "Description");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@QuantityOnHand", SqlDbType.NVarChar, 100, "QuantityOnHand");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Price(p/u)", SqlDbType.NVarChar, 100, "Price(p/u)");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ProductID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@productid", SqlDbType.NVarChar, 15, "ProductID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(Product aProduct)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Product (ProductID, Type, Description, QuantityOnHand,Price(p/u)) VALUES (@productid, @Type, @Description,@QuantityOnHand, @Price(p/u))", cnMain);
            Build_INSERT_Parameters(aProduct);
        }

        private void Create_UPDATE_Command(Product aProduct)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE Product SET Type =@Type, Description = @Description, QuantityOnHand=@QuantityOnHand,Price(p/u) =@Price(p/u) " + "WHERE ProductID = @Original_ID", cnMain);
            Build_INSERT_Parameters(aProduct);
        }
        private string Create_DELETE_Command(Product aProduct)
        {
            string errorString = null;
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Product WHERE ProductID = @productid", cnMain);
            try
            {
                Build_DELETE_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }
        public bool UpdateDataSource(Product aProduct)
        {
            bool success = true;
            Create_INSERT_Command(aProduct);
            Create_UPDATE_Command(aProduct);
            Create_DELETE_Command(aProduct);
            success = UpdateDataSource(sqlLocal2, table2);
            return success;
        }
    }
}
