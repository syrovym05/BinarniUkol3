using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ukolBin3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.ShowIcon = false;
            this.Text = "Binarni Ukol 3";
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs1 = new FileStream("texty.dat", FileMode.Open, FileAccess.Read);
            FileStream fs2 = new FileStream ("oprava.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs1, Encoding.UTF8);
            BinaryWriter bw = new BinaryWriter(fs2, Encoding.UTF8);  

            br.BaseStream.Position = 0;

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                char c = br.ReadChar();
                textBox1.Text += c;

                if (c == '.') c = '!';    
                
                bw.Write(c);
                textBox2.Text += c;
            }
                                      
            fs1.Close();
            fs2.Close();

        }
    }
}
