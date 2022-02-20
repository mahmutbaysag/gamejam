using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    Text isletmeIsim, sohret, servet, sohret1, servet1, isletmeBilgi, seviyeNum, kararSorusu;
    GameObject sonrakiLvlPanel;

    public int anlikSohret = 0;
    public int anlikServet = 0;
    public int calisanMenuniyet = 0;

    // Start is called before the first frame update
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

        soruhazirla();
        yeniIsletmeYukle();
    }

    // Update is called once per frame
    void Update()
    {

        


    }

    public void soruDegistir(int a)
    {
        //1:onay    0=redd
        kararSayaci++;

        
    }

    public int isletmeSayaci = 0;
    public int kararSayaci = 0;
    public void yeniIsletmeYukle()
    {
        //zaman fonsiyonu kurulacak
        kararSayaci = 0;
        isletmeIsim.text = isletmeler[isletmeSayaci].ad;
        sohret.text = isletmeler[isletmeSayaci].sohret.ToString();
        servet.text = isletmeler[isletmeSayaci].servet.ToString();
        sohret1.text = isletmeler[isletmeSayaci].istenenSohret.ToString();
        servet1.text = isletmeler[isletmeSayaci].istenenServet.ToString();
        isletmeBilgi.text = isletmeler[isletmeSayaci].bilgi;
        seviyeNum.text = (isletmeSayaci + 1).ToString();
        kararSorusu.text = isletmeler[isletmeSayaci].kararlar[kararSayaci].soru;

        anlikSohret = isletmeler[isletmeSayaci].istenenSohret;
        anlikServet = isletmeler[isletmeSayaci].istenenServet;

        sonrakiLvlPanel.SetActive(false);

    }

    public void sonrakiLvl()
    {

    }

    public void kaybettin()
    {

    }

    isletme[] isletmeler = new isletme[5];
    public void soruhazirla()
    {
        string[] adlar = new string[5];
        adlar[0] = "KAFE";
        adlar[1] = "BAKKAL";
        adlar[2] = "DERSHANE";
        adlar[3] = "KIYAFET MA�AZASI";
        adlar[4] = "ELEKTRON�K MA�AZASI";

        string[,] sorular = new string[5, 5] { {
        "1kahve otomat�",
        "1bah�e temal� konsept ",
        "0ka�ak kat ��k�p parti",
        "0m��teriler poker masas� isteniyor",
        "0m��teriler �al��andan memnun de�il �al��anlar de�i�tirilsin"
         },
         {
        "�r�nler i artt�rma",
        "�irket geni�letme",
        "mallar�n fiyat�n� artt�rma",
        "mallara indirim yapt�rma",
        "tarihi ge�mi� bir �r�n satt���n�z s�yleniyor"
         },
         {
        "��renciler daha iyi yay�n istiyorlar",
        "reklam yap�p ��renci say�s�n� artt�rma",
        "dershane bah�esini d�zenleme",
        "dershane s�ralar�n� d�zenleme",
        "��retmenler ders saatlerinin k�salmas�n� istiyor"
         },{
        "�al��anlar fazla �al��t�klar�n� d���n�yorlar",
        "yeni kiyaftler gelsin mi ",
        "yan ma�azalar�da sat�n al�p geni�lesin mi",
        "m��teriler yerler kirli diye �ikayet ediyorlar",
        "kabinler k�t� kokuyor koku sistemi tak�ls�n" },
         {
        "firmaya yeni laptoplar isteniyor",
        "firmada ki �r�nlere tester olmas�n� isteniyor",
        "�r�nler i 1 hafta deneme �ans� isteniyor ",
        "�al��anlar fazla �al���yoruz diye isyan ediyorlar",
        "yeni ev aletleri istiyor m��teriler "
         }
         };
        int c = 0;
        

        for(int i=0;i<5;i++)
        {
            isletmeler[c] = new isletme();
            isletmeler[c].isletmeEkle(c, adlar[i], adlar[i], Random.Range(1, 10), Random.Range(10000, 500000), Random.Range(1, 10), Random.Range(10000, 500000), Random.Range(1, 6));
            karar[] kar = new karar[5];
            for(int j = 0; j < 5; j++)
            {
                karar x = new karar();
                x.kararEkle(j+1,sorular[i,j],Random.Range(1,4),4);//son de�er d�zemenecek
                kar[j]=x;
            }
            isletmeler[c].kararlar = kar;
            c++;
        }

        foreach (isletme isl in isletmeler)
        {
            //Debug.Log(isl.ad);
            foreach (karar ks in isl.kararlar)
            {
                Debug.Log(isl.ad + " " + ks.soru+" "+ks.etki);
            }
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


