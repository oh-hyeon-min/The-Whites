using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePoint : MonoBehaviour
{
    public GameObject savingText;
    public GameObject savePanel;
    public HardLight2D hardLight;

    public ScriptManager scriptManager;
    GameObject scanObject;

    public bool isActive = false;
    public bool isSaving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        scanObject = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            savingText.SetActive(true);
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            savingText.SetActive(false);
            isActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSaving && isActive && Input.GetKeyDown(KeyCode.Space)){
            scriptManager.scriptPanel(scanObject);
            if (!scriptManager.isAction) {
                Save();
            }
        }
    }

    public void Save() {
        isSaving = true;
        savePanel.SetActive(true);
    }

    public void SaveOver() {
        isSaving = false;
    }
}
