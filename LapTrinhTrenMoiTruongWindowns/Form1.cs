using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapTrinhTrenMoiTruongWindowns
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void GetPay()
        {
            // Kiểm tra nếu không có tên khách hàng thì yêu cầu nhập
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khởi tạo tổng tiền là 0
            double total = 0;
            string history = $" Khách hàng: {txtName.Text}\n Dịch vụ đã chọn:";

            // Kiểm tra các dịch vụ đã chọn và tính tổng tiền
            if (chkClean.Checked)
            {
                total += 100000;
                history += "\n- Cạo vôi: 100,000 VND";
            }

            if (chkWhitening.Checked)
            {
                total += 1200000;
                history += "\n- Tẩy trắng: 1,200,000 VND";
            }

            if (chkWhitening.Checked)
            {
                total += 200000;
                history += "\n- Chụp hình răng: 200,000 VND";
            }

            // Tính tiền dựa trên số răng trám
            int soRangTram;
            if (int.TryParse(num1.Text, out soRangTram))
            {
                double costTram = soRangTram * 80000;
                total += costTram;
                history += $"\n- Trám răng ({soRangTram} răng): {costTram:N0} VND";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số răng trám hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xuất tổng tiền ra TextBox txtTotal
            txtTotal.Text = total.ToString("N0"); // Định dạng hiển thị với dấu phân cách hàng nghìn

            // Thêm thông tin vào lịch sử
            history += $"\nTổng cộng: {total:N0} VND";
            lstHistory.Items.Add(history);
        }

        private void txtTotal_Click(object sender, EventArgs e)
        {

        }

        private void bthCalc_Click(object sender, EventArgs e)
        {
            GetPay();
        }
    }
}
