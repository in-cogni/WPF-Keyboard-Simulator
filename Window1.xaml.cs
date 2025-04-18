using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Exam;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Stopwatch stopwatch = new Stopwatch();//для определения время нажатия кнопки 

        Random rand = new Random();
        DispatcherTimer _timer;
        TimeSpan _time;
        double timePressed = 0;
        Dictionary<int, TextBlock> dictionary = new Dictionary<int, TextBlock>();
        int numOfKeys = 0, r;
        bool isGameActive;

        public Window1(int time)
        {
            InitializeComponent();

            _time = TimeSpan.FromSeconds(time);
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
            dictionaryAdd();
            isGameActive = true;

            NextKey();//начало
        }

        private void NextKey()
        {
            r = rand.Next(0, 34);
            BackLight(r);
            stopwatch.Start();
        }

        private void BackLight(int val) //подсвечивает клавишу, которую нужно нажать
        {
            dictionary[val].Background = Brushes.Gainsboro;
        }

        private void BackLight1(int val) //подсвечивает клавишу, если она нажата
        {
            dictionary[val].Background = Brushes.PaleGreen;
        }

        async protected override void OnKeyDown(KeyEventArgs e)
        {
            if (isGameActive)//пока идет таймер
            {
                Key k = WhatKey(r); //r = клавиша
                if (e.Key == k)//если нажата правильная клавиша
                {
                    stopwatch.Stop();//остановка таймера
                    timePressed += stopwatch.Elapsed.TotalMilliseconds;// получаем время нажатия кнопки
                    stopwatch.Reset(); // сброс таймера для следующего использования
                    numOfKeys++;
                    BackLight1(r);
                    await Task.Delay(100);
                    dictionary[r].Background = Brushes.WhiteSmoke;
                    NextKey();
                }
            }
        }

        private static readonly Key[] KeyMapping = new[]//массив ключей (для метода WhatKey)
        {
            Key.Q, Key.W, Key.E, Key.R, Key.T, Key.Y, Key.U, Key.I, Key.O, Key.P,
            Key.OemOpenBrackets, Key.OemCloseBrackets,
            Key.A, Key.S, Key.D, Key.F, Key.G, Key.H, Key.J, Key.K, Key.L,
            Key.OemSemicolon, Key.OemQuotes, Key.OemPipe,
            Key.Z, Key.X, Key.C, Key.V, Key.B, Key.N, Key.M,
            Key.OemComma, Key.OemPeriod, Key.OemQuestion
        };

        private Key WhatKey(int r)
        {
            return r >= 0 && r < KeyMapping.Length ? KeyMapping[r] : Key.None; //возвращаем нужный Key по индексу r
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_time > TimeSpan.Zero)
            {
                _time = _time.Add(TimeSpan.FromSeconds(-1));
                Tic.Text = _time.ToString(@"c");
            }
            else
            {
                stopwatch.Stop();//остановка таймера
                timePressed += stopwatch.Elapsed.TotalMilliseconds;// получаем время нажатия кнопки
                stopwatch.Reset(); // сброс таймера для следующего использования
                double averageDuration = numOfKeys > 0 ? timePressed / numOfKeys : 0;

                _timer.Stop();
                isGameActive = false;
                Window2 window1 = new Window2(numOfKeys, averageDuration);
                this.Close();
                window1.Show();
            }
        }
        private void dictionaryAdd() //заполняет словарь TextBlock (по типу dictionary.Add(0, t1);)
        {
            for (int i = 0; i < 34; i++)
            {
                string textBlockName = $"t{i + 1}";
                TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                if (textBlock != null)
                {
                    dictionary.Add(i, textBlock);
                }
            }
        }
    }
}
