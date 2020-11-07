using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdAnimation : MonoBehaviour
{
    public float start;
    public float end;
    public float speed;
    public string propertyName;

    private float current;

    private Renderer rend;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
        mat.SetFloat(propertyName, start);
        current = start;
    }

    // Update is called once per frame
    void Update()
    {
        current += speed * Time.deltaTime;
        if(current >= end && end > start)
        {
            current = end;
        }
        if (current <= end && end < start)
        {
            current = end;
        }
        mat.SetFloat(propertyName, current);
    }
}
