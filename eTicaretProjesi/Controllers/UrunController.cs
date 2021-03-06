﻿using eTicaretProjesi.BL.Repository;
using eTicaretProjesi.ENT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTicaretProjesi.Controllers
{
    public class UrunController : Controller
    {
        KategoriRepo kr = new KategoriRepo();
        UrunlerRepo ur = new UrunlerRepo();
        AltKategoriRepo akr = new AltKategoriRepo();
        // GET: Urun
        public ActionResult KategoriGetir()
        {
            var klist = kr.GenelListele().Select(x => new {
                x.KategoriID,
                x.KategoriAD,
                altKategori=x.AltKategori.Select(z=>new {
                    z.AltKategoriAD,
                    z.AltKategoriID
                })
            }).ToList();
            
            return Json(klist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UrunGetir()
        {
            var ulist = ur.GenelListele().Select(x => new {
                x.UrunAD,
                x.UrunID,
                x.UrunFiyat,
                x.UrunAciklama
            }).ToList();

            return Json(ulist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Urunler()
        {
            UrunlerViewModel model = new UrunlerViewModel();
            model.UrunlerList = ur.Listele();
            return View(model);
        }
    }
}