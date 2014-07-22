﻿using SHEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class HomeController : Controller
    {
        kape_SHEMOEntities context = new kape_SHEMOEntities();

        private IEnumerable<TOP_WISATA> getAllTopWisata()
        {
            IEnumerable<TOP_WISATA> results = from b in context.TOP_WISATA
                                          select b;
            return results;
        }

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


        public ActionResult Index()
        {
            ViewBag.deskripsiPortal = "\"Jer Basuki Mawa Bea\" are the words emblazoning the emblem of East Java. Translated. they mean that achievements are only won through sacrifice. This is certainly an appropriate motto, especially for the people of Surabaya. the \'City of Heroes\'. whose history of struggle against foreign invaders is well known.\nSurabaya is the commercial and administrative capital of East Java, a thriving business and industrial centre and the province's main port. Second only to Jakarta in size and importance, the city has a population of around 2.5 million residents. From the port area of Tanjung Perak ferries leave regularly for Madura, and air services to and from Surabaya\'s Juanda Airport connect the city with Jakarta, Yogyakarta, Bali and other parts of Indonesia.\nSurabaya is a progressive capital undergoing rapid change. Former negative reports about the city from foreign visitors are thus clearly unwarranted today. In fact, Surabaya now enjoys the reputation as being the cleanest city in Indonesia, equipped with every modern facility and offering a standard of accommodation to suit every taste and budget. Places of interest for the tourist require Kalimas harbour and Kampung Arab in the old part of town, the Mpu Tantular Museum, as well as one of the largest zoos in south east Asia.\n\nSurabaya is located at the centre of the northern coast of East Java Province, bounded to the north and east by the Java sea, the district of Gresik in the west, and by the district of the Sidoarjo in the south. The topography is mainly flat at about 3-6m above sea level, but in the west, two low ridges from west to east have an elevation of about 20-30m above sea level. The lower hill slopes have tended to be occupied by low income groups because of the low cost of site development. The high ground has become popular for high income group settlement, now that there are good access road and water supply.\n\nThe tropical climate has two main identifiable seasons. The dry season generally lasts from May to October, and the wet or rainy season from November up to April. The heaviest rains normally occur between December and January. wind velocity normally ranes from 3 to 20 knots and is relatively constant throughout the year. The mean annual rainfall is 1,321 mm, and the highest monthly mean rainfall is about 260 mm, usually in January. The lowest temperature, usually in February, is about 25.5 celcius and the highest temperature is 33.0 celcius in October. The average annual temperature is 27.8 celcius.\n\nSurabayas dominant roles, both national and regional, have changed little since it emerged as a major administrative and trading centre of the East Indies in the early 18th century. The development of urban Surabaya since this time has therefore been related to study growth to meet increasing demand, rather than any change in role or function. Since the governments 1960s city policy, Surabaya has functioned as an industrial, commercial, maritime, education and government city. This multi-function policy has required Surabaya to provide land for industrial areas and infrastructure support facilities.\n\nCommercial trading in Surabaya has an important role for the development of Eastern Indonesia, and especially for East Java. The primary trade activities covering the large area from the port in the north to the city center is wholesale trading of products.";
            ViewBag.judulDeskripsiPortal = "Portal Surabaya";

            ViewBag.judulTopWisata = "Tempat Favorit Wisata";
            List<List<string>> topWisata = new List<List<string>>();

            IEnumerable<TOP_WISATA> top = getAllTopWisata();
            IEnumerable<GAMBAR_TEMPAT_WISATA> gambarWisata = GetAllDataGambarTempatWisata();
            IEnumerable<WISATA> wisata = GetAllDataWisata();
            List<string> wisataTerima;
            foreach(var dataTop in top)
            {
                wisataTerima = new List<string>();
                foreach(var dataWisata in wisata)
                {
                    if(dataTop.ID_WISATA == dataWisata.ID_WISATA)
                    {
                        wisataTerima.Add(dataWisata.NAMA_WISATA);
                        wisataTerima.Add("");
                        String desc = dataWisata.DESKRIPSI_WISATA;

                        //difiltern desc

                        wisataTerima.Add(desc);

                        foreach(var dataGambar in gambarWisata)
                        {
                            if(dataGambar.ID_WISATA == dataTop.ID_WISATA)
                            {
                                wisataTerima.Add("../content/image/wisata/" + dataGambar.GAMBAR_WISATA);
                                wisataTerima.Add("/wisata/detail/" + dataGambar.ID_WISATA.ToString());
                            }
                        }
                    }
                }
                topWisata.Add(wisataTerima);
            }
            ViewBag.topWisata = topWisata;

            IEnumerable<KATEGORI_WISATA> wisataKategori = GetAllDataKategoriWisata();
            ViewBag.judulKategori = "Kategori Surabaya";

            List<List<string>> kategoriList = new List<List<string>>();
            List<string> kategori;
            List<int> tempData;
            Random rnd = new Random();
            int rand;
            foreach(var datakategori in wisataKategori)
            {                
                if(datakategori.ID_KATEGORI_WISATA!=0)
                {
                    kategori = new List<string>();
                    tempData = new List<int>();
                    foreach(var tempDataKategori in wisata)
                    {
                        if(tempDataKategori.ID_KATEGORI_WISATA == datakategori.ID_KATEGORI_WISATA)
                        {
                            tempData.Add(tempDataKategori.ID_WISATA);
                        }
                    }
                    rand = rnd.Next(tempData.Count);

                    kategori.Add(datakategori.KATEGORI_WISATA1);
                    kategori.Add(datakategori.KATEGORI_WISATA1);
                    foreach(var tempData1 in gambarWisata)
                    {
                        if(tempData1.ID_WISATA == tempData[rand])
                        {
                            kategori.Add("../content/image/wisata/" + tempData1.GAMBAR_WISATA);
                        }
                    }
                    kategori.Add("/wisata/detail/"+tempData[rand].ToString());
                    kategoriList.Add(kategori);                    
                }
            }


            ViewBag.kategori = kategoriList;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}