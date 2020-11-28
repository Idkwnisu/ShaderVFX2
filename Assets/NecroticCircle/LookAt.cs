using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 transf = Camera.main.transform.position;
        transf.y = transform.position.y;
        transform.LookAt(transf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
