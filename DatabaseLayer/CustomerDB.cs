using PoppelProject1.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoppelProject1.BusinessLayer;

namespace PoppelProject1.DatabaseLayer
{
    public class CustomerDB : DB
    {
        #region Data Members
        private string table1 = "Customer";
        private string sqlLocal1 = "SELECT * FROM Customer";
        private Collection<Customer> customers;
        #endregion

        #region Property Method: Collection
        public Collection<Customer> AllCustomers
        {
            get
            {
                return customers;
            }
        }
        #endregion

        #region Constructor
        public CustomerDB() : base()
        {
            customers = new Collection<Customer>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);

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
            Customer aCust;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Customer object
                    aCust = new Customer();
                    //Obtain each customer attribute from the specific field in the row in the table
                    aCust.ID = Convert.ToString(myRow["ID"]).TrimEnd();
                    //Do the same for all other attributes
                    aCust.CustomerID = Convert.ToInt32(myRow["CustomerID"]);
                    aCust.Name = Convert.ToString(myRow["Name"]).TrimEnd();
                    aCust.Surname = Convert.ToString(myRow["Surname"]).TrimEnd();
                    //aCust.Email = Convert.ToString(myRow["Email"]).TrimEnd();
                    aCust.Telephone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    aCust.CreditScore = Convert.ToString(myRow["CreditScore"]).TrimEnd();
                    //aCust.DeliveryAddress = Convert.ToString(myRow["DeliveryAddress"]).TrimEnd();
                    customers.Add(aCust);
                }


            }
        }

        private void FillRow(DataRow aRow, Customer aCust, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {
                aRow["ID"] = aCust.ID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["CustomerID"] = aCust.CustomerID;
            }
            aRow["Name"] = aCust.Name;
            aRow["Surname"] = aCust.Surname;
            // aRow["Email"] = aCust.Email;
            aRow["Phone"] = aCust.Telephone;
            aRow["CreditScore"] = aCust.CreditScore;
            //aRow["DeliveryAddress"] = aCust.DeliveryAddress;


        }

        private int FindRow(Customer aCust, string table)
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
                    if (aCust.ID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
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
        public void DataSetChange(Customer aCust, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aCust, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:

                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aCust, dataTable)];
                    FillRow(aRow, aCust, operation);


                    break;
                case DB.DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aCust, dataTable)];
                    aRow.Delete();


                    break;
            }
        }
        #endregion

        private void Build_INSERT_Parameters(Customer aCust)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@CustomerID", SqlDbType.NVarChar, 10, "CustomerID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Surname", SqlDbType.NVarChar, 15, "Surname");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.NVarChar, 15, "Email");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CreditScore", SqlDbType.NVarChar, 15, "DeliveryAddress");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@DeliveryAddress", SqlDbType.NVarChar, 15, "DeliveryAddress");
            daMain.InsertCommand.Parameters.Add(param);
        }

        private void Build_UPDATE_Parameters(Customer aCust)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do for all fields other than ID and CustomerID as for Insert 
            param = new SqlParameter("@Surname", SqlDbType.NVarChar, 15, "Surname");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.NVarChar, 100, "Email");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 100, "Phone");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CreditScore", SqlDbType.NVarChar, 100, "CreditScore");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@DeliveryAddress", SqlDbType.NVarChar, 100, "DeliveryAddress");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@id", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(Customer aCust)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Customer (ID, CustomerID, Name, Surname, Email, Phone, CreditScore, DeliveryAddress) VALUES (@id, @CustomerID, @Name, @Surname, @Email, @Phone, @CreditScore, @DeliveryAddress)", cnMain);
            Build_INSERT_Parameters(aCust);
        }

        private void Create_UPDATE_Command(Customer aCust)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE Customer SET Name =@Name, Surname = @Surname, Email=@Email,Phone =@Phone, CreditScore =@CreditScore, DeliveryAddress =@DeliveryAddress " + "WHERE ID = @Original_ID", cnMain);
            Build_UPDATE_Parameters(aCust);
        }
        private string Create_DELETE_Command(Customer aCust)
        {
            string errorString = null;
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Customer WHERE ID = @id", cnMain);
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

        public bool UpdateDataSource(Customer aCust)
        {
            bool success = true;
            Create_INSERT_Command(aCust);
            Create_UPDATE_Command(aCust);
            Create_DELETE_Command(aCust);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
    }
}