using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class Driver : MonoBehaviour
{
    [SerializeField] [Range(7f, 25f)]public float moveSpeed = 1f;
    [SerializeField] [Range(7f, 14f)]public float slowSpeed = 12f;
    [SerializeField] [Range(15f, 20f)]public float boostSpeed = 25f;
    [SerializeField] [Range(100f, 150f)]public float steerSpeed = 1f;
    [SerializeField] public float altMoveSpeed;
    [SerializeField] public string vers = "1.0.0v";
    void Awake()
    {
        altMoveSpeed = moveSpeed;
    }
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float movementAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, -steerAmount);
        transform.Translate(new Vector3(0f, movementAmount));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Sets our speed to slower speed
            moveSpeed = slowSpeed;
        }
        else
        {
            moveSpeed = altMoveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedUp"))
        {
            moveSpeed = boostSpeed;
            Destroy(other.gameObject);
        }
    }
}
