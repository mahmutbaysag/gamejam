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

        isletmeIsim = GameObject.FindGameObjectWithTag("isletmeIs�m").GetComponent<Text>();
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
                            case 0: //i�letme i�in k�t�
                                {
                                    anlikSohret -= isletmeler[isletmeSayaci].kararlar[kararSayaci].etki;
                                    anlikServet -= isletmeler[isletmeSayaci].kararlar[kararSayaci].etki * 10000;
                                }
                                break;
                            case 1: //i�letme i�in iyi
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
                            case 0: //i�letme i�in k�t�
                                {
                                    anlikSohret += isletmeler[isletmeSayaci].kararlar[kararSayaci].etki;
                                    anlikServet += isletmeler[isletmeSayaci].kararlar[kararSayaci].etki * 10000;
                                }
                                break;
                            case 1: // i�letme i�in iyi
                                {
                                    anlikSohret -= isletmeler[isletmeSayaci].kararlar[kararSayaci].etki;
                                    anlikServet -= isletmeler[isletmeSayaci].kararlar[kararSayaci].etki * 10000;
                                }
                                break;
                        }
                    }
                    break;
            }
            Debug.Log("karar sayac� = " + kararSayaci);
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
        Debug.Log("seviyenin istedi�i sohret:"+ isletmeler[isletmeSayaci].istenenSohret);
        Debug.Log("seviyenin istedi�i servet:" + isletmeler[isletmeSayaci].istenenServet);
        if (anlikSohret >= isletmeler[isletmeSayaci].istenenSohret && anlikServet >= isletmeler[isletmeSayaci].istenenServet)
        {
            if (isletmeSayaci < 8) //isletme say�s�na g�re buray� d�zenle
            {
                sonrakiLvlPanel.SetActive(true);
                
                kararSayaci = 0;
            }
            else
            {
                //t�m sorular bitti�ind ene olacak
                Debug.Log("t�m sorualr bitti");
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
        string[] adlar = { "Lemon cafe", "Laklak Dershanesi", "�akal Elektronik", "Papatya Otel", "Gamer Hane", "yakalad�m Bakkal", "giy giy kiyafet", "italyano restorante", "g�t�r�r�z kargo" };

        string[] bilgiler = {"�at� kat�nda bir i�letme",
"Mahalle aras�nda bir i�letme",
"Araba garaj�nda bir i�letme",
"K��e aras�nda bir i�letme",
"Bodrum kat�nda bir i�letme",
"Mahalle aras�nda bir i�letme",
"Aveme i�inde bir ma�aza, �al��ma saatleri = g�nl�k 8 saat",
"i�lek bir cadde deki bir i�letme, bir istalyan restorant�",
"�ar�� i�inde bir i�letme"};

        string[,] sorular = new string[9, 5] { {
        "1kahve otomat�",
        "1bah�e temal� konsept ",
        "0ka�ak kat ��k�p parti",
        "0m��teriler poker masas� isteniyor",
        "0m��teriler �al��andan memnun de�il �al��anlar de�i�tirilsin"
},{
        "1��renciler daha iyi yay�n istiyor",
        "0��retmenler ders saatlerinin k�salmalar�n� istiyor",
        "0veliler dershane �cretlerini fazla buluyor",
        "1Dershanenin reklam�n� yaparak ��renci �ekme",
       "1��renciler tenef�ste ve ��le aralar�nda m�zik istiyor"
}, {
        "1M��teriler �r�nleri deneyerek almak istiyor bunun i�in test �r�nleri koy",
        "1�al��anlar fazla �al���yoruz diye isyan ediyorlar �al��ma s�relerini k�salt",
        "0M��teriler �r�nleri 1 hafta deneme �ans� istiyorlar",
        "1M��teriler �r�nlerin azl���ndan �ikayet ediyorlar yeni e�yalar getir",
        "0�al��analar �r�nleri deniyimlemek istiyorlar"
},{
        "0M��teri i�letmede buz pateni istyor",
        "1Turist m��teriler i�in terc�man i�e al",
        "1M��teriler daha b�y�k ve g�zel havuz istiyor",
        "0M��teriler fiyata her�eyin dahil olmas�n� istiyorlar",
        "0�al��anlara eziyet olsun diye bah�eyi temizlet"
},{
        "1M��teriler daha yeni �zellikli oyun �r�nleri istiyor",
        "0Oyunlara zam yap",
        "0Depo kat�nda oldu�un i�in ka�ak olarak kolonlar� k�r ve yeni oyun salonu yap",
        "0M��teriler oyun oynarken elektirikler gitti para �demeden gitmek istiyorlar",
        "1M��teriler kavga etti ikisini de mekandan at"
},{
    "1�r�n �e�itlili�ini artt�rma",
        "0�r�nlerin fiyat�n� artt�rma",
        "1�r�nlerin fiyat�n� azaltma",
        "1M��teriler tarihi ge�mi� �r�n satt���n�z� ve bunu geri alman�z� istedi",
        "0Son kullanma tarihi ge�mi� �r�nleri sat�n"
},{
    "1M��teriler kiyafet azl���ndan �ikayet�i �irket e yeni �r�nler getirin",
        "1Deneme kabinleri k�t� kokuyor koku sistemi sat�n al�n",
        "1��letmede slow m�zikler �als�n",
        "0�al��anlar fazla �al��t�klar�n� d���n�yorlar",
        "0M��teriler defolu mal satt���n�z� d���n�yorlar"
},
{
    "1M��teriler Yeni tatlar istiyor men�ye yeni yemekler eklensin mi?",
        "1��letme iyi bir �ef al",
        "1��letmede slow m�zikler �als�n m�?",
        "0Bir g�n b�t�n �al��anlara izin verilsin mi?",
        "0�irketiniz duyulmaya ba�land� yemeklere zam yap�ls�n m�?"
},
{
    "1�al��anlar �r�n� tekmelerken g�r�ld� i�ten kovulsun mu?",
        "1yeni ara� al ve i�ini b�y�lt",
        "0�al��anlar�na zam yap�ls�n m�?",
        "0Yeni eleman als�n m�?",
        "1�irketiniz le ilk defa �r�n g�nderimine %10 indirim yap"
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
                x.kararEkle(j+1,sorular[i,j].Substring(1),Random.Range(1,4),int.Parse(sorular[i, j].Substring(0,1)));//son de�er d�zemenecek
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


