using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ColoringGridMaker
{
    struct ImageDef
    {
        public int width, height, size, bitPixel, StartAddr;
    }

    public partial class Form1 : Form
    {
        ImageDef BMP = new ImageDef();
        byte[] rows;
        byte[] Image1 = new byte[480 * 300 * 2];
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
             
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // kép szín dekódolása
            int i = 0;
            int color;

            //bitmap
            Bitmap bmp = new Bitmap(BMP.width, BMP.height);

            //create random pixels
            for (int y = 0; y < BMP.width; y++)
            {
                for (int x = BMP.height - 1; x >= 0; x--)
                {
                    //generate random ARGB value
                    /*RRRRRRRR >> 3 --> RRRRR (5)
                      GGGGGGGG >> 2 --> GGGGGG (6)
                      BBBBBBBB >> 3 --> BBBBB (5)
                     */
                    
                    color = rows[BMP.StartAddr+i++];
                    int r = ((color & 0b11100000) >> 5);
                    int g = ((color & 0b00011100) >> 2);
                    int b =  (color & 0b00000011);


                    //set ARGB value
                    bmp.SetPixel(y, x, Color.FromArgb(255, r, g, b));
                }
            }

            //load bmp in picturebox1
            pictureBox2.Image = bmp;
        }
    }
}
