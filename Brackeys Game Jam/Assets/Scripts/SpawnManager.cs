using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform playerTransform;
    public List<GameObject> enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    IEnumerator Spawn()
    {    
        float randomX = Random.Range(playerTransform.position.x + 5, playerTransform.position.x + 10);
        float randomZ = Random.Range(playerTransform.position.z + 5, playerTransform.position.z + 10);
        Vector3 randomPos = new Vector3(randomX, 0.5f, randomZ);
        int randomIndex = Random.Range(0, 3);

        yield return new WaitForSeconds(2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
