using SHEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEMO.Controllers
{
    public class AcaraController : Controller
    {
        kape_SHEMOEntities context = new kape_SHEMOEntities();

        private IEnumerable<MONTH_EVENT> GetAllDataMonthEvent()
        {
            IEnumerable<MONTH_EVENT> results = from b in context.MONTH_EVENT
                                          select b;
            return results;
        }

        private IEnumerable<GAMBAR_EVENT> GetAllDataGambarMonthEvent()
        {
            IEnumerable<GAMBAR_EVENT> results = from b in context.GAMBAR_EVENT
                                                   select b;
            return results;
        }

        public ActionResult detail(string ID)
        {
            IEnumerable<MONTH_EVENT> monthEvent = GetAllDataMonthEvent();
            IEnumerable<GAMBAR_EVENT> monthEventGambar = GetAllDataGambarMonthEvent();

            if (ID != null)
            {
                int idMonthEvent = int.Parse(ID);
                foreach (var data in monthEvent)
                {
                    if (data.ID_MONTH_EVENT == idMonthEvent)
                    {
                        ViewBag.judul = data.NAMA_EVENT;

                        foreach (var temp in monthEventGambar)
                        {
                            if (temp.ID_MONTH_EVENT == data.ID_MONTH_EVENT)
                            {
                                ViewBag.alamatGambar = "../content/image/monthevent/" + temp.GAMBAR_EVENT1;
                                break;
                            }
                        }
                        ViewBag.telepon = "Telepon : " + data.TELEPON_EVENT;
                        ViewBag.tanggalMulai = "Tanggal Mulai : " + data.TANGGAL_MULAI;
                        ViewBag.tanggalBerakhir = "Tanggal Berakhir : " + data.TANGGAL_BERAKHIR;
                        ViewBag.lokasi = "Lokasi : " + data.LOKASI_EVENT;
                        return View();
                    }
                }
            }
            return View("error");
            //return View();
        }

        public ActionResult kategori(string jenisKategori)
        {
            IEnumerable<MONTH_EVENT> monthEvent = GetAllDataMonthEvent();
            IEnumerable<GAMBAR_EVENT> monthEventGambar = GetAllDataGambarMonthEvent();

            List<string> jenisBulan = new List<string>();
            jenisBulan.Add("Januari");
            jenisBulan.Add("Februari");
            jenisBulan.Add("Maret");
            jenisBulan.Add("April");
            jenisBulan.Add("Mei");
            jenisBulan.Add("Juni");
            jenisBulan.Add("Juli");
            jenisBulan.Add("Agustus");
            jenisBulan.Add("September");
            jenisBulan.Add("Oktober");
            jenisBulan.Add("November");
            jenisBulan.Add("Desember");

            List<List<string>> listGambar = new List<List<string>>();
            List<string> gambar;
            ViewBag.judul = "Month Event - " + jenisKategori;

            int count=1,bulan=0;
            foreach(var data in jenisBulan)
            {
                if(data == jenisKategori)
                {
                    bulan = count;
                    break;
                }
                count++;
            }

            foreach (var data in monthEvent)
            {
                string[] temp = data.TANGGAL_MULAI.ToString().Split('/');
                int tempNumber = int.Parse(temp[0]);
                if(tempNumber==bulan)
                {
                    foreach(var tempData in monthEventGambar)
                    {
                        if(tempData.ID_MONTH_EVENT == data.ID_MONTH_EVENT)
                        {
                            gambar = new List<string>();
                            gambar.Add("../detail/" + data.ID_MONTH_EVENT);
                            gambar.Add("../content/image/monthevent/" + tempData.GAMBAR_EVENT1);
                            listGambar.Add(gambar);
                        }
                    }
                }
            }

            ViewBag.gambar = listGambar;
            return View();
                        
        }

        //
        // GET: /Acara/
        public ActionResult Index()
        {
            ViewBag.judul = "Month Event 2014 Surabaya";
            IEnumerable<MONTH_EVENT> monthEvent = GetAllDataMonthEvent();

            List<string> jenisBulan = new List<string>();
            jenisBulan.Add("Januari");
            jenisBulan.Add("Februari");
            jenisBulan.Add("Maret");
            jenisBulan.Add("April");
            jenisBulan.Add("Mei");
            jenisBulan.Add("Juni");
            jenisBulan.Add("Juli");
            jenisBulan.Add("Agustus");
            jenisBulan.Add("September");
            jenisBulan.Add("Oktober");
            jenisBulan.Add("November");
            jenisBulan.Add("Desember");

            List<int> listNumberMonth = new List<int>();
            List<string> listBulan = new List<string>();

            foreach(var data in monthEvent)
            {
                string[] temp = data.TANGGAL_MULAI.ToString().Split('/');
                int tempNumber = int.Parse(temp[0]);
                if(listNumberMonth == null)
                {
                    listNumberMonth.Add(tempNumber);
                }
                else
                {
                    int check = 0;
                    for(int i=0;i<listNumberMonth.Count;i++)
                    {
                        if(listNumberMonth[i]==tempNumber)
                        {
                            check = 1;
                            break;
                        }
                    }
                    if(check==0)
                    {
                        listNumberMonth.Add(tempNumber);
                    }
                }
                
            }

            for (int i = 1; i <= 12;i++ )
            {
                foreach(var data in listNumberMonth)
                {
                    if(i==data)
                    {
                        listBulan.Add(jenisBulan[i - 1]);
                        break;
                    }
                }
            }

            ViewBag.daftarBulan = listBulan;
            ViewBag.angka = listNumberMonth;
            return View();
        }
	}
}
