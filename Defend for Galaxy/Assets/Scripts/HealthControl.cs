using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HealthControl : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCamShake;
    CamShake cameraShake;
    SoundPlayer audioPlayer;
    ScoreControl scoreControl;
    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CamShake>();
        audioPlayer = FindObjectOfType<SoundPlayer>();
        scoreControl=FindObjectOfType<ScoreControl>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer= collision. GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            damageDealer.Hit();
        }
    }
    public int GetHealth()
    {
        return health;
    }

     void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Die();
        }
    }
    void Die()
    {
        if (!isPlayer)
        {
            scoreControl.ModifyScore(score);
        }
        Destroy(gameObject);
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
