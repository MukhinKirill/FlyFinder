using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace FlyFinder
{
    class Model
    {
        private string currentFile = null;
        private string fullCurrentFile = null;
        public DateTime m_LastTimeFired;
        private int msec = 0;//100
        private int sec = 0;//60
        private int min = 0;
        /// <summary>
        /// событие, что нашли файл 
        /// </summary>
        public event Action<string[]> eventFindFile;
        /// <summary>
        /// событие, что приступили к обработке файла
        /// </summary>
        public event Action eventCurrentFile;
        /// <summary>
        /// событие для ошибки ввода директории или при попытке поиска в недоступных папках 
        /// </summary>
        public event Action<string> eventErrorDirectory;
        /// <summary>
        /// событие окончания поиска
        /// </summary>
        public event EventHandler eventEndSearch;
        public string FindedFile { get; private set; }
        public string CurrentTime { get; private set; }
        public string CurrentFile
        {
            get
            {
                return currentFile;
            }
            private set
            {
                fullCurrentFile = value;
                var tmp = value.Split('\\', '/');
                currentFile = "...\\" + tmp[tmp.Length - 1];
            }
        }
        public string FullCurrentFile { get => fullCurrentFile; }



        public Model()
        {

        }
        /// <summary>
        /// метод запускающий поиск по критериям
        /// </summary>
        /// <param name="obj"></param>
        public void StartSearch(object obj)
        {
            var list = (List<string>)obj;
            var catalog = list[0];
            if (catalog == "")
            {
                ResetTimer();
                eventErrorDirectory.Invoke("Необходимо заполнить поле стартовой директории");
                return;
            }
            var name = list[1];
            if (name == "")
                name = "*";
            var text = list[2];
            if (text == "")
                text = "*";
            try
            {
                foreach (var file in Directory.GetFiles(catalog,"*",SearchOption.AllDirectories))
                {
                    CurrentFile = file;
                    eventCurrentFile.Invoke();
                    CheckFile(file, name, text);
                };
                eventEndSearch.Invoke(this, new EventArgs());
            }
            catch (DirectoryNotFoundException ex)
            {
                ResetTimer();
                eventErrorDirectory.Invoke(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                ResetTimer();
                eventErrorDirectory.Invoke(ex.Message);
            }
        }
        /// <summary>
        /// метод проверки файла по критериям
        /// </summary>
        /// <param name="file">путь файла</param>
        /// <param name="name">шаблон для поиска файла</param>
        /// <param name="text">текст в файле</param>
        private void CheckFile(string file, string name, string text)
        {
            var pathArray = file.Split('\\');
            var currentName = pathArray[pathArray.Length - 1];
            if (CheckFileName(name, currentName))
            {
                if (text.Equals("*"))
                {
                    FindedFile = file;
                    eventFindFile.Invoke(pathArray);
                }
                else
                {
                    using (var sr = new StreamReader(file))
                    {
                        string tmp = sr.ReadToEnd();
                        tmp = tmp.Replace("\r\n","\n");
                        text = text.Replace("\r\n", "\n");
                        if (tmp.Contains(text))
                        {
                            FindedFile = file;
                            eventFindFile.Invoke(pathArray);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// метод проверки имени файла по критерию
        /// </summary>
        /// <param name="pattern">шаблон файла</param>
        /// <param name="sourceString">исходое имя файла</param>
        /// <returns></returns>
        private bool CheckFileName(string pattern, string sourceString)
        {
            Regex mask = new Regex(
                '^' +
                pattern
                    .Replace(".", "[.]")
                    .Replace("*", ".*")
                    .Replace("?", ".")
                + '$',
                RegexOptions.IgnoreCase);
            return mask.IsMatch(sourceString);
        }
        /// <summary>
        /// метод для подсчета времени между тиками для таймера
        /// </summary>
        public void TickModel()
        {
            TimeSpan elapsed = DateTime.Now - m_LastTimeFired;
            m_LastTimeFired = DateTime.Now;
            msec += elapsed.Milliseconds;

            if (msec >= 1000)
            {
                msec -= 1000;
                sec++;
            }
            if (sec >= 60)
            {
                sec -= 60;
                min++;
            }
            CurrentTime = string.Format("Время поиска: {0:00}:{1:00}:{2:00}", this.min, this.sec, this.msec);
        }
        /// <summary>
        /// метод перезапуска таймера
        /// </summary>
        public void ResetTimer()
        {
            this.min = 0;
            this.sec = 0;
            this.msec = 0;
            CurrentTime = string.Format("Время поиска: {0:00}:{1:00}:{2:00}", this.min, this.sec, this.msec);
        }
    }
}
