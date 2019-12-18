using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    //row counter
    public int numRows = 1;

    //spawn speed
    public float spawnSpeed = 3;

    //vislualiser scale
    public float scale = 5;

    //list of game objects
    //List<GameObject> elements = new List<GameObject>();
    public GameObject [] elements;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateVisualisers());
        //CreateVisualisers();
    }

    //create vislualisers function
    IEnumerator CreateVisualisers()
    //void CreateVisualisers()
    {
        //set position
        Vector3 startPos = transform.position;
        startPos.z = 0;

        //8 cubes in row - 8 frequency bands
        Vector3 size = new Vector3(1, 1, 8);

        for (int n = 0; n < numRows; n++)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int z = 0; z < size.z; z++)
                {
                    //spawn cube
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(startPos.z, y * size.y, z * size.z);

                    //parent
                    cube.transform.parent = this.transform;

                    //elements.Add(cube);
                    elements[z] = cube;

                    startPos.z++;
                }
            }
            yield return new WaitForSeconds(spawnSpeed);
            numRows++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for( int j = 0; j < numRows; j++)
        {
            for (int i = 0; i < 1000; i++)
            {
                Vector3 ls = elements[i].transform.localScale;
                ls.y = Mathf.Lerp(ls.y, 1 + (AudioAnalyser.bands[i] * scale), Time.deltaTime * 10.0f);
                elements[i].transform.localScale = ls;

                //assign colour based on y value
                elements[i].GetComponent<Renderer>().material.color = Color.HSVToRGB(ls.y / (float)AudioAnalyser.bands.Length, 1, 1);

            }
        }
        
    }

}
