using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroTransition : MonoBehaviour {

    RawImage image;
    public float fadeTime = 2f;

	// Use this for initialization
	void Start () {
        image = GetComponent<RawImage>();
        //image.color = new Color(1f, 0f, 0f, 0f);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown) {
            OnTransition();
        }
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

