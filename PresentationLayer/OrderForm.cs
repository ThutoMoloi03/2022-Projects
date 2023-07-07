using PoppelProject1.BusinessLayer;
using PoppelProject1.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;

namespace PoppelProject1.PresentationLayer
{
    public partial class OrderForm : Form
    {
        #region Data Members
        private Order order;
        private OrderController orderController; //
        public bool OrderFormClosed = false;
        



        #endregion

        #region Property Method

        public Order Order
        {
            set
            {

                order = value;
            }

        }

        #endregion

        #region Constructor
        public OrderForm(OrderController aController)
        {
            InitializeComponent();
            orderController = aController;
            
        }

        #endregion
        #region Utility Methods
        private void ShowAll(bool value, Order order)
        {
            label1.Visible = value;
            label2.Visible = value;
            label3.Visible = value;
            label4.Visible = value;
            label5.Visible = value;
            label6.Visible = value;
            
        }
        private void ClearAll()
        {
            OrderIDtxt.Text = "";
            Datetxt.Text = "";
            Producttxt.Text = "";
            Qtytxt.Text = "";
            Pricetxt.Text = "";
            Amounttxt.Text = "";
            
        }
        private void PopulateObject()
        {
           
            order = new Order();
            OrderIDtxt.Text = Convert.ToString(order.OrderID);
            order.OrderDate = Datetxt.Text;
            order.ProductID = Producttxt.Text;
            order.Quantity = Qtytxt.Text;
            order.Price = Pricetxt.Text;
            order.AmountDue = Amounttxt.Text;
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            PopulateObject();
            MessageBox.Show("Order Submitted!");
            orderController = new OrderController();
            orderController.DataMaintenance(order, DB.DBOperation.Add);
            orderController.FinalizeChanges(order);
            ClearAll();
            //ShowAll(false, roleValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderListingForm form = new OrderListingForm(orderController);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
