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
    public partial class GoodsInfo : Form
    {
        public List<Goods> goods = new List<Goods>();
        public GoodsInfo()
        {
            InitializeComponent();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = GoodsList.GetItemText(GoodsList.SelectedItem.ToString());
            foreach (Goods item in goods)
            {
                if (a == item.name)
                {
                    this.LbChar.Text = item.character;
                    this.LbDesc.Text = (item.description);
                    this.lbPrice.Text = $"{item.price} $";
                  
                }
            }
        }
        private void ReSetAll()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.GoodsList.Items.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textBox1.Text) &&
                 !String.IsNullOrEmpty(this.textBox2.Text) &&
                 !String.IsNullOrEmpty(this.textBox3.Text) &&
                 !String.IsNullOrEmpty(this.textBox4.Text))
            {
                Goods gds = new Goods(textBox1.Text, textBox2.Text, textBox3.Text, int.Parse(textBox4.Text));
                goods.Add(gds);
                File.Delete("Goods.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<Goods>));
                using (FileStream fs = new FileStream("Goods.xml", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fs, goods);
                    MessageBox.Show("Succsesfully");
                }

            }
            else
                MessageBox.Show("Try again" + MessageBoxButtons.OK);
            ReSetAll();
            foreach(Goods item in goods)
            {
                this.GoodsList.Items.Add(item.name);
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
                this.GoodsList.Items.Add(item.name);
            }

        }
        private void GoodsInfo_Load(object sender, EventArgs e)
        {
          LoadAll();
            
        }
    }
}
