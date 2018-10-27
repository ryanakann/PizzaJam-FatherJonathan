using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UILevelTransition : MonoBehaviour {

    public static UILevelTransition instance;

    RawImage image;
    public float fadeTime = 2f;

    void Start () {
        instance = this;

        image = GetComponent<RawImage>();
        image.color = new Color(1f, 0f, 0f, 0f);

        DontDestroyOnLoad(transform.parent);
    }

    public void OnTransition () {
        StartCoroutine(Fade());
    }

    IEnumerator Fade () {
        while (image.color.a < 1f) {
            image.color += new Color(0f, 0f, 0f, Time.deltaTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        while (image.color.a > 0f) {
            image.color -= new Color(0f, 0f, 0f, Time.deltaTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
