using SHEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class RumahMakanController : Controller
    {
        kape_SHEMOEntities context = new kape_SHEMOEntities();
        private IEnumerable<RUMAH_MAKAN> GetAllDataRumahMakan()
        {
            IEnumerable<RUMAH_MAKAN> results = from b in context.RUMAH_MAKAN
                                          select b;
            return results;
        }

        private IEnumerable<KATEGORI_RUMAH_MAKAN> GetAllDataKategoriRumahMakan()
        {
            IEnumerable<KATEGORI_RUMAH_MAKAN> results = from b in context.KATEGORI_RUMAH_MAKAN
                                                   select b;
            return results;
        }

        private IEnumerable<GAMBAR_RUMAH_MAKAN> GetAllDataGambarRumahMakan()
        {
            IEnumerable<GAMBAR_RUMAH_MAKAN> results = from b in context.GAMBAR_RUMAH_MAKAN
                                                        select b;
            return results;
        }

        private IEnumerable<MAKANAN> GetAllDataMakanan()
        {
            IEnumerable<MAKANAN> results = from b in context.MAKANANs
                                                      select b;
            return results;
        }

        private IEnumerable<MINUMAN> GetAllDataMinuman()
        {
            IEnumerable<MINUMAN> results = from b in context.MINUMen
                                                      select b;
            return results;
        }

        private IEnumerable<RM___MAKANAN> GetAllDataRMMakanan()
        {
            IEnumerable<RM___MAKANAN> results = from b in context.RM___MAKANAN
                                                      select b;
            return results;
        }

        private IEnumerable<RM___MINUMAN> GetAllDataRMMinuman()
        {
            IEnumerable<RM___MINUMAN> results = from b in context.RM___MINUMAN
                                                      select b;
            return results;
        }

        public ActionResult detail(string ID)
        {
            IEnumerable<RUMAH_MAKAN> rumahMakan = GetAllDataRumahMakan();
            IEnumerable<GAMBAR_RUMAH_MAKAN> rumahMakanGambar = GetAllDataGambarRumahMakan();
            IEnumerable<MAKANAN> makanan = GetAllDataMakanan();
            IEnumerable<RM___MAKANAN> rmMakanan = GetAllDataRMMakanan();
            IEnumerable<MINUMAN> minuman = GetAllDataMinuman();
            IEnumerable<RM___MINUMAN> rmMinuman = GetAllDataRMMinuman();

            if (ID != null)
            {
                int idRumahMakan = int.Parse(ID);
                foreach (var data in rumahMakan)
                {
                    if (data.ID_RUMAH_MAKAN == idRumahMakan)
                    {
                        ViewBag.judul = data.NAMA_RUMAH_MAKAN;

                        foreach (var temp in rumahMakanGambar)
                        {
                            if (temp.ID_RUMAH_MAKAN == data.ID_RUMAH_MAKAN)
                            {
                                ViewBag.alamatGambar = "../content/image/rumahmakan/" + temp.GAMBAR_RUMAH_MAKAN1;
                                break;
                            }
                        }
                        ViewBag.alamat = "Alamat : " + data.ALAMAT_RUMAH_MAKAN;
                        ViewBag.telepon = "Telepon : " + data.TELEPON_RUMAH_MAKAN;
                        List<int> idMakanan = new List<int>();
                        List<int> idMinuman = new List<int>();
                        foreach(var data1 in rmMakanan)
                        {
                            if(data1.ID_RUMAH_MAKAN == idRumahMakan)
                            {
                                idMakanan.Add(data1.ID_MAKANAN);
                            }
                        }

                        foreach (var data1 in rmMinuman)
                        {
                            if (data1.ID_RUMAH_MAKAN == idRumahMakan)
                            {
                                idMinuman.Add(data1.ID_MINUMAN);
                            }
                        }

                        List<string> listMakanan = new List<string>();
                        foreach(var data1 in idMakanan)
                        {
                            foreach(var tempMakanan in makanan)
                            {
                                if(data1 == tempMakanan.ID_MAKANAN)
                                {
                                    listMakanan.Add("- "+tempMakanan.NAMA_MAKANAN);
                                }
                            }
                        }
                        ViewBag.listMakanan = listMakanan;

                        List<string> listMinuman = new List<string>();
                        foreach (var data1 in idMinuman)
                        {
                            foreach (var tempMinuman in minuman)
                            {
                                if (data1 == tempMinuman.ID_MINUMAN)
                                {
                                    listMinuman.Add("- " + tempMinuman.MINUMAN1);
                                }
                            }
                        }
                        ViewBag.listMinuman = listMinuman;
                        ViewBag.judulListMakanan = "List Makanan yang tersedia:";
                        ViewBag.judulListMinuman = "List Minuman yang tersedia:";
                        return View();
                    }
                }
            }
            return View("error");
            //return View();
        }


        public ActionResult kategori(string jenisKategori)
        {
            IEnumerable<KATEGORI_RUMAH_MAKAN> rumahMakanKategori = GetAllDataKategoriRumahMakan();
            IEnumerable<RUMAH_MAKAN> rumahMakan = GetAllDataRumahMakan();
            IEnumerable<GAMBAR_RUMAH_MAKAN> rumahMakanGambar = GetAllDataGambarRumahMakan();
            int idKategori;

            List<List<string>> listGambar = new List<List<string>>();
            List<string> gambar;
            foreach (var data in rumahMakanKategori)
            {
                ViewBag.judul = "Rumah Makan " + jenisKategori;
                if (jenisKategori == data.KATEGORI_RUMAH_MAKAN1)
                {
                    idKategori = data.ID_KATEGORI_RUMAH_MAKAN;
                    foreach (var tempData in rumahMakan)
                    {
                        if (tempData.ID_KATEGORI_RUMAH_MAKAN == idKategori)
                        {
                            gambar = new List<string>();
                            gambar.Add("../detail/" + tempData.ID_RUMAH_MAKAN.ToString());
                            foreach (var tempDataGambar in rumahMakanGambar)
                            {
                                if (tempDataGambar.ID_RUMAH_MAKAN == tempData.ID_RUMAH_MAKAN)
                                {
                                    gambar.Add("../content/image/rumahmakan/" + tempDataGambar.GAMBAR_RUMAH_MAKAN1);
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
        // GET: /RumahMakan/
        public ActionResult Index()
        {
            ViewBag.judul = "Daftar Jenis Rumah Makan";

            IEnumerable<KATEGORI_RUMAH_MAKAN> rumahMakanKategori = GetAllDataKategoriRumahMakan();

            List<List<string>> daftarJenisKategori = new List<List<string>>();
            List<string> jenisKategoriRumahMakan;
            int number = 1;
            foreach (var data in rumahMakanKategori)
            {
                if (data.ID_KATEGORI_RUMAH_MAKAN != 0)
                {
                    jenisKategoriRumahMakan = new List<string>();
                    string pilihan = "#pilihan" + number;
                    jenisKategoriRumahMakan.Add(data.KATEGORI_RUMAH_MAKAN1);
                    jenisKategoriRumahMakan.Add(pilihan);
                    number++;
                    daftarJenisKategori.Add(jenisKategoriRumahMakan);
                }
            }
            ViewBag.daftarJenisRumahMakan = daftarJenisKategori;


            IEnumerable<GAMBAR_RUMAH_MAKAN> rumahMakanGambar = GetAllDataGambarRumahMakan();

            IEnumerable<RUMAH_MAKAN> rumahMakan = GetAllDataRumahMakan();

            daftarJenisKategori = new List<List<string>>();
            number = 1;

            List<int> daftarIDRumahMakan;
            Random rnd = new Random();
            int rand;
            foreach (var temp in rumahMakanKategori)
            {
                if (temp.ID_KATEGORI_RUMAH_MAKAN != 0)
                {
                    jenisKategoriRumahMakan = new List<string>();
                    string pilihan = "pilihan" + number;

                    daftarIDRumahMakan = new List<int>();
                    foreach (var data in rumahMakan)
                    {
                        if (data.ID_KATEGORI_RUMAH_MAKAN == number)
                        {
                            daftarIDRumahMakan.Add(data.ID_RUMAH_MAKAN);
                        }
                    }
                    rand = rnd.Next(daftarIDRumahMakan.Count);

                    foreach (var data in rumahMakan)
                    {
                        if (data.ID_RUMAH_MAKAN == daftarIDRumahMakan[rand])
                        {
                            jenisKategoriRumahMakan.Add(data.NAMA_RUMAH_MAKAN);
                            break;
                        }
                    }
                    jenisKategoriRumahMakan.Add(pilihan);

                    foreach (var data in rumahMakanGambar)
                    {
                        if (data.ID_RUMAH_MAKAN == daftarIDRumahMakan[rand])
                        {
                            jenisKategoriRumahMakan.Add("../content/image/rumahmakan/" + data.GAMBAR_RUMAH_MAKAN1);
                        }
                    }

                    number++;
                    jenisKategoriRumahMakan.Add("/rumahmakan/kategori/" + temp.KATEGORI_RUMAH_MAKAN1);
                    jenisKategoriRumahMakan.Add("/rumahmakan/detail/" + daftarIDRumahMakan[rand]);
                    daftarJenisKategori.Add(jenisKategoriRumahMakan);
                }
            }
            ViewBag.namaRumahMakan = daftarJenisKategori;
            return View();

        }
	}
}