using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyFinder
{
    public partial class Form1 : Form
    {
        private Model model = null;
        private int counter;
        public System.Windows.Forms.Timer timer = null;
        private Thread finder;
        private List<string> lblList;
        public Form1()
        {

            InitializeComponent();
            tb_startDirectory.Text = Properties.Settings.Default.start_dir.ToString();
            tb_templateNameOfFile.Text = Properties.Settings.Default.template.ToString();
            tb_textOfFile.Text = Properties.Settings.Default.text.ToString();
            counter = 0;
            model = new Model();
            lblList = new List<string>();
            model.m_LastTimeFired = new DateTime();
            InitializeTimer();
            model.eventFindFile += new Action<string[]>(ShowFindedFileHandler);
            model.eventCurrentFile += new Action(ShowCurrentFileHandler);
            model.eventEndSearch += new EventHandler(endSearchHanler);
            model.eventErrorDirectory += new Action<string>(ErrorDirectoryMessageHandler);
            Application.ApplicationExit += new EventHandler(this.Form1_Leave);
        }
        /// <summary>
        /// обработчик события получения ошибки директории
        /// </summary>
        /// <param name="msg"></param>
        private void ErrorDirectoryMessageHandler(string msg)
        {
            timer.Stop();
            lbl_timeOfSearch.Invoke(new Action(() => lbl_timeOfSearch.Text = this.model.CurrentTime));
            btn_startSearch.Invoke(new Action(() => btn_startSearch.Enabled = true));
            btn_stopSearch.Invoke(new Action(() => btn_stopSearch.Enabled = false));
            btn_continueSearch.Invoke(new Action(() => btn_continueSearch.Enabled = false));
            MessageBox.Show(msg);
        }
        /// <summary>
        /// обработчик события окончания поиска 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endSearchHanler(object sender, EventArgs e)
        {
            btn_startSearch.Invoke(new Action(() => btn_startSearch.Enabled = true));
            btn_stopSearch.Invoke(new Action(() => btn_stopSearch.Enabled = false));
            timer.Stop();
            if (finder.IsAlive)
            {
                finder.Suspend();
            }
        }
        /// <summary>
        /// инициализатор таймера
        /// </summary>
        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(TickTimer);
        }
        /// <summary>
        /// обработчик тика таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TickTimer(object sender, EventArgs e)
        {
            this.model.TickModel();
            lbl_timeOfSearch.Invoke(new Action(() => lbl_timeOfSearch.Text = this.model.CurrentTime));
        }
        /// <summary>
        /// обработчик события клика на кнопку начать_поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_startSearch_Click(object sender, EventArgs e)
        {
            GoToSearch();
            btn_stopSearch.Enabled = true;
            btn_startSearch.Enabled = false;
        }
        /// <summary>
        /// метод для старта поиска с начала
        /// </summary>
        private void GoToSearch()
        {
            Properties.Settings.Default.start_dir = tb_startDirectory.Text;
            Properties.Settings.Default.template = tb_templateNameOfFile.Text;
            Properties.Settings.Default.text = tb_textOfFile.Text;
            Properties.Settings.Default.Save();
            counter = 0;
            model.ResetTimer();
            tree_Files.Nodes.Clear();
            finder = new Thread(new ParameterizedThreadStart(this.model.StartSearch));
            timer.Start();
            lblList.Clear();
            lblList.Add(tb_startDirectory.Text);
            lblList.Add(tb_templateNameOfFile.Text);
            lblList.Add(tb_textOfFile.Text);
            finder.Start(lblList);
        }
        /// <summary>
        /// Обработчик события смены проверяемого файла
        /// </summary>
        private void ShowCurrentFileHandler()
        {
            counter++;

            lbl_counterOfFiles.Invoke(new Action(() => lbl_counterOfFiles.Text = $"Обработанных файлов {counter}"));

            lbl_currentFile.Invoke(new Action(() => lbl_currentFile.Text = $"В обработке {model.CurrentFile}"));
            lbl_timeOfSearch.Invoke(new Action(() => lbl_timeOfSearch.Text = this.model.CurrentTime));
        }
        /// <summary>
        /// Обработчик события, что нашли файл
        /// </summary>
        /// <param name="pathArray">путь файла в виде массива</param>
        private void ShowFindedFileHandler(string[] pathArray)
        {
            tree_Files.Invoke(new Action(() =>
            {

                var first = new TreeNode();
                var tmpNode = new TreeNode();
                first.Text = pathArray[0];
                FillTree(1, pathArray, first);
                tree_Files.Nodes.Add(first);
            }));

        }
        /// <summary>
        /// метод для заполнения дерева
        /// </summary>
        /// <param name="i">номер элемента в масииве</param>
        /// <param name="pathArray">массив с путем файла</param>
        /// <param name="current">текущий узел дерева</param>
        private void FillTree(int i, string[] pathArray, TreeNode current)
        {
            if (i == pathArray.Length)
                return;
            var node = new TreeNode(pathArray[i]);
            current.Nodes.Add(node);
            FillTree(i+1, pathArray, node);
        }
        /// <summary>
        /// обрабочик клика на имя текущего файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_currentFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show(model.FullCurrentFile);
        }
        /// <summary>
        /// обработчик клика на кнопку Стоп
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_stopSearch_Click(object sender, EventArgs e)
        {
            btn_startSearch.Invoke(new Action(() => btn_startSearch.Enabled = true));
            btn_continueSearch.Invoke(new Action(() => btn_continueSearch.Enabled = true));
            btn_stopSearch.Invoke(new Action(() => btn_stopSearch.Enabled = false));
            timer.Stop();
            if (finder.IsAlive)
            {
                finder.Suspend();
            }
        }
        /// <summary>
        /// обработчик клика на кнопку Продолжить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_continueSearch_Click(object sender, EventArgs e)
        {
            btn_continueSearch.Enabled = false;
            btn_startSearch.Enabled = false;
            btn_stopSearch.Enabled = true;
            if (finder.IsAlive)
            {
                finder.Resume();
            }
            timer.Start();
        }
        /// <summary>
        /// обработчик события закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Leave(object sender, EventArgs e)
        {
            ExitApp();
        }
        /// <summary>
        /// метод выхода из приложения
        /// </summary>
        private void ExitApp()
        {
            if (finder != null && finder.IsAlive)
            {
                try
                {
                    finder.Resume();
                    finder.Abort();
                }
                catch (ThreadStateException ex)
                { }
                finally
                {
                    finder.Abort();
                }
            }
            Application.ExitThread();
            //Application.Exit();
        }
    }
}
