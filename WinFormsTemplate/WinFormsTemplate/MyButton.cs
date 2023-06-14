using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTemplate
{
    internal class MyButton : Button
    {
        int c = 0;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), this.ClientRectangle);
            pevent.Graphics.FillEllipse(Brushes.YellowGreen, this.ClientRectangle);

            var sf = new StringFormat() { Alignment = StringAlignment.Center,LineAlignment=StringAlignment.Center};
            pevent.Graphics.DrawString(Text+$"{c++}", SystemFonts.DefaultFont, new SolidBrush(ForeColor), ClientRectangle,sf);
        }
    }
}
