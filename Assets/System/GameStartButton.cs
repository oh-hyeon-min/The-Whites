using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    public Text text_title;
    public Text text_button;
    public Animator anim;
    public bool keepOn = true;
    public GameObject button_set;
    public Button button;
    public bool start = false;
    void Start()
    {
        StartCoroutine(FadeTextToZeroAlpha(text_title, text_button));
    }
    void Update()
    {
        if (Input.anyKeyDown && !start) {
            button.onClick.Invoke();
        }
    }

    public void keepOff() {
        text_button.color = new Color(text_button.color.r, text_button.color.g, text_button.color.b, 1);
        keepOn = false;
    }

    public void setstart() {
        start = true;
    }

    public IEnumerator FadeTextToFullAlpha(Text textTitle, Text textButton) // ���İ� 0���� 1�� ��ȯ
    {
        textButton.color = new Color(textButton.color.r, textButton.color.g, textButton.color.b, 0);
        while (textButton.color.a < 1.0f && keepOn) // ���� ��ư�� ���� �� ������ ���� �ٽ� ���İ��� �����
        {
            textButton.color = new Color(textButton.color.r, textButton.color.g, textButton.color.b, textButton.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroAlpha(textTitle, textButton));
    }

    public IEnumerator FadeTextToZeroAlpha(Text textTitle, Text textButton)  // ���İ� 1���� 0���� ��ȯ
    {
        textButton.color = new Color(textButton.color.r, textButton.color.g, textButton.color.b, 1);
        while (textButton.color.a > 0.0f && textTitle.color.a > 0.0f)
        {
            if (keepOn == false) {
                textTitle.color = new Color(textTitle.color.r, textTitle.color.g, textTitle.color.b, textTitle.color.a - (Time.deltaTime / 2.0f));
            }
            textButton.color = new Color(textButton.color.r, textButton.color.g, textButton.color.b, textButton.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        if (keepOn == true)
        {
            StartCoroutine(FadeTextToFullAlpha(textTitle, textButton));
        }
        else
        {
            anim.SetBool("Start", true);
            button_set.SetActive(false);
        }
    }
}