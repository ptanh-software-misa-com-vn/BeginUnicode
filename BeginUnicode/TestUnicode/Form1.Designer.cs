namespace Anh.TestUnicode
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cboUnicodeRange = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBox1.Location = new System.Drawing.Point(16, 325);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(1159, 230);
			this.textBox1.TabIndex = 1;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(16, 294);
			this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(100, 29);
			this.btnClear.TabIndex = 2;
			this.btnClear.Text = "Clear Text";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(153, 294);
			this.btnDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(100, 29);
			this.btnDel.TabIndex = 3;
			this.btnDel.Text = "X";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Location = new System.Drawing.Point(16, 16);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(921, 270);
			this.panel1.TabIndex = 4;
			// 
			// cboUnicodeRange
			// 
			this.cboUnicodeRange.FormattingEnabled = true;
			this.cboUnicodeRange.Location = new System.Drawing.Point(945, 16);
			this.cboUnicodeRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cboUnicodeRange.Name = "cboUnicodeRange";
			this.cboUnicodeRange.Size = new System.Drawing.Size(220, 23);
			this.cboUnicodeRange.TabIndex = 5;
			this.cboUnicodeRange.SelectedIndexChanged += new System.EventHandler(this.cboUnicodeRange_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1195, 571);
			this.Controls.Add(this.cboUnicodeRange);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.textBox1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ComboBox cboUnicodeRange;
	}
}

