using System.Diagnostics;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using MVC_Giris.Models;

namespace MVC_Giris.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // HTTPGet
    // HTTPPost
    // WEB SAYFALARI POST VE GET ILE CALISIR.
    // GET: SAYFANIN HICBIR PARAMETREYE BAGLI OLMADAN TALEP EDILMESI.
    // POST: SAYFAYA BİR PARAMETRE VEREREK SAYFANIN GONDERILMESI.

 ///////////////////////////////////////////////////////////////////////////////////////

    [HttpGet]
    public IActionResult SaveUser(){
        // BURASI GET İÇİN ÇALIŞIYOR
        // İçeride bir SaveUser modeli oluşturur ve bu modeli View'a gönderir
        // Amaç: Formu kullanıcının doldurması için görüntülemek.
        // SAYFADAN BIR PARAMETRE ALACKSAK BIR DE POST HALI ICINDE YAZMAMIZ LAZIM
        SaveUser user = new SaveUser();
        return View(user);
    }

    [HttpPost]
    public IActionResult SaveUser(SaveUser model){
        // Kullanıcı formu doldurup "Gönder" butonuna bastığında,
        // tarayıcı formdaki verileri sunucuya gönderir. Bu durumda bu metot çağrılır.
        // Parametre olarak SaveUser model alır. Bu, kullanıcının gönderdiği form verilerini temsil eder.
        // Örneğin: Kullanıcı adı alanına "Ayşe" yazmışsa, model.Name değeri "Ayşe" olacaktır.
        // Eğer bir e-posta alanı varsa, gönderilen e-posta adresi de model.
        //Email gibi bir property ile gelir.
        // Amaç: Formdan gelen verileri işlemek.
        return View();
    }

 ///////////////////////////////////////////////////////////////////////////////////////



    public ActionResult MyPage(){
        // KENDİ MVC SAYFAMIZI YAPALIM
        // SAYFA OLUSTURMAK ICIN BIR ACTION BİR DE VİEWA IHTIYACIMIZ VAR
        // EĞER RETURN VİEW DEDIGIMIZDE VİEW ADI VERMEZSEK, ACTION ADINDA BIR VİEW ARAYACKTIR SİSTEM.
        // 
        return View();
    }

    public IActionResult Index()
    {
        // BIR METODUN ACTION OLABASILMESI ICIN GERIYE IActionResult DONDURMESI GEREK
        // IActionResult GERİ BİR SAYFA DONDURMEK DEMEK 


        // EKRANDA GOSTERILECEK OLAN VERILER BURADA HAZIRLANIR
        // BİR VERİ KAYNAGINDAN VERİLER CEKİLEBİLİR
        // HAZIRLANAN VERİ MODEL DENEN YAPILARIN ICINE YERLESTIRILIR
        // MODEL VİEW A TRANSFER EDİLİR.

        // OGRENCİ İSMİNDE HAZIRLANAN MODEL'IN ICERISINI DOLADURALIM


        // HAZIRLAYACAGIM  MODEL List<Ogrenci>
        // List<Ogrenci> Yİ INDEX.CSHTML E GİRİP @MODEL List<Ogrenci>
        //OLARAK VERECEGIM SONRA

        List<Ogrenci> ogrencis = new List<Ogrenci>(){
            new Ogrenci {Name = "Ahmet", Id=1},
            new Ogrenci {Name = "Mehmet", Id=2},
            new Ogrenci {Name = "Veli", Id=3},
        };

        //CONTROLLER DA BIR OGRENCIS MODELI OLUSTURDUM VE ONU VIEW A YOLLLADIM 
        //   return View SAYFA DONDUR DEMEKİ, VİEW
        return View(ogrencis);

        // public IActionResult Index();
        // INDEX ISMINDEN VİEW A GIDIYOR ICINDE INDEX.CSHTML ARAYIP BULUYOR ESLIYOR
        // SONRASINDA EKRANDA GOSTERIYOR, ISIMLERININ AYNI OLMASI LAZIM 
        // return View("Index1", ogrencis); //MODEL CALISTIGINDA INDEX1 ISIMLI VIEWI ARAYACAK
        // VİEWDA O DOSYA VARSA EŞLEŞİRSE EKRANDA GOSTERICEK.  
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
