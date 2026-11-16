using UnityEngine;
using YG;
using UnityEngine.UI;
using System.Collections;
using System.Numerics;

public class Manager : MonoBehaviour
{
    [SerializeField] private Button[] buttonsOnOff;
    [SerializeField] private Collider2D[] collidersOnOff;

    [SerializeField] private Image background;
    [SerializeField] private Sprite[] backsSprites;
    [SerializeField] private Transform lbParent, textClickParent;
    [SerializeField] private Image progressImage, sunImage;
    [SerializeField] private AudioSource horror_sound;
    [SerializeField] private Text counterText, btcPerSecText, progressPercent, currentLevelText, new_level_price, ad_showen_text, rankText;
    [SerializeField] private AudioClip buy_sound, noMoney, newComp, new_level_can_snd, moneyAdded;
    [SerializeField] private AudioSource audio_source;
    [SerializeField] private GameObject adBtn, leaderBoard, new_levelOBJ, _ClickTextPrefab, forbiddenImg, textPrefabNewLevel;
    [SerializeField] private GameObject[] comps;
    [SerializeField] private Font trFont;

    private string rank1, rank2, rank3, rank4, rank5, rank6, rank7, rank8, rank9, rank10, rank11, rank12, rank13, rank14;

    private float targetScale = 1.2f;
    private BigInteger new_level_price_num = 1000;

    public Color blinkColor = Color.red;
    public float blinkDuration = 0.2f;
    private Color originalColor;
    private bool isBlinking = false;

    public BigInteger bitcoins = 0;
    public BigInteger _plus_click = 1;
    public BigInteger _plus_auto = 0;

    public BigInteger slot_buy_count_1 = 0;
    public BigInteger slot_buy_count_2 = 0;
    public BigInteger slot_buy_count_3 = 0;
    public BigInteger slot_buy_count_4 = 0;
    public BigInteger slot_buy_count_5 = 0;
    public BigInteger slot_buy_count_6 = 0;
    public BigInteger slot_buy_count_7 = 0;
    public BigInteger slot_buy_count_8 = 0;
    public BigInteger slot_buy_count_9 = 0;
    public BigInteger slot_buy_count_10 = 0;

    public BigInteger slot_price_1 = 200;
    public BigInteger slot_price_2 = 650;
    public BigInteger slot_price_3 = 3500;
    public BigInteger slot_price_4 = 15000;
    public BigInteger slot_price_6 = 60000;
    public BigInteger slot_price_7 = 150000;
    public BigInteger slot_price_8 = 300000;
    public BigInteger slot_price_9 = 650000;
    public BigInteger slot_price_10 = 1000000;
    private bool allowRotate = false;
    private bool isALreadyBuyShow = false;

    private string num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11,
        num12, num13, num14, num15, num16, num17, num18, num19, num20, num21, max_text, max_level_text;
    private void Start()
    {
        StartCoroutine(PlayRandomSound());
        if (YandexGame.savesData.isBuyBtnShow == true)
        {
            showBuyLevel();
            isALreadyBuyShow = true;
        }
        originalColor = counterText.color;
        if (YandexGame.SDKEnabled == true)
        {
            ad_showen_text.text = YandexGame.savesData.ad_showen + "/4";

            UpdateLang(YandexGame.lang);
            Update_comp();
            StartCoroutine(Saves_Coroutine());
            StartCoroutine(Auto_BTC_Coroutine());
            ConveringNumbers();

            switch (YandexGame.savesData.current_comp)
            {
                case var _ when YandexGame.savesData.current_comp >= 17:
                    background.sprite = backsSprites[10];
                    break;
                case var _ when YandexGame.savesData.current_comp >= 16:
                    background.sprite = backsSprites[9];
                    break;
                case var _ when YandexGame.savesData.current_comp >= 14:
                    background.sprite = backsSprites[8];
                    break;
                case var _ when YandexGame.savesData.current_comp >= 12:
                    background.sprite = backsSprites[7];
                    break;
                case var _ when YandexGame.savesData.current_comp >= 10:
                    background.sprite = backsSprites[6];
                    break;
                case var _ when YandexGame.savesData.current_comp >= 8:
                    background.sprite = backsSprites[5];
                    break;
                case var _ when YandexGame.savesData.current_comp >= 7:
                    background.sprite = backsSprites[4];
                    break;
                case var _ when YandexGame.savesData.current_comp >= 6:
                    background.sprite = backsSprites[3];
                    break;
                case var _ when YandexGame.savesData.current_comp >= 4:
                    background.sprite = backsSprites[2];
                    break;
                case var _ when YandexGame.savesData.current_comp >= 2:
                    background.sprite = backsSprites[1];
                    break;
                default:
                    background.sprite = backsSprites[0];
                    break;
            }
        }
    }

