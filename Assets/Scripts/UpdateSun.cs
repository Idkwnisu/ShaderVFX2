﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shader.SetGlobalVector("_SunDirection", transform.forward);   
        Debug.Log(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}