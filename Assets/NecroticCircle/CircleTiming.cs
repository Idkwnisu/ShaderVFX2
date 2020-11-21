using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTiming : MonoBehaviour
{
    public string NameProperty;
    public bool animatingProperty = true;
    public float startPoint = 0.5f;
    public float endPoint = -0.5f;

    private float current;

    private Material mat;

    public float step = 0.5f;
    public ParticleSystem psystem;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        current = startPoint;
        mat.SetFloat(NameProperty, current);
    }

    // Update is called once per frame
    void Update()
    {
        if(animatingProperty)
        {
            current += step * Time.deltaTime;
            mat.SetFloat(NameProperty, current);
            if(current < endPoint)
            {
                animatingProperty = false;
                psystem.Play();
            }
        }
    }
}
