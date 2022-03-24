using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void scriptPanel(GameObject scanObj){
        if (isAction)
        {
            isAction = false;
            talkPanel.SetActive(false);
        }
        else
        {
            isAction = true;
            talkPanel.SetActive(true);
            if (scanObj.name == "SavePoint")
            {
                talkText.text = "±â¾ïÀ» ¸Ô´Â ²ÉÀÌ¾ß.";
            }
        }
    }
}
