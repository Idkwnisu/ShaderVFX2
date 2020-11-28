using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulTimingFloat : MonoBehaviour
{
    public string NameProperty;
    public bool animatingProperty = false;
    public float startPoint;
    public float time;

    private float current;
    private float currentTime;

    private Material mat;
    
    public float step;

    public Vector2 delayRand;

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
        if (animatingProperty)
        {
            current += step * Time.deltaTime;
            current = Mathf.Max(0, current);
            mat.SetFloat(NameProperty, current);
            currentTime += Time.deltaTime;
            if (currentTime > time)
            {
                animatingProperty = false;
            }
            
        }
    }

    public void StartAnimation()
    {
        animatingProperty = true;
    }
}
