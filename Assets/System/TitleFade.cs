using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFade : MonoBehaviour
{
    Text title;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        title = GetComponent<Text>();
    }

    public void StartFade() {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
        while (title.color.a > 0f) // ���� ��ư�� ���� �� ������ ���� �ٽ� ���İ��� �����
        {
            title.color = new Color(title.color.r, title.color.g, title.color.b, title.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        panel.SetActive(false);
    }

    

    // Update is called once per frame
    void Update()
    {
    }
}
