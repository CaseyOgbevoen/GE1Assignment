using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

    //speed
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        /*/camera start position
        Vector3 pos = new Vector3(-40, 20, 30);

        //camera start rotation
        Vector3 rot = new Vector3(5, 90, (float) -2.5);
        */

        //transform
        //transform.position = new Vector3(-10, 10, 100);
        //transform.rotation = new Quaternion(0, 180, (float)10, 1);
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
