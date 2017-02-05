using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumIdsApp
{
    public class RootObject
    {
        public MenuHolder[] Property1 { get; set; }

        public class MenuHolder
        {
            public Menu Menu { get; set; }
        }

        public class Menu
        {
            public string Header { get; set; }
            public Item[] Items { get; set; }
        }

        public class Item
        {
            public int Id { get; set; }
            public string Label { get; set; }
        }
    }
}
