using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Easy : MonoBehaviour
{
    public GameObject Button;
    public Transform pnlGame;
    public AudioClip ClickClip, WinClip, LoseClip, CorectClip, FailClip, Nhacnenclip;
    private AudioSource AudioSource, nhacnen;
    public GameObject pnlWin, pnlBegin, pnlGameplay, pnlSettings, btn, obj, nhac, pnlFail,pnlEdit;

    public Text txtLuot, txtLuot2, txtTime, txtTime2, txtLever, txtLuot3, txtTime3;
    public Button btnRestar, btnMenu, btnStart, btnSetting, btnmenu2, btnDe, btnTrungBinh, btnKho, btnOpenAudio,
        btnOpenAudio2, btnOpenMusic, btnOpenMusic2,btnEdit;

    public Sprite BackroudImg, OpenMusicImg, OpenAudioImg, sOfMusicImg, sOfAudioImg;
    private List<Button> btnlist = new List<Button>();
    public Sprite[] SourcesSprite;
    public List<Sprite> GameSprite = new List<Sprite>();
    private bool firstGuest, secontGuest, TinhGio, OpenMusics, OpenAudios, isOpenAudio,isEdit;
    string firstName, seconName, Gametime2;
    int firstIndex, seconIndex, TotalGuess, NoOfGuess, CorrectGuess;
    float GameTime = 30;
    void Awake()
    {
        AddButon(8);
    }
    // Start is called before the first frame update
    void Start()
    {
       
        btnOpenAudio.image.sprite = OpenAudioImg;
        pnlEdit.SetActive ( false);
        btnOpenAudio2.image.sprite = OpenAudioImg;
        btnOpenMusic.image.sprite = OpenMusicImg;
        btnOpenMusic2.image.sprite = OpenMusicImg;
        isOpenAudio = true;
        OpenMusics = false;
        OpenAudios = false;
        obj = gameObject;
        AudioSource = obj.GetComponent<AudioSource>();
        nhacnen = nhac.GetComponent<AudioSource>();
        AudioSource.clip = ClickClip;
        nhacnen.clip = Nhacnenclip;
        nhacnen.Play();
        txtLever.text = "Chế Độ Dễ";
        btnmenu2.image.color = new Color(0, 0, 0, 0);
        btnOpenAudio2.image.color = new Color(0, 0, 0, 0);
        btnOpenMusic2.image.color = new Color(0, 0, 0, 0);
        txtTime2.text = "";
        txtLuot2.text = "";
        getbuton();
        AddListener();
        AddSprites();
        Shuffle(GameSprite);
        for (int i = 0; i < btnlist.Count; i++)
        {
            btnlist[i].image.color = new Color(0, 0, 0, 0);
        }
        pnlWin.SetActive(false);
        pnlFail.SetActive(false);
        pnlSettings.SetActive(false);
        pnlBegin.SetActive(true);
    }
    public void stargame()
    {
        clickclip();
        btnmenu2.image.color = new Color(1, 1, 1, 1);
        btnOpenAudio2.image.color = new Color(1, 1, 1, 1);
        btnOpenMusic2.image.color = new Color(1, 1, 1, 1);
        txtLuot2.text = "Lượt: " + NoOfGuess;
        txtTime2.text = "Time: 30";
        pnlBegin.SetActive(false);
        for (int i = 0; i < btnlist.Count; i++)
        {
            btnlist[i].image.color = new Color(1, 1, 1, 1);
        }
    }
    public void OpenAudio()
    {
        if (OpenAudios == true)
        {
            OpenAudios = false;
            isOpenAudio = true;
            btnOpenAudio.image.sprite = OpenAudioImg;
            btnOpenAudio2.image.sprite = OpenAudioImg;
        }
        else
        {
            AudioSource.clip = null;
            AudioSource.clip = null;
            AudioSource.clip = null;
            AudioSource.clip = null;
            AudioSource.clip = null;
            btnOpenAudio.image.sprite = sOfAudioImg;
            btnOpenAudio2.image.sprite = sOfAudioImg;
            OpenAudios = true;
            isOpenAudio = false;
        }

    }

    public void openmusic()
    {
        if (OpenMusics == true)
        {
            nhacnen.clip = Nhacnenclip;
            nhacnen.Play();
            OpenMusics = false;
            btnOpenMusic.image.sprite = OpenMusicImg;
            btnOpenMusic2.image.sprite = OpenMusicImg;
        }
        else
        {
            nhacnen.clip = null;
            nhacnen.Stop();
            OpenMusics = true;
            btnOpenMusic.image.sprite = sOfMusicImg;
            btnOpenMusic2.image.sprite = sOfMusicImg;
        }
    }

    private void Update()
    {
        if (TinhGio == true)
        {

            GameTime -= Time.deltaTime;
            Gametime2 = string.Format("{0:0}", GameTime);
            txtTime2.text = "Time: " + Gametime2;
            checkFail(Gametime2);
        }



    }
    public void clickclip()
    {
        if (isOpenAudio == true)
        {
            AudioSource.clip = ClickClip;
            AudioSource.Play();
        }

    }
    public void winclip()
    {
        if (isOpenAudio == true)
        {
            AudioSource.clip = WinClip;
            AudioSource.Play();
        }
    }
    public void loseclip()
    {
        if (isOpenAudio == true)
        {
            AudioSource.clip = LoseClip;
            AudioSource.Play();
        }
    }
    public void corectclip()
    {
        if (isOpenAudio == true)
        {
            AudioSource.clip = CorectClip;
            AudioSource.Play();
        }
    }
    public void failclip()
    {
        if (isOpenAudio == true)
        {
            AudioSource.clip = FailClip;
            AudioSource.Play();
        }
    }
    public void Setting()
    {
        clickclip();
        pnlSettings.SetActive(true);
        btnSetting.interactable = false;
        btnSetting.image.color = new Color(0, 0, 0, 0);
        btnEdit.interactable = false;
        btnEdit.image.color = new Color(0, 0, 0, 0);
        pnlEdit.SetActive(false);
        btnStart.interactable = true;
        btnStart.image.color = new Color(1, 1, 1, 1);
        isEdit = false;
    }
    public void Edit()
    {
        if (isEdit == false)
        {
            clickclip();
            pnlEdit.SetActive(true);
            btnStart.interactable = false;
            btnStart.image.color = new Color(0, 0, 0, 0);
            isEdit = true;
        }
        else
        {
            clickclip();
            pnlEdit.SetActive(false);
            btnStart.interactable = true;
            btnStart.image.color = new Color(1, 1, 1, 1);
            isEdit = false;
        }
    }

    void openSetting()
    {
        btnEdit.interactable = true;
        btnEdit.image.color = new Color(1, 1, 1, 1);
        btnSetting.interactable = true;
        btnSetting.image.color = new Color(1, 1, 1, 1);
        pnlEdit.SetActive(false);
        btnStart.interactable = true;
        btnStart.image.color = new Color(1, 1, 1, 1);
        isEdit = false;
    }
    public void checkDe()
    {
        clickclip();
        SceneManager.LoadScene(0);
        openSetting();
        pnlSettings.SetActive(false);
    }
    public void checkTrungBinh()
    {
        clickclip();
        openSetting();
        SceneManager.LoadScene(1);
        pnlSettings.SetActive(false);
    }
    public void checkKho()
    {
        clickclip();
        openSetting();
        SceneManager.LoadScene(2);
        pnlSettings.SetActive(false);
    }
    public void menu()
    {
        clickclip();
        TinhGio = false;
        btnmenu2.image.color = new Color(0, 0, 0, 0);
        btnOpenAudio2.image.color = new Color(0, 0, 0, 0);
        btnOpenMusic2.image.color = new Color(0, 0, 0, 0);
        txtTime2.text = "";
        txtLuot2.text = "";
        pnlBegin.SetActive(true);
        pnlWin.SetActive(false);
        pnlFail.SetActive(false);
        Restar();
        for (int i = 0; i < btnlist.Count; i++)
        {
            btnlist[i].image.color = new Color(0, 0, 0, 0);
        }

    }
    void AddSprites()
    {
        int size = btnlist.Count;
        int index = 0;
        for (int i = 0; i < size; i++)
        {
            if (i == size / 2)
            {
                index = 0;
            }
            GameSprite.Add(SourcesSprite[index]);
            index++;
        }
        TotalGuess = size / 2;
    }
    void getbuton()
    {
        //l?y các btn dem vào list
        GameObject[] objects = GameObject.FindGameObjectsWithTag("imgButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btnlist.Add(objects[i].GetComponent<Button>());
            btnlist[i].image.sprite = BackroudImg;
        }
    }

    void AddListener()
    {
        foreach (Button btn in btnlist)
        {
            btn.onClick.AddListener(() => PickPanel());
        }
    }
    void PickPanel()
    {
        // string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (!firstGuest)
        {
            clickclip();
            firstGuest = true;
            firstIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstName = GameSprite[firstIndex].name;
            btnlist[firstIndex].image.sprite = GameSprite[firstIndex];
            TinhGio = true;

        }
        else if (!secontGuest)
        {
            clickclip();
            secontGuest = true;
            seconIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            seconName = GameSprite[seconIndex].name;
            btnlist[seconIndex].image.sprite = GameSprite[seconIndex];
            NoOfGuess++;
            txtLuot2.text = "Lượt: " + NoOfGuess;
            // Debug.Log("totle" + TotalGuess + "corect" + CorrectGuess);
            StartCoroutine(checkgame());
        }
    }
    IEnumerator checkgame()
    {


        if (firstName == seconName && firstIndex != seconIndex)
        {
            corectclip();
            yield return new WaitForSeconds(0.2f);
            CorrectGuess++;
            btnlist[firstIndex].interactable = false;
            btnlist[seconIndex].interactable = false;
            btnlist[firstIndex].image.color = new Color(0, 0, 0, 0);
            btnlist[seconIndex].image.color = new Color(0, 0, 0, 0);
            checkWin();

        }
        else
        {
            failclip();
            yield return new WaitForSeconds(0.5f);
            btnlist[firstIndex].image.sprite = BackroudImg;
            btnlist[seconIndex].image.sprite = BackroudImg;
        }
        firstGuest = secontGuest = false;
    }
    void checkWin()
    {
        if (CorrectGuess == TotalGuess)
        {
            GameTime = 30;
            int tg = int.Parse(Gametime2);
            tg = 30 - tg;
            winclip();
            TinhGio = false;
            pnlWin.SetActive(true);
            txtLuot.text = "Số Lượt: " + NoOfGuess;
            txtTime.text = "Tổng Thời Gian :" + tg;

        }
    }
    void checkFail(string time)
    {
        if (time == "0")
        {
            for (int i = 0; i < btnlist.Count; i++)
            {
                btnlist[i].interactable = false;
                btnlist[i].image.color = new Color(0, 0, 0, 0);
            }
            btnlist[seconIndex].interactable = false;
            btnlist[firstIndex].image.color = new Color(0, 0, 0, 0);

            GameTime = 30;
            loseclip();
            TinhGio = false;
            pnlFail.SetActive(true);
            txtLuot3.text = "Số Lượt: " + NoOfGuess;
            txtTime3.text = "Hết Giờ :D";
        }
    }
    void Shuffle(List<Sprite> list)
    {
        Sprite temp;
        for (int i = 0; i < list.Count; i++)
        {
            temp = list[i];
            int random = Random.Range(i, list.Count);
            list[i] = list[random];
            list[random] = temp;

        }
    }
    public void Restar()
    {
        CorrectGuess = 0;
        clickclip();
        for (int i = 0; i < btnlist.Count; i++)
        {
            btnlist[i].interactable = true;
            btnlist[i].image.color = new Color(1, 1, 1, 1);
        }
        firstGuest = secontGuest = false;
        getbuton();
        Shuffle(GameSprite);
        pnlWin.SetActive(false);
        pnlFail.SetActive(false);
        NoOfGuess = 0;
        txtLuot2.text = "Lượt: " + NoOfGuess;

    }
    void AddButon(int j)
    {
        for (int i = 0; i < j; i++)
        {
            //t?o btn
            btn = Instantiate(Button);
            btn.name = "" + i;
            //dua vào pannel
            btn.transform.SetParent(pnlGame, false);
        }
    }
    public void ThoatGame()
    {
        clickclip();
        Application.Quit();
    }
}
