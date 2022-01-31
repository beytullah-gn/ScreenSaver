using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class Form1 : Form
    {
        List<Image> BGImages = new List<Image>();
        List<Britpic> britPics = new List<Britpic>();
        Random rand = new Random();

        class Britpic
        {
            public int Picnum;
            public float x;
            public float y;
            public float speed;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("pics");
            foreach (string image in images)
            {
                BGImages.Add(new Bitmap(image));

            }
            for (int i = 0; i < 100; i++)
            {
                Britpic mp = new Britpic();
                mp.Picnum = i % BGImages.Count;
                mp.x = rand.Next(0, Width);
                mp.y = rand.Next(0, Height);
                britPics.Add(mp);
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Britpic bp in britPics)
            {
                e.Graphics.DrawImage(BGImages[bp.Picnum],bp.x,bp.y);
                bp.x -= 2;
                if(bp.x<-250)
                {
                    bp.x = Width + 10;

                }
            }
        }
    }
}
