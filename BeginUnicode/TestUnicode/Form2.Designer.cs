namespace Anh.TestUnicode
{
	partial class Form2
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
            this.cboUnicodeRange = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnRunAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboUnicodeRange
            // 
            this.cboUnicodeRange.FormattingEnabled = true;
            this.cboUnicodeRange.Location = new System.Drawing.Point(13, 13);
            this.cboUnicodeRange.Margin = new System.Windows.Forms.Padding(4);
            this.cboUnicodeRange.Name = "cboUnicodeRange";
            this.cboUnicodeRange.Size = new System.Drawing.Size(220, 20);
            this.cboUnicodeRange.TabIndex = 6;
            this.cboUnicodeRange.SelectedIndexChanged += new System.EventHandler(this.cboUnicodeRange_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(13, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 270);
            this.panel1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(12, 345);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(921, 230);
            this.textBox1.TabIndex = 8;
            // 
            // btnRunAll
            // 
            this.btnRunAll.Location = new System.Drawing.Point(253, 11);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(75, 23);
            this.btnRunAll.TabIndex = 9;
            this.btnRunAll.Text = "Run All";
            this.btnRunAll.UseVisualStyleBackColor = true;
            this.btnRunAll.Click += new System.EventHandler(this.btnRunAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(335, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "When you click on this button, will display the entire region\'s Unicode";
            // 
            // btnPut
            // 
            this.btnPut.Location = new System.Drawing.Point(12, 315);
            this.btnPut.Name = "btnPut";
            this.btnPut.Size = new System.Drawing.Size(75, 23);
            this.btnPut.TabIndex = 11;
            this.btnPut.Text = "Put all";
            this.btnPut.UseVisualStyleBackColor = true;
            this.btnPut.Click += new System.EventHandler(this.btnPut_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 617);
            this.Controls.Add(this.btnPut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRunAll);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboUnicodeRange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cboUnicodeRange;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnRunAll;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPut;
    }
}