    private void UpdateLang(string str)
    {
        if (str == "ru")
        {
            max_level_text = "Максимальный";

            rank1 = "Хлюпик";
            rank2 = "Ботаник";
            rank3 = "Псих изобретатель";
            rank4 = "Решившийся";
            rank5 = "Обезумевший";
            rank6 = "Метаморфоз";
            rank7 = "Темная лошадка";
            rank8 = "Мизантроп";
            rank9 = "Хулиган";
            rank10 = "Киллер";
            rank11 = "Разрушитель";
            rank12 = "Джокер";
            rank13 = "Пеннивайз";
            rank14 = "Черномаг";

            num1 = " Тыс";
            num2 = " Млн";
            num3 = " Млрд";
            num4 = " Тн";
            num5 = " К";
            num6 = " Кн";
            num7 = " Ст";
            num8 = " Сп";
            num9 = " О";
            num10 = " Н";
            num11 = " Д";
            num12 = " Уд";
            num13 = " Дд";
            num14 = " Тд";
            num15 = " Чад";
            num16 = " Пнд";
            num17 = " Шнд";
            num18 = " Спд";
            num19 = " Внд";
            num20 = " Днд";
            num21 = " Двд";
            max_text = "Максимум";
        }
        else if (str == "en")
        {
            max_level_text = "Maximum";

            rank1 = "Squishy";
            rank2 = "Nerd";
            rank3 = "Psycho Inventor";
            rank4 = "Decided";
            rank5 = "Madman";
            rank6 = "Metamorphosis";
            rank7 = "Dark Horse";
            rank8 = "Misanthrope";
            rank9 = "Hooligan";
            rank10 = "Killer";
            rank11 = "Destroyer";
            rank12 = "Joker";
            rank13 = "Pennywise";
            rank14 = "Black Mage";

            num1 = " K";
            num2 = " M";
            num3 = " B";
            num4 = " T";
            num5 = " Q";
            num6 = " Qn";
            num7 = " Sx";
            num8 = " Sp";
            num9 = " Oc";
            num10 = " No";
            num11 = " Dc";
            num12 = " Ud";
            num13 = " Dd";
            num14 = " Td";
            num15 = " Qad";
            num16 = " Qnd";
            num17 = " Sxd";
            num18 = " Spd";
            num19 = " Ocd";
            num20 = " Nvd";
            num21 = " Vg";
            max_text = "Maximum";
        }
        else if (str == "tr")
        {
            max_level_text = "Maksimum";
            btcPerSecText.font = trFont;
            currentLevelText.font = trFont;
            new_level_price.font = trFont;
            counterText.font = trFont;

            rank1 = "Yumuşak";
            rank2 = "Kitap Kurdu";
            rank3 = "Psiko İcatçı";
            rank4 = "Karar Veren";
            rank5 = "Deli";
            rank6 = "Metamorfoz";
            rank7 = "Karanlık At";
            rank8 = "İnsan Sevmeyen";
            rank9 = "Serseri";
            rank10 = "Katil";
            rank11 = "Yıkıcı";
            rank12 = "Joker";
            rank13 = "Pennywise";
            rank14 = "Siyah Büyücü";

            num1 = " K";
            num2 = " M";
            num3 = " B";
            num4 = " T";
            num5 = " Q";
            num6 = " Qn";
            num7 = " Sx";
            num8 = " Sp";
            num9 = " Oc";
            num10 = " No";
            num11 = " Dc";
            num12 = " Ud";
            num13 = " Dd";
            num14 = " Td";
            num15 = " Qad";
            num16 = " Qnd";
            num17 = " Sxd";
            num18 = " Spd";
            num19 = " Ocd";
            num20 = " Nvd";
            num21 = " Vg";
            max_text = "Maksimum";
        }
    }

