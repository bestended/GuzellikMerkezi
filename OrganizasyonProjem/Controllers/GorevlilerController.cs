using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using OrganizasyonProjem.Models;
namespace OrganizasyonProjem.Controllers
{
    public class GorevlilerController : Controller
    {

      
        public ActionResult Liste()
        {

            return View(Dap.Listeleme<GörevlilerSet>("GorevliListele"));
        }

       
        public ActionResult GorevliEY(int id=0) 
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
                    param.Add("GörevliNo", id);
                    return View(Dap.Listeleme<GörevlilerSet>("GorevliGetirNo", param).FirstOrDefault<GörevlilerSet>());

                }

            }
            catch
            {

                return View();
            }

        
        }


        [HttpPost]
        public ActionResult GorevliEY(GörevlilerSet gorevli)
        {

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@GörevliNo", gorevli.GörevliNo);
                param.Add("@AdSoyad", gorevli.AdSoyad);
                param.Add("@Yas", gorevli.Yas);
                param.Add("@Telefon", gorevli.Telefon);
                param.Add("@MesaiDurum", gorevli.MesaiDurum);
                param.Add("@Maas", gorevli.Maas);
                param.Add("@Prim", gorevli.Prim);
                param.Add("@SalonNo", gorevli.SalonNo);

                Dap.ExecuteReturn("GorevliEY", param);
                return RedirectToAction("Liste");
            }
            catch 
            {

                return View();
            }


           

        }

        public ActionResult Sil(int id=0)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("GörevliNo", id);
                Dap.ExecuteReturn("GorevliSil", param);
                return RedirectToAction("Liste");
            }
            catch 
            {

                return View();
            }
            
          


        }




    }
}