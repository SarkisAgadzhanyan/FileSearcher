namespace FileSearcher
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tbx = new System.Windows.Forms.TextBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.lblCurrentFileContainer = new System.Windows.Forms.Label();
            this.lblRootDirectory = new System.Windows.Forms.Label();
            this.lblRootDirectoryContainer = new System.Windows.Forms.Label();
            this.lblSearchFilter = new System.Windows.Forms.Label();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.lblFilesCount = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimeContainer = new System.Windows.Forms.Label();
            this.lblFilesCounterContainer = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Location = new System.Drawing.Point(15, 27);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(81, 22);
            this.btnSelectDirectory.TabIndex = 0;
            this.btnSelectDirectory.Text = "Выбрать...";
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(420, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(448, 293);
            this.treeView1.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // tbx
            // 
            this.tbx.Enabled = false;
            this.tbx.Location = new System.Drawing.Point(140, 66);
            this.tbx.Name = "tbx";
            this.tbx.Size = new System.Drawing.Size(215, 20);
            this.tbx.TabIndex = 2;
            this.tbx.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // start_btn
            // 
            this.start_btn.Enabled = false;
            this.start_btn.Location = new System.Drawing.Point(15, 333);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(153, 26);
            this.start_btn.TabIndex = 3;
            this.start_btn.Text = "Поиск";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.StartAsync_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Enabled = false;
            this.cancel_btn.Location = new System.Drawing.Point(188, 333);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(167, 26);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "Стоп";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.CancelAsync_Click);
            // 
            // lblCurrentFileContainer
            // 
            this.lblCurrentFileContainer.AutoSize = true;
            this.lblCurrentFileContainer.Location = new System.Drawing.Point(66, 308);
            this.lblCurrentFileContainer.Name = "lblCurrentFileContainer";
            this.lblCurrentFileContainer.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentFileContainer.TabIndex = 5;
            // 
            // lblRootDirectory
            // 
            this.lblRootDirectory.AutoSize = true;
            this.lblRootDirectory.Location = new System.Drawing.Point(102, 32);
            this.lblRootDirectory.Name = "lblRootDirectory";
            this.lblRootDirectory.Size = new System.Drawing.Size(104, 13);
            this.lblRootDirectory.TabIndex = 7;
            this.lblRootDirectory.Text = "Начальная папка : ";
            // 
            // lblRootDirectoryContainer
            // 
            this.lblRootDirectoryContainer.AutoSize = true;
            this.lblRootDirectoryContainer.Location = new System.Drawing.Point(212, 32);
            this.lblRootDirectoryContainer.Name = "lblRootDirectoryContainer";
            this.lblRootDirectoryContainer.Size = new System.Drawing.Size(0, 13);
            this.lblRootDirectoryContainer.TabIndex = 8;
            this.lblRootDirectoryContainer.TextChanged += new System.EventHandler(this.lblRootDirectoryContainer_TextChanged);
            // 
            // lblSearchFilter
            // 
            this.lblSearchFilter.AutoSize = true;
            this.lblSearchFilter.Location = new System.Drawing.Point(12, 69);
            this.lblSearchFilter.Name = "lblSearchFilter";
            this.lblSearchFilter.Size = new System.Drawing.Size(122, 13);
            this.lblSearchFilter.TabIndex = 9;
            this.lblSearchFilter.Text = "Имя файла или текст :";
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.AutoSize = true;
            this.lblCurrentFile.Location = new System.Drawing.Point(15, 308);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(42, 13);
            this.lblCurrentFile.TabIndex = 10;
            this.lblCurrentFile.Text = "Файл :";
            // 
            // lblFilesCount
            // 
            this.lblFilesCount.AutoSize = true;
            this.lblFilesCount.Location = new System.Drawing.Point(12, 121);
            this.lblFilesCount.Name = "lblFilesCount";
            this.lblFilesCount.Size = new System.Drawing.Size(123, 13);
            this.lblFilesCount.TabIndex = 11;
            this.lblFilesCount.Text = "Просмотрено файлов :";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(12, 150);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(108, 13);
            this.lblTime.TabIndex = 12;
            this.lblTime.Text = "Прошедшее время :";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimeContainer
            // 
            this.lblTimeContainer.AutoSize = true;
            this.lblTimeContainer.Location = new System.Drawing.Point(127, 150);
            this.lblTimeContainer.Name = "lblTimeContainer";
            this.lblTimeContainer.Size = new System.Drawing.Size(0, 13);
            this.lblTimeContainer.TabIndex = 13;
            // 
            // lblFilesCounterContainer
            // 
            this.lblFilesCounterContainer.AutoSize = true;
            this.lblFilesCounterContainer.Location = new System.Drawing.Point(142, 121);
            this.lblFilesCounterContainer.Name = "lblFilesCounterContainer";
            this.lblFilesCounterContainer.Size = new System.Drawing.Size(0, 13);
            this.lblFilesCounterContainer.TabIndex = 14;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(15, 231);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 371);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblFilesCounterContainer);
            this.Controls.Add(this.lblTimeContainer);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblFilesCount);
            this.Controls.Add(this.lblCurrentFile);
            this.Controls.Add(this.lblSearchFilter);
            this.Controls.Add(this.lblRootDirectoryContainer);
            this.Controls.Add(this.lblRootDirectory);
            this.Controls.Add(this.lblCurrentFileContainer);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.tbx);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnSelectDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Поиск файлов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.TreeView treeView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox tbx;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label lblCurrentFileContainer;
        private System.Windows.Forms.Label lblRootDirectory;
        private System.Windows.Forms.Label lblRootDirectoryContainer;
        private System.Windows.Forms.Label lblSearchFilter;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Label lblFilesCount;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimeContainer;
        private System.Windows.Forms.Label lblFilesCounterContainer;
        private System.Windows.Forms.Label lblStatus;
    }
}

