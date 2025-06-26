using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace LAB3
{
    static class IOUtils
    {
        /// <summary>
        /// Reads initial data from folder
        /// </summary>
        /// <param name="folderPath">Path to selected folder</param>
        /// <returns>Associative container (dictionary) of routes
        /// Key: City name
        /// Value:data of routes </returns>
        public static Dictionary<string, MyLinkedList> Read(string folderPath)
        {
            // Associative container to store initial data
            Dictionary<string, MyLinkedList> Data =
            new Dictionary<string, MyLinkedList>();
            // Get Path for selected directory
            DirectoryInfo selectedFolder = new DirectoryInfo(folderPath);
            // Scan files in selected folder
            foreach (FileInfo file in selectedFolder.GetFiles())
            {
                // Returns file path as a string
                string fileName = file.ToString();
                string fullName = file.FullName;
                // Check for .txt files
                // Extract extension for file
                string extension = fileName.Substring(fileName.IndexOf("."));
                extension = extension.ToLower();
                if (extension.Equals(".txt"))
                {
                    // Avoid program crash if selected folder is inappropriate
                    try
                    {
                        // Process each text file
                        using (StreamReader reader = new StreamReader(fullName))
                        {
                            // Extract header fields
                            string[] OwnerHeader = reader.ReadLine().Split(';');
                            string ownerName = OwnerHeader[0];
                            string mLine;
                            MyLinkedList ElectronicDevices = new MyLinkedList();
                            while ((mLine = reader.ReadLine()) != null)
                            {
                                string[] parts = mLine.Split(';');
                                int routenumber = Convert.ToInt32(parts[0]);
                                string routename = parts[1];
                                double length = Convert.ToDouble(parts[2]);
                                int stops = Convert.ToInt32(parts[3]);
                                TimeSpan start = TimeSpan.Parse(parts[4]); // Corrected conversion
                                TimeSpan end = TimeSpan.Parse(parts[5]); // Corrected conversion
                                Route ED =
                                new Route(routenumber, routename, length, stops, start, end);
                                // Avoid duplicates
                                if (!ElectronicDevices.Contains(ED))
                                    // ElectronicDevices.AddToFront(ED);
                                    ElectronicDevices.AddToEnd(ED);
                            }
                            // Add read contents to dictionary
                            // Key: name of owner
                            // Value: data of electronic devices
                            // Avoid possible key duplicates
                            if (!Data.ContainsKey(ownerName))
                            {
                                Data.Add(ownerName, ElectronicDevices);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw; // Rethrow exception (handled in method call)
                    }
                }
            }
            return Data;
        }


    }
}
