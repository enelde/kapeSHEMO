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
            IEnumerable<KATEGORI_WISATA> wisataKategori = GetAllDataKategoriWisata();
            IEnumerable<WISATA> wisata = GetAllDataWisata();
            IEnumerable<GAMBAR_TEMPAT_WISATA> wisataGambar = GetAllDataGambarTempatWisata();
            int idKategori;

            List<List<string>> listGambar = new List<List<string>>();
            List<string> gambar;
            foreach(var data in wisataKategori)
            {
                ViewBag.judul = "WISATA " + jenisKategori;
                if(jenisKategori == data.KATEGORI_WISATA1)
                {
                    idKategori = data.ID_KATEGORI_WISATA;
                    foreach(var tempData in wisata)
                    {                        
                        if(tempData.ID_KATEGORI_WISATA == idKategori)
                        {
                            gambar = new List<string>();
                            gambar.Add("../detail/" + tempData.ID_WISATA.ToString());
                            foreach(var tempDataGambar in wisataGambar)
                            {
                                if(tempDataGambar.ID_WISATA == tempData.ID_WISATA)
                                {
                                    gambar.Add("../content/image/wisata/" + tempDataGambar.GAMBAR_WISATA);
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

        public ActionResult detail(string ID)
        {
            IEnumerable<WISATA> wisata = GetAllDataWisata();
            IEnumerable<GAMBAR_TEMPAT_WISATA> wisataGambar = GetAllDataGambarTempatWisata();

            if (ID != null)
            {
                int idWisata = int.Parse(ID);
                foreach (var data in wisata)
                {
                    if (data.ID_WISATA == idWisata)
                    {
                        ViewBag.judul = data.NAMA_WISATA;                         

                        foreach (var temp in wisataGambar)
                        {
                            if (temp.ID_WISATA == data.ID_WISATA)
                            {
                                ViewBag.alamatGambar = "../content/image/wisata/" + temp.GAMBAR_WISATA;                                
                                break;
                            }
                        }
                        ViewBag.deskripsi = "Deskripsi : " + data.DESKRIPSI_WISATA;
                        ViewBag.alamat = "Lokasi : " + data.LOKASI_WISATA;                      
                        return View();
                    }
                }
            }
            return View("error");
            //return View();
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

            IEnumerable<WISATA> wisata = GetAllDataWisata();

            daftarJenisKategori = new List<List<string>>();            
            number = 1;

            List<int> daftarIDWisata;
            Random rnd = new Random();
            int rand;
            foreach(var temp in wisataKategori)
            {
                if(temp.ID_KATEGORI_WISATA!=0)
                {
                    jenisKategoriWisata = new List<string>();
                    string pilihan = "pilihan" + number;

                    daftarIDWisata = new List<int>();
                    foreach (var data in wisata)
                    {
                        if (data.ID_KATEGORI_WISATA == number)
                        {
                            daftarIDWisata.Add(data.ID_WISATA);
                        }
                    }
                    rand = rnd.Next(daftarIDWisata.Count);

                    foreach (var data in wisata)
                    {
                        if (data.ID_WISATA == daftarIDWisata[rand])
                        {
                            jenisKategoriWisata.Add(data.NAMA_WISATA);
                            break;
                        }
                    }
                    jenisKategoriWisata.Add(pilihan);

                    foreach (var data in wisataGambar)
                    {
                        if (data.ID_WISATA == daftarIDWisata[rand])
                        {
                            jenisKategoriWisata.Add("../content/image/wisata/" + data.GAMBAR_WISATA);
                        }
                    }

                    number++;
                    jenisKategoriWisata.Add("/wisata/kategori/"+temp.KATEGORI_WISATA1);
                    jenisKategoriWisata.Add("/wisata/detail/"+daftarIDWisata[rand]);
                    daftarJenisKategori.Add(jenisKategoriWisata);
                }
            } 
            ViewBag.namaWisata = daftarJenisKategori;            
            return View();
        }
	}
}