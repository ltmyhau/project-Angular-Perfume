namespace GoodCharmePerfume.GUI.Employee.Order
{
    partial class fOrder
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdoPayment = new System.Windows.Forms.RadioButton();
            this.rdoOrderId = new System.Windows.Forms.RadioButton();
            this.rdoStatus = new System.Windows.Forms.RadioButton();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::GoodCharmePerfume.Properties.Resources.loupe;
            this.btnSearch.Location = new System.Drawing.Point(757, 131);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(39, 44);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Image = global::GoodCharmePerfume.Properties.Resources.funnel;
            this.btnShowAll.Location = new System.Drawing.Point(813, 131);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(39, 44);
            this.btnShowAll.TabIndex = 7;
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(342, 36);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(397, 35);
            this.txtSearch.TabIndex = 2;
            // 
            // rdoPayment
            // 
            this.rdoPayment.AutoSize = true;
            this.rdoPayment.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPayment.Location = new System.Drawing.Point(34, 138);
            this.rdoPayment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoPayment.Name = "rdoPayment";
            this.rdoPayment.Size = new System.Drawing.Size(266, 34);
            this.rdoPayment.TabIndex = 3;
            this.rdoPayment.Text = "Phương thức thanh toán";
            this.rdoPayment.UseVisualStyleBackColor = true;
            // 
            // rdoOrderId
            // 
            this.rdoOrderId.AutoSize = true;
            this.rdoOrderId.Checked = true;
            this.rdoOrderId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoOrderId.Location = new System.Drawing.Point(34, 38);
            this.rdoOrderId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoOrderId.Name = "rdoOrderId";
            this.rdoOrderId.Size = new System.Drawing.Size(164, 34);
            this.rdoOrderId.TabIndex = 1;
            this.rdoOrderId.TabStop = true;
            this.rdoOrderId.Text = "Mã đơn hàng";
            this.rdoOrderId.UseVisualStyleBackColor = true;
            // 
            // rdoStatus
            // 
            this.rdoStatus.AutoSize = true;
            this.rdoStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStatus.Location = new System.Drawing.Point(34, 88);
            this.rdoStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoStatus.Name = "rdoStatus";
            this.rdoStatus.Size = new System.Drawing.Size(229, 34);
            this.rdoStatus.TabIndex = 9;
            this.rdoStatus.Text = "Tình trạng đơn hàng";
            this.rdoStatus.UseVisualStyleBackColor = true;
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(342, 86);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(397, 36);
            this.cboStatus.TabIndex = 10;
            // 
            // cboPayment
            // 
            this.cboPayment.FormattingEnabled = true;
            this.cboPayment.Location = new System.Drawing.Point(342, 136);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(397, 36);
            this.cboPayment.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboPayment);
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(this.rdoStatus);
            this.groupBox2.Controls.Add(this.rdoOrderId);
            this.groupBox2.Controls.Add(this.rdoPayment);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.btnShowAll);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(865, 190);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiêu chí tìm kiếm";
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToResizeColumns = false;
            this.dgvOrder.AllowUserToResizeRows = false;
            this.dgvOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrder.ColumnHeadersHeight = 50;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrder.GridColor = System.Drawing.Color.Silver;
            this.dgvOrder.Location = new System.Drawing.Point(26, 232);
            this.dgvOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.RowHeadersWidth = 50;
            this.dgvOrder.RowTemplate.Height = 24;
            this.dgvOrder.RowTemplate.ReadOnly = true;
            this.dgvOrder.Size = new System.Drawing.Size(1006, 532);
            this.dgvOrder.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Image = global::GoodCharmePerfume.Properties.Resources.xls;
            this.btnExport.Location = new System.Drawing.Point(981, 143);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(51, 56);
            this.btnExport.TabIndex = 7;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::GoodCharmePerfume.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(900, 143);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(51, 56);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // fOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 788);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fOrder";
            this.Text = "fCustomer";
            this.Load += new System.EventHandler(this.fOrder_Load);
            this.SizeChanged += new System.EventHandler(this.fOrder_SizeChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdoPayment;
        private System.Windows.Forms.RadioButton rdoOrderId;
        private System.Windows.Forms.RadioButton rdoStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ComboBox cboPayment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
    }
}