using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float Speed = 1;
    public EnemyBullet Misile;
    public float MinShootSpeed = 2;
    public float MaxShootSpeed = 5;
    public GameObject DSound;
    public GameObject HpBar;

    private float LastST;
    public float ShootSpeed;
    private int Hp = 1;
    private AudioSource AController;
    
    private void Start()
    {
        ShootSpeed = UnityEngine.Random.Range(MinShootSpeed, MaxShootSpeed);
        AController = GetComponent<AudioSource>();
        HpBar.transform.localScale = new Vector3(HpBar.transform.localScale.x, HpBar.transform.localScale.y, HpBar.transform.localScale.z);
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime, transform.position.z);

        if (transform.position.y < -7){
            Destroy(gameObject);
        }

        if (Time.time > (LastST + ShootSpeed)){
            Instantiate(Misile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            LastST = Time.time;
        }

        if (Hp < 0){
            Destroy(gameObject);
            Instantiate(DSound, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Missile"){
            AController.PlayOneShot(AController.clip);
            HpBar.transform.localScale = new Vector3(HpBar.transform.localScale.x - 0.1f, HpBar.transform.localScale.y, HpBar.transform.localScale.z);
            Destroy(collision.gameObject);
            --Hp;
        }
    }
}
