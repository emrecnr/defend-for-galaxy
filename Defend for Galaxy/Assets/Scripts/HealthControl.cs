using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCamShake;
    CamShake cameraShake;
    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CamShake>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer= collision. GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }
     void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance=Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration+instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera()
    {
        if (cameraShake!=null&& applyCamShake)
        {
            cameraShake.Play();
        }
    }


}
