using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    Image img;
    public float delay;

    void Start()
    {
        img = GetComponent<Image>();
        StartCoroutine(Flicking(delay));
    }

    private void OnEnable()
    {
        StartCoroutine(Flicking(delay));

    }

    public IEnumerator Flicking(float waitTime)
    {
        for (float i = 0; i < 30000; i += Time.deltaTime)
        {
            var alphaImg = img.color;
            alphaImg.a = 0f;
            img.color = alphaImg;
            yield return new WaitForSeconds(waitTime);
            alphaImg.a = 1f;
            img.color = alphaImg;
            yield return new WaitForSeconds(waitTime);        

        }

        yield return null;
    }

}
