using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulTiming : MonoBehaviour
{
    public string NameProperty;
    public bool animatingProperty = true;
    public Vector2 startPoint;
    public float time;

    private Vector2 current;
    private float currentTime;

    private Material mat;
    
    public Vector2 step;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        current = startPoint;
        mat.SetVector(NameProperty, current);
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
        }
    }
}
