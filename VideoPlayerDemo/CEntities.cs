using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerDemo
{
  public class MenuItem
  {
    public int ID;
    public string Header;
    public string Info;
    public string VideoPath;
    public MenuItem() { ID = -1;}
    public MenuItem(string header = "", string info = "", string videoPath = "")
    {
      Header = header;
      Info = info;
      VideoPath = videoPath;
    }
  }
}
