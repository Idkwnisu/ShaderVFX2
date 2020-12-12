using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAround : MonoBehaviour
{
    public Vector2 speedR;
    public Vector2 desiredHeigthR;
    public Vector2 delayR;

    public Vector2 positionRange;

    private float speed;
    private float desiredHeigth;

    private Vector3 direction;
    bool started = true;
    bool delayOver = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(Random.Range(positionRange.x, positionRange.y), 0, Random.Range(positionRange.x, positionRange.y));
        direction = Vector3.up;
        speed = Random.Range(speedR.x, speedR.y);
        desiredHeigth = Random.Range(desiredHeigthR.x, desiredHeigthR.y);
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
                direction = new Vector3(Random.Range(-2, 2), 1.0f, Random.Range(-2, 2));
                transform.LookAt(transform.position + direction - Vector3.up);
                started = false;
            }
        }
    }

    void EndDelay()
    {
        delayOver = true;
    }
}
