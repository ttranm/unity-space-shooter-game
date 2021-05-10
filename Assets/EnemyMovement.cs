using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D enemyRb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnBecameInvisible(){
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Bullet"){
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if(other.gameObject.tag == "Player"){
            gameObject.SetActive(false);
        }
    }

    void OnEnable(){
        enemyRb = transform.GetComponent<Rigidbody2D>();
        enemyRb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
