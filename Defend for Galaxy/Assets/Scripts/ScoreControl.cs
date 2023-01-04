using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    public int GetScore()
    {
        return score;
    }
    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
    public void ResetScore()
    {
        score= 0;
    }
}
