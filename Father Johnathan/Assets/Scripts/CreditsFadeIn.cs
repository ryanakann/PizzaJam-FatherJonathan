using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsFadeIn : MonoBehaviour {

    public static CreditsFadeIn instance;

    RawImage image;
    public float fadeTime = 2f;
    public float waitTime = 5f;

	void Start () {
        instance = this;

        image = GetComponent<RawImage>();
        // image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

        StartCoroutine(Fadein(fadeTime, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Fadein(float fadeTime, int progress) {
        if (progress == 0) {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        }

        while (image.color.a < 1f) {
            image.color -= new Color(0f, 0f, 0f, Time.deltaTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }

        if (progress == 0) {
            yield return new WaitForSeconds(waitTime);
        }


        while (image.color.a > 0f) {
            image.color -= new Color(0f, 0f, 0f, Time.deltaTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }


    }
}
