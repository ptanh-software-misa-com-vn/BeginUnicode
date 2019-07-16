using Anh.BeginUnicode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anh.TestUnicode
{
    public partial class Form2 : Form
    {
        #region Field
        bool _RenderButton = true;
        #endregion

        #region Constructor
        public Form2()
        {
            InitializeComponent();
            Task.Factory.StartNew(Initialize2);
        }
        #endregion

        #region Initialize
        private async Task Initialize2()
        {
            UniCodeRange[] array1D = await XmlUnicodeRange.Main();
            BeginInvoke(new Action(() =>
            {
                //cboUnicodeRange.Items.AddRange(array1D.Take(3).ToArray());
                cboUnicodeRange.Items.AddRange(array1D);
                cboUnicodeRange.ValueMember = "Value";
                cboUnicodeRange.DisplayMember = "Name";
            }));
        }
        #endregion

        #region Bussiness
        private async Task<string> UnicodeRangeSelected(UniCodeRange range)
        {
            string fileName = string.Format(@".\{0}.xml", range.Value);
            if (File.Exists(fileName))
            {
                Task<string> t = Task.Run<string>(() =>
                {
                    string source = "";
                    using (FileStream fs = System.IO.File.Open(fileName, System.IO.FileMode.Open))
                    {
                        Byte[] bytes = new Byte[fs.Length];
                        fs.Read(bytes, 0, (int)fs.Length);
                        source = new UnicodeEncoding().GetString(bytes);
                    }
                    return source;
                });
                string res = await t;
                object kk = new object[] { res, range };
                await LoadUniCode(kk);

            }
            else
            {
                string url = range.Href;
                string source = await HtmlSourceCode.Code(url);
                object kk = new object[] { source, range };
                await LoadUniCode(kk);
            }
            return range.Value;
        }
        private async Task LoadUniCode(object obj)
        {
            object[] arObj = obj as object[];
            string source = (string)arObj[0];
            UniCodeRange range = arObj[1] as UniCodeRange;

            string fileName = string.Format(@".\{0}.xml", range.Value);
            UnicodeData[] array1D = null;
            if (!File.Exists(fileName))
            {
                array1D = await XmlUnicodeRegion.Main(source, true);
                if (_RenderButton) BeginInvoke(CreatButtons(array1D));
                await XmlUnicodeRegion.SaveXml(array1D, fileName);
                if (AppSetting.IsOpenFileGegionUnicodeData)
                {
                    System.Diagnostics.Process.Start("notepad++.exe", fileName);
                }
                ;
            }
            else
            {
                array1D = await XmlUnicodeRegion.Main(fileName, false);
                if (_RenderButton) BeginInvoke(CreatButtons(array1D));
            }
        }

        Action CreatButtons(UnicodeData[] array1D)
        {
            var act = new Action(() =>
            {
                this.panel1.Controls.Clear();
                int tabIndex = 0;
                for (int i = 0, j = 0, k = 0; i < 1; i++)
                {
                    for (int l = 0; l < array1D.Length; l++)
                    {
                        UnicodeData d = array1D[l];
                        Button butt = new Button();
                        // 
                        // button
                        // 
                        butt.Location = new System.Drawing.Point(3 + j * 40, 3 + k * 40);
                        butt.Name = "btnClear";
                        butt.Size = new System.Drawing.Size(32, 27);
                        butt.TabIndex = i * 17 + l;
                        butt.Text = d.Name;
                        butt.Tag = d;
                        butt.UseVisualStyleBackColor = true;
                        butt.Click += new System.EventHandler(this.btnUnicode_Click);
                        if (d.IsLeaf && !d.Inactive)
                        {
                            this.toolTip1.SetToolTip(butt, d.Title);
                        }
                        else
                        {
                            butt.Enabled = false;
                        }
                        this.panel1.Controls.Add(butt);
                        j++;
                        if (j == 17)
                        {
                            j = 0;
                            k++;
                        }
                        tabIndex = butt.TabIndex;
                    }
                }
                SetTabIndex(tabIndex, new Control[] { textBox1 });
            });
            return act;
        }

        private void SetTabIndex(int currentTabIndex, Control[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].TabIndex = currentTabIndex + 1 + i;
            }
        }
        private async Task RunAll()
        {
            if (MessageBox.Show("When you click on this button, will display the entire region's Unicode. And it will take some time. Do you want to do it?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<UniCodeRange> liAll = new List<UniCodeRange>();
                List<Task<string>> tasks = new List<Task<string>>();
                for (int i = 0; i < cboUnicodeRange.Items.Count; i++)
                {
                    UniCodeRange range = cboUnicodeRange.Items[i] as UniCodeRange;
                    liAll.Add(cboUnicodeRange.Items[i] as UniCodeRange);

                }
                while (liAll.Count > 0)
                {
                    foreach (var item in liAll.Take(5))
                    {
                        tasks.Add(UnicodeRangeSelected(item));
                    }
                    liAll.RemoveRange(0, Math.Min(5, liAll.Count));
                    Task<string[]> taskFinish = Task.WhenAll<string>(tasks);
                    string[] fileName = await taskFinish;
                    foreach (var item in fileName)
                    {
                        textBox1.AppendText(item + " success" + Environment.NewLine);
                    }
                    //if (taskFinish.Status == TaskStatus.RanToCompletion)
                    //{
                    //}

                }
                BeginInvoke(new Action(() =>
                {
                    cboUnicodeRange.SelectedValue = "cjk-unified-ideographs";
                }));


            }
        }
        #endregion

        #region EVENTS
        #region btnRunAll_Click
        private async void btnRunAll_Click(object sender, EventArgs e)
        {
            _RenderButton = false;
            try
            {
                await RunAll();
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region cboUnicodeRange_SelectedIndexChanged
        private async void cboUnicodeRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RenderButton = true;
            UniCodeRange range = cboUnicodeRange.SelectedItem as UniCodeRange;
            try
            {
                await UnicodeRangeSelected(range);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        #endregion

        #region btnUnicode_Click
        private void btnUnicode_Click(object sender, EventArgs e)
        {
            Button butt = sender as Button;
            UnicodeData d = butt.Tag as UnicodeData;
            //int c = Convert.ToInt32("0x" + d.Code, 16);
            int c = d.DataCode;
            string s = ((char)c).ToString();
            textBox1.AppendText(s);
        }
        #endregion

        #endregion

        private void btnPut_Click(object sender, EventArgs e)
        {
            if (cboUnicodeRange.SelectedValue == null)
            {
                cboUnicodeRange.SelectedValue = "cjk-unified-ideographs";
            }

            StringBuilder sbText = new StringBuilder();
            foreach (var item in this.panel1.Controls)
            {

                Button butt = item as Button;
                if (butt != null && butt.Enabled)
                {
                    UnicodeData d = butt.Tag as UnicodeData;
                    int c = d.DataCode;
                    string s = ((char)c).ToString();
                    sbText.AppendLine(s);
                }
            }
            textBox1.Text = sbText.ToString();
        }
    }
}
