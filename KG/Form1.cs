using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
namespace KG
{
    public partial class Form1 : MetroForm
    {

        public Form1()
        {
            InitializeComponent();

        }

        String filePath;
        String filePath2;
        bool Remove2 = false;
        bool Remove1 = false;
        
        int faceHYH, faceHYL, faceWXL, faceWXR, eyeCenterHYL, eyeCenterHYR, noseLY, noseWXL, noseWXR, earHYH, earHYL, chinYH, chinYL, dBEXL, dBEXR, eyebYL, eyebYR; //список неповний
        double faceWidth, faceHeight, eyeWidth, eyeWL, eyeWR, noseWidth, noseHeight, chinHeight, earHeight, distanceBtwEyes, distanceEyesNNose, eyeB, eyeCenter; //список неповний

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int mlngh = m2.Count;
            Remove2 = true;
            if (mlngh > 2)
            {
                m2.RemoveAt(mlngh - 1);
                m2.RemoveAt(mlngh - 2);
                for (int i = 0; i < mlngh - 3; i++)
                {
                    if (filePath != null)
                    {
                        pictureBox2.Load(filePath);
                    }
                    else { g2.Clear(Color.White); }


                    var s1 = m2.ElementAt(i);
                    var s2 = m2.ElementAt(i+1);
                    g2.DrawLine(new Pen(Color.Red, 2), s1, s2);
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            int mlngh = m.Count;
            Remove1 = true;
            if (mlngh > 2)
            {
                m.RemoveAt(mlngh - 1);
                m.RemoveAt(mlngh - 2);
                if (filePath2 != null)
                {
                    pictureBox1.Load(filePath2);
                }
                else { g.Clear(Color.White); }
                for (int i = 0; i < (m.Count); i=i++)
                {
                    


                    if (i == 0||i==1)
                    {
                        var s1 = m.ElementAt(i);
                        var s2 = m.ElementAt(i + 1);
                        g.DrawLine(new Pen(Color.White, 2), s1, s2);
                    }
                    else
                    {
                        var s1 = m.ElementAt(i+1);
                        var s2 = m.ElementAt(i + 2);
                        g.DrawLine(new Pen(Color.White, 2), s1, s2);
                    }
                    
                }
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            faceHYH = m[0].Y;
            faceHYL = m[1].Y;
            faceHeight = faceHYL - faceHYH;

            faceWXL = m[2].X;
            faceWXR = m[3].X;
            faceWidth = faceWXR - faceWXL;

            double garson = (faceWidth / faceHeight) / 100;
            String res = "";
            if (garson < 78.9)
            {
                res = "Дуже широке обличчя\n";
            }
            if (garson > 79 && garson < 83.9)
            {
                res = "Широке обличчя\n";
            }
            if (garson > 84 && garson < 87.9)
            {
                res = "Середнє обличчя\n";
            }
            if (garson > 88 && garson < 92.9)
            {
                res = "Вузьке обличчя\n";
            }
            if (garson > 93)
            {
                res = "Дуже вузьке обличчя\n";
            }
            richTextBox.AppendText("Тип обличчя - " + res);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    pictureBox2.Load(filePath);

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { "1024 x 768", "800 x 600", "1280 x 768", "1280 x 1024", "1280 x 720", "1440 x 1080", "1600 x 1024", "1920 x 1080", "1920 x 1200", "2048 x 1080", "2560 x 1080" });
            string selectedState = comboBox1.SelectedItem.ToString();
            MessageBox.Show( selectedState, "Ви вибрали: ");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        int[] result = new int[7];

        private void button2_Click(object sender, EventArgs e)
        {
            /* 
             Перша лінія - висота лиця
             Друга лінія - ширина лиця
             Третя лінія - ширина ока
             Четварта лінія - підборіддя
             П'ята лінія - відстань між очима
             Шоста лінія - лінія брові
             Сьома лінія - ширина носа
             Восьма лінія - центр очей
            */

            faceHYH = m[0].Y;
            faceHYL = m[1].Y;
            faceHeight = faceHYL - faceHYH; 

            faceWXL = m[2].X;
            faceWXR = m[3].X;
            faceWidth = faceWXR - faceWXL;

            eyeWL = m[4].X;
            eyeWL = m[5].X;
            eyeWidth = eyeWR - eyeWL;

            chinYH = m[6].Y;
            chinYL = m[7].Y;
            chinHeight = chinYL - chinYH;

            dBEXL = m[8].X;
            dBEXR = m[9].X;
            distanceBtwEyes = dBEXR - dBEXL;

            eyebYL = m[10].Y;
            eyebYR = m[11].Y;
            eyeB = eyebYR - eyebYL;

            noseWXL = m[12].X;
            noseWXR = m[13].X;
            noseWidth = noseWXR - noseWXR;

            eyeCenterHYL = m[14].Y;
            eyeCenterHYR = m[15].Y;
            eyeCenter = eyeCenterHYR - eyeCenterHYL;

            /*
            Перша лінія - висота вуха
            Друга лінія - довжина носа
            */

            earHYH = m2[0].Y;
            earHYL = m2[1].Y;
            earHeight = earHYL - earHYH;
            noseHeight = m2[3].Y - m2[2].Y;

            //додаткові розрахунки
            distanceEyesNNose = m2[3].Y - eyeCenter;
            
            /*
            1ша перевірка - співвідношення висоти лиця до ширини. Ідеал - 1.61
            */

            if ((faceHeight / faceWidth) <= 1.65 & (faceHeight / faceWidth) >= 1.57)
            {
                result[0] = 0;
            } 
            else
            {
                result[0] = 1;
            }


            //перевірка чи підборіддя дорівнює ширині ока
            if (chinHeight <= eyeWidth + 20 & chinHeight >= eyeWidth - 20)
            {
                result[2] = 0;
            }
            else
            {
                result[2] = 1;
            }

            //Перевірка чи відстань між очима дорівнює ширині ока

            if ( distanceBtwEyes == eyeWidth )
            {
                result[3] = 0;
            }
            else
            {
                result[3] = 1;
            }

            //перевірка на те чи висота вух дорівнює відстані між лінією очей та носа
            if ((earHeight >= (distanceEyesNNose - 20)) & (earHeight <= (distanceEyesNNose + 20)))
            {
                result[4] = 0;
            }
            else
            {
                result[4] = 1;
            }

            //перевірка чи ділить око лице на дві рівні частини 
            if ((eyeCenter - faceHYH) >= ((faceHYL - eyeCenter) - 20) & (eyeCenter - faceHYH) <= ((faceHYL - eyeCenter) + 20))
            {
                result[5] = 0;
            }  
            else
            {
                result[5] = 1;
            }

            //перевірка чи ділиться лице на три рівні частини
            if ( ((eyeB - faceHYH) >= (m2[3].Y - eyeB - 20) ) & ((eyeB - faceHYH) <= (m2[3].Y - eyeB + 20)) & ((eyeB - faceHYH) >= (faceHYL - m2[3].Y - 20)) & ((eyeB - faceHYH) <= (faceHYL - m2[3].Y + 20)))
            {
                result[6] = 0;
            }
            else
            {
                result[6] = 1;
            }


            int res = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    res++;
                }
            }

            if (res > 0)
            {
                richTextBox.Text = "Згідно з тестуванням ви набрали " + res + " балa з " + result.Length + "\n";
            } else
            {
                richTextBox.Text = "Лице не відповідає стандартам краси";
            }

            richTextBox.AppendText("Висота - " + faceHeight + "\n");
            richTextBox.AppendText("Ширина - " + faceWidth + "\n");
            richTextBox.AppendText("ВІдношення - " + faceHeight/faceWidth + "\n");

        }


