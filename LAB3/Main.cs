using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class Main : Form
    {
        private Dictionary<string, MyLinkedList> Data;
        private Dictionary<string, MyLinkedList> AllLongestBatteryLife;
        private MyLinkedList AllLongestBatteryLife1;
        private MyLinkedList AllLongestBatteryLife2;
        private int X;
        private int Y;
        private double D;
        private string W;

        public Main()
        {
            InitializeComponent();
            ToggleControls();
            

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 'OK' button is clicked (Browse for folder)
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                
                {
                    Data = IOUtils.Read(folderBrowserDialog1.SelectedPath);
                    if (Data.Count != 0)
                    {
                        ToggleControls(true);
                        Display("Initial data", Data);
                        
                    }
                    
                }
                
            }
        }

        private void task1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllLongestBatteryLife = TaskUtils.FindAllLongestBatteryLife(Data);
            Display1("Task1: the totsl length of routes in each City", AllLongestBatteryLife);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void task2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Trim() == "") || (textBox2.Text.Trim() == ""))
            {
                MessageBox.Show("Please enter the values"); }
            else
                {
                    X = Convert.ToInt32(textBox1.Text);
                    Y = Convert.ToInt32(textBox2.Text);
                    // Validation: check if X is range [0;10]
                    if ((X >= 0 && X <= 10000) && (Y >= 0 && Y <= 10000))
                    {
                    AllLongestBatteryLife1 = TaskUtils.Task2(Data,X,Y);
                    if (AllLongestBatteryLife1.Count > 0)
                    {
                        Display2("Task2-a: creation of a result container", AllLongestBatteryLife1);

                        AllLongestBatteryLife1.Sort();
                        Display2("Task2-b: Result container sorted", AllLongestBatteryLife1);
                    }
                    else listBox1.Items.Add("the result container is emoty and no objects were found");
                    
                }
                    else { MessageBox.Show("Invalid X or Y value"); }
                }

            }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar);

        }

        private void task3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            W = textBox3.Text;
            AllLongestBatteryLife1.RemoveALL(W);
            if (AllLongestBatteryLife1.Count > 0)
                Display2("Task3:Removing objects from the container", AllLongestBatteryLife1);
            else
                listBox1.Items.Add("all the bojects were removed and the container is empty");
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void task4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((textBox4.Text.Trim() == ""))
            {
                MessageBox.Show("Please enter the value of D more than 60 (minutes)");
            }
            else
            {
                D = Convert.ToDouble(textBox4.Text);
                // Validation: check if X is range [0;10]
                if ((D >60))
                {
                    AllLongestBatteryLife2 = TaskUtils.Task4(AllLongestBatteryLife1,D);
                    if (AllLongestBatteryLife2.Count > 0)
                        Display2("Task4: creation of a new separate container", AllLongestBatteryLife2);
                    else listBox1.Items.Add("the created separate container is empty");

                }
                else { MessageBox.Show("Invalid D value"); }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save your results";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files|*.txt|Word Documents|*.doc";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Filename for result log file
                string FileResults = saveFileDialog1.FileName;
                using (StreamWriter writer = new StreamWriter(FileResults, false,
               Encoding.GetEncoding(1257)))
                {
                    // Save contents from ListBox to a seperate results file
                    foreach (string item in listBox1.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
    
}
