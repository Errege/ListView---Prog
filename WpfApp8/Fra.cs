using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp8
{
    class Fra
    {
        public static Frame frame { get; set; }
        public static TextBlock text { get; set; }
        public static TextBlock te { get; set; }
        public static ListView list = new ListView();
        public static TextBlock texxt = new TextBlock();
        public static WorldSkilEntities context = new WorldSkilEntities();
        public static List<MATERIAL> glob = new List<MATERIAL>();
    }
}
