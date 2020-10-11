using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColliding : MonoBehaviour
{
    private Rigidbody rb;
    public float gravity;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction * gravity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject); //maybe later with a delay/spawning something else
        }
    }
}
