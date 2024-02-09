using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    [Serializable]
    public class Player{
        
        public String name;
        public int score;
    }
    public Player player;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //LoadName(); 
        Debug.Log(Application.persistentDataPath);
    }

    [System.Serializable]
    class SaveData
    {
        public String bestNamePlayer;
        public int bestScore;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.bestNamePlayer = player.name;
        data.bestScore = player.score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public Player LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Player playerSaved = new Player();
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerSaved.name = data.bestNamePlayer;
            playerSaved.score = data.bestScore;
        }
        return playerSaved;
    }
    private void OnDestroy() {
        SaveName();
    }
}
