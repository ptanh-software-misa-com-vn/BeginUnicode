using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeEncodingFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("Encode", typeof(string));
            dt.Columns.Add("CodePage", typeof(string));
            dt.Columns.Add("Desc", typeof(string));

            dt.Rows.Add("Shift-JIS", "932", "Japanese (Shift-JIS) - Codepage 932");
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "CodePage";
            comboBox1.DisplayMember = "Desc";
        }

        private void btnTakeEndCoding_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy chọn một tệp");
                textBox1.Focus();
                return;
            }
            Encoding code = Form1.GetEncoding(textBox1.Text.Trim());
            string codePage = Form1.GetCharset(textBox1.Text.Trim());
            textBox2.Text = code.ToString() + " " + codePage + Environment.NewLine + Form1.GetEncoding1(textBox1.Text.Trim()) + " " + codePage;
            textBox1.Tag = new EndData() { Encoding = code, Encode = code.BodyName, CodePage = codePage, Desc = code.BodyName + " " + codePage };
        }
        private class EndData
        {
            public Encoding Encoding;
            public string Encode;
            public string CodePage;
            public string Desc;
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }

        public static Encoding GetEncoding1(string fileName)
        {
            using (var reader = new StreamReader(fileName, Encoding.ASCII, true))
            {
                reader.Peek(); // you need this!
                var encoding = reader.CurrentEncoding;
                return encoding;
            }
        }

        public static string GetCharset(string fileName)
        {
            using (FileStream fs = File.OpenRead(fileName))
            {
                Ude.CharsetDetector cdet = new Ude.CharsetDetector();
                cdet.Feed(fs);
                cdet.DataEnd();
                if (cdet.Charset != null)
                {
                    return cdet.Charset;
                }
                return "";
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Tag == null)
            {
                MessageBox.Show("Chưa xác định Encoding");
                btnTakeEndCoding.Focus();
                return;
            }
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn Encoding");
                comboBox1.Focus();
                return;
            }
            EndData data = textBox1.Tag as EndData;
            FileInfo FileInfo = new FileInfo(textBox1.Text.Trim());

            int codePageNew = -1;
            Encoding EncodingNew;
            Encoding EncodingOld;
            if (int.TryParse(comboBox1.SelectedValue.ToString(), out codePageNew))
            {
                EncodingNew = Encoding.GetEncoding(codePageNew);
            }
            else
            {
                string codeNew = ((DataRowView)comboBox1.SelectedItem).Row["Encode"].ToString();
                EncodingNew = Encoding.GetEncoding(codeNew);
            }
            if (data.CodePage.Length == 0)
            {
                EncodingOld = data.Encoding;
            }
            else
            {
                EncodingOld = Encoding.GetEncoding(data.CodePage);
            }

            if (EncodingOld.Equals(EncodingNew))
            {
                MessageBox.Show("It is same Encoding");
                return;
            }
            var stringFromFile = "";

            using (var reader = new StreamReader(textBox1.Text.Trim(), EncodingOld))
            {
                stringFromFile = reader.ReadToEnd();
            }

            using (var writer = new StreamWriter(Path.Combine(Application.StartupPath, FileInfo.Name),false, EncodingNew))
            {
                //read only first line
                writer.Write(stringFromFile);
            }
            
            System.Diagnostics.Process.Start(Application.StartupPath);

        }
    }
}
