using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Windows;
using Timer = System.Timers.Timer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch stopwatch;
        private Timer timer;
        private const string _startTimeDisplay = "00:00:00";


        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            stopwatch = new Stopwatch();
            timer = new Timer(interval: 1000);
            timer.Elapsed += OnTimerElapse;
            TxtTimeDisplay.Text = _startTimeDisplay; ;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Shows the current time in the cronometer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerElapse(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => TxtTimeDisplay.Text = stopwatch.Elapsed.ToString(format: @"hh\:mm\:ss"));
        }
        #endregion

        #region Events
        /// <summary>
        /// Start the cronometer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            timer.Start();
            BtnStop.IsEnabled = false;
        }

        /// <summary>
        /// Pause the cronometer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            timer.Stop();
            BtnStop.IsEnabled = true;
        }

        /// <summary>
        /// Stop and reset the cronometer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            TxtTimeDisplay.Text = _startTimeDisplay;
        } 
        #endregion
    }
}
