using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
namespace VideoPlayerDemo
{
  class CCore
  {
    public static List<MenuItem> videoCollection = new List<MenuItem>();
    public static int AddItem(MenuItem item)
    {
      item.ID = videoCollection.Count();
      videoCollection.Add(item);
      return item.ID;
    }
    public static void LoadFromConfig()
    {
      LoadFromConfig(Properties.Resources.ConfigPath);
    }
    public static void LoadFromConfig(string Path)
    {
      XmlDocument doc = new XmlDocument();
      doc.Load(Path);

      foreach (XmlElement elem in doc.GetElementsByTagName("menuItem"))
      {
        MenuItem menuItem = new MenuItem();
        try
        {
          menuItem.Header = elem.GetElementsByTagName("header")[0].InnerText;
          menuItem.Info = elem.GetElementsByTagName("info")[0].InnerText;
          menuItem.VideoPath = elem.GetElementsByTagName("videoPath")[0].InnerText;
          menuItem.ID = videoCollection.Count();
          videoCollection.Add(menuItem);
        }
        catch (Exception e)
        {
          MessageBox.Show("Элемент меню не загружен, ошибка чтения файла конфигурации :" + e.Message);
          continue;
        }
      }
    }
  }

}
