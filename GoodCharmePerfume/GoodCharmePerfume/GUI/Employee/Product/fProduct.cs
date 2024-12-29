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

namespace GoodCharmePerfume.GUI.Employee.Product
{
    public partial class fProduct : Form
    {
        public fProduct()
        {
            InitializeComponent();
        }

        #region Methods
        public void LoadProductList()
        {
            dgvProduct.DataSource = ProductDAO.Instance.GetProductList();
        }

        public void LoadProductTypeList()
        {
            cboProductType.Items.Clear();
            List<ProductTypeDTO> list = ProductTypeDAO.Instance.GetProductTypeList();
            ProductTypeDTO allItem = new ProductTypeDTO { MaLoaiSP = "", TenLoaiSP = "Tất cả" };
            list.Insert(0, allItem);
            cboProductType.DataSource = list;
            cboProductType.DisplayMember = "TenLoaiSP";
            cboProductType.ValueMember = "MaLoaiSP";
            cboProductType.SelectedIndex = 0;
        }

        private void CustomizeDataGridView()
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
            dgvProduct.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";

            dgvProduct.Columns["NgayThem"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvProduct.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["DungTich"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["NgayThem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduct.Columns["TenLoaiSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProduct.Columns["MaLoaiSP"].Visible = false;
            dgvProduct.Columns["MoTa"].Visible = false;
            dgvProduct.Columns["HinhSP"].Visible = false;
            dgvProduct.Columns["TongSoLuongBan"].Visible = false;
        }

        private void SetColumnWidthsInPercentage()
        {
            int totalWidth = dgvProduct.Width;

            dgvProduct.Columns["MaSP"].Width = (int)(0.135 * totalWidth);
            dgvProduct.Columns["TenSP"].Width = (int)(0.2 * totalWidth);
            dgvProduct.Columns["GiaBan"].Width = (int)(0.15 * totalWidth);
            dgvProduct.Columns["DungTich"].Width = (int)(0.1 * totalWidth);
            dgvProduct.Columns["SoLuongTon"].Width = (int)(0.1 * totalWidth);
            dgvProduct.Columns["NgayThem"].Width = (int)(0.15 * totalWidth);
            dgvProduct.Columns["TenLoaiSP"].Width = (int)(0.15 * totalWidth);

            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        public void ExportFile(DataTable dataTable, string sheetName, string title)
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

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã sản phẩm";
            cl1.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên sản phẩm";
            cl2.ColumnWidth = 30;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Mã loại sản phẩm";
            cl3.ColumnWidth = 17;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Tên loại sản phẩm";
            cl4.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Giá bán";
            cl5.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Dung tích (ml)";
            cl6.ColumnWidth = 17;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Số lượng tồn";
            cl7.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Ngày thêm";
            cl8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");
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
        #endregion

        #region Events
        private void fProduct_Load(object sender, EventArgs e)
        {
            LoadProductList();
            LoadProductTypeList();
            CustomizeDataGridView();
            this.SizeChanged += fProduct_SizeChanged;
            SetColumnWidthsInPercentage();
        }

        private void fProduct_SizeChanged(object sender, EventArgs e)
        {
            if (dgvProduct.Columns.Count > 0)
            {
                SetColumnWidthsInPercentage();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoProductName.Checked)
            {
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    dgvProduct.DataSource = ProductDAO.Instance.GetProductListByProductName(txtSearch.Text);
                }
                else
                {
                    LoadProductList();
                }
            }
            else if (rdoProductType.Checked)
            {
                if (cboProductType.SelectedValue != null)
                {
                    string selectedValue = cboProductType.SelectedValue.ToString();

                    if (string.IsNullOrEmpty(selectedValue))
                    {
                        LoadProductList();
                    }
                    else
                    {
                        dgvProduct.DataSource = ProductDAO.Instance.GetProductListByProductTypeId(selectedValue);
                    }
                }
            }
            else
            {
                if (!int.TryParse(txtFromPrice.Text, out int fromPrice) || fromPrice < 0)
                {
                    MessageBox.Show("Vui lòng nhập khoảng giá bán cần tìm. Khoảng giá phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFromPrice.Focus();
                    return;
                }
                if (!int.TryParse(txtToPrice.Text, out int toPrice) || toPrice < 0)
                {
                    MessageBox.Show("Vui lòng nhập khoảng giá bán cần tìm. Khoảng giá phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtToPrice.Focus();
                    return;
                }
                if (fromPrice > toPrice)
                {
                    MessageBox.Show("Khoảng giá bắt đầu không được lớn hơn khoảng giá kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFromPrice.Focus();
                    return;
                }
                dgvProduct.DataSource = ProductDAO.Instance.GetProductListByPrice(Convert.ToInt32(txtFromPrice.Text), Convert.ToInt32(txtToPrice.Text));
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboProductType.SelectedIndex = 0;
            txtFromPrice.Clear();
            txtToPrice.Clear();
            LoadProductList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //List<MovieDetailDTO> list = MovieDetailDAO.Instance.GetListMoiveDetail();
            //rptMovie r = new rptMovie();
            //r.SetDataSource(list);
            //fReport f = new fReport();
            //f.crvReport.ReportSource = r;
            //f.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("MaSP");
            DataColumn col2 = new DataColumn("TenSP");
            DataColumn col3 = new DataColumn("MaLoaiSP");
            DataColumn col4 = new DataColumn("TenLoaiSP");
            DataColumn col5 = new DataColumn("GiaBan");
            DataColumn col6 = new DataColumn("DungTich");
            DataColumn col7 = new DataColumn("SoLuongTon");
            DataColumn col8 = new DataColumn("NgayThem");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);

            foreach (DataGridViewRow dgvRow in dgvProduct.Rows)
            {
                DataRow row = dataTable.NewRow();

                row[0] = dgvRow.Cells["MaSP"].Value;
                row[1] = dgvRow.Cells["TenSP"].Value;
                row[2] = dgvRow.Cells["MaLoaiSP"].Value;
                row[3] = dgvRow.Cells["TenLoaiSP"].Value;
                row[4] = dgvRow.Cells["GiaBan"].Value;
                row[5] = dgvRow.Cells["DungTich"].Value;
                row[6] = dgvRow.Cells["SoLuongTon"].Value;
                row[7] = ((DateTime)dgvRow.Cells["NgayThem"].Value).ToString("dd/MM/yyyy");

                dataTable.Rows.Add(row);
            }

            ExportFile(dataTable, "Sản phẩm", "DANH SÁCH SẢN PHẨM");
        }
        #endregion
    }
}
