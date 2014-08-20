using System;
using SHEMO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class TransportasiController : Controller
    {
        kape_SHEMOEntities context = new kape_SHEMOEntities();
        private IEnumerable<TRANSPORTASI> GetAllDataTransportasi()
        {
            IEnumerable<TRANSPORTASI> results = from b in context.TRANSPORTASIs
                                          select b;
            return results;
        }

        private IEnumerable<KATEGORI_TRANSPORTASI> GetAllDataKategoriTransportasi()
        {
            IEnumerable<KATEGORI_TRANSPORTASI> results = from b in context.KATEGORI_TRANSPORTASI
                                                   select b;
            return results;
        }

        private IEnumerable<GAMBAR_TRANSPORTASI> GetAllDataGambarTransportasi()
        {
            IEnumerable<GAMBAR_TRANSPORTASI> results = from b in context.GAMBAR_TRANSPORTASI
                                                        select b;
            return results;
        }

        public ActionResult detail(string ID)
        {
            IEnumerable<TRANSPORTASI> transportasi = GetAllDataTransportasi();
            IEnumerable<GAMBAR_TRANSPORTASI> transportasiGambar = GetAllDataGambarTransportasi();

            if (ID != null)
            {
                int idTransportasi = int.Parse(ID);
                foreach (var data in transportasi)
                {
                    if (data.ID_TRANSPORTASI == idTransportasi)
                    {
                        ViewBag.judul = data.NAMA_PERUSAHAAN_TRANSPORTASI;

                        foreach (var temp in transportasiGambar)
                        {
                            if (temp.ID_TRANSPORTASI == data.ID_TRANSPORTASI)
                            {
                                ViewBag.alamatGambar = "../content/image/transportasi/" + temp.GAMBAR_TRANSPORTASI1;
                                break;
                            }
                        }
                        ViewBag.telepon = "Telepon : " + data.NOMOR_TELEPON_TRANSPORTASI;
                        ViewBag.ruteAsal = "Rute Asal : " + data.RUTE_ASAL;
                        ViewBag.ruteTujuan = "Rute Tujuan : " + data.RUTE_TUJUAN;
                        ViewBag.jam = "Jam Operasi : " + data.JAM_OPERASIONAL;
                        return View();
                    }
                }
            }
            return View("error");
            //return View();
        }

        public ActionResult kategori(string jenisKategori)
        {
            IEnumerable<KATEGORI_TRANSPORTASI> transportasiKategori = GetAllDataKategoriTransportasi();
            IEnumerable<TRANSPORTASI> transportasi = GetAllDataTransportasi();
            IEnumerable<GAMBAR_TRANSPORTASI> transportasiGambar = GetAllDataGambarTransportasi();
            int idKategori;

            List<List<string>> listGambar = new List<List<string>>();
            List<string> gambar;
            foreach (var data in transportasiKategori)
            {
                ViewBag.judul = "Transportasi - " + jenisKategori;
                if (jenisKategori == data.NAMA_KATEGORI_TRANSPORTASI)
                {
                    idKategori = data.ID_KATEGORI_TRANSPORTASI;
                    foreach (var tempData in transportasi)
                    {
                        if (tempData.ID_KATEGORI_TRANSPORTASI == idKategori)
                        {
                            gambar = new List<string>();
                            gambar.Add("../detail/" + tempData.ID_TRANSPORTASI.ToString());
                            foreach (var tempDataGambar in transportasiGambar)
                            {
                                if (tempDataGambar.ID_TRANSPORTASI == tempData.ID_TRANSPORTASI)
                                {
                                    gambar.Add("../content/image/transportasi/" + tempDataGambar.GAMBAR_TRANSPORTASI1);
                                }
                            }
                            listGambar.Add(gambar);
                        }
                    }
                    ViewBag.gambar = listGambar;
                    return View();
                }
            }

            return View("Error");

            //IEnumerable<GAMBAR_TEMPAT_WISATA> wisataKategori = GetAllDataGambarTempatWisata();

            //List<string> datas = new List<string>();
            //List<string> data1 = new List<string>();
            //data1.Add("Halo");
            //data1.Add("Bro");
            ////foreach (var data in wisataKategori)
            ////{
            ////    datas.Add(data.NAMA_WISATA);
            ////}


            //ViewBag.judul = wisataKategori.Count();
            //return View();
        }


        //
        // GET: /Transportasi/
        public ActionResult Index()
        {
            ViewBag.judul = "Daftar Jenis Transportasi";
            IEnumerable<KATEGORI_TRANSPORTASI> transportasiKategori = GetAllDataKategoriTransportasi();

            List<List<string>> daftarJenisKategori = new List<List<string>>();
            List<string> jenisKategoriWisata;
            int number = 1;
            foreach (var data in transportasiKategori)
            {
                if (data.ID_KATEGORI_TRANSPORTASI != 0)
                {
                    jenisKategoriWisata = new List<string>();
                    string pilihan = "#pilihan" + number;
                    jenisKategoriWisata.Add(data.NAMA_KATEGORI_TRANSPORTASI);
                    jenisKategoriWisata.Add(pilihan);
                    number++;
                    daftarJenisKategori.Add(jenisKategoriWisata);
                }
            }
            ViewBag.daftarJenisTransportasi = daftarJenisKategori;

            IEnumerable<GAMBAR_TRANSPORTASI> transportasiGambar = GetAllDataGambarTransportasi();

            IEnumerable<TRANSPORTASI> transportasi = GetAllDataTransportasi();

            daftarJenisKategori = new List<List<string>>();
            number = 1;

            List<int> daftarIDWisata;
            Random rnd = new Random();
            int rand;
            foreach (var temp in transportasiKategori)
            {
                if (temp.ID_KATEGORI_TRANSPORTASI != 0)
                {
                    jenisKategoriWisata = new List<string>();
                    string pilihan = "pilihan" + number;

                    daftarIDWisata = new List<int>();
                    foreach (var data in transportasi)
                    {
                        if (data.ID_KATEGORI_TRANSPORTASI == number)
                        {
                            daftarIDWisata.Add(data.ID_TRANSPORTASI);
                        }
                    }
                    rand = rnd.Next(daftarIDWisata.Count);

                    foreach (var data in transportasi)
                    {
                        if (data.ID_TRANSPORTASI == daftarIDWisata[rand])
                        {
                            jenisKategoriWisata.Add(data.NAMA_PERUSAHAAN_TRANSPORTASI);
                            break;
                        }
                    }
                    jenisKategoriWisata.Add(pilihan);

                    foreach (var data in transportasiGambar)
                    {
                        if (data.ID_TRANSPORTASI == daftarIDWisata[rand])
                        {
                            jenisKategoriWisata.Add("../content/image/transportasi/" + data.GAMBAR_TRANSPORTASI1);
                        }
                    }

                    number++;
                    jenisKategoriWisata.Add("/transportasi/kategori/" + temp.NAMA_KATEGORI_TRANSPORTASI);
                    jenisKategoriWisata.Add("/transportasi/detail/" + daftarIDWisata[rand]);
                    daftarJenisKategori.Add(jenisKategoriWisata);
                }
            }
            ViewBag.namaTransportasi = daftarJenisKategori;
            return View();
       }
	}
}