using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SnowParticleSystem : MonoBehaviour
{
    public GameObject player;
    public float emittorHeight = 25f;
    private ParticleSystem snow;
    void Start()
    {
        snow = GetComponent<ParticleSystem>();
        if(snow.isPaused || snow.isStopped)
        {
            snow.Play();
        }
    }

    void Update()
    {
        snow.transform.position = new Vector3(player.transform.position.x, emittorHeight, 0);
    }
}