        bool flagDown = false;
        Graphics g;
        Graphics g2;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        System.Drawing.Point first;
        System.Drawing.Point second;
        List<Point> m = new List<Point>();
        List<Point> m2 = new List<Point>();

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (m2.Count < 4)
                if (!flagDown)
                {
                    first.X = e.X;
                    first.Y = e.Y;
                    flagDown = true;
                }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (flagDown)
            {
                second.X = e.X;
                second.Y = e.Y;
                flagDown = false;

               
                g2.DrawLine(new Pen(Color.Red, 2), first, second);

                m2.Add(first);
                m2.Add(second);
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Remove2 == true)
            {
                var s1 = m2.ElementAt(0);
                var s2 = m2.ElementAt(0 + 1);
                g2.DrawLine(new Pen(Color.Red, 2), s1, s2);
                Remove2 = false;
            }
            if (flagDown)
            {
                second.X = e.X;
                second.Y = e.Y;

            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (m.Count < 16) 
            if (!flagDown)
            {
                first.X = e.X;
                first.Y = e.Y;
                flagDown = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (flagDown)
            {
                second.X = e.X;
                second.Y = e.Y;
                flagDown = false;

                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(new Pen(Color.AliceBlue, 2), first, second);

                m.Add(first);
                m.Add(second);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Remove1 == true)
            {
                for (int i = 0; m.Count < i; i++)
                {
                    if (i == 0)
                    {
                        var s1 = m.ElementAt(i);
                        var s2 = m.ElementAt(i + 1);
                        g.DrawLine(new Pen(Color.White, 2), s1, s2);
                    }
                    else {
                        var s1 = m.ElementAt(i+1);
                        var s2 = m.ElementAt(i + 2);
                        g.DrawLine(new Pen(Color.White, 2), s1, s2);
                    }
                    
                    Remove1 = false;
                }
            }
            if (flagDown)
            {
                second.X = e.X;
                second.Y = e.Y;

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g2 = pictureBox2.CreateGraphics();
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (Remove2 == true)
            {
                var s1 = m2.ElementAt(0);
                var s2 = m2.ElementAt(0 + 1);
                g.DrawLine(new Pen(Color.White, 2), s1, s2);
                Remove2 = false;
            }

        }

       

        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadfile();
        }

        private void завантажитиФотоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadfile();
        }

        private void loadfile ()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath2 = openFileDialog.FileName;
                    pictureBox1.Load(filePath2);
                }
               
            }
        }

    }
}