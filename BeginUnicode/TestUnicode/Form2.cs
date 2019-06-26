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
		public Form2()
		{
			InitializeComponent();
			Task.Factory.StartNew(Initialize2);
		}

		private async void Initialize2()
		{
			UniCodeRange[] array1D = await XmlUnicodeRange.Main();
			BeginInvoke(new Action(() =>
			{
				cboUnicodeRange.Items.AddRange(array1D);
				cboUnicodeRange.ValueMember = "Value";
				cboUnicodeRange.DisplayMember = "Name";
			}));
		}

		private void cboUnicodeRange_SelectedIndexChanged(object sender, EventArgs e)
		{
			UniCodeRange range = cboUnicodeRange.SelectedItem as UniCodeRange;
			UnicodeRangeSelected(range);
		}

		private void UnicodeRangeSelected(UniCodeRange range)
		{
			string fileName = string.Format(@".\{0}.xml", range.Value);
			if (File.Exists(fileName))
			{
				string source = "";
				using (FileStream fs = System.IO.File.Open(fileName, System.IO.FileMode.Open))
				{
					Byte[] bytes = new Byte[fs.Length];
					fs.Read(bytes, 0, (int)fs.Length);
					source = new UnicodeEncoding().GetString(bytes);
				}
				object kk = new object[] { source, range };
				Task.Factory.StartNew((s) =>
				{
					LoadUniCode(s);
				}, kk);
			}
			else
			{
				string url = range.Href;
				HtmlDocument doc = HtmlSourceCode.Code(url);
				string source = HtmlSourceCode.FindCode(doc);
				object kk = new object[] { source, range };
				Task.Factory.StartNew((s) =>
				{
					LoadUniCode(s);
				}, kk);
			}

		}
		private async void LoadUniCode(object obj)
		{
			object[] arObj = obj as object[];
			string source = (string)arObj[0];
			UniCodeRange range = arObj[1] as UniCodeRange;

			string fileName = string.Format(@".\{0}.xml", range.Value);
			UnicodeData[] array1D = null;
			if (!File.Exists(fileName))
			{

				array1D = await XmlUnicodeRegion.Main(source, true);
				BeginInvoke(CreatButtons(array1D));
				XmlUnicodeRegion.SaveXml(array1D, fileName);
				if (AppSetting.IsOpenFileGegionUnicodeData)
				{
					System.Diagnostics.Process.Start("notepad++.exe", fileName);
				}
				;
			}
			else
			{
				array1D = await XmlUnicodeRegion.Main(fileName, false);
				BeginInvoke(CreatButtons(array1D));
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

		private void btnUnicode_Click(object sender, EventArgs e)
		{
			Button butt = sender as Button;
			UnicodeData d = butt.Tag as UnicodeData;
			int c = Convert.ToInt32("0x" + d.Code, 16);
			String s = ((char)c).ToString();
			textBox1.AppendText(s);
		}

		private void SetTabIndex(int currentTabIndex, Control[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i].TabIndex = currentTabIndex + 1 + i;
			}
		}

		private async void btnRunAll_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("When you click on this button, will display the entire region's Unicode. And it will take some time. Do you want to do it?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				int failed = 0;
				Task[] tasks = new Task[cboUnicodeRange.Items.Count];
				for (int i = 0; i < cboUnicodeRange.Items.Count; i++)
				{
					UniCodeRange range = cboUnicodeRange.Items[i] as UniCodeRange;
					tasks[i] = new Task((p) =>
					{
						try
						{
							UnicodeRangeSelected(p as UniCodeRange);
						}
						catch (Exception)
						{
							Interlocked.Increment(ref failed);
						}
					}, range);
					tasks[i].Start();
				}
				Task taskFinish = Task.WhenAll(tasks);
				try
				{
					await taskFinish;
				}
				catch { }

				if (taskFinish.Status == TaskStatus.RanToCompletion)
					MessageBox.Show("Finished");
				else if (taskFinish.Status == TaskStatus.Faulted)
					Console.WriteLine("{0} region's Unicode failed", failed);
			}
		}

	}
}
