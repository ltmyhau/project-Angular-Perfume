namespace GoodCharmePerfume.GUI.Admin.Employee
{
    partial class fEmployee
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
            this.dgvEmloyee = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdoEployeeName = new System.Windows.Forms.RadioButton();
            this.rdoEmployeeID = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmloyee)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmloyee
            // 
            this.dgvEmloyee.AllowUserToResizeColumns = false;
            this.dgvEmloyee.AllowUserToResizeRows = false;
            this.dgvEmloyee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmloyee.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmloyee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmloyee.ColumnHeadersHeight = 50;
            this.dgvEmloyee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEmloyee.GridColor = System.Drawing.Color.Silver;
            this.dgvEmloyee.Location = new System.Drawing.Point(26, 180);
            this.dgvEmloyee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvEmloyee.Name = "dgvEmloyee";
            this.dgvEmloyee.ReadOnly = true;
            this.dgvEmloyee.RowHeadersVisible = false;
            this.dgvEmloyee.RowHeadersWidth = 50;
            this.dgvEmloyee.RowTemplate.Height = 24;
            this.dgvEmloyee.RowTemplate.ReadOnly = true;
            this.dgvEmloyee.Size = new System.Drawing.Size(1006, 584);
            this.dgvEmloyee.TabIndex = 16;
            this.dgvEmloyee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmloyee_CellClick);
            this.dgvEmloyee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmloyee_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(819, 88);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(213, 62);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowAll);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.rdoEployeeName);
            this.groupBox1.Controls.Add(this.rdoEmployeeID);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(656, 138);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiêu chí tìm kiếm";
            // 
            // btnShowAll
            // 
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Image = global::GoodCharmePerfume.Properties.Resources.funnel;
            this.btnShowAll.Location = new System.Drawing.Point(602, 80);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(39, 44);
            this.btnShowAll.TabIndex = 9;
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::GoodCharmePerfume.Properties.Resources.loupe;
            this.btnSearch.Location = new System.Drawing.Point(546, 80);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(39, 44);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdoEployeeName
            // 
            this.rdoEployeeName.AutoSize = true;
            this.rdoEployeeName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoEployeeName.Location = new System.Drawing.Point(258, 38);
            this.rdoEployeeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoEployeeName.Name = "rdoEployeeName";
            this.rdoEployeeName.Size = new System.Drawing.Size(167, 34);
            this.rdoEployeeName.TabIndex = 1;
            this.rdoEployeeName.Text = "Tên nhân viên";
            this.rdoEployeeName.UseVisualStyleBackColor = true;
            // 
            // rdoEmployeeID
            // 
            this.rdoEmployeeID.AutoSize = true;
            this.rdoEmployeeID.Checked = true;
            this.rdoEmployeeID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoEmployeeID.Location = new System.Drawing.Point(34, 38);
            this.rdoEmployeeID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoEmployeeID.Name = "rdoEmployeeID";
            this.rdoEmployeeID.Size = new System.Drawing.Size(165, 34);
            this.rdoEmployeeID.TabIndex = 0;
            this.rdoEmployeeID.TabStop = true;
            this.rdoEmployeeID.Text = "Mã nhân viên";
            this.rdoEmployeeID.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(17, 84);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(514, 35);
            this.txtSearch.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::GoodCharmePerfume.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(695, 91);
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
            this.btnExport.Location = new System.Drawing.Point(754, 91);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(51, 56);
            this.btnExport.TabIndex = 18;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // fEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 788);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvEmloyee);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fEmployee";
            this.Text = "fEmployee";
            this.Load += new System.EventHandler(this.fEmployee_Load);
            this.SizeChanged += new System.EventHandler(this.fEmployee_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmloyee)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvEmloyee;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdoEployeeName;
        private System.Windows.Forms.RadioButton rdoEmployeeID;
        private System.Windows.Forms.TextBox txtSearch;
    }
}