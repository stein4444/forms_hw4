using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Shop
{
    public partial class Form1 : Form
    {
        private List<Goods> goods = new List<Goods>();
        private GoodsInfo info = new GoodsInfo();
        private int goodCount;
        private int totalPrice = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoodsInfo goods = new GoodsInfo();
            goods.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = LGoods.GetItemText(LGoods.SelectedItem.ToString());
            foreach (Goods item in goods)
            {
                if (a == item.name)
                {
                    this.label3.Text = $"Price: {item.price}$";

                }
            }
            this.goodCount = this.LGoods.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Goods> soldGoods = new List<Goods>();
            soldGoods.Add(goods[this.goodCount]);
            foreach(Goods item in soldGoods)
            {
                this.Sales.Items.Add(item.name);
                this.lable5.Text = $"Total sold: {totalPrice += item.price}$";
            }
        }
        public void LoadAll()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Goods>));
            using (FileStream fs = new FileStream("Goods.xml", FileMode.Open))
            {
                goods = serializer.Deserialize(fs) as List<Goods>;
            }
            foreach (Goods item in goods)
            {
                this.LGoods.Items.Add(item.name);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAll();
        }
    }
}