    private void Update_comp()
    {
        switch (YandexGame.savesData.current_comp)
        {
            case 1:
                foreach(GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[0].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 2:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[1].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 3:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[2].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 4:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[3].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 5:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[4].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 6:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[5].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 7:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[6].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 8:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[7].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 9:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[8].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 10:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[9].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 11:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[10].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 12:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[11].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 13:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[12].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 14:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[13].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 15:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[14].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 16:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[15].SetActive(true);
                progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
                progressPercent.text = Mathf.RoundToInt(YandexGame.savesData.currentProgress) + "%";
                break;
            case 17:
                foreach (GameObject obj in comps)
                {
                    obj.SetActive(false);
                }
                comps[16].SetActive(true);
                progressPercent.text = max_level_text;
                progressImage.fillAmount = 100f;
                break;
        }
    }

    private void Update()
    {
        if(allowRotate == true)
        {
            sunImage.transform.Rotate(UnityEngine.Vector3.forward * 100 * Time.deltaTime);
        }
        if (bitcoins < new_level_price_num)
        {
            new_level_price.color = Color.red;
        }
        else
        {
            new_level_price.color = Color.white;
        }

        if (isALreadyBuyShow == true)
        {
            new_level_price.text = FormatNumberShort(new_level_price_num);
        }
        if (YandexGame.SDKEnabled == true)
        {
            if(YandexGame.savesData.ad_showen == 4)
            {
                forbiddenImg.SetActive(true);
            }
            if (YandexGame.lang == "ru")
            {
                currentLevelText.text = "Злодей Уровня " + YandexGame.savesData.current_comp;
                btcPerSecText.text = FormatNumberShort(_plus_auto).ToString() + " злости/сек";
            }
            else if (YandexGame.lang == "en")
            {
                currentLevelText.text = "Villain Level " + YandexGame.savesData.current_comp;
                btcPerSecText.text = FormatNumberShort(_plus_auto).ToString() + " anger/sec";
            }
            else if (YandexGame.lang == "tr")
            {
                currentLevelText.text = "Kötü Adam Seviye " + YandexGame.savesData.current_comp;
                btcPerSecText.text = FormatNumberShort(_plus_auto).ToString() + " öfke/sn";
            }

            FormatNumber(bitcoins);
            ShowAdButton();
            UpdateLang(YandexGame.lang);
            UpdateRank();
        }
    }
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
    private void ShowAdButton()
    {
        if (bitcoins > 0)
        {
            adBtn.SetActive(true);
        }
        else
        {
            adBtn.SetActive(false);
        }
    }
    public void UpdateTextCounter()
    {
        bitcoins += _plus_click;

        // Получаем позицию курсора
        UnityEngine.Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = 10; // Меняем Z-координату для правильного отображения в двухмерном пространстве

        // Преобразуем экранные координаты в мировые
        UnityEngine.Vector3 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);

        // Создаем экземпляр _ClickTextPrefab в нужной позиции
        GameObject instantiatedObject = Instantiate(_ClickTextPrefab, worldPosition, UnityEngine.Quaternion.identity, textClickParent);

        Text click_num_fade = instantiatedObject.transform.Find("number").GetComponent<Text>();
        click_num_fade.text = "+" + FormatNumberShort(_plus_click);
    }

