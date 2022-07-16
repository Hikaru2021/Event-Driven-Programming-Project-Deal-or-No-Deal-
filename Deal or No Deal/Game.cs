using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Deal_or_No_Deal
{
    public partial class Game : Form
    {
        long[] scoreLists = new long[20] {5,10,15,25,100,500,1000,5000,10000,25000,50000,75000,100000,200000,500000,750000,1000000,1500000,2000000,3000000};
        long[] buttonLists = new long[20];
        long[] offer = new long[20] { 5, 10, 15, 25, 100, 500, 1000, 5000, 10000, 25000, 50000, 75000, 100000, 200000, 500000, 750000, 1000000, 1500000, 2000000, 3000000};
        int[] tempList = new int[20];
        long finalValue;
        bool[] buttonFlag = new bool[20];
        long newOffer;
        bool accept = false;
        int offerCounter = 0;
        int offerRemainder;
        string tempLabel;
        Random random = new Random();
        public Game()
        {
            int temp;

            for(int i = 0; i < 20; i++)
            {
                buttonFlag[i] = false;
            }

            for(int i = 0; i < 20; i++)
            {
                tempList[i] = 30;
            }

            for(int i = 0; i < 20; i++)
            {
                temp = random.Next(20);

                while(Used(temp))
                {
                    temp = random.Next(20);
                }

                buttonLists[i] = scoreLists[temp];
                tempList[i] = temp;
            }

            
            InitializeComponent();
        }

        private bool Used(int temp)
        {
            bool flag = false;

            for(int i = 0; i < 20; i++)
            {
                if(tempList[i] == temp)
                {
                    flag = true;
                }
            }

            return flag;
        }

        private void GenerateNewOffer()
        {
            long sum = 0;
            long avg;

            for(int i = 0; i < 20; i++)
            {
                sum += offer[i];
            }

            avg = sum / (20 - offerCounter);
            newOffer = avg;
        }

        private void CallZero(string tempLabel)
        {
            long val = Convert.ToInt64(tempLabel);

            for(int i = 0; i < 20; i++)
            {
                if(offer[i] == val)
                {
                    offer[i] = 0;
                }
            }
        }

        private long getFinalValue()
        {
            for(int i = 0; i < 20; i++)
            {
                if(offer[i] != 0)
                {
                    finalValue = offer[i];
                }
            }

            return finalValue;
        }

        private void checker(string n)
        {
            if (n == "5")
            {
                amt5.BackColor = Color.LightGray;
            }

            else if (n == "10")
            {
                amt10.BackColor = Color.LightGray;
            }

            else if (n == "15")
            {
                amt15.BackColor = Color.LightGray;
            }

            else if (n == "25")
            {
                amt25.BackColor = Color.LightGray;
            }

            else if (n == "100")
            {
                amt100.BackColor = Color.LightGray;
            }

            else if (n == "500")
            {
                amt500.BackColor = Color.LightGray;
            }

            else if (n == "1000")
            {
                amt1k.BackColor = Color.LightGray;
            }

            else if (n == "5000")
            {
                amt5k.BackColor = Color.LightGray;
            }

            else if (n == "10000")
            {
                amt10k.BackColor = Color.LightGray;
            }

            else if (n == "25000")
            {
                amt25k.BackColor = Color.LightGray;
            }

           else if (n == "50000")
            {
                amt50k.BackColor = Color.LightGray;
            }

            else if (n == "75000")
            {
                amt75k.BackColor = Color.LightGray;
            }

            else if (n == "100000")
            {
                amt100k.BackColor = Color.LightGray;
            }

            else if (n == "200000")
            {
                amt200k.BackColor = Color.LightGray;
            }

            else if (n == "500000")
            {
                amt500k.BackColor = Color.LightGray;
            }

            else if (n == "750000")
            {
                amt750k.BackColor = Color.LightGray;
            }

            else if (n == "1000000")
            {
                amt1M.BackColor = Color.LightGray;
            }

            else if (n == "1500000")
            {
                amt15M.BackColor = Color.LightGray;
            }

            else if (n == "2000000")
            {
                amt2M.BackColor = Color.LightGray;
            }

            else
            {
                amt3M.BackColor = Color.LightGray;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (buttonFlag[4])
            {
                return;
            }

            buttonFlag[4] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[4].ToString();
            button5.Text = tempLabel;
            button5.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open "+ offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (buttonFlag[6])
            {
                return;
            }

            buttonFlag[6] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[6].ToString();
            button7.Text = tempLabel;

            button7.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (buttonFlag[9])
            {
                return;
            }

            buttonFlag[9] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[9].ToString();
            button10.Text = tempLabel;

            button10.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (buttonFlag[13])
            {
                return;
            }

            buttonFlag[13] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[13].ToString();
            button14.Text = tempLabel;

            button14.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (buttonFlag[14])
            {
                return;
            }

            buttonFlag[14] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[14].ToString();
            button15.Text = tempLabel;

            button15.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                finalValue = getFinalValue();
                MessageBox.Show("Game is over. You won" + finalValue.ToString());
                accept = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(button1, true);
            ControlExtension.Draggable(button2, true);
            ControlExtension.Draggable(button3, true);
            ControlExtension.Draggable(button4, true);
            ControlExtension.Draggable(button5, true);
            ControlExtension.Draggable(button6, true);
            ControlExtension.Draggable(button7, true);
            ControlExtension.Draggable(button8, true);
            ControlExtension.Draggable(button9, true);
            ControlExtension.Draggable(button10, true);
            ControlExtension.Draggable(button11, true);
            ControlExtension.Draggable(button12, true);
            ControlExtension.Draggable(button13, true);
            ControlExtension.Draggable(button14, true);
            ControlExtension.Draggable(button15, true);
            ControlExtension.Draggable(button16, true);
            ControlExtension.Draggable(button17, true);
            ControlExtension.Draggable(button18, true);
            ControlExtension.Draggable(button19, true);
            ControlExtension.Draggable(button20, true);
            textBox1.Visible = false;
            youWon.Visible = false;
            youWon.Parent = pictureBox1;
            youWon.BackColor = Color.Transparent;
            restart.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(buttonFlag[0])
            {
                return;
            }

            buttonFlag[0] = true;

            if(accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[0].ToString();
            button1.Text = tempLabel;

            button1.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                finalValue = getFinalValue();
                MessageBox.Show("Game is over. You won" + finalValue.ToString());
                accept = true;
            }

            else
            {
                if((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();
                    
                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (buttonFlag[1])
            {
                return;
            }

            buttonFlag[1] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[1].ToString();
            button2.Text = tempLabel;

            button2.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                finalValue = getFinalValue();
                MessageBox.Show("Game is over. You won" + finalValue.ToString());
                accept = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (buttonFlag[2])
            {
                return;
            }

            buttonFlag[2] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[2].ToString();
            button3.Text = tempLabel;

            button3.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                finalValue = getFinalValue();
                MessageBox.Show("Game is over. You won" + finalValue.ToString());
                accept = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (buttonFlag[3])
            {
                return;
            }

            buttonFlag[3] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[3].ToString();
            button4.Text = tempLabel;

            button4.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                finalValue = getFinalValue();
                MessageBox.Show("Game is over. You won" + finalValue.ToString());
                accept = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (buttonFlag[5])
            {
                return;
            }

            buttonFlag[5] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[5].ToString();
            button6.Text = tempLabel;

            button6.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (buttonFlag[7])
            {
                return;
            }

            buttonFlag[7] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[7].ToString();
            button8.Text = tempLabel;

            button8.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (buttonFlag[8])
            {
                return;
            }

            buttonFlag[8] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[8].ToString();
            button9.Text = tempLabel;

            button9.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (buttonFlag[12])
            {
                return;
            }

            buttonFlag[12] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[12].ToString();
            button13.Text = tempLabel;

            button13.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (buttonFlag[11])
            {
                return;
            }

            buttonFlag[11] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[11].ToString();
            button12.Text = tempLabel;

            button12.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (buttonFlag[10])
            {
                return;
            }

            buttonFlag[10] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[10].ToString();
            button11.Text = tempLabel;

            button11.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (buttonFlag[15])
            {
                return;
            }

            buttonFlag[15] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[15].ToString();
            button16.Text = tempLabel;

            button16.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true; 
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer "+ newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (buttonFlag[16])
            {
                return;
            }

            buttonFlag[16] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[16].ToString();
            button17.Text = tempLabel;

            button17.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer " + newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (buttonFlag[17])
            {
                return;
            }

            buttonFlag[17] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[17].ToString();
            button18.Text = tempLabel;

            button18.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer " + newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (buttonFlag[18])
            {
                return;
            }

            buttonFlag[18] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[18].ToString();
            button19.Text = tempLabel;

            button19.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront();
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer " + newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (buttonFlag[19])
            {
                return;
            }

            buttonFlag[19] = true;

            if (accept)
            {
                return;
            }

            offerCounter++;

            tempLabel = buttonLists[19].ToString();
            button20.Text = tempLabel;

            button20.BackColor = Color.DarkGray;
            checker(tempLabel);

            banker.Text = "You opened " + tempLabel + ".";

            CallZero(tempLabel);

            if (offerCounter == 20)
            {
                pictureBox1.BringToFront();
                youWon.BringToFront();
                youWon.Visible = true;
                textBox1.BringToFront();
                textBox1.Visible = true;
                textBox1.Text = tempLabel;
                restart.BringToFront(); 
                restart.Visible = true;
            }

            else
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    MessageBox.Show("You have recieved an offer!");
                    banker.Text = "You have a new offer " + newOffer.ToString();

                }

                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    banker.Text += "Open " + offerRemainder.ToString() + "more briefcase for a new offer.";
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
            youWon.BringToFront();
            youWon.Visible = true;
            textBox1.BringToFront();
            textBox1.Visible = true;
            textBox1.Text = newOffer.ToString();
            restart.BringToFront();
            restart.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void restart_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();
            this.Close();

        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu menu = new MainMenu();
            menu.Show(); 
        }
    }
}
