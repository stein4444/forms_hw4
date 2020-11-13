using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Serializable]
    public class Goods
    {
        public string name { get; set; }
        public string character { get; set; }
        public string description { get; set; }

        public int price { get; set; }
        public Goods() { }
        public Goods(string n, string ch, string desc, int p)
        {
            name = n;
            character = ch;
            description = desc;
            price = p;
        }
    }
}
