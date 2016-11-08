using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Client
{
    class CFile
    {
        private static CFile fileInstance = new CFile();

        private  CFile(){}

        public static CFile GetInstance
        {
            get
            {
                return fileInstance;
            }
        }

        private string selectedFilePath = "";
        private string selectedFileName = "";
        private string selectedFileText = "";

        private void readFile()
        {
            if (selectedFilePath != "")
            {
                string text = "";
                using (FileStream stream = File.Open(selectedFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader reader = new StreamReader(stream))
                    while (!reader.EndOfStream)
                        text += reader.ReadLine() + '\n';

                selectedFileText = text;
            }
        }

        public void setFile(string selectedFilePath)
        {
            this.selectedFilePath = selectedFilePath;
            this.selectedFileName = Path.GetFileName(selectedFilePath);

            readFile();
        }

        public string retFilePath()
        {
            return selectedFilePath;
        }

        public string retFileText()
        {
            return selectedFileText;
        }

        public void updateFileText(string text)
        {
            selectedFileText = text;
        }

        public void writeFile()
        {
            if (selectedFilePath != "")
            {
                string newFileName = selectedFilePath.Replace(selectedFileName, "saveFile.txt");

                if (!File.Exists(newFileName))
                {
                    File.Create(newFileName).Dispose();
                    using (TextWriter tw = new StreamWriter(newFileName))
                    {
                        string[] splitText = selectedFileText.Split('\n');

                        for (int i = 0; i < splitText.Length; i++)
                            tw.WriteLine(splitText[i]);
                        tw.Close();
                    }

                }
                else if (File.Exists(newFileName))
                {
                    using (TextWriter tw = new StreamWriter(newFileName))
                    {
                        string[] splitText = selectedFileText.Split('\n');

                        for (int i = 0; i < splitText.Length; i++)
                            tw.WriteLine(splitText[i]);

                        tw.Close();
                    }
                }

            }
        }
    }
}
