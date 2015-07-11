using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Microsoft.Win32;

namespace VideoPlayerDemo
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private bool mediaPlayerIsPlaying = false;
    private bool userIsDraggingSlider = false;
    private ControlWindow controlWindow;
    public MainWindow()
    {
      InitializeComponent();
      CCore.LoadFromConfig();
      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromSeconds(1);
      timer.Tick += timer_Tick;
      timer.Start();

      controlWindow = new ControlWindow();
      controlWindow.Show();
      controlWindow.Closing += controlWindow_Closing;
      this.Closing += MainWindow_Closing;
      this.KeyDown += new KeyEventHandler(ESC_Pressed);
      mePlayer.MouseDown += new MouseButtonEventHandler(Maximize_Video); 
    }

    void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {

      if (controlWindow != null && controlWindow.IsLoaded)
      {
        controlWindow.Closing -= controlWindow_Closing;
        controlWindow.Close();
        
      }
    }

    void controlWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {

    }

    void Maximize_Video(object senderm, MouseEventArgs e)
    {
     
      this.WindowState = WindowState.Maximized;
    }

    private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
    {
      mePlayer.Position = TimeSpan.FromMilliseconds(1);
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
      {
        //sliProgress.Minimum = 0;
        //sliProgress.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
        //sliProgress.Value = mePlayer.Position.TotalSeconds;
      }
    }

    private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Media files (*.mp3;*.mp4;*.mpg;*.mpeg; *.wmv; *.avi)|*.mp3;*.mp4;*.mpg;*.mpeg;*.wmv; *.avi|All files (*.*)|*.*";
      if (openFileDialog.ShowDialog() == true)
      {
        mePlayer.Source = new Uri(openFileDialog.FileName);
        this.Cursor = System.Windows.Input.Cursors.None;
      }
    }

    private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = (mePlayer != null) && (mePlayer.Source != null);
    }

    private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
    {

      mePlayer.Play();
      mediaPlayerIsPlaying = true;
    }

    private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = mediaPlayerIsPlaying;
    }

    private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      mePlayer.Pause();
    }

    private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = mediaPlayerIsPlaying;
    }

    private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      mePlayer.Stop();
      mediaPlayerIsPlaying = false;
    }

    private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
    {
      userIsDraggingSlider = true;
    }

    private void ESC_Pressed(object sender,KeyEventArgs e )
    {

      if (e.Key == Key.Escape)
        this.WindowState = WindowState.Normal;
    }


    private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
    {
      mePlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
    }
  }
}
