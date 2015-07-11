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
using System.Windows.Shapes;

namespace VideoPlayerDemo
{
  /// <summary>
  /// Логика взаимодействия для ControlWindow.xaml
  /// </summary>
  public partial class ControlWindow : Window
  {
    public ControlWindow()
    {
      InitializeComponent();
      CCore.LoadFromConfig();
      foreach (MenuItem menuItem in CCore.videoCollection)
      {
        UserControl1 menuElement = new UserControl1();
        this.MenuItemsListBox.Items.Add(menuElement);
      }
    }
  }
}
