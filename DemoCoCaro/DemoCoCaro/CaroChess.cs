using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCoCaro
{
    public enum KetThuc
    {
        Hoa,
        P1,
        P2,
        COM
    }
    class CaroChess
    {
        public static SolidBrush sbWhite;
        public static SolidBrush sbBlack;
        public static Pen pen;

        private BanCo _BanCo;
        private Oco[,] _MangOco;

        private Stack<Oco> stack_CacNuocDaDi;
        private int _LuotDi;
        private bool _SanSang;
        private Stack<Oco> stack_CacNuocUndo;
        private KetThuc _ketThuc;
        private int _CheDoChoi;

        public bool SanSang { get => _SanSang; }
        public int CheDoChoi { get => _CheDoChoi; set => _CheDoChoi = value; }

        public CaroChess()
        {
            pen = new Pen(Color.Green);
            sbWhite = new SolidBrush(Color.White);
            sbBlack = new SolidBrush(Color.Black);
            _BanCo = new BanCo(16,16);
            _MangOco = new Oco[_BanCo.SoDong, _BanCo.SoCot];
            stack_CacNuocDaDi = new Stack<Oco>();
            stack_CacNuocUndo = new Stack<Oco>();
            _LuotDi = 1;
        }

        public void VeBanCo(Graphics g)
        {
            _BanCo.VeBanCo(g);
        }
        public void KhoiTaoMangOco()
        {
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    _MangOco[i, j] = new Oco(i,j,new Point(j*Oco._ChieuRong,i*Oco._ChieuCao),0);
                }
            }
        }
        public bool DanhCo(int MouseX, int MouseY, Graphics g)
        {
            if (MouseX % Oco._ChieuRong == 0 || MouseY % Oco._ChieuCao == 0) return false;
            int cot = MouseX / Oco._ChieuRong;
            int dong = MouseY / Oco._ChieuCao;
            if (_MangOco[dong, cot].SoHuu != 0) return false;

            switch(_LuotDi)
            {
                case 1:
                    _MangOco[dong, cot].SoHuu = 1;
                    _BanCo.VeQuanCo(g, _MangOco[dong, cot].ViTri, sbBlack);
                    _LuotDi = 2;
                    break;
                case 2:
                    _MangOco[dong, cot].SoHuu = 2;
                    _BanCo.VeQuanCo(g, _MangOco[dong, cot].ViTri, sbWhite);
                    _LuotDi = 1;
                    break;
                default:
                    MessageBox.Show("Fail");
                    break;
            }
            stack_CacNuocUndo = new Stack<Oco>();
            stack_CacNuocDaDi.Push(_MangOco[dong, cot]);
            return true;
        }
        public void VeLaiQuanCo(Graphics g)
        {
            foreach(Oco oco in stack_CacNuocDaDi)
            {
                if(oco.SoHuu==1)
                    _BanCo.VeQuanCo(g, oco.ViTri, sbBlack);
                else if(oco.SoHuu==2) _BanCo.VeQuanCo(g, oco.ViTri, sbWhite);
            }
        }
        public void StartPvsP(Graphics g)
        {
            _SanSang = true;
            stack_CacNuocDaDi = new Stack<Oco>();
            stack_CacNuocUndo = new Stack<Oco>(); 
            _LuotDi = 1;
            KhoiTaoMangOco();
            VeBanCo(g);
            _CheDoChoi = 1;
        }
        public void StartPvsC(Graphics g)
        {
            _SanSang = true;
            stack_CacNuocDaDi = new Stack<Oco>();
            stack_CacNuocUndo = new Stack<Oco>();
            _LuotDi = 1;
            KhoiTaoMangOco();
            VeBanCo(g);
            _CheDoChoi = 2;
            KhoiDongCOM(g);
        }
        public void Undo(Graphics g)
        {
            if (stack_CacNuocDaDi.Count != 0)
            {
                Oco oco = stack_CacNuocDaDi.Pop();
                stack_CacNuocUndo.Push(new Oco(oco.Dong,oco.Cot,oco.ViTri,oco.SoHuu));
                _MangOco[oco.Dong, oco.Cot].SoHuu = 0;
                _BanCo.XoaQuanCo(g, oco.ViTri, new SolidBrush(Color.FromArgb(0,192,0)));
                if (_LuotDi == 1) _LuotDi = 2; else _LuotDi = 1;
            }
        }
        public void Redo(Graphics g)
        {
            if (stack_CacNuocUndo.Count != 0)
            {
                Oco oco = stack_CacNuocUndo.Pop();
                stack_CacNuocDaDi.Push(new Oco(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                _MangOco[oco.Dong, oco.Cot].SoHuu = oco.SoHuu;
                _BanCo.VeQuanCo(g, oco.ViTri, oco.SoHuu == 1 ? sbBlack : sbWhite);
                if (_LuotDi == 1) _LuotDi = 2; else _LuotDi = 1;
            }
        }
        #region Duyệt thắng thua
        public void KetThucTroChoi(int chedo)
        {
            switch(_ketThuc)
            {
                case KetThuc.Hoa: MessageBox.Show("Hoà"); break;
                case KetThuc.P1:
                    
                    if (chedo == 1)
                        MessageBox.Show("P1 Thắng");
                    else MessageBox.Show("COM Thang");
                        break;
                case KetThuc.P2: MessageBox.Show("P2 Thắng"); break;
                case KetThuc.COM: MessageBox.Show("COM thắng"); break;
            }
            _SanSang = false;
        }
        public bool KiemtraChienThang()
        {
            if (stack_CacNuocDaDi.Count == _BanCo.SoCot*_BanCo.SoDong)
            {
                _ketThuc = KetThuc.Hoa;
                return true;
            }

            foreach(Oco oco in stack_CacNuocDaDi)
            {
                if(DuyetDoc(oco.Dong, oco.Cot, oco.SoHuu)||DuyetNgang(oco.Dong, oco.Cot, oco.SoHuu)||DuyetCheoXuoi(oco.Dong, oco.Cot, oco.SoHuu)||DuyetCheoNguoc(oco.Dong, oco.Cot, oco.SoHuu))
                {
                    _ketThuc = oco.SoHuu == 1 ? KetThuc.P1 : KetThuc.P2;
                    return true;
                }
            }

            return false;
        }
        private bool DuyetDoc(int curDong, int curCot, int curSoHuu)
        {
            if (curDong > _BanCo.SoDong - 5) return false;
            int dem = 1;
            for(dem = 1;dem<5;dem++)
            {
                if (_MangOco[curDong + dem, curCot].SoHuu != curSoHuu) return false;
            }
            if (curDong == 0||curDong+dem==_BanCo.SoDong) return true;
            if (_MangOco[curDong - 1, curCot].SoHuu == 0 ||
                _MangOco[curDong + dem, curCot].SoHuu == 0) return true;
            return false;
        }
        private bool DuyetNgang(int curDong, int curCot, int curSoHuu)
        {
            if (curCot > _BanCo.SoCot - 5) return false;
            int dem = 1;
            for (dem = 1; dem < 5; dem++)
            {
                if (_MangOco[curDong, curCot + dem].SoHuu != curSoHuu) return false;
            }
            if (curCot == 0 || curCot + dem == _BanCo.SoCot) return true;
            if (_MangOco[curDong , curCot-1].SoHuu == 0 ||
                _MangOco[curDong, curCot + dem].SoHuu == 0) return true;
            return false;
        }
        private bool DuyetCheoXuoi(int curDong, int curCot, int curSoHuu)
        {
            if (curDong> _BanCo.SoDong-5 || curCot > _BanCo.SoCot - 5) return false;
            int dem = 1;
            for (dem = 1; dem < 5; dem++)
            {
                if (_MangOco[curDong + dem, curCot + dem].SoHuu != curSoHuu) return false;
            }
            if (curCot == 0 || curCot + dem == _BanCo.SoCot || curCot == 0 || curCot + dem == _BanCo.SoCot) return true;
            if (_MangOco[curDong-1, curCot - 1].SoHuu == 0 ||
                _MangOco[curDong+dem, curCot + dem].SoHuu == 0) return true;
            return false;
        }
        private bool DuyetCheoNguoc(int curDong, int curCot, int curSoHuu)
        {
            if (curDong < 4 || curCot > _BanCo.SoCot - 5) return false;
            int dem = 1;
            for (dem = 1; dem < 5; dem++)
            {
                if (_MangOco[curDong - dem , curCot + dem].SoHuu != curSoHuu) return false;
            }
            if (curDong==4||curDong==_BanCo.SoDong-1||curCot==0 || curCot+dem==_BanCo.SoCot) return true;
            if (_MangOco[curDong+1, curCot - 1].SoHuu == 0 ||
                _MangOco[curDong - dem, curCot + dem].SoHuu == 0) return true;
            return false;
        }
        #endregion

        #region AI
        private long[] _ArrAttact = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008 }; //{ 0, 3, 24, 192, 1536, 12288, 98304 }
        private long[] _ArrDefence = new long[7] { 0, 3, 27, 99, 729, 6561, 59049 }; // { 0, 1, 9, 81, 729, 6561, 59049 }
        public void KhoiDongCOM(Graphics g)
        {
            if(stack_CacNuocDaDi.Count==0)
            {
                DanhCo(_BanCo.SoCot / 2 * Oco._ChieuRong + 1, _BanCo.SoDong / 2 * Oco._ChieuCao + 1, g);
            }
            else
            {
                Oco oco = TimKiemNuocDi();
                DanhCo(oco.ViTri.X + 1, oco.ViTri.Y + 1, g);
            }
        }
        private Oco TimKiemNuocDi()
        {
            Oco oCoResult = new Oco();
            long DiemMax = 0;
            for(int i=0;i<_BanCo.SoDong;i++)
                for(int j=0;j<_BanCo.SoCot;j++)
                {
                    if(_MangOco[i,j].SoHuu==0)
                    {
                        long DiemATT = DiemATT_DuyetDoc(i,j) + DiemATT_DuyetCheoNguoc(i,j) + DiemATT_DuyetNgang(i,j) + DiemATT_DuyetCheoXuoi(i,j);
                        long DiemDEF= DiemDEF_DuyetDoc(i,j) + DiemDEF_DuyetCheoNguoc(i,j) + DiemDEF_DuyetNgang(i,j) + DiemDEF_DuyetCheoXuoi(i,j);
                        long temp = DiemATT > DiemDEF ? DiemATT : DiemDEF;
                        if (DiemMax < temp)
                        {
                            DiemMax = temp;
                            oCoResult = new Oco(_MangOco[i, j].Dong, _MangOco[i, j].Cot, _MangOco[i, j].ViTri, _MangOco[i,j].SoHuu);
                        }
                    }
                }

            return oCoResult;
        }
        #region ATT
        private long DiemATT_DuyetDoc(int curDong, int curCot)
        {
            long DiemTong = 0;
            int soQuanTa = 0;
            int soQuanDich = 0;
            for(int dem=1;dem<6 && curDong + dem<_BanCo.SoDong;dem++)
            {
                if (_MangOco[curDong + dem, curCot].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_MangOco[curDong + dem, curCot].SoHuu == 2)
                {
                    soQuanDich++;
                    break;
                }
                else break;
            }
            for (int dem = 1; dem < 6 && curDong - dem >=0; dem++)
            {
                if (_MangOco[curDong - dem, curCot].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_MangOco[curDong - dem, curCot].SoHuu == 2)
                {
                    soQuanDich++;
                    break;
                }
                else break;
            }
            if (soQuanDich == 2) return 0;
            DiemTong -= _ArrDefence[soQuanDich+1]*2; 
	    	DiemTong+= _ArrAttact[soQuanTa];

            return DiemTong;
        }
        private long DiemATT_DuyetNgang(int curDong, int curCot)
        {
            long DiemTong = 0;
            int soQuanTa = 0;
            int soQuanDich = 0;
            for(int dem=1;dem<6 && curCot + dem<_BanCo.SoCot;dem++)
            {
                if (_MangOco[curDong, curCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_MangOco[curDong, curCot+ dem].SoHuu == 2)
                {
                    soQuanDich++;
                    break;
                }
                else break;
            }
            for (int dem = 1; dem < 6 && curCot - dem >=0; dem++)
            {
                if (_MangOco[curDong , curCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_MangOco[curDong , curCot - dem].SoHuu == 2)
                {
                    soQuanDich++;
                    break;
                }
                else break;
            }
            if (soQuanDich == 2) return 0;
            DiemTong -= _ArrDefence[soQuanDich+1]*2; 
	    	DiemTong+= _ArrAttact[soQuanTa];

            return DiemTong;
        }
        private long DiemATT_DuyetCheoNguoc(int curDong, int curCot)
        {
            long DiemTong = 0;
            int soQuanTa = 0;
            int soQuanDich = 0;
            for (int dem = 1; dem < 6 && curCot + dem < _BanCo.SoCot && curDong-dem>=0; dem++)
            {
                if (_MangOco[curDong-dem, curCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_MangOco[curDong-dem, curCot + dem].SoHuu == 2)
                {
                    soQuanDich++;
                    break;
                }
                else break;
            }
            for (int dem = 1; dem < 6 && curCot - dem >= 0 && curDong+dem <_BanCo.SoDong; dem++)
            {
                if (_MangOco[curDong + dem, curCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_MangOco[curDong + dem, curCot - dem].SoHuu == 2)
                {
                    soQuanDich++;
                    break;
                }
                else break;
            }
            if (soQuanDich == 2) return 0;
            DiemTong -= _ArrDefence[soQuanDich + 1]*2;
            DiemTong += _ArrAttact[soQuanTa];

            return DiemTong;
        }
        private long DiemATT_DuyetCheoXuoi(int curDong, int curCot)
        {
            long DiemTong = 0;
            int soQuanTa = 0;
            int soQuanDich = 0;
            for (int dem = 1; dem < 6 && curCot + dem < _BanCo.SoCot && curDong + dem <_BanCo.SoDong; dem++)
            {
                if (_MangOco[curDong + dem, curCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_MangOco[curDong + dem, curCot + dem].SoHuu == 2)
                {
                    soQuanDich++;
                    break;
                }
                else break;
            }
            for (int dem = 1; dem < 6 && curCot - dem >= 0 && curDong - dem >=0; dem++)
            {
                if (_MangOco[curDong - dem, curCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_MangOco[curDong - dem, curCot - dem].SoHuu == 2)
                {
                    soQuanDich++;
                    break;
                }
                else break;
            }
            if (soQuanDich == 2) return 0;
            DiemTong -= _ArrDefence[soQuanDich + 1]*2;
            DiemTong += _ArrAttact[soQuanTa];

            return DiemTong;
        }
        #endregion

        #region DEF
        private long DiemDEF_DuyetDoc(int curDong, int curCot)
        {
            long DiemTong = 0;
            int soQuanTa = 0;
            int soQuanDich = 0;
            for (int dem = 1; dem < 6 && curDong + dem < _BanCo.SoDong; dem++)
            {
                if (_MangOco[curDong + dem, curCot].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_MangOco[curDong + dem, curCot].SoHuu == 2)
                {
                    soQuanDich++;
                    
                }
                else break;
            }
            for (int dem = 1; dem < 6 && curDong - dem >= 0; dem++)
            {
                if (_MangOco[curDong - dem, curCot].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_MangOco[curDong - dem, curCot].SoHuu == 2)
                {
                    soQuanDich++;
                    
                }
                else break;
            }
            if (soQuanTa == 2) return 0;
            DiemTong += _ArrDefence[soQuanDich];

            return DiemTong;
        }
        private long DiemDEF_DuyetNgang(int curDong, int curCot)
        {
            long DiemTong = 0;
            int soQuanTa = 0;
            int soQuanDich = 0;
            for (int dem = 1; dem < 6 && curCot + dem < _BanCo.SoCot; dem++)
            {
                if (_MangOco[curDong, curCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_MangOco[curDong, curCot + dem].SoHuu == 2)
                {
                    soQuanDich++;
                    
                }
                else break;
            }
            for (int dem = 1; dem < 6 && curCot - dem >= 0; dem++)
            {
                if (_MangOco[curDong, curCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_MangOco[curDong, curCot - dem].SoHuu == 2)
                {
                    soQuanDich++;
                }
                else break;
            }
            if (soQuanDich == 2) return 0;
            DiemTong += _ArrDefence[soQuanDich];

            return DiemTong;
        }
        private long DiemDEF_DuyetCheoNguoc(int curDong, int curCot)
        {
            long DiemTong = 0;
            int soQuanTa = 0;
            int soQuanDich = 0;
            for (int dem = 1; dem < 6 && curCot + dem < _BanCo.SoCot && curDong - dem >= 0; dem++)
            {
                if (_MangOco[curDong - dem, curCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_MangOco[curDong - dem, curCot + dem].SoHuu == 2)
                {
                    soQuanDich++;
                }
                else break;
            }
            for (int dem = 1; dem < 6 && curCot - dem >= 0 && curDong + dem < _BanCo.SoDong; dem++)
            {
                if (_MangOco[curDong + dem, curCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_MangOco[curDong + dem, curCot - dem].SoHuu == 2)
                {
                    soQuanDich++;
                    
                }
                else break;
            }
            if (soQuanDich == 2) return 0;
            DiemTong += _ArrDefence[soQuanDich];

            return DiemTong;
        }
        private long DiemDEF_DuyetCheoXuoi(int curDong, int curCot)
        {
            long DiemTong = 0;
            int soQuanTa = 0;
            int soQuanDich = 0;
            for (int dem = 1; dem < 6 && curCot + dem < _BanCo.SoCot && curDong + dem < _BanCo.SoDong; dem++)
            {
                if (_MangOco[curDong + dem, curCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_MangOco[curDong + dem, curCot + dem].SoHuu == 2)
                {
                    soQuanDich++;
                }
                else break;
            }
            for (int dem = 1; dem < 6 && curCot - dem >= 0 && curDong - dem >= 0; dem++)
            {
                if (_MangOco[curDong - dem, curCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_MangOco[curDong - dem, curCot - dem].SoHuu == 2)
                {
                    soQuanDich++;
                }
                else break;
            }
            if (soQuanDich == 2) return 0;
            DiemTong += _ArrDefence[soQuanDich];

            return DiemTong;
        }
        #endregion
        #endregion
    }
}
