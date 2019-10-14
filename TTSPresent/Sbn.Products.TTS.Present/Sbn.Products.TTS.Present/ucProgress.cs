using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sbn.Products.TTS.Present
{
    public partial class ucProgress : ProgressBar
    {
        public ucProgress()
        {
            InitializeComponent();
        }

        private void ucProgress_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            try
            {
                Font fm = new Font(new FontFamily("Tahoma"), 9, FontStyle.Regular);
                SizeF sf = e.Graphics.MeasureString(Main.frm.currentActivity, fm);
                PointF pfm = new PointF { X = this.Width / 2 - ((int)sf.Width) / 2, Y = 10 };
                e.Graphics.DrawString(Main.frm.currentActivity, fm,
                     new SolidBrush(Color.Black), pfm);
            }
            catch
            {

            }            

        }
    }
}
