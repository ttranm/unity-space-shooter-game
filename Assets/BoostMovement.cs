using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D boostRb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnBecameInvisible(){
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            gameObject.SetActive(false);
        }
    }

    void OnEnable(){
        boostRb = transform.GetComponent<Rigidbody2D>();
        boostRb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
