using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    private Transform playerTransform;
    public List<GameObject> enemies;
    public TextMeshProUGUI timer;
    private float timerTime = 60.0f;
    private bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        isGameActive = true;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        timerTime -= Time.deltaTime;
        Mathf.Round(timerTime);
        timer.text = "TIMER:\n " + timerTime;
        if(timerTime<0)
        {
            isGameActive = false;
            Debug.Log("You Survived!");
            //GameOver();
        }    
    }
    IEnumerator Spawn()
    {
        while (isGameActive)
        {
            float randomX = Random.Range(playerTransform.position.x + 5, playerTransform.position.x + 10);
            float randomZ = Random.Range(playerTransform.position.z + 5, playerTransform.position.z + 10);
            Vector3 randomPos = new Vector3(randomX, 0.5f, randomZ);
            int randomIndex = Random.Range(0, 3);
            if (isGameActive)
            {
                Instantiate(enemies[randomIndex], randomPos, enemies[randomIndex].transform.rotation);
            }
            yield return new WaitForSeconds(2);
        }
    }
}
