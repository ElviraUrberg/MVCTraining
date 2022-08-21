using MVCTraining.Interfaces;
using System.Threading;

namespace MVCTraining.Services
{
    public class FileExplorerService : IFileExplorerService
    {
        //This service is not working yet
        public string PickImageFromFileExplorer()
        {
            string selectedPath = "";

            Thread t = new Thread((ThreadStart)(() => {
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();

                saveFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = saveFileDialog1.FileName;
                }
            }));

            return selectedPath;

            //var fileContent = string.Empty;
            //var filePath = string.Empty;

            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.InitialDirectory = "c:\\";
            //    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*
            //    openFileDialog.FilterIndex = 2;
            //    openFileDialog.RestoreDirectory = true;

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        //Get the path of specified file
            //        filePath = openFileDialog.FileName;

            //        //Read the contents of the file into a stream
            //        var fileStream = openFileDialog.OpenFile();

            //        using (StreamReader reader = new StreamReader(fileStream))
            //        {
            //            fileContent = reader.ReadToEnd();
            //        }
            //    }
            //}

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            //return filePath;
        }
    }
}
