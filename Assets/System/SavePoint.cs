using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePoint : MonoBehaviour
{
    public GameObject text;
    public HardLight2D hardLight;

    public ScriptManager scriptManager;
    GameObject scanObject;

    public bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        scanObject = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            text.SetActive(true);
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            text.SetActive(false);
            isActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Space)){
            scriptManager.scriptPanel(scanObject);
        }
    }
}
