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

namespace GoodCharmePerfume.GUI.Admin.Statistic
{
    public partial class fStatistic : Form
    {
        public fStatistic()
        {
            InitializeComponent();
            this.SizeChanged += fStatistic_SizeChanged;
        }

        #region Methods
        public void LoadStatisticsRevenue()
        {
            if (rdoEmployee.Checked)
            {
                if (rdoDTTatCa.Checked)
                {
                    dgvStatisticsRevenue.DataSource = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuTheoNhanVien");
                }
                else
                {
                    dgvStatisticsRevenue.DataSource = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuTheoNhanVien @tuNgay , @denNgay ", new object[] { dtpDTTuNgay.Value, dtpDTDenNgay.Value });
                }
                CustomizeDgvStatisticsRevenueByEmployee();
                SetColumnWidthsInPercentageDgvStatisticsRevenueByEmployee();
            }
            else
            {
                if (rdoDTTatCa.Checked)
                {
                    dgvStatisticsRevenue.DataSource = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuTheoKhachHang");
                }
                else
                {
                    dgvStatisticsRevenue.DataSource = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuTheoKhachHang @tuNgay , @denNgay ", new object[] { dtpDTTuNgay.Value, dtpDTDenNgay.Value });
                }
                CustomizeDgvStatisticsRevenueByCustomer();
                SetColumnWidthsInPercentageDgvStatisticsRevenueByCustomer();
            }
        }

