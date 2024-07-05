using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cogalacak : MonoBehaviour
{
    public List<Sorular> SorularList;
    [HideInInspector]
    public Sorular SuankiSoru;
    public Text SoruText;

    public GameObject SlotObje;
    public InputField input;
    public AudioSource losemusic;
    public AudioSource winmusic;

    public Animator imageanim;
    public Image image;
    public GameObject nextLevelPanel;

    int RandomSoru;
    void Awake()
    {
        SoruVer();
    }

    void Start()
    {
        nextLevelPanel.SetActive(false);
        winmusic.Stop();
        losemusic.Stop();
    }

    void Uptade()
    {

    }


    void SoruVer()
    {

        if (SorularList.Count == 0)
        {
            ShowNextLevelPanel();
        }

        foreach (Transform obje in this.transform)
        {
            Destroy(obje.gameObject);
        }
        RandomSoru = Random.Range(0, SorularList.Count);
        SuankiSoru.Soru = SorularList[RandomSoru].Soru;
        SuankiSoru.Cevap = SorularList[RandomSoru].Cevap;

        Vector3 spawnPosition = new Vector3(0f, 0f, 0f);

        for (int i = 0; i < SuankiSoru.Cevap.Length; i++)
        {
            GameObject Cogalan = Instantiate(SlotObje,transform);
            Cogalan.transform.Find("SoruText").GetComponent<Text>().text = SuankiSoru.Cevap[i].ToString();
            SorularList[RandomSoru].Acilmayanlar.Add(Cogalan.transform.Find("SoruText").GetComponent<Text>());
            SoruText.text = SuankiSoru.Soru;
            Cogalan.transform.Find("SoruText").gameObject.SetActive(false);

            
        }
        SuankiSoru.Acilmayanlar = SorularList[RandomSoru].Acilmayanlar;
    }

    public void HarfAl()
    {
        if (SuankiSoru.Acilmayanlar.Count > 0)
        {
            int RandomHarf = Random.Range(0, SuankiSoru.Acilmayanlar.Count);
            SuankiSoru.Acilmayanlar[RandomHarf].gameObject.SetActive(true);
            SuankiSoru.Acilmayanlar.RemoveAt(RandomHarf);
        }

        else
        {
            SorularList.RemoveAt(RandomSoru);
            Debug.Log("kazandiniz");
            image.enabled = true;
            imageanim.enabled = true;
            imageanim.SetTrigger("elwin");


            winmusic.Play();
            Invoke("SoruVer", 3.5f);
        }
    }

    void ShowNextLevelPanel()
    {
        
        nextLevelPanel.SetActive(true);
        
    }


    public void DirekTahmin()
    {
        if (input.text == SuankiSoru.Cevap || input.text.ToLower() == SuankiSoru.Cevap.ToLower())
        {
            Debug.Log("Kazandiniz.");
            image.enabled = true;
            imageanim.enabled = true;
            imageanim.SetTrigger("elwin");

            if (SorularList.Count == 0)
            {
                ShowNextLevelPanel();
            }

            winmusic.Play();
            SorularList.RemoveAt(RandomSoru);
            foreach (Text textler in SuankiSoru.Acilmayanlar)
            {
                textler.gameObject.SetActive(true);
            }
            Invoke("SoruVer", 3.5f);
            input.text = "";

        }

        else
        {
            losemusic.Play();
            image.enabled = true;
            imageanim.enabled = true;
            imageanim.SetTrigger("ellose");

            Debug.Log("Yanlis tahmin ettiniz.");
            input.text = "";
        }
    }
}
[System.Serializable]
public class Sorular
{
    public string Soru;
    public string Cevap;
    public List<Text> Acilmayanlar;

    public Sorular(string soru, string cevap, List<Text> acilmayanlar)
    {
        Soru = soru;
        Cevap = cevap;
        Acilmayanlar = acilmayanlar;
    }
}
