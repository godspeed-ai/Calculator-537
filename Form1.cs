using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        // 全域變數
        float firstNumber, secondNumber; // firstNumber 儲存第一個數字，secondNumber 儲存第二個數字
        int operators = -1; // 記錄選擇哪一種運算符號？0:加、1:減、2:乘、3:除、-1:重新設定

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 添加數字到顯示窗口
        /// </summary>
        /// <param name="_number">要添加的數字字符串</param>
        private void Add_Number(string _number)
        {
            if (txtNumber.Text == "0")
                txtNumber.Text = "";
            txtNumber.Text = txtNumber.Text + _number;
        }

        /// <summary>
        /// 選擇運算符號
        /// </summary>
        /// <param name="_operator">運算符號代碼(0:加、1:減、2:乘、3:除)</param>
        private void Select_Operator(int _operator)
        {
            firstNumber = Convert.ToSingle(txtNumber.Text); // 將輸入文字框轉換成浮點數，存入第一個數字的全域變數
            txtNumber.Text = "0"; // 重新將輸入文字框重新設定為0
            operators = _operator; // 設定運算符號
        }

        /// <summary>
        /// 計算結果
        /// </summary>
        private void Calculate()
        {
            float finalResults = 0f; // 宣告最後計算結果變數
            secondNumber = Convert.ToSingle(txtNumber.Text); // 將輸入文字框轉換成浮點數，存入第二個數字的全域變數

            // 依照四則運算符號的選擇，進行加減乘除
            switch (operators)
            {
                case 0:
                    finalResults = firstNumber + secondNumber;
                    break;
                case 1:
                    finalResults = firstNumber - secondNumber;
                    break;
                case 2:
                    finalResults = firstNumber * secondNumber;
                    break;
                case 3:
                    finalResults = firstNumber / secondNumber;
                    break;
            }

            txtNumber.Text = string.Format("{0:0.##########}", finalResults); // 在輸入文字框中，顯示最後計算結果，並且轉換成格式化的字串內容
            ResetCalculator(); // 重置計算機
        }

        /// <summary>
        /// 重置計算機狀態
        /// </summary>
        private void ResetCalculator()
        {
            firstNumber = 0f;
            secondNumber = 0f;
            operators = -1;
        }

        /// <summary>
        /// 清除當前輸入和所有計算狀態
        /// </summary>
        private void Clear()
        {
            txtNumber.Text = "0";
            ResetCalculator();
        }

        /// <summary>
        /// 添加小數點
        /// </summary>
        private void AddDecimalPoint()
        {
            // 確認輸入文字框中完全沒有小數點
            if (txtNumber.Text.IndexOf(".") == -1)
                txtNumber.Text = txtNumber.Text + ".";
        }

        /// <summary>
        /// 倒退鍵功能 - 刪除最後一個字符
        /// </summary>
        private void Backspace()
        {
            // 如果輸入框不為空且不是一個字符
            if (txtNumber.Text.Length > 1)
            {
                // 刪除最後一個字符
                txtNumber.Text = txtNumber.Text.Substring(0, txtNumber.Text.Length - 1);
            }
            else
            {
                // 如果只有一個字符，則設為0
                txtNumber.Text = "0";
            }
        }

        /// <summary>
        /// 百分比功能 - 將當前數字轉換為百分比值
        /// </summary>
        private void CalculatePercent()
        {
            // 將當前數字轉換為浮點數
            float currentValue = Convert.ToSingle(txtNumber.Text);

            // 計算百分比 (除以100)
            float percentValue = currentValue / 100.0f;

            // 如果已經選擇了運算符號，將百分比值應用於第一個數字
            if (operators != -1)
            {
                switch (operators)
                {
                    case 0: // 加法
                    case 1: // 減法
                        // 加減法中的百分比表示第一個數字的百分比
                        percentValue = firstNumber * (currentValue / 100.0f);
                        break;
                    case 2: // 乘法
                    case 3: // 除法
                        // 乘除法中的百分比就是除以100
                        // percentValue 已經計算好了，不需要額外處理
                        break;
                }
            }

            // 更新顯示
            txtNumber.Text = string.Format("{0:0.##########}", percentValue);
        }

        // 數字按鈕事件處理
        private void btnOne_Click(object sender, EventArgs e)
        {
            Add_Number("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            Add_Number("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            Add_Number("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            Add_Number("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            Add_Number("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            Add_Number("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            Add_Number("7");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            Add_Number("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            Add_Number("9");
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            Add_Number("0");
        }

        private void txtNumber_Click(object sender, EventArgs e)
        {
        }

        // 運算符號按鈕事件處理
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Select_Operator(0); // 選擇「加」號
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Select_Operator(1); // 選擇「減」號
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Select_Operator(2); // 選擇「乘」號
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Select_Operator(3); // 選擇「除」號
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            AddDecimalPoint();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        // 新增的按鈕事件處理
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            Backspace();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            CalculatePercent();
        }
    }
}