using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float playtime;
    public String chapter;
    public int pieceOfMemories;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playtime += Time.deltaTime;
    }
}
