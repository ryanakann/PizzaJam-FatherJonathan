using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UILevelTransition : MonoBehaviour {

    public static UILevelTransition instance;

    RawImage image;
    public float fadeTime = 2f;

    void Start () {
        instance = this;

        image = GetComponent<RawImage>();
        //image.color = new Color(1f, 0f, 0f, 0f);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);

        DontDestroyOnLoad(transform.parent);

        EventManager.StartListening(EventType.EnterFurnace, OnTransition);
        EventManager.StartListening(EventType.PlayerDeath, OnDie);
    }

    void OnTransition () {
        StartCoroutine(Fade(fadeTime, 1));
    }

    void OnDie () {
        StartCoroutine(Fade(fadeTime, 0));
    }

    IEnumerator Fade (float fadeTime, int progress) {
        if (progress == 0) {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        }

        while (image.color.a < 1f) {
            image.color += new Color(0f, 0f, 0f, Time.deltaTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }

        if (progress == 0) {
            yield return new WaitForSeconds(1.5f);
        }

        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + progress));

        while (image.color.a > 0f) {
            image.color -= new Color(0f, 0f, 0f, Time.deltaTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
