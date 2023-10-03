using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using OrganizasyonProjem.Models;

namespace OrganizasyonProjem.Controllers
{
    public class MalzemelerController : Controller
    {
        public ActionResult Liste()
        {

            return View(Dap.Listeleme<MalzemelerSet>("MalzemelerListe"));
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
                param.Add("MalzemeNo", id);
                return View(Dap.Listeleme<MalzemelerSet>("MalzemeGetirNo", param).FirstOrDefault<MalzemelerSet>());

            }


        }


        [HttpPost]
        public ActionResult GorevliEY(MalzemelerSet malzeme)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MalzemeNo", malzeme.MalzemeNo);
                param.Add("@MalzemeAdi", malzeme.MalzemeAdi);
                param.Add("@MalzemeGider", malzeme.MalzemeGider);
                param.Add("@HizmetNo", malzeme.HizmetNo);
                param.Add("@Fayda", malzeme.Fayda);
                param.Add("@Aciklama", malzeme.Aciklama);


                Dap.ExecuteReturn("MalzemelerEY", param);
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

                param.Add("MalzemeNo", id);
                Dap.ExecuteReturn("MalzemelerSil", param);
                return RedirectToAction("Liste");
            }
            catch 
            {

                return View();
            }
           


        }

    }
}