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

    public IEnumerator FadeTextToFullAlpha() // ���İ� 0���� 1�� ��ȯ
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f && keepOn) // ���� ��ư�� ���� �� ������ ���� �ٽ� ���İ��� �����
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroAlpha());
    }

    public IEnumerator FadeTextToZeroAlpha()  // ���İ� 1���� 0���� ��ȯ
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