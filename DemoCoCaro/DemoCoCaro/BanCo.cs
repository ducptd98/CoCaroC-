using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCoCaro
{
    class BanCo
    {
        private int _SoDong;
        private int _SoCot;

        public BanCo()
        {
            _SoCot = 0;
            _SoDong = 0;
        }
        public BanCo(int sodong, int socot)
        {
            _SoDong = sodong;
            _SoCot = socot;
        }

        public int SoDong { get => _SoDong; }
        public int SoCot { get => _SoCot; }

        public void VeBanCo(Graphics g)
        {
            for(int i=0; i<=SoCot;i++)
            {
                g.DrawLine(CaroChess.pen, i * Oco._ChieuRong, 0, i * Oco._ChieuRong, SoDong * Oco._ChieuCao);
            }
            for (int j = 0; j <= SoCot; j++)
            {
                g.DrawLine(CaroChess.pen, 0, j*Oco._ChieuCao,SoCot*Oco._ChieuRong, j * Oco._ChieuCao);
            }
        }
        public void VeQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            g.FillEllipse(sb, point.X+1, point.Y+1, Oco._ChieuRong-4, Oco._ChieuCao-4);
        }
        public void XoaQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            g.FillRectangle(sb,point.X + 1, point.Y + 1, Oco._ChieuRong - 4, Oco._ChieuCao - 4);
        }
    }
}
