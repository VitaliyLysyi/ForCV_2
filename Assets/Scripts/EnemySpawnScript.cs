using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public float MinSpawnTime = 1;
    public float MaxSpawnTime = 10;
    public GameObject Enemy;

    private float LastSpawnTime = 0;
    private float SpawnTime = 0;
    private float PosX;
    void Update()
    {
        if (Time.time > (LastSpawnTime + SpawnTime)){
            LastSpawnTime = Time.time;
            SpawnTime = UnityEngine.Random.Range(MinSpawnTime, MaxSpawnTime);
            PosX = UnityEngine.Random.Range(-2, 2);
            GameObject NewEnemy = Instantiate(Enemy, new Vector3(PosX, transform.position.y, transform.position.z), quaternion.identity);
            NewEnemy.name = "Enemy";
        }
    }
}
