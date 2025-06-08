using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE_soundset_tool
{
    internal class FormData
    {
        public FormData()
        {
        }

        public FormData(string longName, string author, List<DataItem> items)
        {
            LongName = longName;
            Author = author;
            Items = items;
        }

        public string LongName { get; set; }
        public string Author { get; set; }
        public List<DataItem> Items { get; set; }
    }
}
