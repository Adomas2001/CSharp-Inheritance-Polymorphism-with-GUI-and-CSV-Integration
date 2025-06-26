using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class Main : Form
    {
        /// <summary>
        /// Disable (enable) text input, Save menu and menu items for task execution
        /// </summary>
        public void ToggleControls(bool enabled = false)
        {
            saveToolStripMenuItem.Enabled = enabled;
            task1ToolStripMenuItem.Enabled = enabled;
            task2ToolStripMenuItem.Enabled = enabled;
            task3ToolStripMenuItem.Enabled = enabled;
            task4ToolStripMenuItem.Enabled = enabled;
            listBox1.Items.Clear();
            //// Sets folder browse path to root of solution configuration (e.g. Debug)
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
        }
        /// <summary>
        /// Writes contents of initial data to ListBox
        /// </summary>
        /// <param name="header">Note (label) above table</param>
        /// <param name="Data">Associative container of initial data</param>
        public void Display(string header, Dictionary<string, MyLinkedList> Data)
        {
            listBox1.Items.Add(header);
            // Navigation in associative container of initial data
            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                // Extract keys i.e. name of owner as table headers
                string owner = pair.Key;
                listBox1.Items.Add(new string('-', 25));
                string headerFormat = string.Format("| {0,-8} |", owner);
                listBox1.Items.Add(headerFormat);
                listBox1.Items.Add(new string('-', 25));
                // Extract values (electronic devices)
                MyLinkedList ED = pair.Value;
                listBox1.Items.Add(new string('-', 150));
                listBox1.Items.Add(" Number           Name     Length      stops    start              end");
                listBox1.Items.Add(new string('-', 150));
                for (ED.Start(); ED.Exists(); ED.Next())
                {
                    Route ed = ED.GetData();
                    listBox1.Items.Add(ed.ToString());
                }
                listBox1.Items.Add(new string('-', 150));
                string numElements = string.Format("Number of routes: {0}",
                ED.Count);
                listBox1.Items.Add(numElements);
            }
            listBox1.Items.Add("\n");
        }
        /// <summary>
        /// Writes contents of initial data to ListBox
        /// </summary>
        /// <param name="header">Note (label) above table</param>
        /// <param name="Data">Associative container of initial data</param>
        public void Display1(string header, Dictionary<string, MyLinkedList> Data)
        {
            listBox1.Items.Add(header);
            // Navigation in associative container of initial data
            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                // Extract keys i.e. name of owner as table headers
                string owner = pair.Key;
                //listBox1.Items.Add(new string('-', 25));
                string headerFormat = string.Format("total length of all routes in: {0,-8} ", owner);
                listBox1.Items.Add(headerFormat);
                //listBox1.Items.Add(new string('-', 25));
                // Extract values (electronic devices)
                MyLinkedList ED = pair.Value;
                listBox1.Items.Add(new string('-', 150));
                
                listBox1.Items.Add("Length");
                listBox1.Items.Add(new string('-', 150));
                for (ED.Start(); ED.Exists(); ED.Next())
                {
                    Route ed = ED.GetData();
                    string headerFormat1 = string.Format("{0,4:f} ", ed.Length);
                    listBox1.Items.Add(headerFormat1);
                }
                listBox1.Items.Add(new string('-', 150));
                
            }
            listBox1.Items.Add("\n");
        }
        /// <summary>
        /// Writes contents of initial data to ListBox
        /// </summary>
        /// <param name="header">Note (label) above table</param>
        /// <param name="Data">Associative container of initial data</param>
        public void Display2(string header, MyLinkedList Data)
        {
            listBox1.Items.Add(header);
            listBox1.Items.Add(new string('-', 150));
            listBox1.Items.Add(" Number           Name     Length      stops    start                end");
            listBox1.Items.Add(new string('-', 150));
            // Navigation in associative container of initial data
            for(Data.Start();Data.Exists();Data.Next())
            {
                
                
               
                    Route ed = Data.GetData();
                    listBox1.Items.Add(ed.ToString());
                
                
                
            }
            listBox1.Items.Add(new string('-', 150));
            listBox1.Items.Add("\n");
        }



    }
}
