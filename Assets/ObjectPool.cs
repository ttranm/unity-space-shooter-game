using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ObjectPoolItems {
    public GameObject objectToPool;
    public int amountOfObjects;
    public bool expand;

}

public class ObjectPool : MonoBehaviour{

    public static ObjectPool SharedInstance;
    
    public List<ObjectPoolItems> poolItems;

    public List<GameObject> pooledObjects;

    void Awake(){
        SharedInstance = this;
    }

    void Start () {
        pooledObjects = new List<GameObject>();
            foreach (ObjectPoolItems item in poolItems) {
                for (int i = 0; i < item.amountOfObjects; i++) {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                }
            }
    }

    public GameObject GetPooledObject(string tag) {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag) {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItems item in poolItems) {
            if (item.objectToPool.tag == tag) {
                if (item.expand) {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

    void Update(){

    }

}
