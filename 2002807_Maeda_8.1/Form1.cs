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
        int[] povRates = { 0, 10210, 13690, 17170, 20650, 24130, 27610, 31090, 34570 };

        int familyIndex = 0;
        double averageIncome = 0;
        double income = 0;
        int user = 0;

        int[,] familyData = new int[20, 3];
        const int ID = 0,
            PEOPLE = 1,
            INCOME = 2;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            familyData[familyIndex, ID] = int.Parse(identificationInput.Text);
            familyData[familyIndex, PEOPLE] = int.Parse(sizeInput.Text);
            familyData[familyIndex, INCOME] = int.Parse(incomeInput.Text);
            //restart if 20+ entries have been entered
            familyIndex++;

            if (familyIndex >= 20) familyIndex = 0;
            //average income calculate
            income += double.Parse(incomeInput.Text);
            if (enterDataToolStripMenuItem.CanSelect)
            {
                user++;
            }
            averageIncome = income / user;
        }

        private void report1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //print id number and income with higher than average income
            Font printFont = new Font("Arial", 14);
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);
            float lineHeightFloat = (float)printFont.GetHeight() + 2f;
            float column1Float = e.MarginBounds.Left;
            float yFloat = e.MarginBounds.Top;
            float column3Float = 450f;
            float column2Float = 300f;
            string lineString;
            //title
            lineString = "Houses with higher than average income";
            e.Graphics.DrawString(lineString,
                headingFont,
                Brushes.Black,
                column1Float,
                yFloat);
            yFloat += (lineHeightFloat * 2);

            e.Graphics.DrawString("Average Income: " + averageIncome.ToString("C"),
                headingFont, Brushes.Black, column1Float,
                yFloat);
            yFloat += (lineHeightFloat * 3);

            //id number
            e.Graphics.DrawString("ID Number: ",
                headingFont, Brushes.Black,
                column2Float, yFloat);

            //income
            e.Graphics.DrawString("Income: ",
                headingFont, Brushes.Black, column3Float, yFloat);
            yFloat += (lineHeightFloat * 2);

            for(int index = 0; index <= familyData.GetUpperBound(0); index++)
            {
                if (familyData[index, ID] == 0) break;
                if(familyData[index, INCOME] > averageIncome)
                {
                    e.Graphics.DrawString(familyData[index, ID].ToString(), printFont,
                        Brushes.Black,
                        column3Float, yFloat);

                    e.Graphics.DrawString(familyData[index, INCOME].ToString("C"), printFont,
                        Brushes.Black,
                        column3Float, yFloat);
                    yFloat += (lineHeightFloat * 2);
                }
            }
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font printFont = new Font("Arial", 14);
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);
            float lineHeightFloat = (float)printFont.GetHeight() + 2f;
            float column1Float = e.MarginBounds.Left;
            float yFloat = e.MarginBounds.Top;
            string lineString;
            double percentage = 0,
                poverty = 0;

            for (int index = 0; index <= familyData.GetUpperBound(0); index++)
            {
                if (familyData[index, ID] == 0) break;
                if(familyData[index, PEOPLE] > familyData[index, INCOME])
                {
                    poverty++;
                    percentage = poverty / user;
                }
            }

            lineString = "Percentage of Houses with Below Average Incomes";
            e.Graphics.DrawString(lineString,
                headingFont, Brushes.Black, column1Float,
                yFloat);
            yFloat += (lineHeightFloat * 2);
            e.Graphics.DrawString("Percentage: " + percentage.ToString("P"), headingFont,
                Brushes.Black, column1Float,
                yFloat);
            yFloat += (lineHeightFloat * 3);
        }

        private void report2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument2;
            printPreviewDialog1.ShowDialog();
        }

        private void report3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument3;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font printFont = new Font("Arial", 10);
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);
            float lineHeightFloat = (float)printFont.GetHeight() + 2f;
            float column1Float = e.MarginBounds.Left;
            float yFloat = e.MarginBounds.Top;
            float column2Float = 300f;
            float column3Float = 450f;
            string lineString;

            lineString = "Family Info Report #1";
            e.Graphics.DrawString(lineString,
                headingFont,
                Brushes.Black,
                column1Float, yFloat);
            yFloat += (lineHeightFloat * 2);

            //id number, people, income
            e.Graphics.DrawString("ID Number",
                headingFont,
                Brushes.Black,
                column1Float, yFloat);

            e.Graphics.DrawString("People",
                headingFont,
                Brushes.Black,
                column2Float, yFloat);

            e.Graphics.DrawString("Income", headingFont,
                Brushes.Black,
                column3Float, yFloat);
            yFloat += (lineHeightFloat * 2);

            for(int index = 0; index <= familyData.GetUpperBound(0); index++)
            {
                if (familyData[index, ID] == 0) break;
                {
                    e.Graphics.DrawString(familyData[index, ID].ToString(),
                        headingFont,
                        Brushes.Black,
                        column1Float, yFloat);

                    e.Graphics.DrawString(familyData[index, PEOPLE].ToString(),
                        headingFont,
                        Brushes.Black,
                        column2Float,
                        yFloat);

                    e.Graphics.DrawString(familyData[index, INCOME].ToString("C"),
                        headingFont,
                        Brushes.Black,
                        column3Float,
                        yFloat);
                    yFloat += (lineHeightFloat * 2);
                }
            }
        }

        

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program name - 8.1 Survey \nProgrammed by - Ransom Maeda");
        }
    }
}
