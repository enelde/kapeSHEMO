using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class RumahMakanController : Controller
    {
        //
        // GET: /RumahMakan/
        public ActionResult Index()
        {
            ViewBag.judul = "Daftar Jenis Rumah Makan";

            List<List<string>> daftarJenis = new List<List<string>>();
            List<string> jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("Surabaya Pusat");
            jenisRumahMakan.Add("#pilihan1");
            daftarJenis.Add(jenisRumahMakan);

            jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("Surabaya Barat");
            jenisRumahMakan.Add("#pilihan2");
            daftarJenis.Add(jenisRumahMakan);

            jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("Surabaya Utara");
            jenisRumahMakan.Add("#pilihan3");
            daftarJenis.Add(jenisRumahMakan);

            jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("Surabaya Timur");
            jenisRumahMakan.Add("#pilihan4");
            daftarJenis.Add(jenisRumahMakan);

            jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("Surabaya Selatan");
            jenisRumahMakan.Add("#pilihan5");
            daftarJenis.Add(jenisRumahMakan);

            ViewBag.daftarJenisRumahMakan = daftarJenis;

            daftarJenis = new List<List<string>>();
            jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("Blue Bird");
            jenisRumahMakan.Add("pilihan1");
            jenisRumahMakan.Add("../content/image/contoh/Blue-Bird.jpg");
            daftarJenis.Add(jenisRumahMakan);

            jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("Bu RUdi");
            jenisRumahMakan.Add("pilihan2");
            jenisRumahMakan.Add("../content/image/contoh/Bu-Rudi.jpg");
            daftarJenis.Add(jenisRumahMakan);

            jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("Jembatan Suramadu");
            jenisRumahMakan.Add("pilihan3");
            jenisRumahMakan.Add("../content/image/contoh/Jembatan-Suramadu.jpg");
            daftarJenis.Add(jenisRumahMakan);

            jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("gray");
            jenisRumahMakan.Add("pilihan4");
            jenisRumahMakan.Add("../content/image/contoh/gray.jpg");
            daftarJenis.Add(jenisRumahMakan);

            jenisRumahMakan = new List<string>();
            jenisRumahMakan.Add("Mall Tunjungan Plaza");
            jenisRumahMakan.Add("pilihan5");
            jenisRumahMakan.Add("../content/image/contoh/Tunjungan-Plaza.jpg");
            daftarJenis.Add(jenisRumahMakan);

            ViewBag.namaRumahMakan = daftarJenis;
            return View();
        }
	}
}