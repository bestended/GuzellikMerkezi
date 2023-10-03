using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using OrganizasyonProjem.Models;

namespace OrganizasyonProjem.Controllers
{
    public class SalonlarController : Controller
    {
        public ActionResult Liste()
        {

            return View(Dap.Listeleme<SalonlarSet>("SalonlarListele"));
        }

        public ActionResult GorevliEY(int id = 0)
        {

            try
            {
                if (id == 0)
                {
                    return View();
                }

                else
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("SalonNo", id);
                    return View(Dap.Listeleme<SalonlarSet>("SalonlarGetirNo", param).FirstOrDefault<SalonlarSet>());

                }
            }
            catch 
            {

                return View();
            }
       


        }


        [HttpPost]
        public ActionResult GorevliEY(SalonlarSet salon)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SalonNo", salon.SalonNo);
                param.Add("@SalonAdi", salon.SalonAdi);
                param.Add("@SalonKapiNo", salon.SalonKapiNo);
                param.Add("@YapilanIslem", salon.YapilanIslem);
                param.Add("@IslemSayisi", salon.IslemSayisi);



                Dap.ExecuteReturn("SalonlarEY", param);
                return RedirectToAction("Liste");
            }
            catch 
            {

                return View();
            }

           

        }

        public ActionResult Sil(int id = 0)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("SalonNo", id);
                Dap.ExecuteReturn("SalonlarSil", param);
                return RedirectToAction("Liste");
            }
            catch 
            {

                return View();
            }

           


        }

    }
    
}