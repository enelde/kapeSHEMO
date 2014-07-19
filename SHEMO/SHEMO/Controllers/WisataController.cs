using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class WisataController : Controller
    {
        //
        // GET: /Wisata/

        public ActionResult kategori(string jenisKategori)
        {
            ViewBag.judul = jenisKategori;
            return View();
        }

        public ActionResult detail()
        {            
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.judul = "Daftar Jenis Wisata";

            List<List<string>> daftarJenis = new List<List<string>>();
            List<string> jenisWisata = new List<string>();
            jenisWisata.Add("Wisata Alam");
            jenisWisata.Add("#pilihan1");
            daftarJenis.Add(jenisWisata);

            jenisWisata = new List<string>();
            jenisWisata.Add("Wisata Religi");
            jenisWisata.Add("#pilihan2");
            daftarJenis.Add(jenisWisata);

            jenisWisata = new List<string>();
            jenisWisata.Add("Wisata Bersejarah");
            jenisWisata.Add("#pilihan3");
            daftarJenis.Add(jenisWisata);

            jenisWisata = new List<string>();
            jenisWisata.Add("Wisata Budaya");
            jenisWisata.Add("#pilihan4");
            daftarJenis.Add(jenisWisata);

            jenisWisata = new List<string>();
            jenisWisata.Add("Wisata Kuliner");
            jenisWisata.Add("#pilihan5");
            daftarJenis.Add(jenisWisata);

            ViewBag.daftarJenisWisata = daftarJenis;

            daftarJenis = new List<List<string>>();
            jenisWisata = new List<string>();
            jenisWisata.Add("Blue Bird");
            jenisWisata.Add("pilihan1");
            jenisWisata.Add("../content/image/contoh/Blue-Bird.jpg");
            daftarJenis.Add(jenisWisata);

            jenisWisata = new List<string>();
            jenisWisata.Add("Bu RUdi");
            jenisWisata.Add("pilihan2");
            jenisWisata.Add("../content/image/contoh/Bu-Rudi.jpg");
            daftarJenis.Add(jenisWisata);

            jenisWisata = new List<string>();
            jenisWisata.Add("Jembatan Suramadu");
            jenisWisata.Add("pilihan3");
            jenisWisata.Add("../content/image/contoh/Jembatan-Suramadu.jpg");
            daftarJenis.Add(jenisWisata);

            jenisWisata = new List<string>();
            jenisWisata.Add("gray");
            jenisWisata.Add("pilihan4");
            jenisWisata.Add("../content/image/contoh/gray.jpg");
            daftarJenis.Add(jenisWisata);

            jenisWisata = new List<string>();
            jenisWisata.Add("Mall Tunjungan Plaza");
            jenisWisata.Add("pilihan5");
            jenisWisata.Add("../content/image/contoh/Tunjungan-Plaza.jpg");
            daftarJenis.Add(jenisWisata);

            ViewBag.namaWisata = daftarJenis;
            return View();
        }
	}
}