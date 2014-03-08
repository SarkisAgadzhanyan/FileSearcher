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

namespace FileSearcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
        }

        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            lblRootDirectoryContainer.Text = folderBrowserDialog1.SelectedPath;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if (tbx.Text != "" && folderBrowserDialog1.SelectedPath != "")
                    Program.SearchFile(folderBrowserDialog1.SelectedPath, backgroundWorker1, tbx.Text);
            }
        }

        private void StartAsync_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                date = new DateTime(0, 0);
                Program.ClearAllData(treeView1, lblFilesCounterContainer);
                filesCounter = 0;
                backgroundWorker1.WorkerSupportsCancellation = false;
                timer1.Enabled = true;
                backgroundWorker1.RunWorkerAsync();
                start_btn.Enabled = false;
                cancel_btn.Enabled = true;
                lblStatus.Text = "";
                btnSelectDirectory.Enabled = false;
            }
        }

        private void CancelAsync_Click(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.CancelAsync();
            cancel_btn.Enabled = false;
            timer1.Enabled = false;
            start_btn.Enabled = true;
            this.backgroundWorker1.WorkerReportsProgress = false;
            btnSelectDirectory.Enabled = true;
        }

        private int filesCounter;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.backgroundWorker1.CancellationPending != true)
            {
                filesCounter++;

                string absolutePathToFile = Convert.ToString(e.UserState);

                string relativePathToFile = Program.GetRelativePathToFile(absolutePathToFile, lblRootDirectoryContainer.Text);

                if (lblCurrentFileContainer.Text == relativePathToFile)
                {
                    filesCounter--;

                    int lastIndexOfBackslash = absolutePathToFile.LastIndexOf("\\");

                    string fileName = absolutePathToFile.Substring(lastIndexOfBackslash + 1);

                    string currentDirectory = absolutePathToFile.Substring(0, lastIndexOfBackslash);

                    if (treeView1.Nodes.Count != 0)
                    {
                        bool isSubstringCurrentDirectory = false;

                        foreach (TreeNode node in treeView1.Nodes)
                        {
                            if (currentDirectory.IndexOf(node.Name) > -1)
                            {
                                isSubstringCurrentDirectory = true;
                                Program.FillTree(currentDirectory, fileName, node);
                            }
                        }
                        if (isSubstringCurrentDirectory == false)
                        {
                            treeView1.Nodes.Add(currentDirectory, currentDirectory);
                            (treeView1.Nodes.Find(currentDirectory, false))[0].Nodes.Add(fileName, fileName);
                        }
                    }
                    else
                    {
                        treeView1.Nodes.Add(currentDirectory, currentDirectory);
                        treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Add(fileName, fileName);
                    }
                }
                else
                {
                    lblCurrentFileContainer.Text = relativePathToFile;
                }
                lblFilesCounterContainer.Text = filesCounter.ToString();
            }
            else
            {
                return;
            }
        }

        protected override void OnClosing(CancelEventArgs e)//сохранение состояний при закрытии формы
        {
            Properties.Settings.Default.RootDirectory = this.folderBrowserDialog1.SelectedPath; //сохранение начальной директории поиска
            Properties.Settings.Default.SearchString = this.tbx.Text;//сохранение строки поиска
            Properties.Settings.Default.Save();
            base.OnClosing(e);
        }

        private void LoadSettings()//загрузка сохраненных состояний
        {
            this.tbx.Text = Properties.Settings.Default.SearchString; //загрузка строки поиска
            this.lblRootDirectoryContainer.Text = Properties.Settings.Default.RootDirectory; //загрузка начальной директории поиска
            this.folderBrowserDialog1.SelectedPath = Properties.Settings.Default.RootDirectory; //загрузка начальной директории поиска
        }


        DateTime date;
        private void timer1_Tick(object sender, EventArgs e) //действия происходящие с частотой 1 миллисекунда 
        {
            date = date.AddSeconds(1); //добавление секунды 
            lblTimeContainer.Text = date.ToString("HH:mm:ss"); //вывод текущего время таймера в формате "ЧЧ:мм:сс" с учетом того, что каждую миллисекунду будет добавляться 1 секунда.
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Enabled = false;
            start_btn.Enabled = true;
            cancel_btn.Enabled = false;
            lblStatus.Text = "Поиск завершен!";
            btnSelectDirectory.Enabled = true;
        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            if (tbx.Text != "" && !backgroundWorker1.IsBusy)
            {
                start_btn.Enabled = true;
            }
            else
            {
                start_btn.Enabled = false;
            }
        }

        private void lblRootDirectoryContainer_TextChanged(object sender, EventArgs e)
        {
            if (lblRootDirectoryContainer.Text != "")
            {
                tbx.Enabled = true;
            }
        }
    }
}