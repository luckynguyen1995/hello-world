using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thuctapdemoGiaoDien
{
    class Cxulynhanvien
    {

        private databaseDataContext dc = new databaseDataContext();

        public IEnumerable<object> getDSNhanVien()
        {
            return dc.NhanViens.Select(x => new NhanVienView
            {
                MaNV=x.MaNV,
                TenNV=x.TenNV,
                NgaySinh=x.NgaySinh,
                GioiTinh=x.GioiTinh?"Nam":"Nữ",
                DiaChi=x.DiaChi,
                SDT=x.SDT
            });
            
        }
        public string phatsinhma()
        {
            string so = "";
            var kq = dc.NhanViens.OrderByDescending(x => x.MaNV).Take(1);
            if (kq.Count() <= 0) so = "NV0001";
            else
            {
                foreach (NhanVien a in kq.ToList())
                {
                    string s = a.MaNV.Substring(2);
                    int n = int.Parse(s) + 1;
                    so = "NV" + n.ToString("D4");

                    break;
                }
            }
            return so;
        }
        public void Them(NhanVien a)
        {
            dc.NhanViens.InsertOnSubmit(a);
            dc.SubmitChanges();
        }

        public void Xoa(NhanVien a)
        {
            dc.NhanViens.DeleteOnSubmit(a);
            dc.SubmitChanges();

        }
        public void Sua(NhanVien nv)
        {
            foreach (NhanVien a in dc.NhanViens.Where(x => x.MaNV == nv.MaNV))
            {
                a.TenNV = nv.TenNV;
                a.GioiTinh = nv.GioiTinh;
                a.NgaySinh = nv.NgaySinh;
                a.DiaChi = nv.DiaChi;
                a.SDT = nv.SDT;
                dc.SubmitChanges();
            }
        }
        public NhanVien Tim(NhanVien nv)
        {
            foreach (NhanVien a in dc.NhanViens.Where(x => x.MaNV == nv.MaNV))
            {
                if (a != null)
                    return a;
            }
            return null;
        }
        public List<NhanVien> getDSNVTracuu(NhanVien a,string strMa,string strTen)
        {
            List<NhanVien> b = new List<NhanVien>();
            if (strTen == "")
            {
                foreach (NhanVien r in dc.NhanViens.Where(x => x.MaNV.Contains(strMa)))
                {

                    NhanVien e = b.Find(x => x.MaNV == r.MaNV);
                    if (e == null)
                    {

                        b.Add(r);

                    }
                }
                return b;
            }
            else if (strMa == "")
            {
                foreach (NhanVien k in dc.NhanViens.Where(x => x.TenNV.Contains(strTen)))
                {
                    NhanVien e = b.Find(x => x.MaNV == k.MaNV);
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
                foreach (NhanVien r in dc.NhanViens.Where(x => x.MaNV.Contains(strMa)))
                {

                    NhanVien e = b.Find(x => x.MaNV == r.MaNV);
                    if (e == null)
                    {

                        b.Add(r);

                    }
                }
                foreach (NhanVien k in dc.NhanViens.Where(x => x.TenNV.Contains(strTen)))
                {
                    NhanVien e = b.Find(x => x.MaNV == k.MaNV);
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
