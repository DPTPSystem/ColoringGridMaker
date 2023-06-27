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
    public partial class Form1 : Form
    {
        byte[] Image1 = new byte[480 * 300 * 2];
        byte[] Image2 = new byte[480 * 300 * 2];
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
            open.Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            open.FilterIndex = 0;
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Generálás engedélyezve
                button1.Enabled = true;
                // Fájl neve
                label4.Text = Path.GetFileName(open.FileName);
                // Képet újraméretezzük
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                // Kép kirajzolása
                pictureBox1.Image = Image.FromFile(open.FileName);
            }
        }
    }
}
