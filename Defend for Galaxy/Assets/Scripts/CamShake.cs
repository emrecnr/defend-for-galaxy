using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
     float shakeDuration = 0.5f;
     float shakeMagnitude = 0.25f;

    Vector3 initialPos;
    void Start()
    {
        initialPos = transform.position;
    }


    public void Play()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake() 
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initialPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();

        }
        transform.position = initialPos;
        
    }

}
