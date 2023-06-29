﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace ColoringGridMaker
{
    struct ImageDef
    {
        public int width, height, size, bitPixel, StartAddr;
        public int[] Colors;
    }

    public partial class Form1 : Form
    {
        ImageDef BMP = new ImageDef();
        Bitmap bmp;
        byte[] rows;
        
        public Form1()
        {
            InitializeComponent();
            init();
        }

        // Saját inicializló eljárás, csak hogy rendezettebb legyen a kód
        private void init()
        {

            // icon beállítása
            Icon icon = new Icon("../../adatok.ico");
            this.Icon = icon;
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            trackBar1.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
        }

        // Kilépés
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Fájl betöltése
        private void fileLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open file";
            open.Filter = "BMP Files (*.bmp)|*.bmp|All Files (*.*)|*.*";
            open.FilterIndex = 0;
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Generálás engedélyezve
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                trackBar1.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                // Fájl neve
                label4.Text = Path.GetFileName(open.FileName);

                // Ha a kép nem fér bele a megadott fix keretbe
                if (Image.FromFile(open.FileName).Width > 480 || Image.FromFile(open.FileName).Height > 300)
                {
                    // Képet újraméretezzük
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                // Kép kirajzolása
                pictureBox1.Image = Image.FromFile(open.FileName);

                // Fájl byteban történő olvasása
                //byte[] rows;
                rows = System.IO.File.ReadAllBytes(open.FileName);

                // Saját BMP adat struktúra
                

                BMP.size = rows[0x05];
                BMP.size = BMP.size << 8 | rows[0x04];
                BMP.size = BMP.size << 8 | rows[0x03];
                BMP.size = BMP.size << 8 | rows[0x02];

                BMP.StartAddr = rows[0x0D];
                BMP.StartAddr = BMP.StartAddr << 8 | rows[0x0C];
                BMP.StartAddr = BMP.StartAddr << 8 | rows[0x0B];
                BMP.StartAddr = BMP.StartAddr << 8 | rows[0x0A];

                BMP.width = rows[0x15];
                BMP.width = BMP.width << 8 | rows[0x14];
                BMP.width = BMP.width << 8 | rows[0x13];
                BMP.width = BMP.width << 8 | rows[0x12];

                BMP.height = rows[0x19];
                BMP.height = BMP.height << 8 | rows[0x18];
                BMP.height = BMP.height << 8 | rows[0x17];
                BMP.height = BMP.height << 8 | rows[0x16];

                BMP.bitPixel = rows[0x1D];
                BMP.bitPixel = BMP.bitPixel << 8 | rows[0x1C];

                // Szinpaletta kinyerése
                BMP.Colors = new int[16];
                for (int i = 0; i < 16; i++)
                {
                    BMP.Colors[i] = rows[0x38+(i*4)];
                    BMP.Colors[i] = BMP.Colors[i] << 8 | rows[0x37 + (i * 4)];
                    BMP.Colors[i] = BMP.Colors[i] << 8 | rows[0x36 + (i * 4)];
                    BMP.Colors[i] = BMP.Colors[i] << 8 | rows[0x35 + (i * 4)];
                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // kép szín dekódolása
            int i = 0, r, g, b;
            int color;

            int Pix = Convert.ToInt16(textBox1.Text);
            int NewW = Pix * BMP.width;
            int NewH = Pix * BMP.height;

            if (NewW > 480 && NewH > 300)
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            label6.Text = "{" + BMP.width + " * " + BMP.height + "} -> " + "{" + NewW + " * " + NewH + "}";

            //bitmap
            bmp = new Bitmap(NewW, NewH);// BMP.width, BMP.height);
            Graphics graf = Graphics.FromImage(bmp);

            /*
            for (int y = BMP.height - 1; y >= 0; y--)
            {
                for (int x = 0; x < BMP.width; x++)
                {
                    color = BMP.Colors[rows[BMP.StartAddr + i++]];
                    r = ((color >> 24) & 0x000000FF);
                    g = ((color >> 16) & 0x000000FF);
                    b = ((color >>  8) & 0x000000FF);

                    //set ARGB value
                    bmp.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                }
            }
            */

            int TileNumber = 0;
            for (int y = BMP.height - 1; y >= 0; y--)
            {
                for (int x = 0; x < BMP.width; x++)
                {
                    TileNumber = rows[BMP.StartAddr + i++];
                    color = BMP.Colors[TileNumber];

                    r = ((color >> 24) & 0x000000FF);
                    g = ((color >> 16) & 0x000000FF);
                    b = ((color >> 8)  & 0x000000FF);

                    //set ARGB value
                    SolidBrush fill = new SolidBrush(Color.FromArgb(Convert.ToInt16(trackBar1.Value), r, g, b));
                    graf.FillRectangle(fill, Pix * x, Pix * y, Pix, Pix);
                    RectangleF rectf = new RectangleF(Pix * x, Pix * y, Pix, Pix);

                    graf.SmoothingMode = SmoothingMode.AntiAlias;

                    // The interpolation mode determines how intermediate values between two endpoints are calculated.
                    graf.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
                    graf.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    // This one is important
                    graf.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    // Create string formatting options (used for alignment)
                    StringFormat format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    
                    graf.DrawString(TileNumber.ToString("X"), new Font("Monospace", Convert.ToInt16(textBox2.Text)), Brushes.Gray, rectf, format);

                    // Flush all graphics changes to the bitmap
                    graf.Flush();
                }
            }
           

            /*
            for (i = 0; i < 16; i++)
            {
                color = BMP.Colors[i];
                r = ((color >> 24) & 0x000000FF);
                g = ((color >> 16) & 0x000000FF);
                b = ((color >>  8) & 0x000000FF);
                SolidBrush fill = new SolidBrush(Color.FromArgb(255, r, g, b));
                graf.FillRectangle(fill, 21*i, 275, 20, 20);
            }
            */

            bmp.Save("SaveImage.png");

            //load bmp in picturebox
            pictureBox2.Image = bmp;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bmp.Save("SaveImage.png");
                MessageBox.Show("Save successful!");
            }
            catch
            {
                MessageBox.Show("File save error.");
            }
            
        }
    }
}