    public void UpdateTextCounterAuto()
    {
        bitcoins += _plus_auto;
    }
    private IEnumerator Auto_BTC_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            UpdateTextCounterAuto();
        }
    }
    private IEnumerator Saves_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            ConveringNumbersBack();
            YandexGame.SaveProgress();
        }
    }
    
    public void BuySlot_1()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            if (bitcoins >= slot_price_1)
            {
                bitcoins -= slot_price_1;
                _plus_click += 1;
                audio_source.PlayOneShot(buy_sound);
                slot_buy_count_1 += 1;

                BigInteger bigIntValue = (slot_price_1);
                BigInteger multipliedValue = BigInteger.Multiply(bigIntValue, 110);
                BigInteger roundedValue = BigInteger.Divide(multipliedValue, 100);
                slot_price_1 = roundedValue;
                UpdateRank();
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    public void BuySlot_2()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            if (bitcoins >= slot_price_2)
            {
                bitcoins -= slot_price_2;
                _plus_auto += 1;
                audio_source.PlayOneShot(buy_sound);
                slot_buy_count_2 += 1;

                BigInteger bigIntValue = (slot_price_2);
                BigInteger multipliedValue = BigInteger.Multiply(bigIntValue, 110);
                BigInteger roundedValue = BigInteger.Divide(multipliedValue, 100);
                slot_price_2 = roundedValue;
                UpdateRank();
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    public void BuySlot_3()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            if (bitcoins >= slot_price_3)
            {
                bitcoins -= slot_price_3;
                _plus_click += 20;
                audio_source.PlayOneShot(buy_sound);
                slot_buy_count_3 += 1;

                BigInteger bigIntValue = (slot_price_3);
                BigInteger multipliedValue = BigInteger.Multiply(bigIntValue, 110);
                BigInteger roundedValue = BigInteger.Divide(multipliedValue, 100);
                slot_price_3 = roundedValue;
                UpdateRank();
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    public void BuySlot_4()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            if (bitcoins >= slot_price_4)
            {
                bitcoins -= slot_price_4;
                _plus_auto += 65;
                audio_source.PlayOneShot(buy_sound);
                slot_buy_count_4 += 1;

                BigInteger bigIntValue = (slot_price_4);
                BigInteger multipliedValue = BigInteger.Multiply(bigIntValue, 110);
                BigInteger roundedValue = BigInteger.Divide(multipliedValue, 100);
                slot_price_4 = roundedValue;
                UpdateRank();
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    public void BuySlot_5()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            OpenRewardAd2(2);
        }
    }
    public void BuySlot_6()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            if (bitcoins >= slot_price_6)
            {
                bitcoins -= slot_price_6;
                _plus_auto += 500;
                audio_source.PlayOneShot(buy_sound);
                slot_buy_count_6 += 1;

                BigInteger bigIntValue = (slot_price_6);
                BigInteger multipliedValue = BigInteger.Multiply(bigIntValue, 110);
                BigInteger roundedValue = BigInteger.Divide(multipliedValue, 100);
                slot_price_6 = roundedValue;
                UpdateRank();
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    public void BuySlot_7()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            if (bitcoins >= slot_price_7)
            {
                bitcoins -= slot_price_7;
                _plus_click += 2000;
                audio_source.PlayOneShot(buy_sound);
                slot_buy_count_7 += 1;

                BigInteger bigIntValue = (slot_price_7);
                BigInteger multipliedValue = BigInteger.Multiply(bigIntValue, 110);
                BigInteger roundedValue = BigInteger.Divide(multipliedValue, 100);
                slot_price_7 = roundedValue;
                UpdateRank();
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    public void BuySlot_8()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            if (bitcoins >= slot_price_8)
            {
                bitcoins -= slot_price_8;
                _plus_auto += 4500;
                audio_source.PlayOneShot(buy_sound);
                slot_buy_count_8 += 1;

                BigInteger bigIntValue = (slot_price_8);
                BigInteger multipliedValue = BigInteger.Multiply(bigIntValue, 110);
                BigInteger roundedValue = BigInteger.Divide(multipliedValue, 100);
                slot_price_8 = roundedValue;
                UpdateRank();
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    public void BuySlot_9()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            if (bitcoins >= slot_price_9)
            {
                bitcoins -= slot_price_9;
                audio_source.PlayOneShot(buy_sound);
                _plus_click += 6500;
                slot_buy_count_9 += 1;

                BigInteger bigIntValue = (slot_price_9);
                BigInteger multipliedValue = BigInteger.Multiply(bigIntValue, 110);
                BigInteger roundedValue = BigInteger.Divide(multipliedValue, 100);
                slot_price_9 = roundedValue;
                UpdateRank();
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    public void BuySlot_10()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            if (bitcoins >= slot_price_10)
            {
                bitcoins -= slot_price_10;
                audio_source.PlayOneShot(buy_sound);
                _plus_auto += 10000;
                slot_buy_count_10 += 1;

                BigInteger bigIntValue = (slot_price_10);
                BigInteger multipliedValue = BigInteger.Multiply(bigIntValue, 110);
                BigInteger roundedValue = BigInteger.Divide(multipliedValue, 100);
                slot_price_10 = roundedValue;
                UpdateRank();
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    public void StartBlinkingNoMoney()
    {
        if (!isBlinking)
        {
            StartCoroutine(BlinkText());
        }
    }
    IEnumerator BlinkText()
    {
        isBlinking = true;
        float time = 0f;

        while (time < blinkDuration)
        {
            counterText.color = (counterText.color == originalColor) ? blinkColor : originalColor;
            time += Time.deltaTime;
            yield return null;
        }

        counterText.color = originalColor;
        isBlinking = false;
    }
    void Rewarded(int id)
    {
        if (id == 1)
        {
            if(YandexGame.savesData.ad_showen != 4)
            {
                audio_source.PlayOneShot(moneyAdded);
                YandexGame.savesData.ad_showen += 1;
                ad_showen_text.text = YandexGame.savesData.ad_showen + "/4";
                bitcoins *= 2;
                YandexGame.SaveProgress();
            }
        }
        if (id ==2)
        {
            audio_source.PlayOneShot(buy_sound);
            _plus_click += 250;
            slot_buy_count_5 += 1;
            UpdateRank();
            YandexGame.SaveProgress();
        }
    }
    public void OpenRewardAd(int id)
    {
        if(YandexGame.savesData.ad_showen != 4)
        {
            YandexGame.RewVideoShow(id);
        }
    }
    public void OpenRewardAd2(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    private void FormatNumber(BigInteger number)
    {
        string formattedNumber = FormatNumberShort(number);
        counterText.text = formattedNumber;
    }

    public string FormatNumberShort(BigInteger number)
    {
        string[] suffixes = { num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11,
            num12, num13, num14, num15, num16, num17, num18, num19, num20, num21 };
        int suffixIndex = 0;

        // Handle cases where BigInteger is within decimal range
        if (number <= (BigInteger)decimal.MaxValue &&
            number >= (BigInteger)decimal.MinValue)
        {
            decimal numValue = (decimal)number;
            while (numValue >= 1000 && suffixIndex < suffixes.Length)
            {
                numValue /= 1000;
                suffixIndex++;
            }

            if (suffixIndex >= suffixes.Length)
            {
                return max_text;
            }
            else if (suffixIndex > 0)
            {
                return $"{numValue:0.00}{suffixes[suffixIndex - 1]}";
            }
            else
            {
                return number.ToString();
            }
        }
        else
        {
            // Handle cases exceeding decimal range - keep as BigInteger
            BigInteger numValue = number;
            while (numValue >= 1000 && suffixIndex < suffixes.Length)
            {
                numValue /= 1000;
                suffixIndex++;
            }

            if (suffixIndex >= suffixes.Length)
            {
                return max_text;
            }
            else
            {
                return $"{numValue}{suffixes[suffixIndex - 1]}"; // No decimal formatting here
            }
        }
    }

    private void ConveringNumbers()
    {
        bitcoins = ConvertStringToBigInteger(YandexGame.savesData.bitcoins);
        _plus_click = ConvertStringToBigInteger(YandexGame.savesData._plus_click);
        _plus_auto = ConvertStringToBigInteger(YandexGame.savesData._plus_auto);
        slot_buy_count_1 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_1);
        slot_buy_count_2 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_2);
        slot_buy_count_3 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_3);
        slot_buy_count_4 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_4);
        slot_buy_count_5 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_5);
        slot_buy_count_6 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_6);
        slot_buy_count_7 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_7);
        slot_buy_count_8 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_8);
        slot_buy_count_9 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_9);
        slot_buy_count_10 = ConvertStringToBigInteger(YandexGame.savesData.slot_buy_count_10);
        slot_price_1 = ConvertStringToBigInteger(YandexGame.savesData.slot_price_1);
        slot_price_2 = ConvertStringToBigInteger(YandexGame.savesData.slot_price_2);
        slot_price_3 = ConvertStringToBigInteger(YandexGame.savesData.slot_price_3);
        slot_price_4 = ConvertStringToBigInteger(YandexGame.savesData.slot_price_4);
        slot_price_6 = ConvertStringToBigInteger(YandexGame.savesData.slot_price_6);
        slot_price_7 = ConvertStringToBigInteger(YandexGame.savesData.slot_price_7);
        slot_price_8 = ConvertStringToBigInteger(YandexGame.savesData.slot_price_8);
        slot_price_9 = ConvertStringToBigInteger(YandexGame.savesData.slot_price_9);
        slot_price_10 = ConvertStringToBigInteger(YandexGame.savesData.slot_price_10);
    }
    private void ConveringNumbersBack()
    {
        YandexGame.savesData.bitcoins = ConvertBigIntegerToString(bitcoins);
        YandexGame.savesData._plus_click = ConvertBigIntegerToString(_plus_click);
        YandexGame.savesData._plus_auto = ConvertBigIntegerToString(_plus_auto);
        YandexGame.savesData.slot_buy_count_1 = ConvertBigIntegerToString(slot_buy_count_1);
        YandexGame.savesData.slot_buy_count_2 = ConvertBigIntegerToString(slot_buy_count_2);
        YandexGame.savesData.slot_buy_count_3 = ConvertBigIntegerToString(slot_buy_count_3);
        YandexGame.savesData.slot_buy_count_4 = ConvertBigIntegerToString(slot_buy_count_4);
        YandexGame.savesData.slot_buy_count_5 = ConvertBigIntegerToString(slot_buy_count_5);
        YandexGame.savesData.slot_buy_count_6 = ConvertBigIntegerToString(slot_buy_count_6);
        YandexGame.savesData.slot_buy_count_7 = ConvertBigIntegerToString(slot_buy_count_7);
        YandexGame.savesData.slot_buy_count_8 = ConvertBigIntegerToString(slot_buy_count_8);
        YandexGame.savesData.slot_buy_count_9 = ConvertBigIntegerToString(slot_buy_count_9);
        YandexGame.savesData.slot_buy_count_10 = ConvertBigIntegerToString(slot_buy_count_10);
        YandexGame.savesData.slot_price_1 = ConvertBigIntegerToString(slot_price_1);
        YandexGame.savesData.slot_price_2 = ConvertBigIntegerToString(slot_price_2);
        YandexGame.savesData.slot_price_3 = ConvertBigIntegerToString(slot_price_3);
        YandexGame.savesData.slot_price_4 = ConvertBigIntegerToString(slot_price_4);
        YandexGame.savesData.slot_price_6 = ConvertBigIntegerToString(slot_price_6);
        YandexGame.savesData.slot_price_7 = ConvertBigIntegerToString(slot_price_7);
        YandexGame.savesData.slot_price_8 = ConvertBigIntegerToString(slot_price_8);
        YandexGame.savesData.slot_price_9 = ConvertBigIntegerToString(slot_price_9);
        YandexGame.savesData.slot_price_10 = ConvertBigIntegerToString(slot_price_10);
    }
    public string ConvertBigIntegerToString(BigInteger bigIntegerValue)
    {
        string stringValue = bigIntegerValue.ToString();

        return stringValue;
    }

    private BigInteger ConvertStringToBigInteger(string stringValue)
    {
        BigInteger bigIntegerValue;

        if (BigInteger.TryParse(stringValue, out bigIntegerValue))
        {
            return bigIntegerValue;
        }
        else
        {
            return BigInteger.Zero;
        }
    }

    public void ProgressUp(float progress)
    {
        if(YandexGame.savesData.current_comp != 17)
        {
            YandexGame.savesData.currentProgress += progress;
            YandexGame.savesData.currentProgress = Mathf.Clamp(YandexGame.savesData.currentProgress, 0, 100);
            progressImage.fillAmount = YandexGame.savesData.currentProgress / 100f;
            progressPercent.text = Mathf.RoundToInt(progressImage.fillAmount * 100) + "%";
            if (YandexGame.savesData.currentProgress == 100f)
            {
                if(isALreadyBuyShow == false)
                {
                    audio_source.PlayOneShot(new_level_can_snd); 
                    YandexGame.savesData.isBuyBtnShow = true;
                    isALreadyBuyShow = true;

                    showBuyLevel();
                }
            }
        }
    }
    private void showBuyLevel()
    {
        string price2 = "3500";
        string price3 = "10000";
        string price4 = "35000";
        string price5 = "60000";
        string price6 = "100000";
        string price7 = "150000";
        string price8 = "250000";
        string price9 = "500000";
        string price10 = "750000";
        string price11 = "1000000";
        string price12 = "1550000";
        string price13 = "2570000";
        string price14 = "4000000";
        string price15 = "9750000";
        string price16 = "15400000";
        string price17 = "25500000";

        switch (YandexGame.savesData.current_comp)
        {
            case 1:
                //2
                new_level_price_num = ConvertStringToBigInteger(price2);
                break;
            case 2:
                //3
                new_level_price_num = ConvertStringToBigInteger(price3);
                break;
            case 3:
                //4
                new_level_price_num = ConvertStringToBigInteger(price4);
                break;
            case 4:
                //5
                new_level_price_num = ConvertStringToBigInteger(price5);
                break;
            case 5:
                //6
                new_level_price_num = ConvertStringToBigInteger(price6);
                break;
            case 6:
                //7
                new_level_price_num = ConvertStringToBigInteger(price7);
                break;
            case 7:
                //8
                new_level_price_num = ConvertStringToBigInteger(price8);
                break;
            case 8:
                //9
                new_level_price_num = ConvertStringToBigInteger(price9);
                break;
            case 9:
                //10
                new_level_price_num = ConvertStringToBigInteger(price10);
                break;
            case 10:
                //11
                new_level_price_num = ConvertStringToBigInteger(price11);
                break;
            case 11:
                //12
                new_level_price_num = ConvertStringToBigInteger(price12);
                break;
            case 12:
                //13
                new_level_price_num = ConvertStringToBigInteger(price13);
                break;
            case 13:
                //14
                new_level_price_num = ConvertStringToBigInteger(price14);
                break;
            case 14:
                //15
                new_level_price_num = ConvertStringToBigInteger(price15);
                break;
            case 15:
                //16
                new_level_price_num = ConvertStringToBigInteger(price16);
                break;
            case 16:
                //17
                new_level_price_num = ConvertStringToBigInteger(price17);
                break;
        }
        progressPercent.gameObject.SetActive(false);
        new_levelOBJ.SetActive(true);
        YandexGame.SaveProgress();
    }
    public void hideBuyLevel()
    {
        if(YandexGame.savesData.current_comp < 17)
        {
            if (bitcoins >= new_level_price_num)
            {
                StartCoroutine(StartSunScaleAndRotate());
                YandexGame.savesData.isBuyBtnShow = false;
                new_levelOBJ.SetActive(false);
                progressPercent.text = "0%";
                progressImage.fillAmount = 0f;
                YandexGame.savesData.current_comp += 1;
                YandexGame.savesData.currentProgress = 0f;
                audio_source.PlayOneShot(newComp);
                YandexGame.NewLeaderboardScores("complevel", YandexGame.savesData.current_comp);
                bitcoins -= new_level_price_num;
                progressPercent.gameObject.SetActive(true);
                foreach (Transform child in lbParent)
                {
                    Destroy(child.gameObject);
                }
                Instantiate(leaderBoard, lbParent);
                Update_comp();
                YandexGame.SaveProgress();
                isALreadyBuyShow = false;
                YandexGame.savesData.ad_showen = 0;
                ad_showen_text.text = YandexGame.savesData.ad_showen + "/4";
                forbiddenImg.SetActive(false);
                
                switch (YandexGame.savesData.current_comp)
                {
                    case var _ when YandexGame.savesData.current_comp >= 17:
                        background.sprite = backsSprites[10];
                        break;
                    case var _ when YandexGame.savesData.current_comp >= 16:
                        background.sprite = backsSprites[9];
                        break;
                    case var _ when YandexGame.savesData.current_comp >= 14:
                        background.sprite = backsSprites[8];
                        break;
                    case var _ when YandexGame.savesData.current_comp >= 12:
                        background.sprite = backsSprites[7];
                        break;
                    case var _ when YandexGame.savesData.current_comp >= 10:
                        background.sprite = backsSprites[6];
                        break;
                    case var _ when YandexGame.savesData.current_comp >= 8:
                        background.sprite = backsSprites[5];
                        break;
                    case var _ when YandexGame.savesData.current_comp >= 7:
                        background.sprite = backsSprites[4];
                        break;
                    case var _ when YandexGame.savesData.current_comp >= 6:
                        background.sprite = backsSprites[3];
                        break;
                    case var _ when YandexGame.savesData.current_comp >= 4:
                        background.sprite = backsSprites[2];
                        break;
                    case var _ when YandexGame.savesData.current_comp >= 2:
                        background.sprite = backsSprites[1];
                        break;
                    default:
                        background.sprite = backsSprites[0];
                        break;
                }
            }
            else
            {
                audio_source.PlayOneShot(noMoney);
                StartBlinkingNoMoney();
            }
        }
    }
    private IEnumerator StartSunScaleAndRotate()
    {
        allowRotate = true;
        float duration = 2f;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            sunImage.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, t));
            sunImage.transform.localScale = UnityEngine.Vector3.Lerp(UnityEngine.Vector3.one, UnityEngine.Vector3.one * targetScale, t);
            sunImage.transform.Rotate(UnityEngine.Vector3.forward * 100 * Time.deltaTime);
            yield return null;
        }

        duration = 2f;
        startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            sunImage.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, t));
            yield return null;
        }
        allowRotate = false;
    }

    private void UpdateRank()
    {
        BigInteger generalPlus = slot_buy_count_1 + slot_buy_count_2 + slot_buy_count_3 + slot_buy_count_4 + slot_buy_count_5 +
            slot_buy_count_6 + slot_buy_count_7 + slot_buy_count_8 + slot_buy_count_9 + slot_buy_count_10;

        switch (generalPlus)
        {
            case var _ when generalPlus >= 425:
                rankText.text = rank14;
                break;
            case var _ when generalPlus >= 350:
                rankText.text = rank13;
                break;
            case var _ when generalPlus >= 300:
                rankText.text = rank12;
                break;
            case var _ when generalPlus >= 275:
                rankText.text = rank11;
                break;
            case var _ when generalPlus >= 250:
                rankText.text = rank10;
                break;
            case var _ when generalPlus >= 225:
                rankText.text = rank9;
                break;
            case var _ when generalPlus >= 200:
                rankText.text = rank8;
                break;
            case var _ when generalPlus >= 175:
                rankText.text = rank7;
                break;
            case var _ when generalPlus >= 150:
                rankText.text = rank6;
                break;
            case var _ when generalPlus >= 125:
                rankText.text = rank5;
                break;
            case var _ when generalPlus >= 100:
                rankText.text = rank4;
                break;
            case var _ when generalPlus >= 65:
                rankText.text = rank3;
                break;
            case var _ when generalPlus >= 20:
                rankText.text = rank2;
                break;
            default:
                rankText.text = rank1;
                break;
        }
    }

    public void On_onOffObjs()
    {
        foreach(Button btns in buttonsOnOff)
        {
            btns.enabled = true;
        }
        foreach (Collider2D clds in collidersOnOff)
        {
            clds.enabled = true;
        }
    }
    public void Off_onOffObjs()
    {
        foreach (Button btns in buttonsOnOff)
        {
            btns.enabled = false;
        }
        foreach (Collider2D clds in collidersOnOff)
        {
            clds.enabled = false;
        }
    }
    private IEnumerator PlayRandomSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(60, 180));

            if (!horror_sound.isPlaying)
            {
                horror_sound.Play();
            }
        }
    }
}
