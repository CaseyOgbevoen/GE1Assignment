﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public float scale = 25.0f;
    public float radius = 30.0f;

    List<GameObject> elements = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        CreateVisualisers();
    }

    void CreateVisualisers()
    {
        float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyser.frameSize;
        for (int i = 0; i < AudioAnalyser.frameSize; i++)
        {
            Vector3 p = new Vector3(30 + (Mathf.Sin(theta * i) * radius), -40, -2 + (Mathf.Cos(theta * i) * radius));
            p = transform.TransformPoint(p);
            Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            q = transform.rotation * q;

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetPositionAndRotation(p, q);
            cube.transform.parent = this.transform;
            
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)AudioAnalyser.frameSize, 1, 1);

            elements.Add(cube);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * moveCamera.speed * Time.deltaTime);

        for (int i = 0; i < elements.Count; i++)
        {
            elements[i].transform.localScale = new Vector3(1, 1 + AudioAnalyser.samples[i] * scale, 1);
        }
    }
}
