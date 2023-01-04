using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterControl : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float laserLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    Coroutine coroutine;

    public bool isFiring;
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        
    }
    void Fire()
    {
        if (isFiring&& coroutine == null)
        {
           coroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring&& coroutine != null) 
        {
            StopCoroutine(coroutine);
            coroutine= null;
        }
        
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();
            if (rb2d != null) { rb2d.velocity = transform.up * laserSpeed; }
            Destroy(instance,laserLifeTime);
            float timeToNextLaser = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextLaser = Mathf.Clamp(timeToNextLaser,minimumFiringRate,float.MaxValue);
            yield return new WaitForSeconds(timeToNextLaser);

        }
    }
}
