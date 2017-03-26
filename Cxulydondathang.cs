using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thuctapdemoGiaoDien
{
    class Cxulydondathang
    {
        private databaseDataContext dc = new databaseDataContext();
        public List<DonDatHang> getcmbDDH(String ma)
        {
            List<DonDatHang> lstDDH = new List<DonDatHang>();
            foreach(DonDatHang a in dc.DonDatHangs.Where(x=>x.MaKH==ma))
            {
                lstDDH.Add(a);
            }
            return lstDDH;
        }
        public DonDatHang timDDHTheoMa(string ma)
        {
            foreach(DonDatHang a in dc.DonDatHangs.Where(x=>x.MaDDH==ma))
            {
                return a;
            }
            return null;
        }
    }
}
