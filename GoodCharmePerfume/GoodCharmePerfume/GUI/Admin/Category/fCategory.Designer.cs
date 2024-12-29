namespace GoodCharmePerfume.GUI.Admin.Category
{
    partial class fCategory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlConfirm = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPrintCategory = new System.Windows.Forms.Button();
            this.btnExportCategory = new System.Windows.Forms.Button();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPrintProduct = new System.Windows.Forms.Button();
            this.btnExportProduct = new System.Windows.Forms.Button();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.pnlConfirm.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pnlConfirm);
            this.panel1.Controls.Add(this.pnlControls);
            this.panel1.Controls.Add(this.btnPrintCategory);
            this.panel1.Controls.Add(this.btnExportCategory);
            this.panel1.Controls.Add(this.dgvCategory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCategoryName);
            this.panel1.Controls.Add(this.txtCategoryID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 788);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 46);
            this.label4.TabIndex = 29;
            this.label4.Text = "LOẠI SẢN PHẨM";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlConfirm
            // 
            this.pnlConfirm.Controls.Add(this.btnOK);
            this.pnlConfirm.Controls.Add(this.btnCancel);
            this.pnlConfirm.Location = new System.Drawing.Point(43, 162);
            this.pnlConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlConfirm.Name = "pnlConfirm";
            this.pnlConfirm.Size = new System.Drawing.Size(124, 68);
            this.pnlConfirm.TabIndex = 28;
            this.pnlConfirm.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::GoodCharmePerfume.Properties.Resources.check;
            this.btnOK.Location = new System.Drawing.Point(6, 6);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(51, 56);
            this.btnOK.TabIndex = 12;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::GoodCharmePerfume.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(63, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 56);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnAdd);
            this.pnlControls.Controls.Add(this.btnDelete);
            this.pnlControls.Controls.Add(this.btnEdit);
            this.pnlControls.Location = new System.Drawing.Point(253, 168);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(459, 56);
            this.pnlControls.TabIndex = 27;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(3, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(146, 49);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(309, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(146, 49);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(156, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(146, 49);
            this.btnEdit.TabIndex = 25;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnPrintCategory
            // 
            this.btnPrintCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintCategory.FlatAppearance.BorderSize = 0;
            this.btnPrintCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintCategory.Image = global::GoodCharmePerfume.Properties.Resources.printer;
            this.btnPrintCategory.Location = new System.Drawing.Point(603, 262);
            this.btnPrintCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintCategory.Name = "btnPrintCategory";
            this.btnPrintCategory.Size = new System.Drawing.Size(51, 56);
            this.btnPrintCategory.TabIndex = 14;
            this.btnPrintCategory.UseVisualStyleBackColor = true;
            this.btnPrintCategory.Click += new System.EventHandler(this.btnPrintCategory_Click);
            // 
            // btnExportCategory
            // 
            this.btnExportCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCategory.FlatAppearance.BorderSize = 0;
            this.btnExportCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCategory.Image = global::GoodCharmePerfume.Properties.Resources.xls;
            this.btnExportCategory.Location = new System.Drawing.Point(662, 262);
            this.btnExportCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportCategory.Name = "btnExportCategory";
            this.btnExportCategory.Size = new System.Drawing.Size(51, 56);
            this.btnExportCategory.TabIndex = 13;
            this.btnExportCategory.UseVisualStyleBackColor = true;
            this.btnExportCategory.Click += new System.EventHandler(this.btnExportCategory_Click);
            // 
            // dgvCategory
            // 
            this.dgvCategory.AllowUserToResizeColumns = false;
            this.dgvCategory.AllowUserToResizeRows = false;
            this.dgvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategory.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategory.ColumnHeadersHeight = 40;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCategory.GridColor = System.Drawing.Color.Silver;
            this.dgvCategory.Location = new System.Drawing.Point(43, 325);
            this.dgvCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.ReadOnly = true;
            this.dgvCategory.RowHeadersVisible = false;
            this.dgvCategory.RowHeadersWidth = 50;
            this.dgvCategory.RowTemplate.Height = 24;
            this.dgvCategory.Size = new System.Drawing.Size(669, 424);
            this.dgvCategory.TabIndex = 2;
            this.dgvCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategory_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 30);
            this.label1.TabIndex = 20;
            this.label1.Text = "Mã loại sản phẩm";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.Location = new System.Drawing.Point(237, 102);
            this.txtCategoryName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(475, 35);
            this.txtCategoryName.TabIndex = 23;
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.Enabled = false;
            this.txtCategoryID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryID.Location = new System.Drawing.Point(237, 35);
            this.txtCategoryID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.Size = new System.Drawing.Size(475, 35);
            this.txtCategoryID.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 30);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tên loại sản phẩm";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.btnPrintProduct);
            this.panel2.Controls.Add(this.btnExportProduct);
            this.panel2.Controls.Add(this.dgvProduct);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(736, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 788);
            this.panel2.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(21, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(196, 46);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "SẢN PHẨM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintProduct
            // 
            this.btnPrintProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintProduct.FlatAppearance.BorderSize = 0;
            this.btnPrintProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintProduct.Image = global::GoodCharmePerfume.Properties.Resources.printer;
            this.btnPrintProduct.Location = new System.Drawing.Point(174, 35);
            this.btnPrintProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintProduct.Name = "btnPrintProduct";
            this.btnPrintProduct.Size = new System.Drawing.Size(51, 56);
            this.btnPrintProduct.TabIndex = 18;
            this.btnPrintProduct.UseVisualStyleBackColor = true;
            this.btnPrintProduct.Click += new System.EventHandler(this.btnPrintProduct_Click);
            // 
            // btnExportProduct
            // 
            this.btnExportProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportProduct.FlatAppearance.BorderSize = 0;
            this.btnExportProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportProduct.Image = global::GoodCharmePerfume.Properties.Resources.xls;
            this.btnExportProduct.Location = new System.Drawing.Point(233, 35);
            this.btnExportProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportProduct.Name = "btnExportProduct";
            this.btnExportProduct.Size = new System.Drawing.Size(51, 56);
            this.btnExportProduct.TabIndex = 17;
            this.btnExportProduct.UseVisualStyleBackColor = true;
            this.btnExportProduct.Click += new System.EventHandler(this.btnExportProduct_Click);
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
            this.dgvProduct.Location = new System.Drawing.Point(21, 102);
            this.dgvProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.RowHeadersWidth = 50;
            this.dgvProduct.RowTemplate.Height = 24;
            this.dgvProduct.Size = new System.Drawing.Size(262, 646);
            this.dgvProduct.TabIndex = 13;
            // 
            // fCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 788);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fCategory";
            this.Text = "fGenre";
            this.Load += new System.EventHandler(this.fCategory_Load);
            this.SizeChanged += new System.EventHandler(this.fCategory_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlConfirm.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.Button btnPrintCategory;
        private System.Windows.Forms.Button btnExportCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Panel pnlConfirm;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnPrintProduct;
        private System.Windows.Forms.Button btnExportProduct;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label4;
    }
}