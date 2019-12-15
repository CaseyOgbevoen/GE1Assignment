using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

    //smooth speed
    public float smoothSpeed = 0.125f;

    //speed
    public float speed = 3f;

    //waypoint list
    public List<Vector3> waypoints = new List<Vector3>();


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
