using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace DSBarCode
{
	public class BarCodeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.ComponentModel.Container components = null;
        
		public enum AlignType
		{
			//Left, Center, Right
            Left, Right
		}

        public enum BCType
        {
            Code39, MSI
        }

		public enum BarCodeWeight
		{
			Small = 1, Medium, Large
		}

        private BCType barcodeType = BCType.Code39;
		private AlignType align = AlignType.Left;
		private String code = "1234567890";
        private StringCollection codes = new StringCollection();
        private StringCollection headers = new StringCollection();
		private int leftMargin = 10;
		private int topMargin = 10;
		private int height = 50;
        private int horizontalGap = 300;
        private int verticalGap = 120;
		private bool showHeader = true;
		private bool showFooter = true;
		private String headerText = "BarCode Generator";
		private BarCodeWeight weight = BarCodeWeight.Small;
		private Font headerFont = new Font("Courier", 18);
		private Font footerFont = new Font("Courier", 8);
		//private int iBCCount= 1;
        private int iColumnCount = 2;
        private Boolean SameHeader = true;

        //public BCType BarCodeType
        //{
        //    get { return barcodeType; }
        //    set { barcodeType = value; panel1.Invalidate(); }
        //}
		public AlignType VertAlign
		{
			get { return align; }
			set { align = value; panel1.Invalidate(); }
		}

        public Boolean UseSameHeader
        {
            get { return SameHeader; }
            set { SameHeader = value; panel1.Invalidate(); }
        }
        [Editor(
        "System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        "System.Drawing.Design.UITypeEditor,System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        )]
        public StringCollection BarCodes
        {
            get { panel1.Invalidate(); return codes; }
            set { codes = value; panel1.Invalidate(); }
        }
        /// <summary>
        /// Must be as count as barcodes
        /// </summary>
        [Editor(
        "System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        "System.Drawing.Design.UITypeEditor,System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        )]
        public StringCollection HeadersText
        {
            get { return headers; }
            set { headers = value; panel1.Invalidate(); }
        }

        /// <summary>
        /// Work when UseSameHeader is off
        /// </summary>
        public String HeaderText
		{
			get { return headerText; }
			set { headerText = value; panel1.Invalidate(); }
		}
		public int BarCodeHeight
		{
			get { return height; }
			set { height = value; panel1.Invalidate(); }
		}
        
		public int LeftMargin
		{
			get { return leftMargin; }
			set { leftMargin = value; panel1.Invalidate(); }
		}

		public int TopMargin
		{
			get { return topMargin; }
			set { topMargin = value; panel1.Invalidate(); }
		}

        public int HorizontalGap
        {
            get { return horizontalGap; }
            set { horizontalGap = value; panel1.Invalidate(); }
        }

        public int VerticalGap
        {
            get { return verticalGap; }
            set { verticalGap = value; panel1.Invalidate(); }
        }

        public int ColumnCount
        {
            get { return iColumnCount; }
            set { iColumnCount = value; panel1.Invalidate(); }
        }

		public bool ShowHeader
		{
			get { return showHeader; }
			set { showHeader = value; panel1.Invalidate(); }
		}

		public bool ShowFooter
		{
			get { return showFooter; }
			set { showFooter = value; panel1.Invalidate(); }
		}

		public BarCodeWeight Weight
		{
			get { return weight; }
			set { weight = value; panel1.Invalidate(); }
		}

		public Font HeaderFont
		{
			get { return headerFont; }
			set { headerFont = value; panel1.Invalidate(); }
		}

		public Font FooterFont
		{
			get { return footerFont; }
			set { footerFont = value; panel1.Invalidate(); }
		}

        //public int BarCodeCount
        //{
        //    get { return iBCCount; }
        //    set { iBCCount = value; panel1.Invalidate(); }
        //}
		public BarCodeCtrl()
		{
            InitializeComponent();
            
            this.BackgroundImageChanged += new EventHandler(BarCodeCtrl_BackgroundImageChanged);
            this.BackColor = Color.White;
            this.BackColorChanged += new EventHandler(BarCodeCtrl_BackColorChanged);
		}

        void BarCodeCtrl_BackColorChanged(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255,this.BackColor);
        }

        void BarCodeCtrl_BackgroundImageChanged(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            panel1.BackgroundImage = this.BackgroundImage;
        }

		public void Print()
		{
			PrintDialog pd = new PrintDialog();
			pd.Document = printDocument1;

			if (pd.ShowDialog() == DialogResult.OK)
			{
				pd.Document.Print();
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 240);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // BarCodeCtrl
            // 
            this.Controls.Add(this.panel1);
            this.Name = "BarCodeCtrl";
            this.Size = new System.Drawing.Size(424, 240);
            this.Resize += new System.EventHandler(this.BarCodeCtrl_Resize);
            this.ResumeLayout(false);

		}
		#endregion

		String alphabet39="0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*";
        String[] MSIChar = 
        {
            "0000",
            "0001",
            "0010",
            "0011",
            "0100",
            "0101",
            "0110",
            "0111",
            "1000",
            "1001"
        };
        String[] oddUPCAChar = 
		{
            "0001101",
            "0011001",
            "0010011",
            "0111101",
            "0100011",
            "0110001",
            "0101111",
            "0111011",
            "0110111",
            "0001011"
        };
        String[] evenUPCAChar = 
		{
            "1110010",
            "1100110",
            "1101100",
            "1000010",
            "1011100",
            "1001110",
            "1010000",
            "1000100",
            "1001000",
            "1110100"
        };

		String [] coded39Char = 
		{
            
			/* 0 */ "000110100", 
			/* 1 */ "100100001", 
			/* 2 */ "001100001", 
			/* 3 */ "101100000",
			/* 4 */ "000110001", 
			/* 5 */ "100110000", 
			/* 6 */ "001110000", 
			/* 7 */ "000100101",
			/* 8 */ "100100100", 
			/* 9 */ "001100100", 
			/* A */ "100001001", 
			/* B */ "001001001",
			/* C */ "101001000", 
			/* D */ "000011001", 
			/* E */ "100011000", 
			/* F */ "001011000",
			/* G */ "000001101", 
			/* H */ "100001100", 
			/* I */ "001001100", 
			/* J */ "000011100",
			/* K */ "100000011", 
			/* L */ "001000011", 
			/* M */ "101000010", 
			/* N */ "000010011",
			/* O */ "100010010", 
			/* P */ "001010010", 
			/* Q */ "000000111", 
			/* R */ "100000110",
			/* S */ "001000110", 
			/* T */ "000010110", 
			/* U */ "110000001", 
			/* V */ "011000001",
			/* W */ "111000000", 
			/* X */ "010010001", 
			/* Y */ "110010000", 
			/* Z */ "011010000",
			/* - */ "010000101", 
			/* . */ "110000100", 
			/*' '*/ "011000100",
			/* $ */ "010101000",
			/* / */ "010100010", 
			/* + */ "010001010", 
			/* % */ "000101010", 
			/* * */ "010010100" 
		};



        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (codes != null)
            {
                for (int iCodesIndex = 0; iCodesIndex < codes.Count; iCodesIndex++)
                {

                    int iJustifyIndex = align == AlignType.Left ? 1 : -1;
                    string _code = (string)codes[iCodesIndex].ToUpper();
                    if (barcodeType == BCType.Code39)
                    {
                        String intercharacterGap = "0";
                        String str = '*' + _code.ToUpper() + '*';
                        int strLength = str.Length;

                        if (!SameHeader && headers.Count != codes.Count)
                        {
                            e.Graphics.DrawString("Headres's count and barcodes's count must be equal", Font, Brushes.Red, 10, 10);
                            return;
                        }

                        for (int i = 0; i < _code.Length; i++)
                        {
                            if (alphabet39.IndexOf(_code[i]) == -1 || _code[i] == '*')
                            {
                                e.Graphics.DrawString("INVALID BAR _code TEXT", Font, Brushes.Red, 10, 10);
                                return;
                            }
                        }

                        String en_codedString = "";

                        for (int i = 0; i < strLength; i++)
                        {
                            if (i > 0)
                                en_codedString += intercharacterGap;

                            en_codedString += coded39Char[alphabet39.IndexOf(str[i])];
                        }

                        int en_codedStringLength = en_codedString.Length;
                        int widthOfBar_codeString = 0;
                        double wideToNarrowRatio = 3;


                        if (align != AlignType.Left)
                        {
                            for (int i = 0; i < en_codedStringLength; i++)
                            {
                                if (en_codedString[i] == '1')
                                    widthOfBar_codeString += (int)(wideToNarrowRatio * (int)weight);
                                else
                                    widthOfBar_codeString += (int)weight;
                            }
                        }

                        int x = 0;
                        int wid = 0;
                        int yTop = 0;

                        SizeF hSize = e.Graphics.MeasureString(headerText, headerFont);
                        SizeF fSize = e.Graphics.MeasureString(_code, footerFont);

                        int headerX = 0;
                        int footerX = 0;

                        if (align == AlignType.Left)
                        {
                            x = leftMargin;
                            headerX = leftMargin;
                            footerX = leftMargin;
                        }
                        //else if (align == AlignType.Center)
                        //{
                        //    x = (Width - widthOfBar_codeString) / 2;
                        //    headerX = (Width - (int)hSize.Width) / 2;
                        //    footerX = (Width - (int)fSize.Width) / 2;
                        //}
                        else
                        {
                            x = Width - widthOfBar_codeString - leftMargin;
                            headerX = Width - (int)hSize.Width - leftMargin;
                            footerX = Width - (int)fSize.Width - leftMargin;
                        }

                        if (showHeader)
                        {
                            yTop = (int)hSize.Height + topMargin;
                            if (SameHeader)
                                e.Graphics.DrawString(headerText, headerFont, Brushes.Black, headerX + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex, yTop + (int)(iCodesIndex / iColumnCount) * verticalGap - (int)hSize.Height);
                            else
                                e.Graphics.DrawString(headers[iCodesIndex], headerFont, Brushes.Black, headerX + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex, yTop + (int)(iCodesIndex / iColumnCount) * verticalGap - (int)hSize.Height);
                        }
                        else
                        {
                            yTop = topMargin;
                        }

                        for (int i = 0; i < en_codedStringLength; i++)
                        {
                            if (en_codedString[i] == '1')
                                wid = (int)(wideToNarrowRatio * (int)weight);
                            else
                                wid = (int)weight;

                            //e.Graphics.FillRectangle(i % 2 == 0 ? Brushes.Black : Brushes.White, x, yTop, wid, height);
                            e.Graphics.FillRectangle(i % 2 == 0 ? Brushes.Black : Brushes.White,
                                                    x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex, yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, wid, height);

                            x += wid;
                        }

                        yTop += height;

                        if (showFooter)
                            e.Graphics.DrawString(_code, footerFont, Brushes.Black, footerX + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex, yTop + (int)(iCodesIndex / iColumnCount) * verticalGap);

                    }

                    else if (barcodeType == BCType.MSI)
                    {
                        String strECheckDigit="", strOCheckDigit = "";
                        int OSum, ESum, iCheckDigit, OCheckNumber, ECheckNumber = 0;
                        for (int j = 0; j < _code.Length; j++)
                        {
                            if (j % 2 == 0)
                                strOCheckDigit += _code[j];
                            else
                                strECheckDigit += _code[j];
                        }
                        OCheckNumber = 0;
                        iCheckDigit = Convert.ToInt32(strOCheckDigit);
                        iCheckDigit *= 2;
                        strOCheckDigit = iCheckDigit.ToString();
                        for (int j = 0; j < strOCheckDigit.Length; j++)
                            OCheckNumber += Convert.ToInt16(strOCheckDigit[j].ToString());
                        for (int j = 0; j < strECheckDigit.Length; j++)
                            ECheckNumber += Convert.ToInt16(strECheckDigit[j].ToString());
                        iCheckDigit = OCheckNumber + ECheckNumber;
                        if (((int)(iCheckDigit % 10)) == 0)
                            iCheckDigit = 0;
                        else
                            iCheckDigit -= ((int)(iCheckDigit / 10) + 1) * 10;
                        



                        //String str = _code.ToUpper()+iCheckDigit.ToString();
                        String str = _code.ToUpper();
                        int strLength = str.Length;

                        if (!SameHeader && headers.Count != codes.Count)
                        {
                            e.Graphics.DrawString("Headres's count and barcodes's count must be equal", Font, Brushes.Red, 10, 10);
                            return;
                        }

                        for (int i = 0; i < _code.Length; i++)
                        {
                            if (alphabet39.IndexOf(_code[i]) == -1 || _code[i] == '*')
                            {
                                e.Graphics.DrawString("INVALID BAR _code TEXT", Font, Brushes.Red, 10, 10);
                                return;
                            }
                        }

                        String en_codedString ="";

                        for (int i = 0; i < strLength; i++)
                        {
                            //if (i > 0)
                            //    en_codedString += intercharacterGap;

                            en_codedString += MSIChar[alphabet39.IndexOf(str[i])];
                        }

                        int en_codedStringLength = en_codedString.Length;
                        int widthOfBar_codeString = 0;
                        double wideToNarrowRatio = 3;


                        if (align != AlignType.Left)
                        {
                            for (int i = 0; i < en_codedStringLength; i++)
                            {
                                if (en_codedString[i] == '1')
                                    widthOfBar_codeString += (int)(wideToNarrowRatio * (int)weight);
                                else
                                    widthOfBar_codeString += (int)weight;
                            }
                        }

                        int x = 0;
                        int wid = 0;
                        int yTop = 0;

                        SizeF hSize = e.Graphics.MeasureString(headerText, headerFont);
                        SizeF fSize = e.Graphics.MeasureString(_code, footerFont);

                        int headerX = 0;
                        int footerX = 0;

                        if (align == AlignType.Left)
                        {
                            x = leftMargin;
                            headerX = leftMargin;
                            footerX = leftMargin;
                        }
                        else
                        {
                            x = Width - widthOfBar_codeString - leftMargin;
                            headerX = Width - (int)hSize.Width - leftMargin;
                            footerX = Width - (int)fSize.Width - leftMargin;
                        }

                        if (showHeader)
                        {
                            yTop = (int)hSize.Height + topMargin;
                            if (SameHeader)
                                e.Graphics.DrawString(headerText, headerFont, Brushes.Black, headerX + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex, yTop + (int)(iCodesIndex / iColumnCount) * verticalGap - (int)hSize.Height);
                            else
                                e.Graphics.DrawString(headers[iCodesIndex], headerFont, Brushes.Black, headerX + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex, yTop + (int)(iCodesIndex / iColumnCount) * verticalGap - (int)hSize.Height);
                        }
                        else
                        {
                            yTop = topMargin;
                        }

                        int wide = (int)wideToNarrowRatio * (int)weight;
                        int narrow = (int)weight;

                        e.Graphics.FillRectangle(Brushes.Black,
                                                         x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex,
                                                         yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, wide, height);
                        x += wide;
                        e.Graphics.FillRectangle(Brushes.White,
                                                 x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex,
                                                 yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, narrow, height);
                        x += narrow;

                        for (int i = 0; i < en_codedStringLength; i++)
                        {
                            if (en_codedString[i] == '1')
                            {
                                e.Graphics.FillRectangle(Brushes.Black,
                                                         x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex,
                                                         yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, wide, height);
                                x += wide;
                                e.Graphics.FillRectangle(Brushes.White,
                                                         x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex,
                                                         yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, narrow, height);
                                x += narrow;
                            }
                            else
                            {
                                e.Graphics.FillRectangle(Brushes.Black,
                                                         x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex,
                                                         yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, narrow, height);
                                x += narrow;
                                e.Graphics.FillRectangle(Brushes.White,
                                                         x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex,
                                                         yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, wide, height);
                                x += wide;
                            }
                        }
                        e.Graphics.FillRectangle(Brushes.Black,
                                                 x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex,
                                                 yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, narrow, height);
                        x += narrow;
                        e.Graphics.FillRectangle(Brushes.White,
                                                 x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex,
                                                 yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, wide, height);
                        x += wide;
                        e.Graphics.FillRectangle(Brushes.Black,
                                                 x + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex,
                                                 yTop + (int)(iCodesIndex / iColumnCount) * verticalGap, narrow, height);
                        x += narrow;


                        yTop += height;

                        if (showFooter)
                            e.Graphics.DrawString(_code, footerFont, Brushes.Black, footerX + (iCodesIndex % iColumnCount) * horizontalGap * iJustifyIndex, yTop + (int)(iCodesIndex / iColumnCount) * verticalGap);


                    }
                }
            }
        }

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			panel1_Paint(sender, new PaintEventArgs(e.Graphics, this.ClientRectangle));
		}

		public void SaveImage(String file)
		{
			Bitmap bmp = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			Graphics g = Graphics.FromImage(bmp);
			g.FillRectangle(Brushes.White, 0, 0, Width, Height);

			panel1_Paint(null, new PaintEventArgs(g, this.ClientRectangle));

			bmp.Save(file);
		}

		private void BarCodeCtrl_Resize(object sender, System.EventArgs e)
		{
			panel1.Invalidate();
		}
	}
}
