using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compute;

namespace Calculate
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                
        
        private void One_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "1";
        }

        private void Two_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "2";
        }

        private void Three_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "3";
        }

        private void Four_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "4";            
        }

        private void Five_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "5";
        }

        private void Six_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "6";
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "7";
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "8";
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "9";
        }

        private void Comma_Click(object sender, EventArgs e)
        {
            int lenght = Result_Window.Text.Length;
            if (lenght != 0 && Result_Window.Text[lenght - 1] >= '0' && Result_Window.Text[lenght - 1] <= '9')
            {
                int indComma = Result_Window.Text.LastIndexOf(',');
                int indSpace = Result_Window.Text.LastIndexOf(' ');
                if (indComma <= indSpace)
                {
                    Result_Window.Text = Result_Window.Text + ",";
                }
                
            }            
        }

        private void Minus_Click(object sender, EventArgs e)
        {            
            int lenght = Result_Window.Text.Length;
            if (lenght != 0 && Result_Window.Text[lenght - 1] != ' ' && Result_Window.Text[lenght - 1] != ',')
            {
                Result_Window.Text += " - ";
            }
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            int lenght = Result_Window.Text.Length;
            if (lenght != 0 && Result_Window.Text[lenght - 1] != ' ' && Result_Window.Text[lenght - 1] != ',')
            {
                Result_Window.Text += " + ";
            }
        }

        private void Multiply_Click(object sender, EventArgs e)
        {            
            int lenght = Result_Window.Text.Length;
            if (lenght != 0 && Result_Window.Text[lenght - 1] != ' ' && Result_Window.Text[lenght - 1] != ',')
            {
                Result_Window.Text += " * ";
            }
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            int lenght = Result_Window.Text.Length;
            if (lenght != 0 && Result_Window.Text[lenght - 1] != ' ' && Result_Window.Text[lenght - 1] != ',')
            {
                Result_Window.Text += " / ";
            }
        }

        private void L_Bracket_Click(object sender, EventArgs e)
        {
            int lenght = Result_Window.Text.Length;
            if (lenght == 0 || Result_Window.Text[lenght - 1] == ' ')
            {
                Result_Window.Text = Result_Window.Text + "( ";
            }
            
        }

        private void R_Bracket_Click(object sender, EventArgs e)
        {
            int lenght = Result_Window.Text.Length;
            if (lenght != 0 && Result_Window.Text[lenght - 1] != ' ' && Result_Window.Text[lenght - 1] != ',')
            {
                int repOpen = lenght - Result_Window.Text.Replace("(","").Length;
                int repClose = lenght - Result_Window.Text.Replace(")", "").Length;
                if (repOpen > repClose)
                {
                    Result_Window.Text = Result_Window.Text + " )";
                }
                
            }
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            Result_Window.Text = Result_Window.Text + "0";
        }

        private void CleanBTN_Click(object sender, EventArgs e)
        {
            Result_Window.Text = "";
        }

        private void Result_Window_TextChanged(object sender, EventArgs e)
        {
            if (Result_Window.Text.Length > 12)
            {
                Result_Window.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            }          
            else
            {
                Result_Window.Font = new Font("Times New Roman", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            }
            
        }

        private void BackspaceBTN_Click(object sender, EventArgs e)
        {
            int lenght = Result_Window.Text.Length;
            if (lenght > 0)
            {
                if (Result_Window.Text[lenght - 1] == ' ')
                {
                    if (Result_Window.Text[lenght - 2] == '(')
                    {
                        Result_Window.Text = Result_Window.Text.Substring(0, lenght - 2);
                    }
                    else
                    {
                        Result_Window.Text = Result_Window.Text.Substring(0, lenght - 3);
                    }
                }
                else
                {
                    if (Result_Window.Text[lenght - 1] == ')')
                    {
                        Result_Window.Text = Result_Window.Text.Substring(0, lenght - 2);
                    }
                    else
                    {
                        Result_Window.Text = Result_Window.Text.Substring(0, lenght - 1);
                    }
                }
            }
            
            
        }

        private void ResultBTN_Click(object sender, EventArgs e)
        {
            int repOpen = Result_Window.Text.Length - Result_Window.Text.Replace("(", "").Length;
            int repClose = Result_Window.Text.Length - Result_Window.Text.Replace(")", "").Length;
            if (repOpen > repClose)
            {
                MessageBox.Show("Количество открытых скобок превышает количество закрытых скобок");
            }
            else 
            { 
                Result_Window.Text = Formula.Calculatetext(Result_Window.Text); 
            }
        }
    }
}
