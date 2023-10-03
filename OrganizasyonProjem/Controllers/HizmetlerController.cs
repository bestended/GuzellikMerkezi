using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using OrganizasyonProjem.Models;
namespace OrganizasyonProjem.Controllers
{
    public class HizmetlerController : Controller
    {
        public ActionResult Liste()
        {

            return View(Dap.Listeleme<HizmetlerSet>("HizmetlerListele"));
        }

        public ActionResult GorevliEY(int id = 0)
        {

            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("HizmetNo", id);
                return View(Dap.Listeleme<HizmetlerSet>("HizmetlerGetirNo", param).FirstOrDefault<HizmetlerSet>());

            }


        }


        [HttpPost]
        public ActionResult GorevliEY(HizmetlerSet hizmet)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@HizmetNo", hizmet.HizmetNo);
                param.Add("@HizmetAdi", hizmet.HizmetAdi);
                param.Add("@HizmetAmaci", hizmet.HizmetAmaci);
                param.Add("@HizmetGider", hizmet.HizmetGider);
                param.Add("@OdemeTuru", hizmet.OdemeTuru);
                param.Add("@GörevliNo", hizmet.GörevliNo);


                Dap.ExecuteReturn("HizmetlerEY", param);
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

                param.Add("HizmetNo", id);
                Dap.ExecuteReturn("HizmetlerSil", param);
                return RedirectToAction("Liste");
            }
            catch 
            {

                return View();
            }
            


        }





    }
}