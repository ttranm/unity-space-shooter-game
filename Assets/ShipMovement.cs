using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    //private Vector3 mousePos;
    private float depth = 5.0f;
    public GameObject bullet;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // Fire a bullet whenever we left click.
        // I couldn't get the held down working for bullet per second.
        // It was never implemented
        if(Input.GetMouseButtonDown(0)){
            fireBullet();
        }
        
    }

    void FixedUpdate(){
        shipMove();
    }

    void fireBullet(){
        bullet = ObjectPool.SharedInstance.GetPooledObject("Bullet");
        if(bullet != null){
            var renderer = bullet.GetComponent<Renderer>();
            renderer.material.SetColor("_Color", Color.red);
            Vector3 spawnBulletPos = new Vector3(this.transform.position.x, this.transform.position.y + 1, 0);
            bullet.transform.position = spawnBulletPos;
            bullet.SetActive(true);
        }
    }

    void shipMove(){
        // Moving the ship based on the mouse position
        Vector3 mousePos = Input.mousePosition;
        // Converting from the camera screen to the world point using mouse position
        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));
        // Updating the position for the ship to be where the mouse is
        transform.position = wantedPos;
    }

}
