using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{

    private float STime;
    public float DsTime;
    // Start is called before the first frame update
    void Start()
    {
        STime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > STime + DsTime){
            Destroy(gameObject);
        }
    }
}
