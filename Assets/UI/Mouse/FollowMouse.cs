using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    private Vector2 mousePos;
    [SerializeField] private float mouseFollowSpeed = 0.5f;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.position = Vector2.Lerp(transform.position,mousePos, Time.deltaTime * mouseFollowSpeed);
    }
}
