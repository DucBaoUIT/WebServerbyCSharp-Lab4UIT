using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab41
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string filePath = textBox2.Text;

            try
            {
                // Khởi tạo WebClient
                using (WebClient client = new WebClient())
                {
                    // Tải xuống nội dung trang web và lưu thành file
                    client.DownloadFile(url, filePath);

                    // Hiển thị nội dung trang web lên TextBox
                    string htmlContent = File.ReadAllText(filePath);
                    richTextBox1.Text = htmlContent;

                    MessageBox.Show("Tải xuống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
