using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    Text isletmeIsim, sohret, servet, sohret1, servet1, isletmeBilgi, seviyeNum, kararSorusu;
    public GameObject sonrakiLvlPanel,kybPanel;

    public int anlikSohret = 0;
    public int anlikServet = 0;
    public int calisanMenuniyet = 0;
    public int isletmeSayaci = 0;
    public int kararSayaci = 0;

    void Start()
    {

        isletmeIsim = GameObject.FindGameObjectWithTag("isletmeIsým").GetComponent<Text>();
        sohret = GameObject.FindGameObjectWithTag("sohret").GetComponent<Text>();
        servet = GameObject.FindGameObjectWithTag("servet").GetComponent<Text>();
        sohret1 = GameObject.FindGameObjectWithTag("sohret1").GetComponent<Text>();
        servet1 = GameObject.FindGameObjectWithTag("servet1").GetComponent<Text>();
        isletmeBilgi = GameObject.FindGameObjectWithTag("isletmeBilgi").GetComponent<Text>();
        seviyeNum = GameObject.FindGameObjectWithTag("seviyeNum").GetComponent<Text>();
        kararSorusu = GameObject.FindGameObjectWithTag("kararSorusu").GetComponent<Text>();

        sonrakiLvlPanel = GameObject.FindGameObjectWithTag("sonrakilvlPanel");
        kybPanel = GameObject.FindGameObjectWithTag("kbScreen");

        soruhazirla();
        yeniIsletmeYukle();
    }

    void Update()
    {
        
        


    }

    public void soruDegistir(int a)
    {
        if (kararSayaci < 4)
        {
            switch (a)
            {
                case 1: //onayla butonu
                    {
                        switch (isletmeler[isletmeSayaci].kararlar[kararSayaci].sirketeEtki)
                        {
                            case 0: //iþletme için kötü
                                {
                                    anlikSohret -= isletmeler[isletmeSayaci].kararlar[kararSayaci].etki;
                                    anlikServet -= isletmeler[isletmeSayaci].kararlar[kararSayaci].etki * 10000;
                                }
                                break;
                            case 1: //iþletme için iyi
                                {
                                    anlikSohret += isletmeler[isletmeSayaci].kararlar[kararSayaci].etki;
                                    anlikServet += isletmeler[isletmeSayaci].kararlar[kararSayaci].etki * 10000;
                                }
                                break;
                        }
                    }
                    break;
                case 0: // reddet butonu
                    {
                        switch (isletmeler[isletmeSayaci].kararlar[kararSayaci].sirketeEtki)
                        {
                            case 0: //iþletme için kötü
                                {
                                    anlikSohret += isletmeler[isletmeSayaci].kararlar[kararSayaci].etki;
                                    anlikServet += isletmeler[isletmeSayaci].kararlar[kararSayaci].etki * 10000;
                                }
                                break;
                            case 1: // iþletme için iyi
                                {
                                    anlikSohret -= isletmeler[isletmeSayaci].kararlar[kararSayaci].etki;
                                    anlikServet -= isletmeler[isletmeSayaci].kararlar[kararSayaci].etki * 10000;
                                }
                                break;
                        }
                    }
                    break;
            }
            Debug.Log("karar sayacý = " + kararSayaci);
            kararSayaci++;
            
            sohret.text = anlikSohret.ToString();
            servet.text = anlikServet.ToString();
            kararSorusu.text = isletmeler[isletmeSayaci].kararlar[kararSayaci].soru;
        }
        else
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<zaman>().sifirla();
            kontrolNoktasi();
        } 
    }
  
    public void yeniIsletmeYukle()
    {
        //zaman fonsiyonu kurulacak
       
        isletmeIsim.text = isletmeler[isletmeSayaci].ad;
        sohret.text = isletmeler[isletmeSayaci].sohret.ToString();
        servet.text = isletmeler[isletmeSayaci].servet.ToString();
        sohret1.text = isletmeler[isletmeSayaci].istenenSohret.ToString();
        servet1.text = isletmeler[isletmeSayaci].istenenServet.ToString();
        isletmeBilgi.text = isletmeler[isletmeSayaci].bilgi;
        seviyeNum.text = (isletmeSayaci + 2).ToString();
        kararSorusu.text = isletmeler[isletmeSayaci].kararlar[kararSayaci].soru;

        anlikSohret = isletmeler[isletmeSayaci].istenenSohret;
        anlikServet = isletmeler[isletmeSayaci].istenenServet;

        sonrakiLvlPanel.SetActive(false);

    }

    public void kontrolNoktasi()
    {
        Debug.Log("anliksohret:"+ anlikSohret);
        Debug.Log("anlikservet:" + anlikServet);
        Debug.Log("seviyenin istediði sohret:"+ isletmeler[isletmeSayaci].istenenSohret);
        Debug.Log("seviyenin istediði servet:" + isletmeler[isletmeSayaci].istenenServet);
        if (anlikSohret >= isletmeler[isletmeSayaci].istenenSohret && anlikServet >= isletmeler[isletmeSayaci].istenenServet)
        {
            if (isletmeSayaci < 8) //isletme sayýsýna göre burayý düzenle
            {
                sonrakiLvlPanel.SetActive(true);
                
                kararSayaci = 0;
            }
            else
            {
                //tüm sorular bittiðind ene olacak
                Debug.Log("tüm sorualr bitti");
                GameObject bitisEkran = GameObject.FindGameObjectWithTag("Finish");
                bitisEkran.transform.Rotate(new Vector3(0, -90, 0));
            }
        }
        else
        {
            Debug.Log("kaybettin");
            kybPanel.transform.Rotate(new Vector3(0,-90,0));
            isletmeSayaci = 0;
            kararSayaci = 0;

        }
    }

    public void sonrakiLvlYukle()
    {
        if(isletmeSayaci<8)
        {
            isletmeSayaci++;
            sonrakiLvlPanel.SetActive(false);
            kararSayaci = 0;
            yeniIsletmeYukle();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<zaman>().sifirla();
        }
        
    }

    isletme[] isletmeler = new isletme[9];
    public void soruhazirla()
    {
        string[] adlar = { "Lemon cafe", "Laklak Dershanesi", "Çakal Elektronik", "Papatya Otel", "Gamer Hane", "yakaladým Bakkal", "giy giy kiyafet", "italyano restorante", "götürürüz kargo" };

        string[] bilgiler = {"Çatý katýnda bir iþletme",
"Mahalle arasýnda bir iþletme",
"Araba garajýnda bir iþletme",
"Köþe arasýnda bir iþletme",
"Bodrum katýnda bir iþletme",
"Mahalle arasýnda bir iþletme",
"Aveme içinde bir maðaza, çalýþma saatleri = günlük 8 saat",
"iþlek bir cadde deki bir iþletme, bir istalyan restorantý",
"çarþý içinde bir iþletme"};

        string[,] sorular = new string[9, 5] { {
        "1kahve otomatý",
        "1bahçe temalý konsept ",
        "0kaçak kat çýkýp parti",
        "0müþteriler poker masasý isteniyor",
        "0müþteriler çalýþandan memnun deðil çalýþanlar deðiþtirilsin"
},{
        "1Öðrenciler daha iyi yayýn istiyor",
        "0öðretmenler ders saatlerinin kýsalmalarýný istiyor",
        "0veliler dershane ücretlerini fazla buluyor",
        "1Dershanenin reklamýný yaparak öðrenci çekme",
       "1öðrenciler tenefüste ve öðle aralarýnda müzik istiyor"
}, {
        "1Müþteriler ürünleri deneyerek almak istiyor bunun için test ürünleri koy",
        "1çalýþanlar fazla çalýþýyoruz diye isyan ediyorlar çalýþma sürelerini kýsalt",
        "0Müþteriler ürünleri 1 hafta deneme þansý istiyorlar",
        "1Müþteriler ürünlerin azlýðýndan þikayet ediyorlar yeni eþyalar getir",
        "0Çalýþanalar ürünleri deniyimlemek istiyorlar"
},{
        "0Müþteri iþletmede buz pateni istyor",
        "1Turist müþteriler için tercüman iþe al",
        "1Müþteriler daha büyük ve güzel havuz istiyor",
        "0Müþteriler fiyata herþeyin dahil olmasýný istiyorlar",
        "0Çalýþanlara eziyet olsun diye bahçeyi temizlet"
},{
        "1Müþteriler daha yeni özellikli oyun ürünleri istiyor",
        "0Oyunlara zam yap",
        "0Depo katýnda olduðun için kaçak olarak kolonlarý kýr ve yeni oyun salonu yap",
        "0Müþteriler oyun oynarken elektirikler gitti para ödemeden gitmek istiyorlar",
        "1Müþteriler kavga etti ikisini de mekandan at"
},{
    "1Ürün çeþitliliðini arttýrma",
        "0Ürünlerin fiyatýný arttýrma",
        "1Ürünlerin fiyatýný azaltma",
        "1Müþteriler tarihi geçmiþ ürün sattýðýnýzý ve bunu geri almanýzý istedi",
        "0Son kullanma tarihi geçmiþ ürünleri satýn"
},{
    "1Müþteriler kiyafet azlýðýndan þikayetçi þirket e yeni ürünler getirin",
        "1Deneme kabinleri kötü kokuyor koku sistemi satýn alýn",
        "1Ýþletmede slow müzikler çalsýn",
        "0Çalýþanlar fazla çalýþtýklarýný düþünüyorlar",
        "0Müþteriler defolu mal sattýðýnýzý düþünüyorlar"
},
{
    "1Müþteriler Yeni tatlar istiyor menüye yeni yemekler eklensin mi?",
        "1Ýþletme iyi bir þef al",
        "1Ýþletmede slow müzikler çalsýn mý?",
        "0Bir gün bütün çalýþanlara izin verilsin mi?",
        "0Þirketiniz duyulmaya baþlandý yemeklere zam yapýlsýn mý?"
},
{
    "1Çalýþanlar ürünü tekmelerken görüldü iþten kovulsun mu?",
        "1yeni araç al ve iþini büyült",
        "0Çalýþanlarýna zam yapýlsýn mý?",
        "0Yeni eleman alsýn mý?",
        "1Þirketiniz le ilk defa ürün gönderimine %10 indirim yap"
}
         };
        int c = 0;
        

        for(int i=0;i<9;i++)
        {
            isletmeler[c] = new isletme();
            isletmeler[c].isletmeEkle(c, adlar[i], bilgiler[i], Random.Range(1, 10), Random.Range(10000, 500000), Random.Range(1, 10), Random.Range(10000, 500000), Random.Range(1, 6));
            karar[] kar = new karar[5];
            for(int j = 0; j < 5; j++)
            {
                karar x = new karar();
                x.kararEkle(j+1,sorular[i,j].Substring(1),Random.Range(1,4),int.Parse(sorular[i, j].Substring(0,1)));//son deðer düzemenecek
                kar[j]=x;
            }
            isletmeler[c].kararlar = kar;
            c++;
        }
    }
}

public class isletme
{
    public int id;
    public string ad;
    public string bilgi;
    public int sohret;
    public int servet;
    public int istenenSohret;
    public int istenenServet;
    public int calisanMemnuniyeti;
    public karar[] kararlar = new karar[5];

    public void isletmeEkle(int a, string b, string c, int d, int e, int f, int g, int h)
    {
        this.id = a;
        this.ad = b;
        this.bilgi = c;
        this.sohret = d;
        this.servet = e;
        this.istenenSohret = f;
        this.istenenServet = g;
        this.calisanMemnuniyeti = h;
    }
}

public class karar
{
    public int kid;
    public string soru;
    public int etki; // *10000=servete etki
    public int sirketeEtki;

    public void kararEkle(int a, string b, int c, int e)
    {
        this.kid = a;
        this.soru = b;
        this.etki = c;
        this.sirketeEtki= e;
    }

}


