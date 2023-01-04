using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIDispConroller : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] HealthControl playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreControl scoreKeeper;

    private void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreControl>();
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    
    void Update()
    {
        healthSlider.value= playerHealth.GetHealth();
        scoreText.text=scoreKeeper.GetScore().ToString("0000000");
    }
}
