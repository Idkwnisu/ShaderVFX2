using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject toSpawn;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        toSpawn.SetActive(true);
    }
}
