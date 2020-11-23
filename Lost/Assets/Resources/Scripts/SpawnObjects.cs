using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{

    public GameObject spawnObject;
    public GameObject plane;

    public float height = 5f;

    public int nSpawns = 0;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindWithTag("MinePlane");
        Random.InitState(340);
        SpawnRandomObjects();
    }

    private void SpawnRandomObjects()
    {  
        for (int i = 0; i < nSpawns; i++){
            Vector3 randomPosition = GetRandomPos(plane);
            Instantiate<GameObject>(spawnObject, randomPosition, Quaternion.identity);
        }
    }

    public Vector3 GetRandomPos(GameObject plane)
    {
        float randomX = Random.Range (plane.transform.position.x - plane.transform.localScale.x / 2, plane.transform.position.x + plane.transform.localScale.x / 2);
        float randomY = plane.transform.position.y + height;
        float randomZ = Random.Range (plane.transform.position.z - plane.transform.localScale.z / 2, plane.transform.position.z + plane.transform.localScale.z / 2);

        Vector3 newVec = new Vector3(randomX, randomY, randomZ);
        return newVec;
    }
}
