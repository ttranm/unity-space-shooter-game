using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller SharedInstance;
    public GameObject enemy;
    public GameObject boost;
    public GameObject wing;
    public int enemySpawn;
    public int boostSpawn;
    public int totalWings;
    public float spawnTime = 1.0f;
    public float spawnRate = 1.0f;
    void Awake(){
        SharedInstance = this;
    }
    // Spawning the enemy ships
    IEnumerator spawnEnemies () {
        yield return new WaitForSeconds(1.5f);
		while (true) {
			for (int i = 0 ; i < enemySpawn; i++) {
                // Setting the spawn location at the top of the camera screen
				Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight + 2, 0));
				Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight + 2, 0));
				Vector3 spawnPosition = new Vector3 (Random.Range(topLeft.x, topRight.x), topLeft.y, 0);
                // Setting the spawn rotation so it's looking down, but technically moving "forward" in the enemies movement code.
				Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);
                enemy = ObjectPool.SharedInstance.GetPooledObject("Enemy"); 
                if (enemy != null) {
                    var renderer = enemy.GetComponent<Renderer>();
                    renderer.material.SetColor("_Color", Color.blue);
                    enemy.transform.position = spawnPosition;
                    enemy.transform.rotation = spawnRotation;
                    enemy.SetActive(true);
                }
            yield return new WaitForSeconds (spawnRate);
		    }
        yield return new WaitForSeconds (spawnTime);
	    }
    }

    IEnumerator spawnBoosts () {
        yield return new WaitForSeconds(1.5f);
		while (true) {
			for (int i = 0 ; i < boostSpawn; i++) {
                // Setting the spawn location at the top of the camera screen
				Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0));
				Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
				Vector3 spawnPosition = new Vector3 (Random.Range(topLeft.x, topRight.x), topLeft.y, 0);
                // Setting the spawn rotation so it's looking down, but technically moving "forward" in the enemies movement code.
				Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);
                boost = ObjectPool.SharedInstance.GetPooledObject("Boost"); 
                if (boost != null) {
                    var renderer = boost.GetComponent<Renderer>();
                    renderer.material.SetColor("_Color", Color.yellow);
                    boost.transform.position = spawnPosition;
                    boost.transform.rotation = spawnRotation;
                    boost.SetActive(true);
                }
            yield return new WaitForSeconds (spawnRate);
		    }
        yield return new WaitForSeconds (spawnTime);
	    }
    }

    IEnumerator spawnWings () {
        yield return new WaitForSeconds(1.5f);
		while (true) {
			for (int i = 0 ; i < totalWings; i++) {
                // Setting the spawn location at the top of the camera screen
				Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0));
				Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
				Vector3 spawnPosition = new Vector3 (Random.Range(topLeft.x, topRight.x), topLeft.y, 0);
                // Setting the spawn rotation so it's looking down, but technically moving "forward" in the enemies movement code.
				Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);
                wing = ObjectPool.SharedInstance.GetPooledObject("Wing"); 
                if (wing != null) {
                    var renderer = wing.GetComponent<Renderer>();
                    renderer.material.SetColor("_Color", Color.green);
                    wing.transform.position = spawnPosition;
                    wing.transform.rotation = spawnRotation;
                    wing.SetActive(true);
                }
            yield return new WaitForSeconds (spawnRate);
		    }
        yield return new WaitForSeconds (spawnTime);
	    }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemies());
        StartCoroutine(spawnBoosts());
        StartCoroutine(spawnWings());
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
