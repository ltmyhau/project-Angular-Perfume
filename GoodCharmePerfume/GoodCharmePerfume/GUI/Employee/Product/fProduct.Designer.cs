namespace GoodCharmePerfume.GUI.Employee.Product
{
    partial class fProduct
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
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.rdoProductType = new System.Windows.Forms.RadioButton();
            this.txtToPrice = new System.Windows.Forms.TextBox();
            this.rdoProductName = new System.Windows.Forms.RadioButton();
            this.rdoPrice = new System.Windows.Forms.RadioButton();
            this.txtFromPrice = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToResizeColumns = false;
            this.dgvProduct.AllowUserToResizeRows = false;
            this.dgvProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProduct.ColumnHeadersHeight = 50;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProduct.GridColor = System.Drawing.Color.Silver;
            this.dgvProduct.Location = new System.Drawing.Point(26, 232);
            this.dgvProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.RowHeadersWidth = 50;
            this.dgvProduct.RowTemplate.Height = 24;
            this.dgvProduct.RowTemplate.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(1006, 532);
            this.dgvProduct.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboProductType);
            this.groupBox2.Controls.Add(this.rdoProductType);
            this.groupBox2.Controls.Add(this.txtToPrice);
            this.groupBox2.Controls.Add(this.rdoProductName);
            this.groupBox2.Controls.Add(this.rdoPrice);
            this.groupBox2.Controls.Add(this.txtFromPrice);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.btnShowAll);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(865, 190);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiêu chí tìm kiếm";
            // 
            // cboProductType
            // 
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(282, 86);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(457, 36);
            this.cboProductType.TabIndex = 10;
            // 
            // rdoProductType
            // 
            this.rdoProductType.AutoSize = true;
            this.rdoProductType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoProductType.Location = new System.Drawing.Point(34, 88);
            this.rdoProductType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoProductType.Name = "rdoProductType";
            this.rdoProductType.Size = new System.Drawing.Size(173, 34);
            this.rdoProductType.TabIndex = 9;
            this.rdoProductType.Text = "Loại sản phẩm";
            this.rdoProductType.UseVisualStyleBackColor = true;
            // 
            // txtToPrice
            // 
            this.txtToPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToPrice.Location = new System.Drawing.Point(579, 136);
            this.txtToPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtToPrice.Name = "txtToPrice";
            this.txtToPrice.Size = new System.Drawing.Size(160, 35);
            this.txtToPrice.TabIndex = 5;
            // 
            // rdoProductName
            // 
            this.rdoProductName.AutoSize = true;
            this.rdoProductName.Checked = true;
            this.rdoProductName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoProductName.Location = new System.Drawing.Point(34, 38);
            this.rdoProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoProductName.Name = "rdoProductName";
            this.rdoProductName.Size = new System.Drawing.Size(167, 34);
            this.rdoProductName.TabIndex = 1;
            this.rdoProductName.TabStop = true;
            this.rdoProductName.Text = "Tên sản phẩm";
            this.rdoProductName.UseVisualStyleBackColor = true;
            // 
            // rdoPrice
            // 
            this.rdoPrice.AutoSize = true;
            this.rdoPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPrice.Location = new System.Drawing.Point(34, 138);
            this.rdoPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoPrice.Name = "rdoPrice";
            this.rdoPrice.Size = new System.Drawing.Size(109, 34);
            this.rdoPrice.TabIndex = 3;
            this.rdoPrice.Text = "Giá bán";
            this.rdoPrice.UseVisualStyleBackColor = true;
            // 
            // txtFromPrice
            // 
            this.txtFromPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromPrice.Location = new System.Drawing.Point(343, 136);
            this.txtFromPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFromPrice.Name = "txtFromPrice";
            this.txtFromPrice.Size = new System.Drawing.Size(160, 35);
            this.txtFromPrice.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(282, 36);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(457, 35);
            this.txtSearch.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(516, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "đến";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(286, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "Từ";
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
            this.btnPrint.TabIndex = 19;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.btnExport.TabIndex = 18;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // fProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 788);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fProduct";
            this.Text = "fEmployee";
            this.Load += new System.EventHandler(this.fProduct_Load);
            this.SizeChanged += new System.EventHandler(this.fProduct_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtToPrice;
        private System.Windows.Forms.RadioButton rdoPrice;
        private System.Windows.Forms.TextBox txtFromPrice;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdoProductName;
        private System.Windows.Forms.RadioButton rdoProductType;
        private System.Windows.Forms.ComboBox cboProductType;
    }
}