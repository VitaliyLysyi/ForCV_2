using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    public Joystick Jstick;
    public Button FireButton;
    public Bullet Misile;
    public float ShootSpeed = 5;
    public GameObject HPBar;
    public AudioClip ShootSound;

    private float FBPosition;
    private float LastST;
    private AudioSource AudioComponent;
 

    void Start()
    {
        FBPosition = FireButton.transform.position.y;
        HPBar.transform.localScale = new Vector3(HPBar.transform.localScale.x, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
        AudioComponent = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (HPBar.transform.localScale.x < 0){
            Destroy(gameObject);
            Destroy(HPBar.gameObject);
        }
        
        HPBar.transform.localScale = new Vector3(HPBar.transform.localScale.x, HPBar.transform.localScale.y, HPBar.transform.localScale.z);

        transform.position = new Vector3(transform.position.x + Jstick.Horizontal * 0.1f, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + Jstick.Vertical * 0.1f, transform.position.z);

        if (transform.position.x < -2.8){
            transform.position = new Vector3(2.8f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 2.8){
            transform.position = new Vector3(-2.8f, transform.position.y, transform.position.z);
        }

        if ((FBPosition != FireButton.transform.position.y) & (Time.time > (LastST + ShootSpeed))){
            Bullet NewBullet = Instantiate(Misile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            NewBullet.name = "Misslie";
            AudioComponent.PlayOneShot(AudioComponent.clip);
            LastST = Time.time;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyMissile(Clone)"){
            Destroy(collision.gameObject);
            HPBar.transform.localScale = new Vector3(HPBar.transform.localScale.x - 0.2f, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
        }
        if (collision.gameObject.name == "Enemy"){
            Destroy(collision.gameObject);
            HPBar.transform.localScale = new Vector3(-0.1f, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
        }
    }
}