        private void CustomizeDgvStatisticsRevenueByEmployee()
        {
            dgvStatisticsRevenue.EnableHeadersVisualStyles = false;
            dgvStatisticsRevenue.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvStatisticsRevenue.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStatisticsRevenue.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvStatisticsRevenue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsRevenue.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvStatisticsRevenue.RowTemplate.Height = 40;

            dgvStatisticsRevenue.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgvStatisticsRevenue.Columns["HoTenNV"].HeaderText = "Họ tên nhân viên";
            dgvStatisticsRevenue.Columns["SoLuongDonHang"].HeaderText = "Số đơn hàng";
            dgvStatisticsRevenue.Columns["TongTien"].HeaderText = "Doanh thu";

            dgvStatisticsRevenue.Columns["MaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsRevenue.Columns["HoTenNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStatisticsRevenue.Columns["SoLuongDonHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsRevenue.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CustomizeDgvStatisticsRevenueByCustomer()
        {
            dgvStatisticsRevenue.EnableHeadersVisualStyles = false;
            dgvStatisticsRevenue.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvStatisticsRevenue.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStatisticsRevenue.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvStatisticsRevenue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsRevenue.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvStatisticsRevenue.RowTemplate.Height = 40;

            dgvStatisticsRevenue.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dgvStatisticsRevenue.Columns["HoTenKH"].HeaderText = "Họ tên khách hàng";
            dgvStatisticsRevenue.Columns["SoLuongDonHang"].HeaderText = "Số đơn hàng";
            dgvStatisticsRevenue.Columns["TongTien"].HeaderText = "Doanh thu";

            dgvStatisticsRevenue.Columns["MaKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsRevenue.Columns["HoTenKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStatisticsRevenue.Columns["SoLuongDonHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsRevenue.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void SetColumnWidthsInPercentageDgvStatisticsRevenueByEmployee()
        {
            int totalWidth = dgvStatisticsRevenue.Width;

            dgvStatisticsRevenue.Columns["MaNV"].Width = (int)(0.2 * totalWidth);
            dgvStatisticsRevenue.Columns["HoTenNV"].Width = (int)(0.4 * totalWidth);
            dgvStatisticsRevenue.Columns["SoLuongDonHang"].Width = (int)(0.2 * totalWidth);
            dgvStatisticsRevenue.Columns["TongTien"].Width = (int)(0.2 * totalWidth);

            dgvStatisticsRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void SetColumnWidthsInPercentageDgvStatisticsRevenueByCustomer()
        {
            int totalWidth = dgvStatisticsRevenue.Width;

            dgvStatisticsRevenue.Columns["MaKH"].Width = (int)(0.2 * totalWidth);
            dgvStatisticsRevenue.Columns["HoTenKH"].Width = (int)(0.4 * totalWidth);
            dgvStatisticsRevenue.Columns["SoLuongDonHang"].Width = (int)(0.2 * totalWidth);
            dgvStatisticsRevenue.Columns["TongTien"].Width = (int)(0.2 * totalWidth);

            dgvStatisticsRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        public void LoadStatisticsProduct()
        {
            if (rdoProduct.Checked)
            {
                if (rdoSPTatCa.Checked)
                {
                    dgvStatisticsProduct.DataSource = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuTheoSanPham");
                }
                else
                {
                    dgvStatisticsProduct.DataSource = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuTheoSanPham @tuNgay , @denNgay ", new object[] { dtpDTTuNgay.Value, dtpDTDenNgay.Value });
                }
                CustomizeDgvStatisticsProduct();
                SetColumnWidthsInPercentageDgvStatisticsProduct();
            }
            else
            {
                if (rdoSPTatCa.Checked)
                {
                    dgvStatisticsProduct.DataSource = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuTheoLoaiSanPham");
                }
                else
                {
                    dgvStatisticsProduct.DataSource = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuTheoLoaiSanPham @tuNgay , @denNgay ", new object[] { dtpDTTuNgay.Value, dtpDTDenNgay.Value });
                }
                CustomizeDgvStatisticsProductType();
                SetColumnWidthsInPercentageDgvStatisticsProductType();
            }
        }

        private void CustomizeDgvStatisticsProduct()
        {
            dgvStatisticsProduct.EnableHeadersVisualStyles = false;
            dgvStatisticsProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvStatisticsProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStatisticsProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvStatisticsProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvStatisticsProduct.RowTemplate.Height = 40;

            dgvStatisticsProduct.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgvStatisticsProduct.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvStatisticsProduct.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";
            dgvStatisticsProduct.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvStatisticsProduct.Columns["SoLuongDaBan"].HeaderText = "Số lượng đã bán";
            dgvStatisticsProduct.Columns["TongTien"].HeaderText = "Doanh thu";

            dgvStatisticsProduct.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.Columns["TenLoaiSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.Columns["SoLuongDaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CustomizeDgvStatisticsProductType()
        {
            dgvStatisticsProduct.EnableHeadersVisualStyles = false;
            dgvStatisticsProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvStatisticsProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStatisticsProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvStatisticsProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvStatisticsProduct.RowTemplate.Height = 40;

            dgvStatisticsProduct.Columns["MaLoaiSP"].HeaderText = "Mã loại sản phẩm";
            dgvStatisticsProduct.Columns["TenLoaiSP"].HeaderText = "Tên loại sản phẩm";
            dgvStatisticsProduct.Columns["SoLuongSanPham"].HeaderText = "Số lượng sản phẩm";
            dgvStatisticsProduct.Columns["SoLuongDaBan"].HeaderText = "Số lượng đã bán";
            dgvStatisticsProduct.Columns["TongTien"].HeaderText = "Doanh thu";

            dgvStatisticsProduct.Columns["MaLoaiSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.Columns["TenLoaiSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.Columns["SoLuongSanPham"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.Columns["SoLuongDaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatisticsProduct.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void SetColumnWidthsInPercentageDgvStatisticsProduct()
        {
            int totalWidth = dgvStatisticsProduct.Width;

            dgvStatisticsProduct.Columns["MaSP"].Width = (int)(0.15 * totalWidth);
            dgvStatisticsProduct.Columns["TenSP"].Width = (int)(0.25 * totalWidth);
            dgvStatisticsProduct.Columns["TenLoaiSP"].Width = (int)(0.15 * totalWidth);
            dgvStatisticsProduct.Columns["GiaBan"].Width = (int)(0.15 * totalWidth);
            dgvStatisticsProduct.Columns["SoLuongDaBan"].Width = (int)(0.15 * totalWidth);
            dgvStatisticsProduct.Columns["TongTien"].Width = (int)(0.15 * totalWidth);

            dgvStatisticsProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void SetColumnWidthsInPercentageDgvStatisticsProductType()
        {
            int totalWidth = dgvStatisticsProduct.Width;

            dgvStatisticsProduct.Columns["MaLoaiSP"].Width = (int)(0.15 * totalWidth);
            dgvStatisticsProduct.Columns["TenLoaiSP"].Width = (int)(0.25 * totalWidth);
            dgvStatisticsProduct.Columns["SoLuongSanPham"].Width = (int)(0.2 * totalWidth);
            dgvStatisticsProduct.Columns["SoLuongDaBan"].Width = (int)(0.2 * totalWidth);
            dgvStatisticsProduct.Columns["TongTien"].Width = (int)(0.2 * totalWidth);

            dgvStatisticsProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        public void ExportFileStatisticsByMovie(DataTable dataTable, string sheetName, string title)
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

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã phim";
            cl1.ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên phim";
            cl2.ColumnWidth = 40;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Số suất chiếu";
            cl3.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Tổng số vé";
            cl4.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Số vé bán ra";
            cl5.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Số vé tồn";
            cl6.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Doanh thu";
            cl7.ColumnWidth = 13;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "G3");
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

        public void ExportFileStatisticsByProduct(DataTable dataTable, string sheetName, string title)
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

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã sản phẩm";
            cl1.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên sản phẩm";
            cl2.ColumnWidth = 40;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Số lượng tồn";
            cl3.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Số lượng bán ra";
            cl4.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Doanh thu";
            cl5.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");
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
        private void fStatistic_Load(object sender, EventArgs e)
        {
            LoadStatisticsRevenue();
            LoadStatisticsProduct();
            this.SizeChanged += fStatistic_SizeChanged;
        }

        private void fStatistic_SizeChanged(object sender, EventArgs e)
        {
            if (dgvStatisticsRevenue.Columns.Count > 0)
            {
                if (rdoEmployee.Checked)
                {
                    CustomizeDgvStatisticsRevenueByEmployee();
                    SetColumnWidthsInPercentageDgvStatisticsRevenueByEmployee();
                }
                else
                {
                    CustomizeDgvStatisticsRevenueByCustomer();
                    SetColumnWidthsInPercentageDgvStatisticsRevenueByCustomer();
                }
            }

            if (dgvStatisticsProduct.Columns.Count > 0)
            {
                if (rdoProduct.Checked)
                {
                    CustomizeDgvStatisticsProduct();
                    SetColumnWidthsInPercentageDgvStatisticsProduct();
                }
                else
                {
                    CustomizeDgvStatisticsProductType();
                    SetColumnWidthsInPercentageDgvStatisticsProductType();
                }
            }
        }

        private void rdoDTTatCa_CheckedChanged(object sender, EventArgs e)
        {
            LoadStatisticsRevenue();
        }

        private void rdoDTKhoangThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            LoadStatisticsRevenue();
        }

        private void dtpDTTuNgay_ValueChanged(object sender, EventArgs e)
        {
            rdoDTKhoangThoiGian.Checked = true;
            LoadStatisticsRevenue();
        }

        private void dtpDTDenNgay_ValueChanged(object sender, EventArgs e)
        {
            rdoDTKhoangThoiGian.Checked = true;
            LoadStatisticsRevenue();
        }

        private void rdoEmployee_CheckedChanged(object sender, EventArgs e)
        {
            LoadStatisticsRevenue();
        }

        private void rdoCustomer_CheckedChanged(object sender, EventArgs e)
        {
            LoadStatisticsRevenue();
        }

        private void dgvStatisticsRevenue_DataSourceChanged(object sender, EventArgs e)
        {
            int tongDonHang = 0;
            double tongDoanhThu = 0;
            foreach (DataGridViewRow row in dgvStatisticsRevenue.Rows)
            {
                if (row.Cells["SoLuongDonHang"].Value != null && int.TryParse(row.Cells["SoLuongDonHang"].Value.ToString(), out int donHang))
                {
                    tongDonHang += donHang;
                }
                if (row.Cells["TongTien"].Value != null && int.TryParse(row.Cells["TongTien"].Value.ToString(), out int doanhThu))
                {
                    tongDoanhThu += doanhThu;
                }
            }
            txtTongSoHD.Text = tongDonHang.ToString();
            txtDoanhThu.Text = string.Format("{0:N0} đ", tongDoanhThu);
        }

        private void rdoSPTatCa_CheckedChanged(object sender, EventArgs e)
        {
            LoadStatisticsProduct();
        }

        private void rdoSPKhoangThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            LoadStatisticsProduct();
        }

        private void dtpSPTuNgay_ValueChanged(object sender, EventArgs e)
        {
            rdoSPKhoangThoiGian.Checked = true;
            LoadStatisticsProduct();
        }

        private void dtpSPDenNgay_ValueChanged(object sender, EventArgs e)
        {
            rdoSPKhoangThoiGian.Checked = true;
            LoadStatisticsProduct();
        }

        private void rdoProduct_CheckedChanged(object sender, EventArgs e)
        {
            LoadStatisticsProduct();
        }

        private void rdoProductType_CheckedChanged(object sender, EventArgs e)
        {
            LoadStatisticsProduct();
        }

        private void dgvProduct_DataSourceChanged(object sender, EventArgs e)
        {
            int soLuongDaBan = 0;
            double tongDoanhThu = 0;
            foreach (DataGridViewRow row in dgvStatisticsProduct.Rows)
            {
                if (row.Cells["SoLuongDaBan"].Value != null && int.TryParse(row.Cells["SoLuongDaBan"].Value.ToString(), out int soLuong))
                {
                    soLuongDaBan += soLuong;
                }
                if (row.Cells["TongTien"].Value != null && int.TryParse(row.Cells["TongTien"].Value.ToString(), out int doanhTHu))
                {
                    tongDoanhThu += doanhTHu;
                }
            }
            txtSoLuongDaBan.Text = soLuongDaBan.ToString();
            txtDoanhThuSP.Text = string.Format("{0:N0} đ", tongDoanhThu);
        }

        private void btnDTChart_Click(object sender, EventArgs e)
        {
            fChart f = new fChart();
            if (rdoCustomer.Checked)
            {
                f.DrawRevenueChartCustomer(dgvStatisticsRevenue);
            }
            else
            {
                f.DrawRevenueChartEmployee(dgvStatisticsRevenue);
            }
            f.ShowDialog();
        }

        private void btnDTPrint_Click(object sender, EventArgs e)
        {
            //DataTable dataTable = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuPhim");
            //rptStatisticMovie r = new rptStatisticMovie();
            //r.SetDataSource(dataTable);
            //fReport f = new fReport();
            //f.crvReport.ReportSource = r;
            //f.ShowDialog();
        }

        private void btnDTExport_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("MaPhim");
            DataColumn col2 = new DataColumn("TenPhim");
            DataColumn col3 = new DataColumn("SoSuatChieu");
            DataColumn col4 = new DataColumn("TongSoVe");
            DataColumn col5 = new DataColumn("SoVeBanRa");
            DataColumn col6 = new DataColumn("SoVeTon");
            DataColumn col7 = new DataColumn("DoanhThu");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);

            foreach (DataGridViewRow dgvRow in dgvStatisticsRevenue.Rows)
            {
                DataRow row = dataTable.NewRow();

                row[0] = dgvRow.Cells["MaPhim"].Value;
                row[1] = dgvRow.Cells["TenPhim"].Value;
                row[2] = dgvRow.Cells["SoSuatChieu"].Value;
                row[3] = dgvRow.Cells["TongSoVe"].Value;
                row[4] = dgvRow.Cells["SoVeBanRa"].Value;
                row[5] = dgvRow.Cells["SoVeTon"].Value;
                row[6] = dgvRow.Cells["DoanhThu"].Value;

                dataTable.Rows.Add(row);
            }

            ExportFileStatisticsByMovie(dataTable, "Doanh thu", "THỐNG KÊ DOANH THU THEO PHIM");
        }

        private void btnSPChart_Click(object sender, EventArgs e)
        {
            fChart f = new fChart();
            if (rdoProduct.Checked)
            {
                f.DrawRevenueChartProduct(dgvStatisticsProduct);
            }
            else
            {
                f.DrawRevenueChartProductType(dgvStatisticsProduct);
            }
            f.ShowDialog();
        }

        private void btnSPPrint_Click(object sender, EventArgs e)
        {
            //DataTable dataTable = DataProvider.Instance.ExecuteQuery("EXEC spThongKeDoanhThuSanPham");
            //rptStatisticProduct r = new rptStatisticProduct();
            //r.SetDataSource(dataTable);
            //fReport f = new fReport();
            //f.crvReport.ReportSource = r;
            //f.ShowDialog();
        }

        private void btnSPExport_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("MaSP");
            DataColumn col2 = new DataColumn("TenSP");
            DataColumn col3 = new DataColumn("SoLuongTon");
            DataColumn col4 = new DataColumn("SoLuongDaBan");
            DataColumn col5 = new DataColumn("DoanhThu");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);

            foreach (DataGridViewRow dgvRow in dgvStatisticsProduct.Rows)
            {
                DataRow row = dataTable.NewRow();

                row[0] = dgvRow.Cells["MaSP"].Value;
                row[1] = dgvRow.Cells["TenSP"].Value;
                row[2] = dgvRow.Cells["SoLuongTon"].Value;
                row[3] = dgvRow.Cells["SoLuongDaBan"].Value;
                row[4] = dgvRow.Cells["DoanhThu"].Value;

                dataTable.Rows.Add(row);
            }

            ExportFileStatisticsByProduct(dataTable, "Doanh thu", "THỐNG KÊ DOANH THU THEO SẢN PHẨM");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                fStatistic_SizeChanged(sender, e);
            }
        }
        #endregion
    }
}
