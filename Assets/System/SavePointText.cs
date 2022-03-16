using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointText : MonoBehaviour
{

    public float moveMax;
    public float speed;

    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dirPos = pos;
        dirPos.y = pos.y + moveMax * Mathf.Sin(Time.time * speed);
        transform.position = dirPos;
    }
}
