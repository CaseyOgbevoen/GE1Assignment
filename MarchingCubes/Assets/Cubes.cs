using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    //dimensions of cubes
    public int width = 20;
    public int height = 20;

    //vislualiser scale
    public float scale = 10;

    //list of game objects
    List<GameObject> elements = new List<GameObject>();

    //create vislualisers function
    void CreateVisualisers()
    {
        float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyser.bands.Length;
        for (int i = 0; i < AudioAnalyser.bands.Length; i++)
        {
            //Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            //pos = transform.TransformPoint(pos);

            //Quaternion (rotation)
            //Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            //q = transform.rotation * q;


            //cube grid
            int halfWidth = width / 2;

            for (int j = 0; j < height; j++)
            {
                for (int k = -halfWidth; k < halfWidth; k++)
                {
                    //position cubes on top of quad
                    Vector3 pos = transform.TransformPoint(new Vector3(k, 1, 0.5f + j));

                    //create cube
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    //position cube
                    cube.transform.position = pos;
                    cube.transform.rotation = transform.rotation;

                    //color cube
                    cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)AudioAnalyser.bands.Length, 1, 1);

                    //Parent
                    cube.transform.parent = this.transform;

                    //make rigid body
                    cube.AddComponent<Rigidbody>();

                    //add to elements list
                    elements.Add(cube);
                }
            }


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateVisualisers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //creating grid of cubes
    /* 
     int halfWidth = width / 2;

        for (int i = 0; i < height; i++)
        {
            for (int j = -halfWidth; j < halfWidth; j++)
            {
                //position cubes on top of quad
                Vector3 pos = transform.TransformPoint(new Vector3(j, 1, 0.5f + i));

                //create cube
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                //position cube
                cube.transform.position = pos;
                cube.transform.rotation = transform.rotation;

                //color cube
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.value, 1, 1);

                //Parent
                cube.transform.parent = this.transform;

                //make rigid body
                cube.AddComponent<Rigidbody>();
            }
        }
     */
}
