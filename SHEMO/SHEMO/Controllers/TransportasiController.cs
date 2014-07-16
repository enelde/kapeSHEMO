using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class TransportasiController : Controller
    {
        //
        // GET: /Transportasi/
        public ActionResult Index()
        {
            ViewBag.judul = "Daftar Jenis Rumah Makan";

            List<List<string>> daftarJenis = new List<List<string>>();
            List<string> jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Bus");
            jenisTransportasi.Add("#pilihan1");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Taksi");
            jenisTransportasi.Add("#pilihan2");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Angkot");
            jenisTransportasi.Add("#pilihan3");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Kereta Api");
            jenisTransportasi.Add("#pilihan4");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Pesawat");
            jenisTransportasi.Add("#pilihan5");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Kapal Laut");
            jenisTransportasi.Add("#pilihan6");
            daftarJenis.Add(jenisTransportasi);

            ViewBag.daftarJenisTransportasi = daftarJenis;

            daftarJenis = new List<List<string>>();
            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Blue Bird");
            jenisTransportasi.Add("pilihan1");
            jenisTransportasi.Add("../content/image/contoh/Blue-Bird.jpg");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Bu RUdi");
            jenisTransportasi.Add("pilihan2");
            jenisTransportasi.Add("../content/image/contoh/Bu-Rudi.jpg");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Jembatan Suramadu");
            jenisTransportasi.Add("pilihan3");
            jenisTransportasi.Add("../content/image/contoh/Jembatan-Suramadu.jpg");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("gray");
            jenisTransportasi.Add("pilihan4");
            jenisTransportasi.Add("../content/image/contoh/gray.jpg");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("Mall Tunjungan Plaza");
            jenisTransportasi.Add("pilihan5");
            jenisTransportasi.Add("../content/image/contoh/Tunjungan-Plaza.jpg");
            daftarJenis.Add(jenisTransportasi);

            jenisTransportasi = new List<string>();
            jenisTransportasi.Add("gray");
            jenisTransportasi.Add("pilihan6");
            jenisTransportasi.Add("../content/image/contoh/gray.jpg");
            daftarJenis.Add(jenisTransportasi);

            ViewBag.namaTransportasi = daftarJenis;
            return View();
        }
	}
}