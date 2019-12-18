using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

    //speed
    public static float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        /*/camera start position
        Vector3 pos = new Vector3(-50, 20, 25);

        //camera start rotation
        Vector3 rot = new Vector3(0, 90, -1);
        */

        //transform
        //transform.position = new Vector3(-50, 50, 25);
        //transform.rotation = new Quaternion(0, 90, (float)-1, 1);
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
