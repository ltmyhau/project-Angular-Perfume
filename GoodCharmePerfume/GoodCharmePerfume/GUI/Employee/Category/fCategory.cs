using GoodCharmePerfume.DAO;
using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodCharmePerfume.GUI.Employee.Category
{
    public partial class fCategory : Form
    {
        BindingSource bsCatygoryList = new BindingSource();

        public fCategory()
        {
            InitializeComponent();

            lblTitle.Text = "DANH SÁCH SẢN PHẨM THEO LOẠI SẢN PHẨM";
        }

        #region Methods
        public void LoadCategoryList()
        {
            bsCatygoryList.DataSource = ProductTypeDAO.Instance.GetProductTypeList();
        }

        private void CustomizeDgvProduct()
        {
            dgvProduct.EnableHeadersVisualStyles = false;
            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvProduct.RowTemplate.Height = 40;

            dgvProduct.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgvProduct.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvProduct.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvProduct.Columns["DungTich"].HeaderText = "Dung tích (ml)";
            dgvProduct.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
            dgvProduct.Columns["NgayThem"].HeaderText = "Ngày thêm";

            dgvProduct.Columns["NgayThem"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvProduct.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["DungTich"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["NgayThem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["TenLoaiSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProduct.Columns["MaLoaiSP"].Visible = false;
            dgvProduct.Columns["TenLoaiSP"].Visible = false;
            dgvProduct.Columns["MoTa"].Visible = false;
            dgvProduct.Columns["HinhSP"].Visible = false;
            dgvProduct.Columns["TongSoLuongBan"].Visible = false;
        }

        private void CustomizeDgvCategory()
        {
            dgvCategory.EnableHeadersVisualStyles = false;
            dgvCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvCategory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCategory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCategory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCategory.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCategory.RowTemplate.Height = 40;

            dgvCategory.Columns["MaLoaiSP"].HeaderText = "Mã loại sản phẩm";
            dgvCategory.Columns["TenLoaiSP"].HeaderText = "Tên loại sản phẩm";

            dgvCategory.Columns["MaLoaiSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void SetColumnWidthsInPercentageDgvProduct()
        {
            int totalWidth = dgvProduct.Width;

            dgvProduct.Columns["MaSP"].Width = (int)(0.15 * totalWidth);
            dgvProduct.Columns["TenSP"].Width = (int)(0.25 * totalWidth);
            dgvProduct.Columns["GiaBan"].Width = (int)(0.15 * totalWidth);
            dgvProduct.Columns["DungTich"].Width = (int)(0.15 * totalWidth);
            dgvProduct.Columns["SoLuongTon"].Width = (int)(0.15 * totalWidth);
            dgvProduct.Columns["NgayThem"].Width = (int)(0.15 * totalWidth);

            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void SetColumnWidthsInPercentageDgvCategory()
        {
            int totalWidth = dgvCategory.Width;

            dgvCategory.Columns["MaLoaiSP"].Width = (int)(0.4 * totalWidth);
            dgvCategory.Columns["TenLoaiSP"].Width = (int)(0.6 * totalWidth);

            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void BindingGenre()
        {
            txtCategoryID.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "MaLoaiSP", true, DataSourceUpdateMode.Never));
            txtCategoryName.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "TenLoaiSP", true, DataSourceUpdateMode.Never));
        }

        public void ExportFileCategory(DataTable dataTable, string sheetName, string title)
        {
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = oExcel.Workbooks.Add(Type.Missing);
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "B1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "13";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã thể loại";
            cl1.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên thể loại";
            cl2.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "B3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 6;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowHead.Font.Name = "Times New Roman";
            rowHead.Font.Size = "11";

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            int rowStart = 4;
            int colStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count - 1;
            int colEnd = dataTable.Columns.Count;
            Microsoft.Office.Interop.Excel.Range c0 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart];
            Microsoft.Office.Interop.Excel.Range cN = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colEnd];
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c0, cN);
            range.Value2 = arr;
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            oSheet.get_Range(c0, cN).Font.Name = "Times New Roman";
            oSheet.get_Range(c0, cN).Font.Size = "11";
            oSheet.get_Range(c0, cN).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c02 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart + 1];
            Microsoft.Office.Interop.Excel.Range cN2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colStart + 1];
            oSheet.get_Range(c02, cN2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
        }

        public void ExportFileProduct(DataTable dataTable, string sheetName, string title, string tenLoaiSP)
        {
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = oExcel.Workbooks.Add(Type.Missing);
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cDate = oSheet.get_Range("E2", "F2");
            cDate.MergeCells = true;
            cDate.Value2 = "Loại sản phẩm: " + tenLoaiSP;
            cDate.Font.Name = "Times New Roman";
            cDate.Font.Size = "11";
            cDate.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A4", "A4");
            cl1.Value2 = "Mã sản phẩm";
            cl1.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B4", "B4");
            cl2.Value2 = "Tên sản phẩm";
            cl2.ColumnWidth = 30;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C4", "C4");
            cl3.Value2 = "Giá bán";
            cl3.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D4", "D4");
            cl4.Value2 = "Dung tích (ml)";
            cl4.ColumnWidth = 17;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E4", "E4");
            cl5.Value2 = "Số lượng tồn";
            cl5.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F4", "F4");
            cl6.Value2 = "Ngày thêm";
            cl6.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A4", "F4");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 6;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowHead.Font.Name = "Times New Roman";
            rowHead.Font.Size = "11";

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            int rowStart = 5;
            int colStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count - 1;
            int colEnd = dataTable.Columns.Count;
            Microsoft.Office.Interop.Excel.Range c0 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart];
            Microsoft.Office.Interop.Excel.Range cN = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colEnd];
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c0, cN);
            range.Value2 = arr;
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            oSheet.get_Range(c0, cN).Font.Name = "Times New Roman";
            oSheet.get_Range(c0, cN).Font.Size = "11";
            oSheet.get_Range(c0, cN).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c02 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart + 1];
            Microsoft.Office.Interop.Excel.Range cN2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colStart + 1];
            oSheet.get_Range(c02, cN2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
        }
        #endregion

        #region Events
        private void fCategory_Load(object sender, EventArgs e)
        {
            dgvCategory.DataSource = bsCatygoryList;
            dgvCategory.AllowUserToAddRows = false;
            LoadCategoryList();
            string maLoaiSP = dgvCategory.Rows[0].Cells["MaLoaiSP"].Value.ToString();
            dgvProduct.DataSource = ProductDAO.Instance.GetProductListByProductTypeId(maLoaiSP);
            CustomizeDgvProduct();
            CustomizeDgvCategory();
            BindingGenre();
            this.SizeChanged += fCategory_SizeChanged;
            SetColumnWidthsInPercentageDgvProduct();
            SetColumnWidthsInPercentageDgvCategory();
        }

        private void fCategory_SizeChanged(object sender, EventArgs e)
        {
            if (dgvProduct.Columns.Count > 0)
            {
                SetColumnWidthsInPercentageDgvProduct();
            }
            if (dgvCategory.Columns.Count > 0)
            {
                SetColumnWidthsInPercentageDgvCategory();
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string maLoaiSP = dgvCategory.Rows[e.RowIndex].Cells["MaLoaiSP"].Value.ToString();
                dgvProduct.DataSource = ProductDAO.Instance.GetProductListByProductTypeId(maLoaiSP);
            }
        }

        private void btnExportCategory_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("MaLoaiSP");
            DataColumn col2 = new DataColumn("TenLoaiSP");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);

            foreach (DataGridViewRow dgvRow in dgvCategory.Rows)
            {
                DataRow row = dataTable.NewRow();

                row[0] = dgvRow.Cells["MaLoaiSP"].Value;
                row[1] = dgvRow.Cells["TenLoaiSP"].Value;

                dataTable.Rows.Add(row);
            }

            ExportFileCategory(dataTable, "Loại sản phẩm", "DANH SÁCH LOẠI SẢN PHẨM");
        }

        private void btnPrintCategory_Click(object sender, EventArgs e)
        {
            List<ProductTypeDTO> list = ProductTypeDAO.Instance.GetProductTypeList();
            //rptGenre r = new rptGenre();
            //r.SetDataSource(list);
            //fReport f = new fReport();
            //f.crvReport.ReportSource = r;
            //f.ShowDialog();
        }

        private void btnExportProduct_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("MaSP");
            DataColumn col2 = new DataColumn("TenSP");
            DataColumn col3 = new DataColumn("GiaBan");
            DataColumn col4 = new DataColumn("DungTich");
            DataColumn col5 = new DataColumn("SoLuongTon");
            DataColumn col6 = new DataColumn("NgayThem");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);

            foreach (DataGridViewRow dgvRow in dgvProduct.Rows)
            {
                DataRow row = dataTable.NewRow();

                row[0] = dgvRow.Cells["MaSP"].Value;
                row[1] = dgvRow.Cells["TenSP"].Value;
                row[2] = dgvRow.Cells["GiaBan"].Value;
                row[3] = dgvRow.Cells["DungTich"].Value;
                row[4] = dgvRow.Cells["SoLuongTon"].Value;
                row[5] = ((DateTime)dgvRow.Cells["NgayThem"].Value).ToString("dd/MM/yyyy");

                dataTable.Rows.Add(row);
            }

            ExportFileProduct(dataTable, "Sản phẩm", "DANH SÁCH SẢN PHẨM", txtCategoryName.Text);
        }

        private void btnPrintProduct_Click(object sender, EventArgs e)
        {
            List<ProductDTO> list = ProductDAO.Instance.GetProductListByProductTypeId(txtCategoryID.Text);
            //TextObject text = rptMovie.ReportDefinition.Section["Section3"].ReportObjects["tobTheLoai"];
            //text.Text = txtGenreName.Text;

            //rptMovieByGenre r = new rptMovieByGenre();
            //r.SetDataSource(list);
            //fReportMovieByGenre f = new fReportMovieByGenre(txtGenreName.Text);
            //f.crvReport.ReportSource = r;
            //f.ShowDialog();
        }
        #endregion
    }
}
