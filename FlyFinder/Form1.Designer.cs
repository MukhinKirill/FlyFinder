namespace FlyFinder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_info = new System.Windows.Forms.Label();
            this.tb_startDirectory = new System.Windows.Forms.TextBox();
            this.lbl_startInfo = new System.Windows.Forms.Label();
            this.lbl_nameFile = new System.Windows.Forms.Label();
            this.tb_templateNameOfFile = new System.Windows.Forms.TextBox();
            this.lbl_textOfFile = new System.Windows.Forms.Label();
            this.tb_textOfFile = new System.Windows.Forms.TextBox();
            this.lbl_timeOfSearch = new System.Windows.Forms.Label();
            this.lbl_counterOfFiles = new System.Windows.Forms.Label();
            this.lbl_currentFile = new System.Windows.Forms.Label();
            this.btn_startSearch = new System.Windows.Forms.Button();
            this.btn_stopSearch = new System.Windows.Forms.Button();
            this.btn_continueSearch = new System.Windows.Forms.Button();
            this.tree_Files = new System.Windows.Forms.TreeView();
            this.lbl_searchingFiles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_info.Location = new System.Drawing.Point(12, 9);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(170, 24);
            this.lbl_info.TabIndex = 0;
            this.lbl_info.Text = "Критерии поиска:";
            // 
            // tb_startDirectory
            // 
            this.tb_startDirectory.Location = new System.Drawing.Point(16, 72);
            this.tb_startDirectory.Name = "tb_startDirectory";
            this.tb_startDirectory.Size = new System.Drawing.Size(600, 20);
            this.tb_startDirectory.TabIndex = 1;
            // 
            // lbl_startInfo
            // 
            this.lbl_startInfo.AutoSize = true;
            this.lbl_startInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_startInfo.Location = new System.Drawing.Point(12, 45);
            this.lbl_startInfo.Name = "lbl_startInfo";
            this.lbl_startInfo.Size = new System.Drawing.Size(223, 24);
            this.lbl_startInfo.TabIndex = 2;
            this.lbl_startInfo.Text = "Стартовая директория:";
            // 
            // lbl_nameFile
            // 
            this.lbl_nameFile.AutoSize = true;
            this.lbl_nameFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_nameFile.Location = new System.Drawing.Point(12, 95);
            this.lbl_nameFile.Name = "lbl_nameFile";
            this.lbl_nameFile.Size = new System.Drawing.Size(204, 24);
            this.lbl_nameFile.TabIndex = 4;
            this.lbl_nameFile.Text = "Шаблон имени файла:";
            // 
            // tb_templateNameOfFile
            // 
            this.tb_templateNameOfFile.Location = new System.Drawing.Point(16, 122);
            this.tb_templateNameOfFile.Name = "tb_templateNameOfFile";
            this.tb_templateNameOfFile.Size = new System.Drawing.Size(600, 20);
            this.tb_templateNameOfFile.TabIndex = 3;
            // 
            // lbl_textOfFile
            // 
            this.lbl_textOfFile.AutoSize = true;
            this.lbl_textOfFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_textOfFile.Location = new System.Drawing.Point(12, 145);
            this.lbl_textOfFile.Name = "lbl_textOfFile";
            this.lbl_textOfFile.Size = new System.Drawing.Size(139, 24);
            this.lbl_textOfFile.TabIndex = 6;
            this.lbl_textOfFile.Text = "Текст в файле";
            // 
            // tb_textOfFile
            // 
            this.tb_textOfFile.Location = new System.Drawing.Point(16, 172);
            this.tb_textOfFile.Multiline = true;
            this.tb_textOfFile.Name = "tb_textOfFile";
            this.tb_textOfFile.Size = new System.Drawing.Size(600, 186);
            this.tb_textOfFile.TabIndex = 5;
            // 
            // lbl_timeOfSearch
            // 
            this.lbl_timeOfSearch.AutoSize = true;
            this.lbl_timeOfSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_timeOfSearch.Location = new System.Drawing.Point(12, 372);
            this.lbl_timeOfSearch.Name = "lbl_timeOfSearch";
            this.lbl_timeOfSearch.Size = new System.Drawing.Size(214, 24);
            this.lbl_timeOfSearch.TabIndex = 7;
            this.lbl_timeOfSearch.Text = "Время поиска: 00:00:00";
            // 
            // lbl_counterOfFiles
            // 
            this.lbl_counterOfFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_counterOfFiles.Location = new System.Drawing.Point(12, 396);
            this.lbl_counterOfFiles.Name = "lbl_counterOfFiles";
            this.lbl_counterOfFiles.Size = new System.Drawing.Size(675, 24);
            this.lbl_counterOfFiles.TabIndex = 8;
            this.lbl_counterOfFiles.Text = "Обработанных файлов: 0";
            // 
            // lbl_currentFile
            // 
            this.lbl_currentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_currentFile.Location = new System.Drawing.Point(12, 420);
            this.lbl_currentFile.Name = "lbl_currentFile";
            this.lbl_currentFile.Size = new System.Drawing.Size(675, 24);
            this.lbl_currentFile.TabIndex = 9;
            this.lbl_currentFile.Text = "В обработке:";
            this.lbl_currentFile.Click += new System.EventHandler(this.lbl_currentFile_Click);
            // 
            // btn_startSearch
            // 
            this.btn_startSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_startSearch.Location = new System.Drawing.Point(12, 447);
            this.btn_startSearch.Name = "btn_startSearch";
            this.btn_startSearch.Size = new System.Drawing.Size(170, 46);
            this.btn_startSearch.TabIndex = 10;
            this.btn_startSearch.Text = "Начать поиск";
            this.btn_startSearch.UseVisualStyleBackColor = true;
            this.btn_startSearch.Click += new System.EventHandler(this.btn_startSearch_Click);
            // 
            // btn_stopSearch
            // 
            this.btn_stopSearch.Enabled = false;
            this.btn_stopSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_stopSearch.Location = new System.Drawing.Point(188, 447);
            this.btn_stopSearch.Name = "btn_stopSearch";
            this.btn_stopSearch.Size = new System.Drawing.Size(170, 46);
            this.btn_stopSearch.TabIndex = 11;
            this.btn_stopSearch.Text = "Стоп";
            this.btn_stopSearch.UseVisualStyleBackColor = true;
            this.btn_stopSearch.Click += new System.EventHandler(this.btn_stopSearch_Click);
            // 
            // btn_continueSearch
            // 
            this.btn_continueSearch.Enabled = false;
            this.btn_continueSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_continueSearch.Location = new System.Drawing.Point(364, 447);
            this.btn_continueSearch.Name = "btn_continueSearch";
            this.btn_continueSearch.Size = new System.Drawing.Size(170, 46);
            this.btn_continueSearch.TabIndex = 12;
            this.btn_continueSearch.Text = "Продолжить";
            this.btn_continueSearch.UseVisualStyleBackColor = true;
            this.btn_continueSearch.Click += new System.EventHandler(this.btn_continueSearch_Click);
            // 
            // tree_Files
            // 
            this.tree_Files.Location = new System.Drawing.Point(693, 45);
            this.tree_Files.Name = "tree_Files";
            this.tree_Files.Size = new System.Drawing.Size(326, 448);
            this.tree_Files.TabIndex = 15;
            // 
            // lbl_searchingFiles
            // 
            this.lbl_searchingFiles.AutoSize = true;
            this.lbl_searchingFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_searchingFiles.Location = new System.Drawing.Point(689, 18);
            this.lbl_searchingFiles.Name = "lbl_searchingFiles";
            this.lbl_searchingFiles.Size = new System.Drawing.Size(176, 24);
            this.lbl_searchingFiles.TabIndex = 16;
            this.lbl_searchingFiles.Text = "Найденные файлы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1037, 509);
            this.Controls.Add(this.lbl_searchingFiles);
            this.Controls.Add(this.tree_Files);
            this.Controls.Add(this.btn_continueSearch);
            this.Controls.Add(this.btn_stopSearch);
            this.Controls.Add(this.btn_startSearch);
            this.Controls.Add(this.lbl_currentFile);
            this.Controls.Add(this.lbl_counterOfFiles);
            this.Controls.Add(this.lbl_timeOfSearch);
            this.Controls.Add(this.lbl_textOfFile);
            this.Controls.Add(this.tb_textOfFile);
            this.Controls.Add(this.lbl_nameFile);
            this.Controls.Add(this.tb_templateNameOfFile);
            this.Controls.Add(this.lbl_startInfo);
            this.Controls.Add(this.tb_startDirectory);
            this.Controls.Add(this.lbl_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "FlyFinder";
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.TextBox tb_startDirectory;
        private System.Windows.Forms.Label lbl_startInfo;
        private System.Windows.Forms.Label lbl_nameFile;
        private System.Windows.Forms.TextBox tb_templateNameOfFile;
        private System.Windows.Forms.Label lbl_textOfFile;
        private System.Windows.Forms.TextBox tb_textOfFile;
        private System.Windows.Forms.Label lbl_timeOfSearch;
        private System.Windows.Forms.Label lbl_counterOfFiles;
        private System.Windows.Forms.Label lbl_currentFile;
        private System.Windows.Forms.Button btn_startSearch;
        private System.Windows.Forms.Button btn_stopSearch;
        private System.Windows.Forms.Button btn_continueSearch;
        private System.Windows.Forms.TreeView tree_Files;
        private System.Windows.Forms.Label lbl_searchingFiles;
    }
}

