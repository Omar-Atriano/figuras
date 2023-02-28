using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace figuras
{
    public partial class Form1 : Form
    {
        public Graphics g;
        Bitmap bmp;
        public Vertex[] vertices;
        public Scene scene;
        public int[,] faces;
        public int angle;
        public bool rotX, rotY, rotZ, rt;
        public Form1()
        {
            InitializeComponent();
            init();
            rotX = true;
            rotY = true;
            rotZ = true;
            scene = new Scene(new Figures(vertices, faces));
            pinta();
        }
        public void pinta()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            scene.Draw(g, pictureBox1.Width, pictureBox1.Height, rotX, rotY, rotZ);
        }

        private void buttonRz_Click(object sender, EventArgs e)
        {
            if (rotZ == false)
                rotZ = true;
            else if (rotZ == true)
                rotZ = false;
        }

        private void buttonRy_Click(object sender, EventArgs e)
        {
            if (rotY == false)
                rotY = true;
            else if (rotY == true)
                rotY = false;
        }

        private void buttonRt_Click(object sender, EventArgs e)
        {
            if (rotX && rotY && rotZ)
            {
                rotX = false;
                rotY = false;
                rotZ = false;
            }
            else if (!rotX && !rotY && !rotZ)
            {
                rotX = true;
                rotY = true;
                rotZ = true;
            }
            else
            {
                rotX = false;
                rotY = false;
                rotZ = false;
            }

        }

        private void buttonRx_Click(object sender, EventArgs e)
        {
            if (rotX == false)
                rotX = true;
            else if (rotX == true)
                rotX = false;
        }

        private void init()
        {
            vertices = new Vertex[]
            {
                new Vertex(-1, 1, -1),
                new Vertex(1, 1, -1),
                new Vertex(1, -1, -1),
                new Vertex  (-1, -1, -1),
                new Vertex(-1, 1, 1),
                new Vertex(1, 1, 1),
                new Vertex(1, -1, 1),
                new Vertex(-1, -1, 1)
            };

            faces = new int[,]
            {
                {
                    0, 1, 2, 3
                },
                {
                    1, 5, 6, 2
                },
                {
                    5, 4, 7, 6
                },
                {
                    4, 0, 3, 7
                },
                {
                    0, 4, 5, 1
                },
                {
                    3, 2, 6, 7
                }
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            pinta();
            angle += 2;
        }
    }
}
