using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    Text text;
    public Animator anim;
    public bool keepOn = true;
    public GameObject button;
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(FadeTextToZeroAlpha());
    }

    public void keepOff() {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        keepOn = false;
    }

    public IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f && keepOn) // 시작 버튼을 아직 안 눌렀을 때만 다시 알파값이 밝아짐
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroAlpha());
    }

    public IEnumerator FadeTextToZeroAlpha()  // 알파값 1에서 0으로 전환
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        if (keepOn == true)
        {
            StartCoroutine(FadeTextToFullAlpha());
        }
        else
        {
            anim.SetBool("Start", true);
            button.SetActive(false);
        }
    }
}