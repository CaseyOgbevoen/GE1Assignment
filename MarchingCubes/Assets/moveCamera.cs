﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

    //speed
    public static float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void LateUpdate()
    { 
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
