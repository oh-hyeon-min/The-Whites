using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update

    public Player player;
    public GameManager gameManager;
    public DateTime savingTime;
    public String sT;

    public void Save() {
        PlayerPrefs.DeleteAll();
        savingTime = DateTime.Now;
        sT = savingTime.ToString("yyyy-MM-dd HH:mm:ss");
        sT = sT.Replace("-", "/");
        Debug.Log(sT);
        PlayerPrefs.SetString("Chapter", gameManager.chapter);
        PlayerPrefs.SetString("SavingTime", sT);

    }
    public void Load() {
    
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
