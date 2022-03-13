using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text PlayerNameText;
    [HideInInspector]public Text BestScoreText;

    public static string PlayerName;
    public int BestScoreValue;
    #region prop
    //private string bestValue;

    //public string BestScore
    //{
    //    get { return bestValue;}
    //    set { bestValue = value; }
    //}

    #endregion
    public static string BestScore;

    public static GameManager Instance;
    private void Awake()
    {
        // start of new code
        if (Instance != null)  //if there was another game manager. destroy this one, so we can use first created one 
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
        SetBestScore();
        InitBestScore();
    }

    public void InitBestScore()
    {
        BestScoreText = GameObject.Find("Best Score Text").GetComponent<Text>();
        SetBestScoreText();
    }

    [System.Serializable]
    class SaveScoreData
    {
        public string PlayerName;
        public int BestScoreValue;
    }
    public void GetPlayerName()
    {
        PlayerName = PlayerNameText.text;
    }
    public void SetBestScore()//Todo:is it "BEST" score
    {
        BestScore = "Best Score" + ":" + PlayerName + ":" + BestScoreValue;
    }
    public void SetBestScoreText()
    {
        BestScoreText.text = BestScore;
    }

    public void SaveBestScore()
    {
        SaveScoreData data = new SaveScoreData();
        data.PlayerName = PlayerName;
        data.BestScoreValue = BestScoreValue;

        string json = JsonUtility.ToJson(data);

        //Application.persistentDataPath that will give you a folder where you can save data
        //that will survive between application reinstall or update and append to it the filename savefile.json.
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveScoreData data = JsonUtility.FromJson<SaveScoreData>(json);
            PlayerName = data.PlayerName;
            BestScoreValue = data.BestScoreValue;
        }
    }
}
