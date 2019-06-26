using Anh.BeginUnicode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anh.TestUnicode
{
	public partial class Form1 : Form
	{
		UnicodeData[][] array2DUnicodeData;
		UniCodeRange[] array1DUniCodeRange;
		Dictionary<string, UnicodeData[]> cacheUniCodeData = new Dictionary<string, UnicodeData[]>(); 
		public Form1()
		{
			InitializeComponent();
			Initialize();
		}
		private void Initialize()
		{
			Task.Factory.StartNew(Initialize2);
			Task.Factory.StartNew(Initialize1);

		}
		private async void Initialize1()
		{
			UnicodeData[][] array2D = await XmlUnicodeTable.Main();
			array2DUnicodeData = array2D;
			UnicodeData[] array1D = array2D[0];
			BeginInvoke(CreatButtons(array1D));
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
						if (d.IsLeaf)
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
				SetTabIndex(tabIndex, new Control[] { btnClear, btnDel, textBox1 });
			});
			return act;
		}
		private async void Initialize2()
		{
			UniCodeRange[] array1D = await XmlUnicodeRange.Main();
			array1DUniCodeRange = array1D;
			BeginInvoke(new Action(() =>
			{
				cboUnicodeRange.Items.AddRange(array1D);
				cboUnicodeRange.ValueMember = "Value";
				cboUnicodeRange.DisplayMember = "Name";
			}));
		}

		private void SetTabIndex(int currentTabIndex, Control[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i].TabIndex = currentTabIndex + 1 + i;
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			UnicodeEncodingExample.Main();
			Console.WriteLine("==================================================");
			Example.Main();

		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
		}

		private void btnDel_Click(object sender, EventArgs e)
		{
			textBox1.Undo();
		}

		private void btnUnicode_Click(object sender, EventArgs e)
		{
			Button butt = sender as Button;
			UnicodeData d = butt.Tag as UnicodeData;
			int c = Convert.ToInt32("0x"+d.Code, 16);
			String s = ((char)c).ToString();
			textBox1.AppendText(s);
		}

		private void cboUnicodeRange_SelectedIndexChanged(object sender, EventArgs e)
		{
			UniCodeRange range = cboUnicodeRange.SelectedItem as UniCodeRange;
			string be = range.CodeBegin;
			string en = range.CodeEnd;
			if (!cacheUniCodeData.ContainsKey(range.DataCode))
			{
				List< UnicodeData> array1D = new List<UnicodeData>();
				bool startFlg = false, endFlg = false; ;
				foreach (var item in array2DUnicodeData)
				{
					if (startFlg && endFlg)
					{
						break;
					}
					if (item.Any(q => q.Code.CompareTo(be) == 0))
					{
						startFlg = true;
					}
					if (startFlg == true)
					{
						if (item.Any(q => q.Code.CompareTo(en) == 0))
						{
							array1D.AddRange(item.Where(q => q.Code.CompareTo(be) >= 0 && q.Code.CompareTo(en) <= 0));
							endFlg = true;
						}
					}
					if (startFlg &&!endFlg)
					{
						array1D.AddRange(item);
					}
				}
				cacheUniCodeData.Add(range.DataCode,array1D.ToArray());
			}
			BeginInvoke(CreatButtons(cacheUniCodeData[range.DataCode]));
		}
	}
}
