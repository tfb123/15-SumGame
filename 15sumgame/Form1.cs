using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _15sumgame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NewGame();
        }

        int[] FillArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] RandList = new int[10];
        Random rnd = new Random();
        bool num1Checked = false;
        bool num2Checked = false;
        int num1;
        int num2;
        int box1;
        int box2;
        int moves=0;
        Stopwatch watch = new Stopwatch();

        void GenerateRandom()
        {
            int temp;
            bool[] used = new bool[10]; 
            for (int i = 0; i < 9; i++)
            {
                do
                {
                    temp = rnd.Next(1, 10);
                    if (!used[temp])
                    {
                        RandList[i] = temp;
                        used[temp] = true;
                        break;
                    }
                } while (true);
            }
        }

        void NewGame()
        {
            watch.Reset();
            watch.Start();
            timer1.Enabled = true;
            moves = 0;
            lblMovesCount.Text = moves.ToString();
            lblTime.Text = "00:00";
            GenerateRandom();
            btn1.Text = RandList[0].ToString();
            btn2.Text = RandList[1].ToString();
            btn3.Text = RandList[2].ToString();
            btn4.Text = RandList[3].ToString();
            btn5.Text = RandList[4].ToString();
            btn6.Text = RandList[5].ToString();
            btn7.Text = RandList[6].ToString();
            btn8.Text = RandList[7].ToString();
            btn9.Text = RandList[8].ToString();
            CheckSums();
        }

        void CheckSums()
        {
            button1.Text = (Convert.ToInt32(btn1.Text) + Convert.ToInt32(btn2.Text) + Convert.ToInt32(btn3.Text)).ToString();
            button2.Text = (Convert.ToInt32(btn4.Text) + Convert.ToInt32(btn5.Text) + Convert.ToInt32(btn6.Text)).ToString();
            button3.Text = (Convert.ToInt32(btn7.Text) + Convert.ToInt32(btn8.Text) + Convert.ToInt32(btn9.Text)).ToString();
            button4.Text = (Convert.ToInt32(btn1.Text) + Convert.ToInt32(btn4.Text) + Convert.ToInt32(btn7.Text)).ToString();
            button5.Text = (Convert.ToInt32(btn2.Text) + Convert.ToInt32(btn5.Text) + Convert.ToInt32(btn8.Text)).ToString();
            button6.Text = (Convert.ToInt32(btn3.Text) + Convert.ToInt32(btn6.Text) + Convert.ToInt32(btn9.Text)).ToString();

            CheckFor15(button1);
            CheckFor15(button2);
            CheckFor15(button3);
            CheckFor15(button4);
            CheckFor15(button5);
            CheckFor15(button6);
        }

        private void CheckFor15(Button btn)
        {
            if (Convert.ToInt32(btn.Text)== 15)
            {
                btn.BackColor = Color.Green;
            }
            else if(Convert.ToInt32(btn.Text) < 15)
            {
                btn.BackColor = Color.Yellow;
            }
            else 
            {
                btn.BackColor = Color.Red;
            }
        }

        private void ChangeButtons(Button btn, int box)
        {
            //if first btn pressed
            if (num1Checked == false)
            {
                num1Checked = true;
                num1 = Convert.ToInt32(btn.Text);
                box1 = box;
                box2 = 0;
                btn.BackColor = Color.Cornsilk;
                return;
            }
            if (num1Checked && num2 != Convert.ToInt32(btn.Text))
            {
                num2 = Convert.ToInt32(btn.Text);
                box2 = box;
                Swap();
                CheckSums();
                DefaultColors();
                moves++;
                lblMovesCount.Text = moves.ToString();
                CheckWin();
            }
        }

        private void CheckWin()
        {
            if (button1.BackColor == Color.Green &&
                button2.BackColor == Color.Green &&
                button3.BackColor == Color.Green &&
                button4.BackColor == Color.Green &&
                button5.BackColor == Color.Green &&
                button6.BackColor == Color.Green)
            {
                timer1.Enabled = false;
                watch.Stop();
                if (MessageBox.Show("You win. Start new game?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NewGame();
                }
                else
                {
                    Application.Exit();
                }
                
            }
        }

        private void DefaultColors()
        {
            btn1.UseVisualStyleBackColor = true;
            btn2.UseVisualStyleBackColor = true;
            btn3.UseVisualStyleBackColor = true;
            btn4.UseVisualStyleBackColor = true;
            btn5.UseVisualStyleBackColor = true;
            btn6.UseVisualStyleBackColor = true;
            btn7.UseVisualStyleBackColor = true;
            btn8.UseVisualStyleBackColor = true;
            btn9.UseVisualStyleBackColor = true;
        }

        private void Swap()
        {
            RandList[box1 - 1] = num2;
            RandList[box2 - 1] = num1;
            box1 = 0;
            box2 = 0;
            num1 = 0;
            num2 = 0;
            num1Checked = false;
            num2Checked = false;

            btn1.Text = RandList[0].ToString();
            btn2.Text = RandList[1].ToString();
            btn3.Text = RandList[2].ToString();
            btn4.Text = RandList[3].ToString();
            btn5.Text = RandList[4].ToString();
            btn6.Text = RandList[5].ToString();
            btn7.Text = RandList[6].ToString();
            btn8.Text = RandList[7].ToString();
            btn9.Text = RandList[8].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            ChangeButtons(btn1, 1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ChangeButtons(btn2, 2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ChangeButtons(btn3, 3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ChangeButtons(btn4, 4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ChangeButtons(btn5, 5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ChangeButtons(btn6, 6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            ChangeButtons(btn7, 7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            ChangeButtons(btn8, 8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            ChangeButtons(btn9, 9);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string min = watch.Elapsed.Minutes<10?"0"+watch.Elapsed.Minutes : watch.Elapsed.Minutes.ToString();
            string sec = watch.Elapsed.Seconds<10?"0"+watch.Elapsed.Seconds : watch.Elapsed.Seconds.ToString();

            lblTime.Text = $"{min} : {sec} ";
        }
    }
}
