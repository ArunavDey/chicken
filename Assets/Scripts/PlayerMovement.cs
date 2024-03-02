using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 12f;
    public float jumpForce = 2.0f;
    public float gravity = -100f;
    public Rigidbody dog;
    public float teleportRadius = 5f;
    private Rigidbody player;
    private bool shouldJump;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity, 0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += moveSpeed * Time.deltaTime * new Vector3(horizontalInput, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            shouldJump = true;
        }

        if(Input.GetKey(KeyCode.Q) && IsPlayerWithinRange() && IsGrounded())
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = player.position.z - Camera.main.transform.position.z;
            player.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    void FixedUpdate()
    {
        if(shouldJump)
        {
            player.AddForce(new Vector3(0, 7.0f, 0) * jumpForce, ForceMode.Impulse);
            shouldJump = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(player.position, Vector3.down, 1.1f, 1 << LayerMask.NameToLayer("Ground"));
    }

    private bool IsPlayerWithinRange()
    {
        return Vector3.Distance(dog.transform.position, player.transform.position) < teleportRadius;
    }

}
