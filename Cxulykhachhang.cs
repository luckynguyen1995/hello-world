using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thuctapdemoGiaoDien
{
    class Cxulykhachhang
    {
        private databaseDataContext dc = new databaseDataContext();

        public IEnumerable<object> getDSKhachhang()
        {
            return dc.KhachHangs.Select(x=>new KhachHangView
            {
                MaKH=x.MaKH,
                TenKH=x.TenKH,
                GioiTinh=x.GioiTinh?"Nam":"Nữ",
                DiaChi=x.DiaChi,
                DienThoai=x.DienThoai,
                GhiChu=x.GhiChu
            });
        }
        public string phatsinhma()
        {
            string so = "";
            var kq = dc.KhachHangs.OrderByDescending(x => x.MaKH).Take(1);
            if (kq.Count() <= 0) so = "KH0001";
            else
            {
                foreach (KhachHang a in kq.ToList())
                {
                    string s = a.MaKH.Substring(2);
                    int n = int.Parse(s) + 1;
                    so = "KH" + n.ToString("D4");

                    break;
                }
            }
            return so;
        }
        public void Them(KhachHang a)
        {
            dc.KhachHangs.InsertOnSubmit(a);
            dc.SubmitChanges();
        }

        public void Xoa(KhachHang a)
        {
            dc.KhachHangs.DeleteOnSubmit(a);
            dc.SubmitChanges();

        }
        public void Sua(KhachHang kh)
        {
            foreach (KhachHang a in dc.KhachHangs.Where(x => x.MaKH == kh.MaKH))
            {
                a.TenKH = kh.TenKH;
                a.GioiTinh = kh.GioiTinh;
                a.GhiChu = kh.GhiChu;
                a.DiaChi = kh.DiaChi;
                a.DienThoai = kh.DienThoai;
                dc.SubmitChanges();
            }
        }
        public KhachHang Tim(KhachHang kh)
        {
            foreach (KhachHang a in dc.KhachHangs.Where(x => x.MaKH == kh.MaKH))
            {
                if (a != null)
                    return a;
            }
            return null;
        }
        public List<KhachHang> getDSKHTracuu(KhachHang a, string strMa, string strTen)
        {
            List<KhachHang> b = new List<KhachHang>();
            if (strTen == "")
            {
                foreach (KhachHang r in dc.KhachHangs.Where(x => x.MaKH.Contains(strMa)))
                {

                    KhachHang e = b.Find(x => x.MaKH == r.MaKH);
                    if (e == null)
                    {

                        b.Add(r);

                    }
                }
                return b;
            }
            else if (strMa == "")
            {
                foreach (KhachHang k in dc.KhachHangs.Where(x => x.TenKH.Contains(strTen)))
                {
                    KhachHang e = b.Find(x => x.MaKH == k.MaKH);
                    if (e != null)
                    {
                        b.Remove(e);

                    }
                    b.Add(k);
                }
                return b;
            }
            else
            {
                foreach (KhachHang r in dc.KhachHangs.Where(x => x.MaKH.Contains(strMa)))
                {

                    KhachHang e = b.Find(x => x.MaKH == r.MaKH);
                    if (e == null)
                    {

                        b.Add(r);

                    }
                }
                foreach (KhachHang k in dc.KhachHangs.Where(x => x.TenKH.Contains(strTen)))
                {
                    KhachHang e = b.Find(x => x.MaKH == k.MaKH);
                    if (e != null)
                    {
                        b.Remove(e);

                    }
                    b.Add(k);
                }
                return b;
            }
        }
    }
}
