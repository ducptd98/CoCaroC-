using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCoCaro
{
    public partial class frmCoCaro : Form
    {
        private CaroChess caroChess;
        private Graphics grs;
        public frmCoCaro()
        {
            InitializeComponent();
            caroChess = new CaroChess();
            caroChess.KhoiTaoMangOco();
            grs = pnBanCo.CreateGraphics();
            bnPvP.Click += new EventHandler(PvP);
            playerVsComToolStripMenuItem.Click += new EventHandler(PvC);
            bnPvC.Click += new EventHandler(PvC);
        }

        private void @new(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tmChuChay_Tick(object sender, EventArgs e)
        {
            lbChuChay.Location = new Point(lbChuChay.Location.X,lbChuChay.Location.Y-1);
            if(lbChuChay.Location.Y+lbChuChay.Height<0)
            {
                lbChuChay.Location = new Point(lbChuChay.Location.X, pnLaw.Height);
            }
        }

        private void frmCoCaro_Load(object sender, EventArgs e)
        {
            lbChuChay.Text = "Xin chào các bạn đến\n với trò chơi cờ caro";
            tmChuChay.Enabled = true;
            
        }

        private void pnBanCo_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang) return;
            if(caroChess.DanhCo(e.X, e.Y, grs))
            {
                if (caroChess.KiemtraChienThang()) caroChess.KetThucTroChoi(caroChess.CheDoChoi);
                if (caroChess.CheDoChoi == 2)
                {
                    caroChess.KhoiDongCOM(grs);
                    if (caroChess.KiemtraChienThang()) caroChess.KetThucTroChoi(caroChess.CheDoChoi);
                }
            }
        }

        private void PvP(object sender, EventArgs e)
        {
            grs.Clear(pnBanCo.BackColor);
            caroChess.StartPvsP(grs);
        }
        private void PvC(object sender, EventArgs e)
        {
            grs.Clear(pnBanCo.BackColor);
            caroChess.StartPvsC(grs);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //grs.Clear(pnBanCo.BackColor);
            caroChess.Undo(grs);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caroChess.Redo(grs);
        }


    }
}
