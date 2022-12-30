using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed =5f;
    Vector2 rawInput;

    [SerializeField] float padLeft;
    [SerializeField] float padRight;
    [SerializeField] float padTop;

    [SerializeField] float padDown;
    Vector2 minSize;
    Vector2 maxSize;

    void Start()
    {
        InitBounds();
    }

    
    void Update()
    {
        Move();
        
    }
    void InitBounds()
    {
        Camera mainCam = Camera.main;
        minSize = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        maxSize = mainCam.ViewportToWorldPoint(new Vector2(1, 1));
    }
    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minSize.x + padLeft, maxSize.x - padRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minSize.y +padDown, maxSize.y - padTop);
        transform.position = newPosition;
    }
}
