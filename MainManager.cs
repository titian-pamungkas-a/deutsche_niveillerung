using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    [SerializeField]
    private AudioSource music, btn;
    //value, name, picture, description
    private List<(int, string, string, string, bool)> hps;
    public List<(int, string, string, string, bool)> availableHps;
    public (int, string, string, string, bool) currentHp;

    public List<(int, string, string, string, bool)> damages;
    public List<(int, string, string, string, bool)> availableDamages;
    public (int, string, string, string, bool) currentDamage;

    public List<(int, string, string, string, bool)> armors;
    public List<(int, string, string, string, bool)> availableArmors;
    public (int, string, string, string, bool) currentArmor;

    // HP, attack damage, armor, critical damage, critical chance, heal, heal chance
    public List<(List<int>, string, string, string, bool)> charms;
    public List<(List<int>, string, string, string, bool)> availableCharms;
    public (List<int>, string, string, string, bool) currentCharm;

    public int currentLvl, openLvl;
    public int openHps, openDamages, openArmors, openCharms;
    public int gold, diamond;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        atStart();
        DontDestroyOnLoad(gameObject);
    }

    private void atStart()
    {
        
        List<int> template = new List<int>() { 0, 0, 0, 0, 0, 0, 0 };
        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            setAll();
        }
        SetHps();
        SetDamages();
        SetArmors();
        SetCharms(template);
        SetAlls();
        SetCurrentHp(GetHps()[PlayerPrefs.GetInt("currentHp")]);
        SetCurrentDamages(GetDamages()[PlayerPrefs.GetInt("currentDamage")]);
        SetCurrentArmor(GetArmors()[PlayerPrefs.GetInt("currentArmor")]);
        SetCurrentCharm(GetCharms()[PlayerPrefs.GetInt("currentCharm")]);
        print(PlayerPrefs.GetInt("openHps") + " last");
        print(PlayerPrefs.GetInt("openDamages"));
        print(PlayerPrefs.GetInt("openArmors"));
        print(PlayerPrefs.GetInt("openCharms"));
        print(PlayerPrefs.GetInt("currentHp") + " last");
        print(PlayerPrefs.GetInt("currentDamage") + " last");
        print(PlayerPrefs.GetInt("currentArmor") + " last");
        print(PlayerPrefs.GetInt("currentCharm") + " last");
        print(PlayerPrefs.GetInt("diamond") + " last");
        print(PlayerPrefs.GetInt("gold") + " last");
        print(PlayerPrefs.GetInt("openLvl") + " last");
        print(PlayerPrefs.GetInt("PlayerName") + " last");
    }

    private void SetAlls()
    {
        if (Instance != null)
        {
            SetOpenHps(PlayerPrefs.GetInt("openHps"));
            SetOpenDamages(PlayerPrefs.GetInt("openDamages"));
            SetOpenArmors(PlayerPrefs.GetInt("openArmors"));
            SetOpenCharms(PlayerPrefs.GetInt("openCharms"));
            SetCurrentLevel(0);
            SetOpenLevel(PlayerPrefs.GetInt("openLvl"));
        }
    }

    private void setAll()
    {
        PlayerPrefs.SetInt("diamond", 0);
        PlayerPrefs.SetInt("gold", 0);
        PlayerPrefs.SetInt("openLHps", 0);
        PlayerPrefs.SetInt("openDamages", 0);
        PlayerPrefs.SetInt("openArmors", 0);
        PlayerPrefs.SetInt("openCharms", 0);
        PlayerPrefs.SetInt("currentHp", 0);
        PlayerPrefs.SetInt("currentDamage", 0);
        PlayerPrefs.SetInt("currentArmor", 0);
        PlayerPrefs.SetInt("currentCharm", 0);
        PlayerPrefs.SetInt("openLvl", 0);
        PlayerPrefs.SetString("PlayerName", "username");
        

    }

    private void Start()
    {
        
    }

    public void SetHps()
    {
        if (Instance != null)
        {
            int temp = 0;
            MainManager.Instance.hps = new List<(int, string, string, string, bool)>() {
                (0, "Irona", "DamageItems/Free-Fantasy-Items_19", "hp", temp++ <= GetOpenHps() ? true : false),
                (20, "Bronzea", "DamageItems/Free-Fantasy-Items_20", "hp", temp++ <= GetOpenHps() ? true : false),
                (50, "Silvera", "DamageItems/Free-Fantasy-Items_18", "hp", temp++ <= GetOpenHps() ? true : false),
                (100, "Golda", "DamageItems/Free-Fantasy-Items_21", "hp", temp++ <= GetOpenHps() ? true : false)
            };
            
        }
    }

    public List<(int, string, string, string, bool)> GetHps()
    {
        return MainManager.Instance.hps;
    }

    public void SetCurrentHp((int, string, string, string, bool) item)
    {
        if (Instance != null)
        {
            MainManager.Instance.currentHp = item;
        }
    }

    public (int, string, string, string, bool) GetCurrentHp()
    {
        return MainManager.Instance.currentHp;
    }

    private void SetDamages()
    {
        if (Instance != null)
        {
            int temp = 0;
            MainManager.Instance.damages = new List<(int, string, string, string, bool)>() {
                (0, "Ironi", "DamageItems/Free-Fantasy-Items_01", "damage", temp++ <= GetOpenDamages() ? true : false),
                (5, "Bronzei", "DamageItems/Free-Fantasy-Items_07", "damage", temp++ <= GetOpenDamages() ? true : false),
                (10, "Silveri", "DamageItems/Free-Fantasy-Items_02", "damage", temp++ <= GetOpenDamages() ? true : false),
                (15, "Goldi", "DamageItems/Free-Fantasy-Items_03", "damage", temp++ <= GetOpenDamages() ? true : false)
                //(200, "Diamond", "DamageItems/Free-Fantasy-Items_05", "damage", false)
            };
        }
    }

    public List<(int, string, string, string, bool)> GetDamages()
    {
        return MainManager.Instance.damages;
    }

    public void SetCurrentDamages((int, string, string, string, bool) item)
    {
        if (Instance != null)
        {
            MainManager.Instance.currentDamage = item;
        }
    }

    public (int, string, string, string, bool) GetCurrentDamage()
    {
        return MainManager.Instance.currentDamage;
    }

    private void SetArmors()
    {
        if (Instance != null)
        {
            int temp = 0;
            MainManager.Instance.armors = new List<(int, string, string, string, bool)>() {
                (1, "Ironu", "DamageItems/Free-Fantasy-Items_24", "armor", temp++ <= GetOpenArmors() ? true : false),
                (2, "Bronzeu", "DamageItems/Free-Fantasy-Items_27", "armor", temp++ <= GetOpenArmors() ? true : false),
                (5, "Silveru", "DamageItems/Free-Fantasy-Items_28", "armor", temp++ <= GetOpenArmors() ? true : false),
                (10, "Goldu", "DamageItems/Free-Fantasy-Items_26", "armor", temp++ <= GetOpenArmors() ? true : false)
                //(200, "Diamonda", "DamageItems/Free-Fantasy-Items_10", "asd")
            };
        }
    }

    public List<(int, string, string, string, bool)> GetArmors()
    {
        return MainManager.Instance.armors;
    }

    public void SetCurrentArmor((int, string, string, string, bool) item)
    {
        if (Instance != null)
        {
            MainManager.Instance.currentArmor = item;
        }
    }

    public (int, string, string, string, bool) GetCurrentArmor()
    {
        return MainManager.Instance.currentArmor;
    }

    private void SetCharms(List<int> item)
    {
        if (Instance != null)
        {
            int temp = 0;
            MainManager.Instance.charms = new List<(List<int>, string, string, string, bool)>() {
                (new List<int>(){ 0, 0, 0, 0, 0, 0, 0}, "Irone", "DamageItems/Free-Fantasy-Items_38", "charm", temp++ <= GetOpenCharms() ? true : false),
                (new List<int>(){ 0, 0, 0, 0, 0, 25, 20}, "Bronzee", "DamageItems/Free-Fantasy-Items_39", "charm", temp++ <= GetOpenArmors() ? true : false),
                (new List<int>(){ 0, 0, 0, 20, 20, 0, 0}, "Silvere", "DamageItems/Free-Fantasy-Items_40", "charm", temp++ <= GetOpenArmors() ? true : false),
                (new List<int>(){ 0, 12, 0, 0, 0, -10, 100}, "Golde", "DamageItems/Free-Fantasy-Items_44", "charm", temp++ <= GetOpenArmors() ? true : false)
                //(new List<int>(item), "Diamonda", "DamageItems/Free-Fantasy-Items_10", "asd")
            };
        }
    }

    public List<(List<int>, string, string, string, bool)> GetCharms()
    {
        return MainManager.Instance.charms;
    }

    public void SetCurrentCharm((List<int>, string, string, string, bool) item)
    {
        if (Instance != null)
        {
            MainManager.Instance.currentCharm = item;
        }
    }

    public (List<int>, string, string, string, bool) GetCurrentCharm()
    {
        return MainManager.Instance.currentCharm;
    }

    public void SetCurrentLevel(int item)
    {

        if (Instance != null)
        {
            MainManager.Instance.currentLvl = item;
        }
        
    }

    public int GetCurrentLevel()
    {
        return MainManager.Instance.currentLvl;
    }

    public void SetOpenLevel(int item)
    {
        if(Instance != null)
        {
            MainManager.Instance.openLvl = item;
        }
        
    }

    public int GetOpenLevel()
    {
        return MainManager.Instance.openLvl;
    }

    public void SetOpenHps(int item)
    {
        if (Instance != null)
        {
            MainManager.Instance.openHps = item;
            for(int i = 0; i < MainManager.Instance.hps.Count; i++)
            {
                MainManager.Instance.hps[i] = (MainManager.Instance.hps[i].Item1, MainManager.Instance.hps[i].Item2, MainManager.Instance.hps[i].Item3, MainManager.Instance.hps[i].Item4, i <= item ? true : false);
            }
            
        }

    }

    public int GetOpenHps()
    {
        return MainManager.Instance.openHps;
    }

    public void SetOpenDamages(int item)
    {
        if (Instance != null)
        {
            MainManager.Instance.openDamages = item;
            for (int i = 0; i < MainManager.Instance.damages.Count; i++)
            {
                MainManager.Instance.damages[i] = (MainManager.Instance.damages[i].Item1, MainManager.Instance.damages[i].Item2, MainManager.Instance.damages[i].Item3, MainManager.Instance.damages[i].Item4, i <= item ? true : false);
            }
        }

    }

    public int GetOpenDamages()
    {
        return MainManager.Instance.openDamages;
    }

    public void SetOpenArmors(int item)
    {
        if (Instance != null)
        {
            MainManager.Instance.openArmors = item;
            for (int i = 0; i < MainManager.Instance.armors.Count; i++)
            {
                MainManager.Instance.armors[i] = (MainManager.Instance.armors[i].Item1, MainManager.Instance.armors[i].Item2, MainManager.Instance.armors[i].Item3, MainManager.Instance.armors[i].Item4, i <= item ? true : false);
            }
        }

    }

    public int GetOpenArmors()
    {
        return MainManager.Instance.openArmors;
    }

    public void SetOpenCharms(int item)
    {
        if (Instance != null)
        {
            MainManager.Instance.openCharms = item;
            for (int i = 0; i < MainManager.Instance.charms.Count; i++)
            {
                MainManager.Instance.charms[i] = (new List<int>(MainManager.Instance.charms[i].Item1), MainManager.Instance.charms[i].Item2, MainManager.Instance.charms[i].Item3, MainManager.Instance.charms[i].Item4, i <= item ? true : false);
            }
        }

    }

    public int GetOpenCharms()
    {
        return MainManager.Instance.openCharms;
    }

    public void StopMusic()
    {
        music.volume = 0.35f;
    }

    public void StopMusic(float vol)
    {
        music.volume = vol;
    }
    public void PlayMusic()
    {
        music.volume = 0.8f;
    }

    public void PlayButton()
    {
        btn.Play();
    }
}
