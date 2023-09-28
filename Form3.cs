using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Windows.Forms;
using System.Net;

namespace Lab41
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;

            try
            {
                // Lấy nội dung HTML từ website
                using (WebClient client = new WebClient())
                {
                    string htmlContent = client.DownloadString(url);

                    // Hiển thị mã nguồn trong MessageBox
                    MessageBox.Show(htmlContent, "Mã nguồn trang web", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;

            try
            {
                // Hiển thị nội dung website trên WebBrowser control
                webBrowser1.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string savePath = Path.Combine(Application.StartupPath, "downloaded.html");

            try
            {
                // Tải xuống và lưu trữ nội dung website vào file HTML
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, savePath);
                }

                MessageBox.Show("Tải xuống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}

