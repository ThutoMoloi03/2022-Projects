﻿namespace PoppelProject1.PresentationLayer
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OrderIDtxt = new System.Windows.Forms.TextBox();
            this.Datetxt = new System.Windows.Forms.TextBox();
            this.Producttxt = new System.Windows.Forms.TextBox();
            this.Qtytxt = new System.Windows.Forms.TextBox();
            this.Pricetxt = new System.Windows.Forms.TextBox();
            this.Amounttxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 374);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "OrderID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "OrderDate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ProductID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "TotalAmount";
            // 
            // OrderIDtxt
            // 
            this.OrderIDtxt.Location = new System.Drawing.Point(166, 50);
            this.OrderIDtxt.Name = "OrderIDtxt";
            this.OrderIDtxt.Size = new System.Drawing.Size(100, 20);
            this.OrderIDtxt.TabIndex = 7;
            // 
            // Datetxt
            // 
            this.Datetxt.Location = new System.Drawing.Point(166, 92);
            this.Datetxt.Name = "Datetxt";
            this.Datetxt.Size = new System.Drawing.Size(100, 20);
            this.Datetxt.TabIndex = 8;
            // 
            // Producttxt
            // 
            this.Producttxt.Location = new System.Drawing.Point(166, 133);
            this.Producttxt.Name = "Producttxt";
            this.Producttxt.Size = new System.Drawing.Size(100, 20);
            this.Producttxt.TabIndex = 9;
            // 
            // Qtytxt
            // 
            this.Qtytxt.Location = new System.Drawing.Point(166, 174);
            this.Qtytxt.Name = "Qtytxt";
            this.Qtytxt.Size = new System.Drawing.Size(100, 20);
            this.Qtytxt.TabIndex = 10;
            // 
            // Pricetxt
            // 
            this.Pricetxt.Location = new System.Drawing.Point(166, 219);
            this.Pricetxt.Name = "Pricetxt";
            this.Pricetxt.Size = new System.Drawing.Size(100, 20);
            this.Pricetxt.TabIndex = 11;
            // 
            // Amounttxt
            // 
            this.Amounttxt.Location = new System.Drawing.Point(166, 265);
            this.Amounttxt.Name = "Amounttxt";
            this.Amounttxt.Size = new System.Drawing.Size(100, 20);
            this.Amounttxt.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 35);
            this.button1.TabIndex = 13;
            this.button1.Text = "SUBMIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(339, 279);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Order Summary";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 372);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Amounttxt);
            this.Controls.Add(this.Pricetxt);
            this.Controls.Add(this.Qtytxt);
            this.Controls.Add(this.Producttxt);
            this.Controls.Add(this.Datetxt);
            this.Controls.Add(this.OrderIDtxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OrderIDtxt;
        private System.Windows.Forms.TextBox Datetxt;
        private System.Windows.Forms.TextBox Producttxt;
        private System.Windows.Forms.TextBox Qtytxt;
        private System.Windows.Forms.TextBox Pricetxt;
        private System.Windows.Forms.TextBox Amounttxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}