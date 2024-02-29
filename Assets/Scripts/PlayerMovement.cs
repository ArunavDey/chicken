using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 12f;
    public float jumpForce = 2.0f;
    public float gravity = -100f;
    private Rigidbody player;
    private bool shouldJump;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity, 0);
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += moveSpeed * Time.deltaTime * new Vector3(horizontalInput, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            shouldJump = true;
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

}




/*
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float snowX = 5f;
    public float snowY = 10f;
    public float snowZ = 5f;
    public float cameraZ = -8f;
    public float cameraX = 5f;
    public float jumpForce = 0.1f;

    Rigidbody player;
    ParticleSystem snowParticleSystem;
    Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        snowParticleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        camera = gameObject.GetComponentInChildren<Camera>();
        player = gameObject.GetComponent<Rigidbody>();

        //position snow particle system relative to player
        snowParticleSystem.transform.position = gameObject.transform.position + new Vector3(snowX, snowY, snowZ);

        //position camera relative to player
        camera.transform.position = gameObject.transform.position + new Vector3(cameraX, 0, cameraZ);

        //start snowfall
        if(snowParticleSystem.isPaused || snowParticleSystem.isStopped){
            snowParticleSystem.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetButtonDown("Jump");
        transform.position += moveSpeed * Time.deltaTime * new Vector3(horizontalInput, 0, 0);
        // snowParticleSystem.transform.position += moveSpeed * Time.deltaTime * new Vector3(horizontalInput, 0, 0);
        // snowParticleSystem.transform.position = gameObject.transform.position;
        // if(Input.GetKeyDown("Jump")){
        //     player.AddForce(new Vector3(0, jumpForce, 0));
        // }
        if(Input.GetKeyDown(KeyCode.Space)){
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }
}


*/