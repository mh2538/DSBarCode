using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data;

namespace TestCtrl
{
    
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    /// 
    public delegate void del(string s);
	public class FrmMain : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button1;
        private TextBox textBox1;
        private Button Generate;
        private Button button2;
        private PropertyGrid propertyGrid1;
        private Button bNew;
        private OracleConnection Cnt = new OracleConnection();
        private OracleCommand Cmd = new OracleCommand();
        private OracleDataAdapter Da = new OracleDataAdapter();
        private DataSet DS = new DataSet();
        private DSBarCode.BarCodeCtrl barCodeCtrl1;
        private System.ComponentModel.Container components = null;

        //[Editor(
        //"System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        //"System.Drawing.Design.UITypeEditor,System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        //)]
        
		public FrmMain()
		{
			InitializeComponent();

            
            /*Cnt.ConnectionString = "Data Source=priprctl;User ID=;Password=";
            Cmd.Connection = Cnt;
            Da.SelectCommand = Cmd;
            //Sample Query
            Cmd.CommandText = "Select * From Defect Where AreaCode=15  and DefectDesc Like '%rightside%' Order By AreaCode ,DefectCode";
            Cnt.Open();
            Da.Fill(DS);
            barCodeCtrl1.BarCodes.Clear();
            barCodeCtrl1.HeadersText.Clear();
            foreach (DataRow DR in DS.Tables[0].Rows)
            {
                barCodeCtrl1.BarCodes.Add(DR["DefectCode"].ToString());
                barCodeCtrl1.HeadersText.Add(DR["DefectDesc"].ToString());
                //barCodeCtrl1..Add(DR["DefectDesc"].ToString());
            }*/
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bNew = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.barCodeCtrl1 = new DSBarCode.BarCodeCtrl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Print";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(789, 507);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Generate
            // 
            this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Generate.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Generate.Location = new System.Drawing.Point(708, 505);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(75, 23);
            this.Generate.TabIndex = 4;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = false;
            this.Generate.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(92, 504);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bNew
            // 
            this.bNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bNew.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bNew.Location = new System.Drawing.Point(627, 504);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 23);
            this.bNew.TabIndex = 10;
            this.bNew.Text = "New";
            this.bNew.UseVisualStyleBackColor = false;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(669, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.barCodeCtrl1;
            this.propertyGrid1.Size = new System.Drawing.Size(220, 482);
            this.propertyGrid1.TabIndex = 9;
            // 
            // barCodeCtrl1
            // 
            this.barCodeCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barCodeCtrl1.BackColor = System.Drawing.Color.White;
            this.barCodeCtrl1.BarCodeHeight = 50;
            this.barCodeCtrl1.BarCodes = ((System.Collections.Specialized.StringCollection)(resources.GetObject("barCodeCtrl1.BarCodes")));
            this.barCodeCtrl1.ColumnCount = 2;
            this.barCodeCtrl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barCodeCtrl1.FooterFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barCodeCtrl1.HeaderFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barCodeCtrl1.HeadersText = ((System.Collections.Specialized.StringCollection)(resources.GetObject("barCodeCtrl1.HeadersText")));
            this.barCodeCtrl1.HeaderText = "BarCode Generator";
            this.barCodeCtrl1.HorizontalGap = 300;
            this.barCodeCtrl1.LeftMargin = 10;
            this.barCodeCtrl1.Location = new System.Drawing.Point(12, 12);
            this.barCodeCtrl1.Name = "barCodeCtrl1";
            this.barCodeCtrl1.ShowFooter = true;
            this.barCodeCtrl1.ShowHeader = true;
            this.barCodeCtrl1.Size = new System.Drawing.Size(651, 482);
            this.barCodeCtrl1.TabIndex = 14;
            this.barCodeCtrl1.TopMargin = 10;
            this.barCodeCtrl1.UseSameHeader = false;
            this.barCodeCtrl1.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Left;
            this.barCodeCtrl1.VerticalGap = 120;
            this.barCodeCtrl1.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small;
            // 
            // FrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(901, 539);
            this.Controls.Add(this.barCodeCtrl1);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmMain";
            this.Text = "BarCode Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FrmMain());

		}
        
		private void Form1_Load(object sender, System.EventArgs e)
		{
            //barCodeCtrl1.HeaderText = 
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
			this.barCodeCtrl1.Print();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
            barCodeCtrl1.SaveImage("c:\\test.bmp");
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            barCodeCtrl1.BarCodes.Add(textBox1.Text);

        }
        private void msg1(string msgs)
        {
            MessageBox.Show(msgs + " 1");
        }
        private void msg2(string msgs)
        {
            MessageBox.Show(msgs + " 2");
        }
        private void msg3(string msgs)
        {
            MessageBox.Show(msgs + " 3");
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            barCodeCtrl1.BarCodes.Clear();
        }

        private void barCodeCtrl1_Load(object sender, EventArgs e)
        {

        }
	}
}
