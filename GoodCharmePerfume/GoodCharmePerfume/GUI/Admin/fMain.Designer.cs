namespace GoodCharmePerfume.GUI.Admin
{
    partial class fMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.flpSidebarTransition = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tmrSidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flpSidebarTransition.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.picHelp);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 50);
            this.panel1.TabIndex = 0;
            // 
            // picHelp
            // 
            this.picHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picHelp.Image = global::GoodCharmePerfume.Properties.Resources.question;
            this.picHelp.Location = new System.Drawing.Point(940, 11);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(30, 30);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHelp.TabIndex = 6;
            this.picHelp.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::GoodCharmePerfume.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(886, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GoodCharmePerfume.Properties.Resources.goodcharme;
            this.pictureBox2.Location = new System.Drawing.Point(12, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(238, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(569, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 36);
            this.txtName.TabIndex = 4;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flpSidebarTransition
            // 
            this.flpSidebarTransition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.flpSidebarTransition.Controls.Add(this.btnOrder);
            this.flpSidebarTransition.Controls.Add(this.btnCategory);
            this.flpSidebarTransition.Controls.Add(this.btnProduct);
            this.flpSidebarTransition.Controls.Add(this.btnCustomer);
            this.flpSidebarTransition.Controls.Add(this.btnEmployee);
            this.flpSidebarTransition.Controls.Add(this.btnStatistic);
            this.flpSidebarTransition.Controls.Add(this.btnLogout);
            this.flpSidebarTransition.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpSidebarTransition.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSidebarTransition.Location = new System.Drawing.Point(0, 50);
            this.flpSidebarTransition.Name = "flpSidebarTransition";
            this.flpSidebarTransition.Padding = new System.Windows.Forms.Padding(0, 24, 0, 0);
            this.flpSidebarTransition.Size = new System.Drawing.Size(230, 503);
            this.flpSidebarTransition.TabIndex = 1;
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Image = global::GoodCharmePerfume.Properties.Resources.order;
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Location = new System.Drawing.Point(3, 27);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnOrder.Size = new System.Drawing.Size(230, 50);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "      Đơn hàng";
            this.btnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.Image = global::GoodCharmePerfume.Properties.Resources.category;
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.Location = new System.Drawing.Point(3, 83);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnCategory.Size = new System.Drawing.Size(230, 50);
            this.btnCategory.TabIndex = 4;
            this.btnCategory.Text = "      Loại nước hoa";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = global::GoodCharmePerfume.Properties.Resources.perfume;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(3, 139);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnProduct.Size = new System.Drawing.Size(230, 50);
            this.btnProduct.TabIndex = 3;
            this.btnProduct.Text = "      Nước hoa";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::GoodCharmePerfume.Properties.Resources.logout;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(3, 363);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(230, 50);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "      Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tmrSidebarTransition
            // 
            this.tmrSidebarTransition.Interval = 10;
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Image = global::GoodCharmePerfume.Properties.Resources.customer;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(3, 195);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnCustomer.Size = new System.Drawing.Size(230, 50);
            this.btnCustomer.TabIndex = 10;
            this.btnCustomer.Text = "      Khách hàng";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnEmployee.FlatAppearance.BorderSize = 0;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.Color.White;
            this.btnEmployee.Image = global::GoodCharmePerfume.Properties.Resources.employee;
            this.btnEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployee.Location = new System.Drawing.Point(3, 251);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnEmployee.Size = new System.Drawing.Size(230, 50);
            this.btnEmployee.TabIndex = 11;
            this.btnEmployee.Text = "      Nhân viên";
            this.btnEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnStatistic
            // 
            this.btnStatistic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnStatistic.FlatAppearance.BorderSize = 0;
            this.btnStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistic.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistic.ForeColor = System.Drawing.Color.White;
            this.btnStatistic.Image = global::GoodCharmePerfume.Properties.Resources.trend;
            this.btnStatistic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistic.Location = new System.Drawing.Point(3, 307);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnStatistic.Size = new System.Drawing.Size(230, 50);
            this.btnStatistic.TabIndex = 12;
            this.btnStatistic.Text = "      Thống kê";
            this.btnStatistic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistic.UseVisualStyleBackColor = false;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // fMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.flpSidebarTransition);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoodCharme Perfume";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.flpSidebarTransition.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpSidebarTransition;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Timer tmrSidebarTransition;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnStatistic;
    }
}