using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    //dimensions of cubes
    //public int width = 20;
    //public int height = 20;

    //vislualiser scale
    public float scale = 10;

    //radius
    public float radius = 50;

    //list of game objects
    List<GameObject> elements = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateVisualisers();
    }

    //create vislualisers function
    void CreateVisualisers()
    {
        float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyser.bands.Length;

        for (int i = 0; i < AudioAnalyser.bands.Length; i++)
        {
            //set position
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            pos = transform.TransformPoint(pos);

            //set rotation
            Quaternion rot = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            rot = transform.rotation * rot;

            //spawn cube
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetPositionAndRotation(pos, rot);

            //parent
            cube.transform.parent = this.transform;

            //color
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)AudioAnalyser.bands.Length, 1, 1);
            elements.Add(cube);

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            Vector3 ls = elements[i].transform.localScale;
            ls.y = Mathf.Lerp(ls.y, 1 + (AudioAnalyser.bands[i] * scale), Time.deltaTime * 3.0f);
            elements[i].transform.localScale = ls;
        }
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
