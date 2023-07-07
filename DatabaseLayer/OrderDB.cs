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
    public class OrderDB:DB
    {
        #region Data Members
        private string table3 = "Order";
        private string sqlLocal3 = "SELECT * FROM [Order]";
        private Collection<Order> orders;
        #endregion

        #region Property Method: Collection
        public Collection<Order> AllOrders
        {
            get
            {
                return orders;
            }
        }
        #endregion
        #region Constructor
        public OrderDB() : base()
        {
            orders = new Collection<Order>();
            FillDataSet(sqlLocal3, table3);
            Add2Collection(table3);

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
            Order anOrder;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    anOrder = new Order();
                    anOrder.OrderID = Convert.ToInt32(myRow["OrderID"]);
                    anOrder.OrderDate = Convert.ToString(myRow["OrderDate"]).TrimEnd();
                    anOrder.ProductID = Convert.ToString(myRow["ProductID"]).TrimEnd();
                    anOrder.Quantity = Convert.ToString(myRow["Quantity"]).TrimEnd();
                    anOrder.Price = Convert.ToString(myRow["Price"]);
                    anOrder.AmountDue = Convert.ToString(myRow["TotalAmount"]).TrimEnd();
                    orders.Add(anOrder);
                }
            }
        }
        private void FillRow(DataRow aRow, Order anOrder, DB.DBOperation operation)
        {
            //Order order;
            if (operation == DB.DBOperation.Add)
            {
                aRow["OrderID"] = anOrder.OrderID;
            }
            aRow["OrderDate"] = anOrder.OrderDate;
            aRow["ProductID"] = anOrder.ProductID;
            aRow["Quantity"] = anOrder.Quantity;
            aRow["Price"] = anOrder.Price;
            aRow["TotalAmount"] = anOrder.AmountDue;
        }

        private int FindRow(Order anOrder, string table)
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
                    if (anOrder.OrderID.ToString() == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["OrderID"]))
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
        public void DataSetChange(Order anOrder, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table3;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anOrder, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anOrder, dataTable)];
                    FillRow(aRow, anOrder, operation);
                    break;
                case DB.DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anOrder, dataTable)];
                    aRow.Delete();
                    //to delete

                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database

        private void Build_INSERT_Parameters(Order anOrder)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@OrderID", SqlDbType.NVarChar, 15, "OrderNo");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@OrderDate", SqlDbType.NVarChar, 15, "OrderDate");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 15, "ProductID");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@Quantity", SqlDbType.NVarChar, 15, "Quantity");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@Price", SqlDbType.NVarChar, 15, "Price");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@TotalAmount", SqlDbType.NVarChar, 15, "AmountDue");
            daMain.InsertCommand.Parameters.Add(param);

        }
        private void Build_UPDATE_Parameters(Order anOrder)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@OrderDate", SqlDbType.NVarChar, 100, "OrderDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 100, "ProductID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            param = new SqlParameter("@Quantity", SqlDbType.NVarChar, 100, "Quantity");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            param = new SqlParameter("@Price", SqlDbType.NVarChar, 100, "Price");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            param = new SqlParameter("@TotalAmount", SqlDbType.NVarChar, 100, "AmountDue");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

        }
        private void Create_INSERT_Command(Order anOrder)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into [Order] (OrderID, OrderDate, ProductID, Quantity, Price, TotalAmount) VALUES (@OrderID, @OrderDate, @ProductID, @Quantity, @Price, @TotalAmount)", cnMain);
            Build_INSERT_Parameters(anOrder);
        }

        private void Create_UPDATE_Command(Order anOrder)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE [Order] SET OrderID =@OrderID, OrderDate = @OrderDate, ProductID = @ProductID, Quantity = @Quantity, Price = @Price, AmountDue= @TotalAmount " + "WHERE OrderID = OrderID", cnMain);
            Build_UPDATE_Parameters(anOrder);
        }

        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@orderid", SqlDbType.NVarChar, 15, "OrderID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private string Create_DELETE_Command(Order anOrder)
        {
            string errorString = null;
            //Create the command that must be used to delete values from the the appropriate table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Order WHERE OrderID = @orderid", cnMain);

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
        public bool UpdateDataSource(Order anOrder)
        {
            bool success = true;
            Create_INSERT_Command(anOrder);
            Create_UPDATE_Command(anOrder);
            Create_DELETE_Command(anOrder);
            success = UpdateDataSource(sqlLocal3, table3);
            return success;

        }
        #endregion
    }
}
