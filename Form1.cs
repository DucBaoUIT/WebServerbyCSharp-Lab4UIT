using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab41
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string htmlContent = GetWebContent(url);

            // Hiển thị nội dung HTML trên TextBox
            richTextBox1.Text = htmlContent;
        }
        private string GetWebContent(string url)
        {
            try
            {
                // Khởi tạo yêu cầu HTTP
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                // Nhận phản hồi từ máy chủ web
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);

                // Đọc dữ liệu từ phản hồi
                string htmlContent = reader.ReadToEnd();

                // Đóng kết nối
                reader.Close();
                dataStream.Close();
                response.Close();

                return htmlContent;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
