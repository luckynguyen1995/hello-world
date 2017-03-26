using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thuctapdemoGiaoDien
{
    class Cxulyvattu
    {
        private databaseDataContext dc = new databaseDataContext();

        public IEnumerable<object> getDSVatTu()
        {
            return dc.VatTus.ToList();
        }
        public string phatsinhma()
        {
            string so = "";
            var kq = dc.VatTus.OrderByDescending(x => x.MaVT).Take(1);
            if (kq.Count() <= 0) so = "VT0001";
            else
            {
                foreach (VatTu a in kq.ToList())
                {
                    string s = a.MaVT.Substring(2);
                    int n = int.Parse(s) + 1;
                    so = "VT" + n.ToString("D4");

                    break;
                }
            }
            return so;
        }
        public void Them(VatTu a)
        {
            dc.VatTus.InsertOnSubmit(a);
            dc.SubmitChanges();
        }

        public void Xoa(VatTu a)
        {
            dc.VatTus.DeleteOnSubmit(a);
            dc.SubmitChanges();

        }
        public void Sua(VatTu kh)
        {
            foreach (VatTu a in dc.VatTus.Where(x => x.MaVT == kh.MaVT))
            {
                a.TenVT = kh.TenVT;
                a.DVTinh = kh.DVTinh;
                a.DonGia = kh.DonGia;
                a.SoLuong = kh.SoLuong;
                a.MaNSX = kh.MaNSX;
                dc.SubmitChanges();
            }
        }
        public VatTu Tim(VatTu kh)
        {
            foreach (VatTu a in dc.VatTus.Where(x => x.MaVT == kh.MaVT))
            {
                if (a != null)
                    return a;
            }
            return null;
        }
        public List<VatTu> getDSVTTracuu(VatTu a,string strMa,string strTen)
        {
            List<VatTu> b = new List<VatTu>();
            if (strTen == "")
            {
                foreach (VatTu r in dc.VatTus.Where(x => x.MaVT.Contains(strMa)))
                {

                    VatTu e = b.Find(x => x.MaVT == r.MaVT);
                    if (e == null)
                    {

                        b.Add(r);

                    }
                }
                return b;
            }
            else if (strMa == "")
            {
                foreach (VatTu k in dc.VatTus.Where(x => x.TenVT.Contains(strTen)))
                {
                    VatTu e = b.Find(x => x.MaVT == k.MaVT);
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
                foreach (VatTu r in dc.VatTus.Where(x => x.MaVT.Contains(strMa)))
                {

                    VatTu e = b.Find(x => x.MaVT == r.MaVT);
                    if (e == null)
                    {

                        b.Add(r);

                    }
                }
                foreach (VatTu k in dc.VatTus.Where(x => x.TenVT.Contains(strTen)))
                {
                    VatTu e = b.Find(x => x.MaVT == k.MaVT);
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
