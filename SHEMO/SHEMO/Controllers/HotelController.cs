using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/
        public ActionResult Index()
        {
            ViewBag.judul = "Daftar Jenis Hotel";

            List<List<string>> daftarJenis = new List<List<string>>();
            List<string> jenisHotel = new List<string>();
            jenisHotel.Add("Surabaya Pusat");
            jenisHotel.Add("#pilihan1");
            daftarJenis.Add(jenisHotel);

            jenisHotel = new List<string>();
            jenisHotel.Add("Surabaya Barat");
            jenisHotel.Add("#pilihan2");
            daftarJenis.Add(jenisHotel);

            jenisHotel = new List<string>();
            jenisHotel.Add("Surabaya Utara");
            jenisHotel.Add("#pilihan3");
            daftarJenis.Add(jenisHotel);

            jenisHotel = new List<string>();
            jenisHotel.Add("Surabaya Timur");
            jenisHotel.Add("#pilihan4");
            daftarJenis.Add(jenisHotel);

            jenisHotel = new List<string>();
            jenisHotel.Add("Surabaya Selatan");
            jenisHotel.Add("#pilihan5");
            daftarJenis.Add(jenisHotel);

            ViewBag.daftarJenisHotel = daftarJenis;

            daftarJenis = new List<List<string>>();
            jenisHotel = new List<string>();
            jenisHotel.Add("Blue Bird");
            jenisHotel.Add("pilihan1");
            jenisHotel.Add("../content/image/contoh/Blue-Bird.jpg");
            daftarJenis.Add(jenisHotel);

            jenisHotel = new List<string>();
            jenisHotel.Add("Bu RUdi");
            jenisHotel.Add("pilihan2");
            jenisHotel.Add("../content/image/contoh/Bu-Rudi.jpg");
            daftarJenis.Add(jenisHotel);

            jenisHotel = new List<string>();
            jenisHotel.Add("Jembatan Suramadu");
            jenisHotel.Add("pilihan3");
            jenisHotel.Add("../content/image/contoh/Jembatan-Suramadu.jpg");
            daftarJenis.Add(jenisHotel);

            jenisHotel = new List<string>();
            jenisHotel.Add("gray");
            jenisHotel.Add("pilihan4");
            jenisHotel.Add("../content/image/contoh/gray.jpg");
            daftarJenis.Add(jenisHotel);

            jenisHotel = new List<string>();
            jenisHotel.Add("Mall Tunjungan Plaza");
            jenisHotel.Add("pilihan5");
            jenisHotel.Add("../content/image/contoh/Tunjungan-Plaza.jpg");
            daftarJenis.Add(jenisHotel);

            ViewBag.namaHotel = daftarJenis;

            return View();
        }
	}
}