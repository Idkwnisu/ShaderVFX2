﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulTiming : MonoBehaviour
{
    public string NameProperty;
    public bool animatingProperty = false;
    public Vector2 startPoint;
    public float time;

    private Vector2 current;
    private float currentTime;

    private Material mat;
    
    public Vector2 step;

    public Vector2 delayRand;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        current = startPoint;
        mat.SetVector(NameProperty, current);
        Invoke("StartAnimation", Random.Range(delayRand.x, delayRand.y));
    }

    // Update is called once per frame
    void Update()
    {
        if (animatingProperty)
        {
            current += step * Time.deltaTime;
            mat.SetVector(NameProperty, current);
            currentTime += Time.deltaTime;
            if (currentTime > time)
            {
                animatingProperty = false;
            }
            transform.position += Vector3.up * Time.deltaTime * 2.0f;
        }
    }

    public void StartAnimation()
    {
        animatingProperty = true;
        GetComponent<SoulTimingFloat>().StartAnimation();
    }
}
