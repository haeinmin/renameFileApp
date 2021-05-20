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

namespace ChangeNameApp
{
    public partial class Form1 : Form
    {

        static string folderPath = @"C:\\Users\crossent\Documents\RDP 문서\Overview Documents\newFolder\\";
        static string newFolderPath = @"C:\\Users\crossent\Documents\RDP 문서\Overview Documents\\";
        string[] files = Directory.GetFiles(folderPath);
        static string newNameFilePath = @"C:\\Users\crossent\Documents\RDP 문서\Overview Documents\\fileNames.txt";
        string[] names = File.ReadAllLines(newNameFilePath);


        public Form1()
        {
            InitializeComponent();
        }

        private void btnRenameFile_click(object sender, EventArgs e)
        {
            foreach (string file in files)
            {
                foreach (string name in names)
                {
                    FileInfo fi = new FileInfo(file);


                    if (fi.Exists)
                    {
                        string[] tempFileName = file.Split(']');    
                        string[] tempOldFileName = tempFileName[0].Split('[');  //path, MS-xxx...
                        string[] tempNewFileName = name.Split(']'); //[MS-xxx...
                        string newName = name.Replace(':', ' ');

                        if (tempOldFileName[1] == tempNewFileName[0].Substring(1,tempNewFileName[0].Length-1))
                        {
                            try
                            {
                                File.Move(folderPath + "[" + tempOldFileName[1] + "].pdf", newFolderPath + newName + ".pdf");
                            }
                            catch (Exception e1)
                            {
                                Console.WriteLine(e1);
                            }
                        }
                    }
                }
            }
        }
    }
}
