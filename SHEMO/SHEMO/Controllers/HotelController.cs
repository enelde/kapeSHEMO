using System;
using SHEMO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class HotelController : Controller
    {
        kape_SHEMOEntities context = new kape_SHEMOEntities();
        private IEnumerable<HOTEL> GetAllDataHotel()
        {
            IEnumerable<HOTEL> results = from b in context.HOTELs
                                         select b;
            return results;
        }

        private IEnumerable<GAMBAR_HOTEL> GetAllDataGambarHotel()
        {
            IEnumerable<GAMBAR_HOTEL> results = from b in context.GAMBAR_HOTEL
                                                select b;
            return results;
        }

        public ActionResult detail(string ID)
        {
            IEnumerable<HOTEL> hotel = GetAllDataHotel();
            IEnumerable<GAMBAR_HOTEL> hotelGambar = GetAllDataGambarHotel();

            if (ID != null)
            {
                int idWisata = int.Parse(ID);
                foreach (var data in hotel)
                {
                    if (data.ID_HOTEL == idWisata)
                    {
                        ViewBag.judul = data.NAMA_HOTEL;

                        foreach (var temp in hotelGambar)
                        {
                            if (temp.ID_HOTEL == data.ID_HOTEL)
                            {
                                ViewBag.alamatGambar = "../content/image/hotel/" + temp.GAMBAR_HOTEL1;
                                break;
                            }
                        }
                        ViewBag.website = "Website : " + data.WEBSITE;
                        ViewBag.telepon = "Telepon : " + data.TELEPON_HOTEL;
                        return View();
                    }
                }
            }
            return View("error");
            //return View();
        }


        public ActionResult kategori(string jenisKategori)
        {
            IEnumerable<HOTEL> dataHotel = GetAllDataHotel();            
            IEnumerable<GAMBAR_HOTEL> hotelGambar = GetAllDataGambarHotel();

            int idHotel;
            List<List<string>> listGambar = new List<List<string>>();
            List<string> gambar;
            ViewBag.judul = "HOTEL Berbintang " + jenisKategori;
            foreach (var data in dataHotel)
            {                
                if (jenisKategori == data.BINTANG.ToString())
                {

                    idHotel = data.ID_HOTEL; 
                    foreach(var data1 in hotelGambar)
                    {
                        if(data1.ID_HOTEL==idHotel)
                        {
                            gambar = new List<string>();
                            gambar.Add("../detail/" + idHotel.ToString());
                            gambar.Add("../content/image/hotel/" + data1.GAMBAR_HOTEL1);                                                            
                            listGambar.Add(gambar);
                        }
                    }
                }
            }
            ViewBag.gambar = listGambar;
            return View();            

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
        // GET: /Hotel/
        public ActionResult Index()
        {
            ViewBag.judul = "Daftar Jenis Hotel";
            IEnumerable<HOTEL> dataHotel = GetAllDataHotel();

            List<List<string>> daftarJenisKategori = new List<List<string>>();
            List<string> jenisKategoriHotel;
            int number = 1;
            foreach (var data in dataHotel)
            {                
                if(data.BINTANG != null)
                {
                    string temp = "" + data.BINTANG;
                    int check = 0;
                    foreach (var data1 in daftarJenisKategori)
                    {
                        if (temp == data1[0])
                        {
                            check = 1;
                            break;
                        }
                    }
                    if (check == 0)
                    {
                        jenisKategoriHotel = new List<string>();
                        string pilihan = "#pilihan" + number;
                        string jenis = "" + data.BINTANG;
                        jenisKategoriHotel.Add(jenis);
                        jenisKategoriHotel.Add(pilihan);
                        number++;
                        daftarJenisKategori.Add(jenisKategoriHotel);
                    }    
                }                                    
            }
            ViewBag.daftarJenisHotel = daftarJenisKategori;

            IEnumerable<GAMBAR_HOTEL> hotelGambar = GetAllDataGambarHotel();

            //IEnumerable<WISATA> wisata = GetAllDataWisata();

            List<List<string>> daftarHotel = new List<List<string>>();
            //daftarJenisKategori = new List<List<string>>();
            number = 1;
            
            Random rnd = new Random();
            int rand;
            foreach (var temp in daftarJenisKategori)
            {

                jenisKategoriHotel = new List<string>();
                string pilihan = "pilihan" + number;

                while(true)
                {
                    rand = rnd.Next(dataHotel.Count());
                    int count = 0, check=0;
                    foreach(var temp1 in dataHotel)
                    {
                        if(count==rand)
                        {
                            string bintang = ""+temp1.BINTANG;
                            if(bintang == temp[0])
                            {
                                jenisKategoriHotel.Add(temp1.NAMA_HOTEL);
                                jenisKategoriHotel.Add(pilihan);
                                foreach(var temp2 in hotelGambar)
                                {
                                    if(temp2.ID_HOTEL == temp1.ID_HOTEL)
                                    {
                                        jenisKategoriHotel.Add("../content/image/hotel/" + temp2.GAMBAR_HOTEL1);
                                        jenisKategoriHotel.Add("/hotel/kategori/" + temp[0]);
                                        jenisKategoriHotel.Add("/hotel/detail/" + temp2.ID_HOTEL);
                                        break;
                                    }
                                }
                                check = 1;
                                break;
                            }
                        }
                        count++;
                    }
                    if(check==1)
                    {
                        break;
                    }
                }                                         

                number++;                
                daftarHotel.Add(jenisKategoriHotel);

            }
            ViewBag.namaHotel = daftarHotel;
            return View();
        }
	}
}