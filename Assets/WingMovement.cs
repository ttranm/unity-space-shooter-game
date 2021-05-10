using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingMovement : MonoBehaviour
{
    //public GameObject bullet;
    public float speed = 1.0f;
    private Rigidbody2D wingRb;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnBecameInvisible(){
        gameObject.SetActive(false);
    }
    // Collision detect when hit player
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            gameObject.SetActive(false);
        }
    }

    // Attempting to do the wing firing bullet

    // void fireBullet(){
    //     bullet = ObjectPool.SharedInstance.GetPooledObject("Bullet");
    //     if(bullet != null){
    //         var renderer = bullet.GetComponent<Renderer>();
    //         renderer.material.SetColor("_Color", Color.red);
    //         Vector3 spawnBulletPos = new Vector3(this.transform.position.x, this.transform.position.y + 1, 0);
    //         bullet.transform.position = spawnBulletPos;
    //         bullet.SetActive(true);
    //     }
    // }

    void OnEnable(){
        wingRb = transform.GetComponent<Rigidbody2D>();
        wingRb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // DOES NOT WORK

        // if(Input.GetMouseButtonDown(0)){
        //     fireBullet();
        // }
    }
}
