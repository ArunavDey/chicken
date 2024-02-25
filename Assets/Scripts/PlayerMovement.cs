using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 12f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += moveSpeed * Time.deltaTime * new Vector3(horizontalInput, 0, 0);
    }
}