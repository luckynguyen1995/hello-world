using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thuctapdemoGiaoDien
{
    class Cxulyphieuthu
    {
        private databaseDataContext dc = new databaseDataContext();
        public List<PhieuThu> getdsPTtheoDDH(string ma)
        {
            List<PhieuThu> lstPT = new List<PhieuThu>();
            foreach (PhieuThu a in dc.PhieuThus.Where(x => x.MaDDH == ma))
            {
                lstPT.Add(a);
            }
            return lstPT;
        }
        public string phatsinhma()
        {
            string soddh = "";
            var kq = dc.PhieuThus.OrderByDescending(x => x.MaPT).Take(1);
            if (kq.Count() <= 0) soddh = "PT001";
            else
            {
                foreach (PhieuThu a in kq.ToList())
                {
                    string s = a.MaPT.Substring(2);
                    int n = int.Parse(s) + 1;
                    soddh = "PT" + n.ToString("D3");

                    break;
                }
            }
            return soddh;
        }
    }
}
