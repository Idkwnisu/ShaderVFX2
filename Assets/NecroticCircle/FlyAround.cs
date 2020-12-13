using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAround : MonoBehaviour
{
    public Vector2 speedR;
    public Vector2 desiredHeigthR;
    public Vector2 delayR;

    public float positionBias = 2.0f;

    private float speed;
    private float desiredHeigth;

    private Vector3 direction;
    bool started = true;
    bool delayOver = false;

    private Vector3 laterDirection;
    // Start is called before the first frame update
    void Start()
    {
        
        direction = Vector3.up;
        speed = Random.Range(speedR.x, speedR.y);
        desiredHeigth = Random.Range(desiredHeigthR.x, desiredHeigthR.y);

        laterDirection = new Vector3(Random.Range(-2, 2), 1.0f, Random.Range(-2, 2));

        transform.position += (laterDirection - Vector3.up) * positionBias;

        transform.LookAt(transform.position + laterDirection - Vector3.up);

        Invoke("EndDelay", Random.Range(delayR.x, delayR.y));
    }

    // Update is called once per frame
    void Update()
    {
        if (delayOver)
        {
            transform.position += direction * speed * Time.deltaTime;
            if (transform.position.y >= desiredHeigth && started)
            {
                direction = laterDirection;
                
                started = false;
            }
        }
    }

    void EndDelay()
    {
        delayOver = true;
    }
}
