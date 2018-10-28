using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditTextFade : MonoBehaviour {

    public static CreditTextFade instance;

    TextMeshProUGUI text;

    public float waitTime = 5f;
    public float fadeTime = 2f;
    public float holdTime = 2f;

    float elapsedTime = 0f;

    void Start() {
        instance = this;

        text = GetComponent<TextMeshProUGUI>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);

        StartCoroutine(Fadein(fadeTime, 0));
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator Fadein(float fadeTime, int progress) {
        if (progress == 0) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        }

        if (progress == 0) {
            yield return new WaitForSeconds(waitTime);
        }


        while (text.color.a < 1f && elapsedTime < fadeTime) {
            elapsedTime += Time.deltaTime;
            text.color += new Color(0f, 0f, 0f, Time.deltaTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }

        while (elapsedTime > fadeTime && elapsedTime < fadeTime + holdTime) {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        while (text.color.a > 0f && elapsedTime > (fadeTime + holdTime) && elapsedTime < (2 * fadeTime) + holdTime) {
            elapsedTime += Time.deltaTime;
            text.color -= new Color(0f, 0f, 0f, Time.deltaTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }

        while (text.color.a > 0f) {
            text.color -= new Color(0f, 0f, 0f, Time.deltaTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }


    }
}
