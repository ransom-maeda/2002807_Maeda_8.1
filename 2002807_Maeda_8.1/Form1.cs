using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2002807_Maeda_8._1
{
    public partial class Form1 : Form
    {
        int familySize,
            income;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            if(familySize == 1)
            {
                income = 10210;
            }
            else if(familySize == 2)
            {
                income = 13690;
            }
            else if (familySize == 3)
            {
                income = 17170;
            }
            else if (familySize == 4)
            {
                income = 20650;
            }
            else if (familySize == 5)
            {
                income = 24130;
            }
            else if (familySize == 6)
            {
                income = 27610;
            }
            else if (familySize == 7)
            {
                income = 31090;
            }
            else if (familySize == 8)
            {
                income = 34570;
            }
            else if(familySize > 8)
            {
                income = 34570;
                income += 3480;
            }
        }

        private void enterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font printFont = new Font("Arial", 10);
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);
            float verticalPrintPositionFloat = e.MarginBounds.Top;
            float horizontalPrintPositionFloat = e.MarginBounds.Left;
            float lineHeightFloat = printFont.GetHeight();

            e.Graphics.DrawString("ID Number ", headingFont, Brushes.Black, horizontalPrintPositionFloat, verticalPrintPositionFloat);
            verticalPrintPositionFloat += 2 * lineHeightFloat;

            for(int indexInteger = 0; indexInteger < familySize; indexInteger++)
            {
                e.Graphics.DrawString(familySize.ToString(), printFont, Brushes.Black, horizontalPrintPositionFloat, verticalPrintPositionFloat);
                verticalPrintPositionFloat += lineHeightFloat;
            }
        }

        

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program name - 8.1 Survey \nProgrammed by - Ransom Maeda");
        }
    }
}
