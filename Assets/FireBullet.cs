using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    public float bulletSpeed = 1.0f;
    private Rigidbody2D bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnBecameInvisible(){
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    void OnEnable(){
        bulletRb = transform.GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.up * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
        
        //transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
       
    }
}
