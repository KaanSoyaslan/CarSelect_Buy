using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarSelect : MonoBehaviour
{
    public Button[] CharButtons;
    public TMP_Text[] CharButtonTxts;
    public TMP_Text[] CharPriceTxts;
    public Image[] CharBuyImages;
    public Color[] ButtonRenkleriAGA; //0 SATIN AL ,1 SE� ,2 SE��LD�
    public Sprite[] CharBuySprites; //0 bo�  //1 coin //2 reklam

    int[] CharCosts = new int[33]; //Ara�Fiyatlar�

    public TMP_Text CoinTXT;

    public static bool DurumRefresh = false;

    void Start()
    {
        //Reklam izlenerek a��lan ara�lar�n reklam maaliyetleri +1
        if (PlayerPrefs.GetInt("isCarAdWatched1") == 0) //0 ise atanmam�� 1 ise elde edilmi�
        {
            PlayerPrefs.SetInt("isCarAdWatched1", 5);
            PlayerPrefs.SetInt("isCarAdWatched3", 5);
            PlayerPrefs.SetInt("isCarAdWatched6", 5);
            PlayerPrefs.SetInt("isCarAdWatched10", 5);
            PlayerPrefs.SetInt("isCarAdWatched11", 5);
            PlayerPrefs.SetInt("isCarAdWatched16", 4);
            PlayerPrefs.SetInt("isCarAdWatched17", 5);
            PlayerPrefs.SetInt("isCarAdWatched24", 5);
            PlayerPrefs.SetInt("isCarAdWatched25", 5);
            PlayerPrefs.SetInt("isCarAdWatched27", 5);
            PlayerPrefs.SetInt("isCarAdWatched28", 6);
            PlayerPrefs.SetInt("isCarAdWatched29", 6);
            PlayerPrefs.SetInt("isCarAdWatched31", 5);
        }



        CharCosts[0] = 0;
        CharCosts[1] = PlayerPrefs.GetInt("isCarAdWatched1");
        CharCosts[2] = 1000;
        CharCosts[3] = PlayerPrefs.GetInt("isCarAdWatched3");
        CharCosts[4] = 500;
        CharCosts[5] = 1500;
        CharCosts[6] = PlayerPrefs.GetInt("isCarAdWatched6");
        CharCosts[7] = 1000;
        CharCosts[8] = 800;
        CharCosts[9] = 800;
        CharCosts[10] = PlayerPrefs.GetInt("isCarAdWatched10");
        CharCosts[11] = PlayerPrefs.GetInt("isCarAdWatched11");
        CharCosts[12] = 600;
        CharCosts[13] = 800;
        CharCosts[14] = 500;
        CharCosts[15] = 500;
        CharCosts[16] = PlayerPrefs.GetInt("isCarAdWatched16");
        CharCosts[17] = PlayerPrefs.GetInt("isCarAdWatched17");
        CharCosts[18] = 1000;
        CharCosts[19] = 2000;
        CharCosts[20] = 1600;
        CharCosts[21] = 900;
        CharCosts[22] = 1000;
        CharCosts[23] = 1000;
        CharCosts[24] = PlayerPrefs.GetInt("isCarAdWatched24");
        CharCosts[25] = PlayerPrefs.GetInt("isCarAdWatched25");
        CharCosts[26] = 3000;
        CharCosts[27] = PlayerPrefs.GetInt("isCarAdWatched27");
        CharCosts[28] = PlayerPrefs.GetInt("isCarAdWatched28");
        CharCosts[29] = PlayerPrefs.GetInt("isCarAdWatched29");
        CharCosts[30] = 1200;
        CharCosts[31] = PlayerPrefs.GetInt("isCarAdWatched31");
        CharCosts[32] = 1000;

        if (PlayerPrefs.GetInt("isCarBuyed?0") == 0) //ilk araba al�nmam�� g�r�n�yorsa
        {
            PlayerPrefs.SetInt("isCarBuyed?0", 1);
            PlayerPrefs.SetInt("ChoosedCar", 0);
        }

        DurumKontrol();

    }
    public void DurumKontrol()
    {
        CharCosts[0] = 0;
        CharCosts[1] = PlayerPrefs.GetInt("isCarAdWatched1");
        CharCosts[2] = 1000;
        CharCosts[3] = PlayerPrefs.GetInt("isCarAdWatched3");
        CharCosts[4] = 500;
        CharCosts[5] = 1500;
        CharCosts[6] = PlayerPrefs.GetInt("isCarAdWatched6");
        CharCosts[7] = 1000;
        CharCosts[8] = 800;
        CharCosts[9] = 800;
        CharCosts[10] = PlayerPrefs.GetInt("isCarAdWatched10");
        CharCosts[11] = PlayerPrefs.GetInt("isCarAdWatched11");
        CharCosts[12] = 600;
        CharCosts[13] = 800;
        CharCosts[14] = 500;
        CharCosts[15] = 500;
        CharCosts[16] = PlayerPrefs.GetInt("isCarAdWatched16");
        CharCosts[17] = PlayerPrefs.GetInt("isCarAdWatched17");
        CharCosts[18] = 1000;
        CharCosts[19] = 2000;
        CharCosts[20] = 1600;
        CharCosts[21] = 900;
        CharCosts[22] = 1000;
        CharCosts[23] = 1000;
        CharCosts[24] = PlayerPrefs.GetInt("isCarAdWatched24");
        CharCosts[25] = PlayerPrefs.GetInt("isCarAdWatched25");
        CharCosts[26] = 3000;
        CharCosts[27] = PlayerPrefs.GetInt("isCarAdWatched27");
        CharCosts[28] = PlayerPrefs.GetInt("isCarAdWatched28");
        CharCosts[29] = PlayerPrefs.GetInt("isCarAdWatched29");
        CharCosts[30] = 1200;
        CharCosts[31] = PlayerPrefs.GetInt("isCarAdWatched31");
        CharCosts[32] = 1000;

        //ara�lar�n buton optimizesi
        for (int i = 0; i < CharButtons.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("ChoosedCar")) //se�ilen araba
            {
                CharButtons[i].interactable = false;
                CharButtons[i].image.color = ButtonRenkleriAGA[1];
                if (PlayerPrefs.GetInt("Dil") == 1)//tr
                {
                    CharButtonTxts[i].text = "Se�ildi";
                }
                else if (PlayerPrefs.GetInt("Dil") == 2)//en
                {
                    CharButtonTxts[i].text = "Selected";
                }

                CharPriceTxts[i].text = "";
                CharBuyImages[i].sprite = CharBuySprites[0];
            }
            else if (i != PlayerPrefs.GetInt("ChoosedCar") && 1 == PlayerPrefs.GetInt("isCarBuyed?" + i))//se�ilmemi� ama sat�n al�nm�� ara�
            {
                CharButtons[i].interactable = true;
                CharButtons[i].image.color = ButtonRenkleriAGA[1];
                if (PlayerPrefs.GetInt("Dil") == 1)//tr
                {
                    CharButtonTxts[i].text = "Se�";
                }
                else if (PlayerPrefs.GetInt("Dil") == 2)//en
                {
                    CharButtonTxts[i].text = "Select";
                }

                CharPriceTxts[i].text = "";
                CharBuyImages[i].sprite = CharBuySprites[0];
            }
            else if (1 != PlayerPrefs.GetInt("isCarBuyed?" + i) && CharCosts[i] > 10) //sat�n al�nmam�� coin arac�
            {
                CharButtons[i].interactable = true;
                CharButtons[i].image.color = ButtonRenkleriAGA[2];

                if (PlayerPrefs.GetInt("Dil") == 1)//tr
                {
                    CharButtonTxts[i].text = "Sat�n Al";
                }
                else if (PlayerPrefs.GetInt("Dil") == 2)//en
                {
                    CharButtonTxts[i].text = "Buy";
                }

                CharPriceTxts[i].text = "x" + CharCosts[i].ToString();
                CharBuyImages[i].sprite = CharBuySprites[1];
            }
            else if (1 != PlayerPrefs.GetInt("isCarBuyed?" + i) && CharCosts[i] < 10) //sat�n al�nmam�� reklam arac�
            {
                CharButtons[i].interactable = true;
                CharButtons[i].image.color = ButtonRenkleriAGA[0];
                if (PlayerPrefs.GetInt("Dil") == 1)//tr
                {
                    CharButtonTxts[i].text = "�zle";
                }
                else if (PlayerPrefs.GetInt("Dil") == 2)//en
                {
                    CharButtonTxts[i].text = "Watch";
                }

                CharPriceTxts[i].text = "x" + (CharCosts[i] - 1).ToString();
                CharBuyImages[i].sprite = CharBuySprites[2];
            }
        }

    }
    public void CoinAlVer(int Say�) //test
    {
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + Say�);
    }
    public void resetAllCars() //test
    {
        for (int i = 0; i < CharButtons.Length; i++)
        {
            PlayerPrefs.SetInt("isCarBuyed?" + i, 0);

        }
        PlayerPrefs.SetInt("isCarAdWatched1", 5);
        PlayerPrefs.SetInt("isCarAdWatched3", 5);
        PlayerPrefs.SetInt("isCarAdWatched6", 5);
        PlayerPrefs.SetInt("isCarAdWatched10", 5);
        PlayerPrefs.SetInt("isCarAdWatched11", 5);
        PlayerPrefs.SetInt("isCarAdWatched16", 4);
        PlayerPrefs.SetInt("isCarAdWatched17", 5);
        PlayerPrefs.SetInt("isCarAdWatched24", 5);
        PlayerPrefs.SetInt("isCarAdWatched25", 5);
        PlayerPrefs.SetInt("isCarAdWatched27", 5);
        PlayerPrefs.SetInt("isCarAdWatched28", 6);
        PlayerPrefs.SetInt("isCarAdWatched29", 6);
        PlayerPrefs.SetInt("isCarAdWatched31", 5);



        PlayerPrefs.SetInt("FirstAudios", 0);
        PlayerPrefs.SetInt("isCarBuyed?0", 1);
        DurumKontrol();
    }
    public void BuyALLcars() //test
    {
        for (int i = 0; i < CharButtons.Length; i++)
        {
            PlayerPrefs.SetInt("isCarBuyed?" + i, 1);

        }
        DurumKontrol();
    }

    void Update()
    {
        CoinTXT.text = "x" + PlayerPrefs.GetInt("coin");

        if (DurumRefresh)
        {
            DurumRefresh = false;
            DurumKontrol();
        }

    }
    public void CharSelectOrBuyButtons(int Charnumber) 
    {
        if (PlayerPrefs.GetInt("isCarBuyed?" + Charnumber) == 1) //Sat�n al�nm�� ve se�ilecek
        {
            PlayerPrefs.SetInt("ChoosedCar", Charnumber);
        }
        else if (1 != PlayerPrefs.GetInt("isCarBuyed?" + Charnumber) && CharCosts[Charnumber] > 10 && CharCosts[Charnumber] <= PlayerPrefs.GetInt("coin")) //sat�n al�nmam�� ve coin + paras� varsa
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - CharCosts[Charnumber]);
            PlayerPrefs.SetInt("isCarBuyed?" + Charnumber, 1);
        }
        else if (1 != PlayerPrefs.GetInt("isCarBuyed?" + Charnumber) && CharCosts[Charnumber] < 10 && PlayerPrefs.GetInt("isCarAdWatched" + Charnumber) > 1) //sat�n al�nmam�� ve reklam izlemek istiyor
        {
            //reklam g�ster

            Rewarded.istenenID = Charnumber;
            Rewarded.istek = true;


        }
        DurumKontrol();
    }
}