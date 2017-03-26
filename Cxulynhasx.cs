using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thuctapdemoGiaoDien
{
    class Cxulynhasx
    {
        private databaseDataContext dc = new databaseDataContext();

        public List<string> getMansx()
        {
            List<string> b = new List<string>();
            foreach(NhaSanXuat a in dc.NhaSanXuats)
            {
                b.Add(a.MaNSX);
            }
            return b;
        }
        public IEnumerable<object> getDSNhaSanXuat()
        {
            return dc.NhaSanXuats.ToList();
        }
        public string phatsinhma()
        {
            string so = "";
            var kq = dc.NhaSanXuats.OrderByDescending(x => x.MaNSX).Take(1);
            if (kq.Count() <= 0) so = "NSX0001";
            else
            {
                foreach (NhaSanXuat a in kq.ToList())
                {
                    string s = a.MaNSX.Substring(3);
                    int n = int.Parse(s) + 1;
                    so = "NSX" + n.ToString("D4");

                    break;
                }
            }
            return so;
        }
        public void Them(NhaSanXuat a)
        {
            dc.NhaSanXuats.InsertOnSubmit(a);
            dc.SubmitChanges();
        }

        public void Xoa(NhaSanXuat a)
        {
            dc.NhaSanXuats.DeleteOnSubmit(a);
            dc.SubmitChanges();

        }
        public void Sua(NhaSanXuat nsx)
        {
            foreach (NhaSanXuat a in dc.NhaSanXuats.Where(x => x.MaNSX == nsx.MaNSX))
            {
                a.TenNSX = nsx.TenNSX;
                a.DiaChi = nsx.DiaChi;
                a.SDT = nsx.SDT;
                a.MaNSX = nsx.MaNSX;            
                dc.SubmitChanges();
            }
        }
        public NhaSanXuat Tim(NhaSanXuat nsx)
        {
            foreach (NhaSanXuat a in dc.NhaSanXuats.Where(x => x.MaNSX == nsx.MaNSX))
            {
                if (a != null)
                    return a;
            }
          
            return null;
          
        }
        public List<NhaSanXuat> getDSNSXTracuu(NhaSanXuat a,string strMa,string strTen)
        {
            List<NhaSanXuat> b = new List<NhaSanXuat>();
            if (strTen == "")
            {
                foreach (NhaSanXuat r in dc.NhaSanXuats.Where(x => x.MaNSX.Contains(strMa)))
                {

                    NhaSanXuat e = b.Find(x => x.MaNSX == r.MaNSX);
                    if (e == null)
                    {

                        b.Add(r);

                    }
                }
                return b;
            }
            else if(strMa=="")
            {
                foreach (NhaSanXuat k in dc.NhaSanXuats.Where(x => x.TenNSX.Contains(strTen)))
                {
                    NhaSanXuat e = b.Find(x => x.MaNSX == k.MaNSX);
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
                foreach (NhaSanXuat r in dc.NhaSanXuats.Where(x => x.MaNSX.Contains(strMa)))
                {

                    NhaSanXuat e = b.Find(x => x.MaNSX == r.MaNSX);
                    if (e == null)
                    {

                        b.Add(r);

                    }
                }
                foreach (NhaSanXuat k in dc.NhaSanXuats.Where(x => x.TenNSX.Contains(strTen)))
                {
                    NhaSanXuat e = b.Find(x => x.MaNSX == k.MaNSX);
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
