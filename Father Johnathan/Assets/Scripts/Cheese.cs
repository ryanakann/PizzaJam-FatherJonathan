using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Interactable {

    public override void Interact () {
        print("Interacting!");
        EventManager.TriggerEvent(EventType.ObtainCheese);
        StartCoroutine(Burn());
    }

    private IEnumerator Burn () {
        GetComponent<AudioSource>().Play();

        ParticleSystem system = gameObject.GetComponentInChildren<ParticleSystem>();
        system.gameObject.SetActive(true);
        system.Play();

        float maxTime = system.main.duration;
        float currentTime = 0f;
        Light myLight = system.transform.GetChild(0).GetComponent<Light>();

        while (currentTime < maxTime) {
            myLight.intensity = Mathf.Lerp(0f, 2f, currentTime / maxTime);
            float scale = Mathf.Lerp(1f, 0f, currentTime / maxTime);
            transform.localScale = Vector3.one * scale;
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        currentTime = 0f;

        while (currentTime < maxTime) {
            myLight.intensity = Mathf.Lerp(2f, 0f, currentTime / maxTime);
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
