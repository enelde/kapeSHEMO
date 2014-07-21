using SHEMO.Models;
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

        kape_SHEMOEntities context = new kape_SHEMOEntities();
        private IEnumerable<WISATA> GetAllDataWisata()
        {
            IEnumerable<WISATA> results = from b in context.WISATAs
                                        select b;
            return results;
        }

        private IEnumerable<KATEGORI_WISATA> GetAllDataKategoriWisata()
        {
            IEnumerable<KATEGORI_WISATA> results = from b in context.KATEGORI_WISATA
                                          select b;
            return results;
        }

        private IEnumerable<GAMBAR_TEMPAT_WISATA> GetAllDataGambarTempatWisata()
        {
            IEnumerable<GAMBAR_TEMPAT_WISATA> results = from b in context.GAMBAR_TEMPAT_WISATA
                                                   select b;
            return results;
        }     

        public ActionResult kategori(string jenisKategori)
        {            
            IEnumerable<GAMBAR_TEMPAT_WISATA> wisataKategori = GetAllDataGambarTempatWisata();

            List<string> datas = new List<string>();
            List<string> data1 = new List<string>();
            data1.Add("Halo");
            data1.Add("Bro");
            //foreach (var data in wisataKategori)
            //{
            //    datas.Add(data.NAMA_WISATA);
            //}


            ViewBag.judul = wisataKategori.Count();
            return View();
        }

        public ActionResult detail()
        {            
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.judul = "Daftar Jenis Wisata";
            IEnumerable<KATEGORI_WISATA> wisataKategori = GetAllDataKategoriWisata();

            List<List<string>> daftarJenisKategori = new List<List<string>>();
            List<string> jenisKategoriWisata;
            int number = 1;
            foreach(var data in wisataKategori)
            {
                if(data.ID_KATEGORI_WISATA!=0)
                {
                    jenisKategoriWisata = new List<string>();
                    string pilihan = "#pilihan" + number;
                    jenisKategoriWisata.Add(data.KATEGORI_WISATA1);
                    jenisKategoriWisata.Add(pilihan);
                    number++;
                    daftarJenisKategori.Add(jenisKategoriWisata);
                }                
            }
            ViewBag.daftarJenisWisata = daftarJenisKategori;

            IEnumerable<GAMBAR_TEMPAT_WISATA> wisataGambar = GetAllDataGambarTempatWisata();

            daftarJenisKategori = new List<List<string>>();            
            number = 1;
            foreach (var data in wisataGambar)
            {                
                    jenisKategoriWisata = new List<string>();
                    string pilihan = "pilihan" + number;
                    jenisKategoriWisata.Add(data.NAMA_GAMBAR_WISATA);
                    jenisKategoriWisata.Add(pilihan);
                    jenisKategoriWisata.Add(data.GAMBAR_WISATA);                    
                    number++;
                    daftarJenisKategori.Add(jenisKategoriWisata);                
            }
            ViewBag.namaWisata = daftarJenisKategori;            
            return View();
        }
	}
}