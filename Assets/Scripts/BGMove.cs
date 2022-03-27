using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float speed = 1;
    public Transform SpawnPoint;
    public GameObject MapSample1;
    public GameObject MapSample2;
    public GameObject MapSample3;

    private GameObject NextMapSample;
    private bool Spawned = false;
    private int NextSample;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);

        if (transform.position.y < -12){
            Destroy(gameObject);
        }

        if ((transform.position.y < 2) & (Spawned == false)){
            Spawned = true;
            NextSample = UnityEngine.Random.Range(1, 4);
            //Debug.Log(NextSample);

            switch (NextSample)
            {
                case 1:
                    NextMapSample = MapSample1;
                    break;
                case 2:
                    NextMapSample = MapSample2;
                    break;
                case 3:
                    NextMapSample = MapSample3;
                    break;
            }
            GameObject NewMap = Instantiate(NextMapSample, new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, SpawnPoint.position.z), quaternion.identity);
            NewMap.name = "NewMap";
        }
    }
}
