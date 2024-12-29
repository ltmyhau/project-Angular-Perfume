namespace GoodCharmePerfume.GUI.Admin.Product
{
    partial class fAddEditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAddEditProduct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpLoadImg = new System.Windows.Forms.Button();
            this.picProductImg = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtStockQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dtpAddedDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImg)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnUpLoadImg);
            this.panel1.Controls.Add(this.picProductImg);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 429);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(572, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 39);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(380, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(183, 39);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpLoadImg
            // 
            this.btnUpLoadImg.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpLoadImg.FlatAppearance.BorderSize = 0;
            this.btnUpLoadImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpLoadImg.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpLoadImg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnUpLoadImg.Image = global::GoodCharmePerfume.Properties.Resources.image;
            this.btnUpLoadImg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpLoadImg.Location = new System.Drawing.Point(12, 259);
            this.btnUpLoadImg.Name = "btnUpLoadImg";
            this.btnUpLoadImg.Size = new System.Drawing.Size(158, 37);
            this.btnUpLoadImg.TabIndex = 8;
            this.btnUpLoadImg.Text = "Chọn ảnh";
            this.btnUpLoadImg.UseVisualStyleBackColor = false;
            this.btnUpLoadImg.Click += new System.EventHandler(this.btnUpLoadImg_Click);
            // 
            // picProductImg
            // 
            this.picProductImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picProductImg.BackColor = System.Drawing.SystemColors.Control;
            this.picProductImg.Location = new System.Drawing.Point(12, 72);
            this.picProductImg.Name = "picProductImg";
            this.picProductImg.Size = new System.Drawing.Size(158, 178);
            this.picProductImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProductImg.TabIndex = 0;
            this.picProductImg.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtProductId);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(3, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(170, 63);
            this.panel5.TabIndex = 0;
            // 
            // txtProductId
            // 
            this.txtProductId.BackColor = System.Drawing.Color.White;
            this.txtProductId.Enabled = false;
            this.txtProductId.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductId.Location = new System.Drawing.Point(7, 29);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(160, 36);
            this.txtProductId.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã sản phẩm";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Location = new System.Drawing.Point(197, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(558, 366);
            this.panel2.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtStockQuantity);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Location = new System.Drawing.Point(282, 135);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(273, 63);
            this.panel7.TabIndex = 6;
            // 
            // txtStockQuantity
            // 
            this.txtStockQuantity.BackColor = System.Drawing.Color.White;
            this.txtStockQuantity.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockQuantity.Location = new System.Drawing.Point(7, 29);
            this.txtStockQuantity.Name = "txtStockQuantity";
            this.txtStockQuantity.Size = new System.Drawing.Size(263, 36);
            this.txtStockQuantity.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "Số lượng tồn";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cboProductType);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(375, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 63);
            this.panel4.TabIndex = 2;
            // 
            // cboProductType
            // 
            this.cboProductType.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(7, 29);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(170, 38);
            this.cboProductType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại sản phẩm";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.txtCapacity);
            this.panel11.Controls.Add(this.label9);
            this.panel11.Location = new System.Drawing.Point(3, 135);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(273, 63);
            this.panel11.TabIndex = 5;
            // 
            // txtCapacity
            // 
            this.txtCapacity.BackColor = System.Drawing.Color.White;
            this.txtCapacity.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacity.Location = new System.Drawing.Point(7, 29);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(263, 36);
            this.txtCapacity.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 30);
            this.label9.TabIndex = 2;
            this.label9.Text = "Dung tích (ml)";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtProductName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(366, 63);
            this.panel3.TabIndex = 1;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.White;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(7, 29);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(356, 36);
            this.txtProductName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên sản phẩm";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtDescription);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(3, 201);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(552, 160);
            this.panel6.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(7, 29);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(542, 128);
            this.txtDescription.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mô tả";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dtpAddedDate);
            this.panel10.Controls.Add(this.label8);
            this.panel10.Location = new System.Drawing.Point(282, 69);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(273, 63);
            this.panel10.TabIndex = 4;
            // 
            // dtpAddedDate
            // 
            this.dtpAddedDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAddedDate.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAddedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAddedDate.Location = new System.Drawing.Point(7, 29);
            this.dtpAddedDate.Name = "dtpAddedDate";
            this.dtpAddedDate.Size = new System.Drawing.Size(263, 36);
            this.dtpAddedDate.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 30);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ngày thêm";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtPrice);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Location = new System.Drawing.Point(3, 69);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(273, 63);
            this.panel8.TabIndex = 3;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(7, 29);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(263, 36);
            this.txtPrice.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 30);
            this.label6.TabIndex = 2;
            this.label6.Text = "Giá bán";
            // 
            // fAddEditProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "fAddEditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fAddEditProduct";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProductImg)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picProductImg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpLoadImg;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpAddedDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtStockQuantity;
        private System.Windows.Forms.Label label5;
    }
}