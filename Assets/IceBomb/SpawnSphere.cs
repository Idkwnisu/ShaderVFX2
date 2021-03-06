﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSphere : MonoBehaviour
{
    public GameObject prefab;
    public GameObject sphereOnHand;
    public Transform hand;
    public ParticleSystem chargingParticles;


    public float ForceForward = 1000.0f;
    public float ForceUp = 400.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSphereMethod()
    {
        GameObject sphere = Instantiate(prefab, hand.position, Quaternion.identity);
        Rigidbody rb = sphere.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * ForceForward + transform.up * ForceUp);
    }

    public void StartParticle()
    {
        chargingParticles.Play();
        sphereOnHand.SetActive(true);
    }

    public void StopParticle()
    {
        chargingParticles.Stop();
        sphereOnHand.SetActive(false);
    }
}
