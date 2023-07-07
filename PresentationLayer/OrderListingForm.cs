using PoppelProject1.BusinessLayer;
using PoppelProject1.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelProject1.PresentationLayer
{
    public partial class OrderListingForm : Form
    {
        #region Variables
        public bool listFormClosed;
        private Collection<Order> orders;
        private OrderController orderController;
        private Order order;
        #endregion

        #region Constructor
        public OrderListingForm(OrderController ordController)
        {
            InitializeComponent();
            orderController = ordController;
        }
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

        #region The List View
        public void setUpOrderListView()
        {
            ListViewItem orderDetails;

            listView1.Clear();
            listView1.Columns.Insert(0, "OrderID", 120, HorizontalAlignment.Left);
            listView1.Columns.Insert(1, "OrderDate", 120, HorizontalAlignment.Left);
            listView1.Columns.Insert(2, "ProductID", 120, HorizontalAlignment.Left);
            listView1.Columns.Insert(3, "Quantity", 150, HorizontalAlignment.Left);
            listView1.Columns.Insert(4, "Price", 100, HorizontalAlignment.Left);
            listView1.Columns.Insert(5, "TotalAmount", 150, HorizontalAlignment.Left);

            orderController = new OrderController();
            orders = orderController.Allorders;
            //Add employee details to each ListView item 
            foreach (Order order in orders)
            {
                orderDetails = new ListViewItem();
                orderDetails.Text = Convert.ToString(order.OrderID);
                orderDetails.SubItems.Add(order.OrderDate);
                orderDetails.SubItems.Add(order.ProductID);
                orderDetails.SubItems.Add(order.Quantity);
                orderDetails.SubItems.Add(order.Price);
                orderDetails.SubItems.Add(order.AmountDue);
                listView1.Items.Add(orderDetails);
            }
            listView1.Refresh();
            listView1.GridLines = true;
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order Confirmed!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            OrderForm form = new OrderForm(orderController);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void OrderListingForm_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            setUpOrderListView();
        }

        private void OrderListForm_Activated(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            setUpOrderListView();

        }
    }
}
