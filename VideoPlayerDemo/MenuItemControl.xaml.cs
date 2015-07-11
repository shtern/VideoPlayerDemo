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
  /// Логика взаимодействия для MenuItemControl.xaml
  /// </summary>
  public partial class MenuItemControl : Window
  {
    public MenuItemControl()
    {
      InitializeComponent();
    }
    public MenuItemControl(MenuItem menuItem)
    {
      InitializeComponent();
      this.Btn_1.Content = menuItem.Header;
      this.Btn_2.Content = menuItem.Info;
      this.text_1.Text = menuItem.VideoPath;
    }
  }
}
