using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALC_DuongCongNhat
{
    //Khai báo liệt kê các phép toán
    public enum Operators
    {
        Add, Sub, Mul, Div
    }
    public partial class Form1 : Form
    {
        public double Result = 0;
        public bool isNewNum = true;
        public Operators Opt = Operators.Add;
        public string hiskq = "";

        public Form1()
        {
            InitializeComponent();
        }

        //hàm nhập các số từ bàn phím
        public void SetNum(string num)
        {
            if (isNewNum)
            {
                lbScreen.Text = num;
                hiskq = num;
                isNewNum = false;
            }
            else if (lbScreen.Text == "0")
            {
                lbScreen.Text = num;
                hiskq = num;
            }
            else
            {
                lbScreen.Text += num;
                hiskq += num;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //hàm xử lí dấu chấm
        private void btn_point_Click(object sender, EventArgs e)
        {
            //kiểm tra xem chuôĩ screen nhập vào  có tồn tại dấu chấm chưa
            if (lbScreen.Text.Contains("."))
            {
                return;
            }
            else
            {
                lbScreen.Text += ".";
            }
        }

        //hàm xóa, reset mọi thứ về ban đầu
        private void btn_C_Click(object sender, EventArgs e)
        {
            Result = 0;
            isNewNum = true;
            Opt = Operators.Add;
            lbScreen.Text = "0";
            lbHistory.Text = "";
            lbOperator.Text = "";
        }

        
        private void operation_click(object sender, EventArgs e)
        {

            double num = double.Parse(hiskq);
            String str = "";
            //xử lí tihs toán với 2 số
            if (!isNewNum)
            {
                if (Opt == Operators.Add)
                    Result += num;
                else if (Opt == Operators.Sub)
                    Result -= num;
                else if (Opt == Operators.Mul)
                    Result *= num;
                else if (Opt == Operators.Div)
                {
                    if (num == 0)
                    {
                        str = "Mẫu !=";
                        Result += num;
                    }
                    else
                    {
                        Result /= num;
                        Result = Math.Round(Result * 1000) / 1000;
                    }
                }
                lbScreen.Text = Result.ToString();
                lbHistory.Text += lbOperator.Text + str + " " + num.ToString() + " ";
                isNewNum = true;
                str = "";
            }
            //xử lí nút toán tử ở ô toán tử cho phép thay dôi phép tính
            Button optButton = (Button)sender;
            if (optButton.Text == "+")
            {
                lbOperator.Text = "+";
                Opt = Operators.Add;
            }
            else if (optButton.Text == "-")
            {
                lbOperator.Text = "-";
                Opt = Operators.Sub;
            }
            else if (optButton.Text == "*")
            {
                lbOperator.Text = "*";
                Opt = Operators.Mul;
            }
            else if (optButton.Text == "/")
            {
                lbOperator.Text = "/";
                Opt = Operators.Div;
            }


        }

        //hàm xử lí kết quả
        private void btn_Result_Click(object sender, EventArgs e)
        {
            double num = double.Parse(hiskq);
            String str = "";

            if (lbOperator.Text == "+")
            {
                Result += num;
            }
            else if (lbOperator.Text == "-")
            {
                Result -= num;
            }
            else if (lbOperator.Text == "*")
            {
                Result *= num;
            }
            else if (lbOperator.Text == "/")
            {
                if (num == 0)
                {
                    str = "Mẫu !=";
                    Result += num ;
                }
                else
                {
                    Result /= num;
                    Result = Math.Round(Result * 1000) / 1000;
                }
               
            }
            lbScreen.Text = Result.ToString();
            lbHistory.Text += lbOperator.Text + str + " " + num.ToString() + " ";
            isNewNum = true;
            str = "";
        }

        //hàm tính phần trăm
        private void btn_percent_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(lbScreen.Text) / Convert.ToDouble(100);
            lbScreen.Text = System.Convert.ToString(a);
            hiskq = lbScreen.Text;
        }

        //hàm backspace
        private void btn_del_Click(object sender, EventArgs e)
        {
            if(lbScreen.Text.Length > 0)
            {
                lbScreen.Text = lbScreen.Text.Remove(lbScreen.Text.Length - 1, 1);
                hiskq = lbScreen.Text;
            }

            if(lbScreen.Text == "")
            {
                lbScreen.Text = "0";
                hiskq = lbScreen.Text;
            }
        }

        //hàm xử lí âm dương
        private void btn_plussub_Click(object sender, EventArgs e)
        {
            Double num = Double.Parse(lbScreen.Text);
            lbScreen.Text = (-num).ToString();
            hiskq = lbScreen.Text;
        }

       
        //Nhập sô 
        private void Numbers_Click(object sender, EventArgs e)
        {
            Button btnNum = (Button)sender;
            SetNum(btnNum.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbHistory_MouseHover(object sender, EventArgs e)
        {

        }
    }
}



