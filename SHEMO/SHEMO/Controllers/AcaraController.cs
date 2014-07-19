using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class AcaraController : Controller
    {
        //
        // GET: /Acara/
        public ActionResult Index()
        {
            ViewBag.judul = "Acara Surabaya";
            
            List<string> jenisBulan = new List<string>();
            jenisBulan.Add("Januari");
            jenisBulan.Add("Februari");
            jenisBulan.Add("Maret");
            jenisBulan.Add("April");
            jenisBulan.Add("Mei");
            jenisBulan.Add("Juni");
            jenisBulan.Add("Juli");
            jenisBulan.Add("Agustus");
            jenisBulan.Add("September");
            jenisBulan.Add("Oktober");
            jenisBulan.Add("November");
            jenisBulan.Add("Desember");
            
            ViewBag.daftarBulan = jenisBulan;

            List<string> daftarTahun = new List<string>();
            daftarTahun.Add("2011");
            daftarTahun.Add("2012");
            daftarTahun.Add("2013");
            daftarTahun.Add("2014");
            daftarTahun.Add("2015");

            ViewBag.daftarTahun = daftarTahun;
            return View();
        }
	}
}
