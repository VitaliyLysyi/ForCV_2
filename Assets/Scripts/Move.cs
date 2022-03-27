using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1;
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>-31.5) {
            transform.position = new Vector3(transform.position.x,transform.position.y-speed/1000,transform.position.z);
        }        

    }
}
