using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2Looper : MonoBehaviour
{
    public string name;
    public Vector2 start;
    public Vector2 offset;
    public float resetTime;

    private float timePassed;
    private Vector2 currentValue;

    private Renderer rend;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0.0f;
        currentValue = start;
        rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue += offset * Time.deltaTime;
        Debug.Log(currentValue);
        timePassed += Time.deltaTime;
        Debug.Log(timePassed);
        if(timePassed >= resetTime)
        {
            currentValue = start;
            timePassed = 0.0f;
        }
        mat.SetVector(name, currentValue);

    }
}
