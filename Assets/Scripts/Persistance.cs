using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int score;
    public string playerName;
}

public class Persistance : MonoBehaviour
{
    public static Persistance Instance;
    public string c_playerName;
    public int c_score;
    public string b_playerName;
    public int b_score;

    private void Awake() 
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void NewHighScore(int score) 
    {
        b_playerName = c_playerName;
        b_score = score;
    }

    public void SaveScore()
    {
        PlayerData data = new PlayerData
        {
            score = b_score,
            playerName = b_playerName
        };

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            b_playerName = data.playerName;
            b_score = data.score;
        }
    }
}
