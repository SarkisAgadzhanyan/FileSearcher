using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcher
{
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        public static void ClearAllData(TreeView treeView, Label counter)
        {
            treeView.Nodes.Clear();
            counter.Text = "";
        }

        public static void SearchFile(String rootDirectory, BackgroundWorker bgrnd_worker, string filter)
        {
            if (bgrnd_worker.CancellationPending)
            {
                return;
            }
            else
            {
                try
                {
                    SearchFileInCurrentDirectory(rootDirectory, filter, bgrnd_worker); // искать файлы в текущей директории (меняется рекурсивно)
                    string[] directories = Directory.GetDirectories(rootDirectory); //все директории, находящиеся, непосредственно, в корновой директории rootDirectory(меняется рекурсивно)

                    if (directories.Length != 0)
                    {
                        foreach (string directory in directories)//для каждой директории, находящейся в текущей директории(rootDirectory),
                        {
                            SearchFile(directory, bgrnd_worker, filter);//искать вложенные директории директории
                        }
                    }
                }
                catch { }
            }
        }


        public static void SearchFileInCurrentDirectory(string directory, string filter, BackgroundWorker bgrnd_worker)
        {
            string[] detectedFiles = null;
            if (filter.IndexOf("*") > -1 || filter.IndexOf("?") > -1) // если фильтр содержит "*" или "?", то поиск ведется по поисковому шаблону (searchPatern)
            {
                detectedFiles = Directory.GetFiles(directory, filter); // файлы из папки directory, удовлетворяющие поисковому шаблону
                string[] allFilesInCurrentDirectory = Directory.GetFiles(directory); // все файлы из папки directory
                int detectedFilesCount = detectedFiles.Length;// количество найденных файлов, удовлетворяющих поисковому шаблону
                foreach (string file in allFilesInCurrentDirectory) //для всех файлов из папки directory
                {
                    ReportFile(bgrnd_worker, file); // сообщить о текущем файле

                    if (detectedFilesCount != 0 && detectedFilesCount != allFilesInCurrentDirectory.Length) // если количество файлов, удовлетворяющих поисковому шаблону НЕ РАВНО нулю И если  количество файлов, удовлетворяющих поисковому шаблону РАВНО количеству всех файлов из папки directory
                    {
                        foreach (string detectedFile in detectedFiles)// для всех файлов из папки directory, , удовлетворяющих поисковому шаблону
                        {
                            System.Threading.Thread.Sleep(20);
                            if (file == detectedFile) //если это один и тот же файл
                            {
                                ReportFile(bgrnd_worker, file); //сообщить об этом файле
                            }
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(50);
                        if (bgrnd_worker.CancellationPending)
                        {
                            return;
                        }
                        else
                        {
                            if (detectedFilesCount != 0) // если количество файло, удовлетворяющих поисковому шаблону НЕ РАВНО нулю,
                                ReportFile(bgrnd_worker, file);// то сообщить о текущем файле
                        }
                    }
                }
            }
            else // поиск фильтра в имени или тексте(для .txt) файла
            {
                try
                {
                    detectedFiles = Directory.GetFiles(directory); // все файлы, находящиеся в папке directory

                    foreach (string file in detectedFiles)
                    {
                        if (bgrnd_worker.CancellationPending)
                        {
                            return;
                        }
                        else
                        {
                            ReportFile(bgrnd_worker, file); //сообщить о текущем файле

                            System.Threading.Thread.Sleep(50);

                            int fileNameStartIndex = 1 + file.LastIndexOf("\\");// индекс первого символа имени файла

                            string fileName = file.Substring(fileNameStartIndex);

                            if (fileName.IndexOf(filter) > -1) // если имя файла содержит фильтр
                            {
                                ReportFile(bgrnd_worker, file); // сообщить о текущем файле
                            }
                            else // имя файла не содержит фильтр
                            {
                                if (fileName.IndexOf(".txt") > -1) // имя файла содержит .txt (текстовый файл?)
                                {
                                    try
                                    {
                                        FileStream fs = new FileStream(file, FileMode.Open);
                                        StreamReader sr = new StreamReader(fs, Encoding.Default);
                                        string line = sr.ReadToEnd();
                                        fs.Position = 0;
                                        if (line.IndexOf(filter) > -1) // содержание файла содержит фильтр
                                        {
                                            ReportFile(bgrnd_worker, file); //сообщить о текущем файле
                                        }
                                        fs.Close();
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }

        public static void FillTree(string directory, string file, TreeNode rootNode)// метод, собирающий дерево файлов.
        {
            if (directory == rootNode.Name)// если директория (directory),в которой лежит файл(file) совпадает с корневой директорией,
            {
                rootNode.Nodes.Add(file, file); // то добавить файл(file), в коллекцую узлов(Nodes) корневой ноды(rootNode).
            }
            else
            {
                bool isCurrentNode = false;// флаг, который показывает есть ли директория currentDirecctory в коллекции узлов корневого узла(rootNode); false - нет, true - да
                string currentDirectory = GetDirectory(rootNode.Name, directory);// получить директорию, следующую по иерархии вложенности к корневому узул(rootNode), которая входит в путь директории (directory)?
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (currentDirectory == node.Name)// директория currentDirectory и узел из коллекции Nodes корневого узла(rootNode) одна и та же директория
                    {
                        isCurrentNode = true; //установить значение флага, демонстрирующее, что  директория currentDirectory и узел из коллекции Nodes корневого узла(rootNode) одна и та же директория
                        FillTree(directory, file, node);//углубиться на уровень, где корневым узлом(rootNode) будет текущий узел
                    }
                }
                if (isCurrentNode == false) // если не нашлось узла с именем (currentDirectory)
                {
                    rootNode.Nodes.Add(currentDirectory, currentDirectory); //добавиь узел с именем [currentDirectory]
                    FillTree(directory, file, (rootNode.Nodes.Find(currentDirectory, false))[0]); // углубиться на уровень, где корневым узлом(rootNode) будет только что созданный узел с именем [currentDirectory]
                }
            }
        }

        private static string GetDirectory(string rootNodeDirectory, string currentFileDirectory)
        {
            string[] rootNodeDirectorySections = rootNodeDirectory.Split('\\');
            string[] currentFileDirectorySections = currentFileDirectory.Split('\\');

            int count1 = rootNodeDirectorySections.Length;
            int count2 = currentFileDirectorySections.Length;

            for (int i = count1; i < count1 + 1; )
            {
                string newNodeDirectory = rootNodeDirectory + "\\" + currentFileDirectorySections[i];
                return newNodeDirectory;
            }

            return "";
        }

        private static void ReportFile(BackgroundWorker bgrnd_worker, string file)
        {
            if (bgrnd_worker.WorkerReportsProgress != true)
            {
                bgrnd_worker.WorkerReportsProgress = true;
                bgrnd_worker.ReportProgress(0, file);
            }
            else
            {
                bgrnd_worker.ReportProgress(0, file);
            }
        }

        public static string GetRelativePathToFile(string filePath, string rootDirectory)
        {
            string relativePathToFile = "";
            if (filePath.Length != rootDirectory.Length)
            {
                if (filePath[rootDirectory.Length].ToString() != "\\")
                {
                    relativePathToFile = filePath.Substring(rootDirectory.Length);
                }
                else
                {
                    relativePathToFile = filePath.Substring(rootDirectory.Length+1);
                }
            }
            return relativePathToFile;
        }
    }
}
