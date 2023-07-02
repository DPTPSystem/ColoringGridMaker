using System.Windows.Forms;

namespace System
{
    internal class MouseEventArgs
    {
        private Action<object, Windows.Forms.MouseEventArgs> pictureBox2_MouseHover;

        public MouseEventArgs(Action<object, Windows.Forms.MouseEventArgs> pictureBox2_MouseHover)
        {
            this.pictureBox2_MouseHover = pictureBox2_MouseHover;
        }
    }
}