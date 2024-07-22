using System.Collections;
using System.Collections.Generic;                                    
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private List<SentenceData> rightSentence;
    private List<string> choices;
    private CreateData createData;
    public Text engText, indText, playerHPText, enemyHPText;
    private string engString, indString;
    public List<Button> choiceButtons;
    public GameObject endPanel;
    public Slider playerSlider, enemySlider;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private GameObject pausePanel, buttonPrefabs, answerParent;
    private GameObject go;
    private MainManager mainManager;
    private int ronde;
    private Text diammond, gold;
    void Start()
    {
        //endPanel.SetActive(false);
        go = GameObject.Find("MainManager");
        mainManager = go.GetComponent<MainManager>();
        createData = this.GetComponent<CreateData>();
        playerSlider.maxValue = player.Hp;
        playerSlider.value = player.Hp;
        enemySlider.maxValue = enemy.Hp;
        enemySlider.value = enemy.Hp;
        answerParent = GameObject.Find("Pilihan");
        pausePanel.SetActive(false);
        ronde = 0;
        rightSentence = new List<SentenceData>(createData.getSentences(mainManager.GetCurrentLevel()));
        Ronde(ronde);
        diammond = GameObject.Find("Stats").transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
        gold = GameObject.Find("Stats").transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        gold.text = PlayerPrefs.GetInt("gold").ToString();
        diammond.text = PlayerPrefs.GetInt("diamond").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        indText.text = indString;
        engText.text =  "\u0022" +engString + "\u0022";
        playerHPText.text = player.Hp.ToString();
        playerSlider.value = player.Hp;
        enemyHPText.text = enemy.Hp.ToString();
        enemySlider.value = enemy.Hp;
        
        /*if (enemyHP <= 0)
        {
            endPanel.SetActive(true);
        }else if (playerHP <= 0)
        {
            endPanel.SetActive(true);
        }*/
    }

    private void Ronde(int rond)
    {
        
        print(rightSentence.Count + " ");

        indString = rightSentence[rond].SentenceInInd;
        engString = "";
        if (rightSentence[rond].Index == 0)
        {
            choices = new List<string>(rightSentence[rond].SentenceInEng.Split(' '));
        }
        else
        {
            choices = new List<string>();
            choices.Add(rightSentence[rond].SentenceInEng);
        }
        choices.AddRange(rightSentence[rond].FalseWord);
        List<string> temp = new List<string>();
        while (choices.Count > 0) // untuk shuffle isi list
        {
            int ind = Random.Range(0, choices.Count);
            temp.Add(choices[ind]);
            choices.RemoveAt(ind);
        }
        if (answerParent.transform.childCount > 0)
        {
            foreach (Transform child in answerParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        if (rightSentence[rond].Index == 0)
        {
            for (int i = 0; i < temp.Count; i++)
            {
                CreateButton(temp[i], new Vector3(-250f + (i % 3) * 250f, -200f - (i / 3) * 125f, 0f));
            }
        }
        else
        {
            for (int i = 0; i < temp.Count; i++)
            {
                CreateButton(temp[i], new Vector3(0f, -200f - i * 125f, 0f));
            }
        }
        
    }

    private void CreateButton(string str, Vector3 pos)
    {
        GameObject buttonObject = Instantiate(buttonPrefabs, Vector3.zero, Quaternion.identity);
        Text textObject = buttonObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        textObject.text = str;
        RectTransform rt = buttonObject.GetComponent<RectTransform>();
        rt.SetParent(answerParent.transform);
        rt.localScale = new Vector3(1, 1, 1);
        rt.localPosition = pos;
        Button btn = buttonObject.GetComponent<Button>();
        btn.onClick.AddListener(delegate { AddText(str); });
    }

    void AddText(string teks)
    {
        engString += teks + " ";
        print(teks);
    }

    public void checkString()
    {
        if (engString.Length > 0)
            engString = engString.Remove(engString.Length - 1, 1);
        //player.Attack();
        if (engString == rightSentence[ronde].SentenceInEng)
        {
            print("Benar");
            player.Attack();
            ronde++;
        }
        else enemy.Attack();
        if (ronde == rightSentence.Count) ronde = 0;
        Ronde(ronde);
    }

    public void deleteText()
    {
        engString = "";
    }

    public void Pause()
    {
        mainManager.StopMusic();
        mainManager.PlayButton();
        pausePanel.SetActive(true);
    }

    public void Continue()
    {
        mainManager.PlayMusic();
        mainManager.PlayButton();
        pausePanel.SetActive(false);
    }
}
