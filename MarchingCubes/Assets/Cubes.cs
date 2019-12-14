using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    //dimensions of cubes
    //public int width = 20;
    //public int height = 20;

    //start position
    //Vector3 startPos = transform.position;

    //number of rows to generate
    //public int numRows = 10;

    //spawn speed
    public float spawnSpeed = 3;

    //vislualiser scale
    public float scale = 10;

    //list of game objects
    List<GameObject> elements = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateVisualisers());
    }

    //create vislualisers function
    IEnumerator CreateVisualisers()
    {
        //set position
        Vector3 startPos = transform.position;
        startPos.z = 0;

        Vector3 size = new Vector3(1, 1, 9);

        for (int n = 0; n < 10; n++)
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

                    //color
                    cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.value, 1, 1);
                    elements.Add(cube);

                    startPos.z++;
                }
            }
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 1000; i++)
        {
            Vector3 ls = elements[i].transform.localScale;
            ls.y = Mathf.Lerp(ls.y, 1 + (AudioAnalyser.bands[i] * scale), Time.deltaTime * 10.0f);
            elements[i].transform.localScale = ls;


        }
    }

}
