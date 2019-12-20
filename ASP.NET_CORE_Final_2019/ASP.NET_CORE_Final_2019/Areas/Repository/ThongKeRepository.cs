using ASP.NET_CORE_Final_2019.Areas.Services;
using ASP.NET_CORE_Final_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.Areas.Repository
{
    public class ThongKeRepository : IThongKe
    {
        private VEGEFOOD_DBContext db;

        public ThongKeRepository(VEGEFOOD_DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Thongkengay> GetThongkengays => db.Thongkengay;

        public IEnumerable<DateTime> GetDates()
        {
            List<DateTime> check = new List<DateTime>();
            IEnumerable<Donhang> list = db.Donhang;
            foreach(Donhang item in list)
            {
                int flag= 0;
                foreach(DateTime fl in check)
                {
                    if (fl.ToShortDateString()==item.Ngay.ToShortDateString())
                    {
                        flag = 1;
                    }
                    if (flag == 1) { break; }
                }
                if (flag == 0)
                {
                    check.Add(item.Ngay);
                    yield return item.Ngay;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
