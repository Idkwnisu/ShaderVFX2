using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAround : MonoBehaviour
{
    public float speed;
    public float desiredHeigth;
    private Vector3 direction;
    bool started = true;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if(transform.position.y >= desiredHeigth && started)
        {
            direction = new Vector3(Random.Range(-2, 2), 1.0f, Random.Range(-2, 2));
            started = false;
        }
    }
}
