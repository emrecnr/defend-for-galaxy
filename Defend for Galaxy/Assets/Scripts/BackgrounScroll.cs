using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounScroll : MonoBehaviour
{
    [SerializeField] Vector2 speed;
    [SerializeField] Vector2 offset;
    Material material;
    void Awake()
    {
        material= GetComponent<SpriteRenderer>().material;
    }

    
    void Update()
    {
        offset = speed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
