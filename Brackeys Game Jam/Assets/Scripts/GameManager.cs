using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private Transform playerTransform;
    public List<GameObject> enemies;
    public TextMeshProUGUI timer;
    public GameObject winText;
    public GameObject loseText;
    public float timerTime = 60.0f;
    public bool isGameActive;
    public void GameOver()
    {
        winText.SetActive(true);
        if (Input.GetKey(KeyCode.Escape))
        {
            Back();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    private float spawnBoundMin = 5f;
    private float spawnBoundMax = 10f;

     void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        isGameActive = true;
        StartCoroutine(Spawn());

    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timerTime -= Time.deltaTime;
        Mathf.Round(timerTime);
        timer.text = "TIMER:\n " + timerTime;
        if (timerTime < 0)
        {
            isGameActive = false;
            Debug.Log("You Survived!");
            GameOver();
        }
    }
    IEnumerator Spawn()
    {
        while (isGameActive)
        {
            float randomX = Random.Range(playerTransform.position.x + spawnBoundMin, playerTransform.position.x + spawnBoundMax);
            float randomZ = Random.Range(playerTransform.position.z + spawnBoundMin, playerTransform.position.z + spawnBoundMax);
            Vector3 randomPos = new Vector3(randomX, 0.5f, randomZ);
            int randomIndex = Random.Range(0, 3);
            if (isGameActive)
            {
                Instantiate(enemies[randomIndex], randomPos, enemies[randomIndex].transform.rotation);
            }
            spawnBoundMin -= 0.04f;
            spawnBoundMax -= 0.04f;
            yield return new WaitForSeconds(2);
        }
    }
    public void Death()
    {
        loseText.SetActive(true);
        if(Input.GetKey(KeyCode.Escape))
        {
            Back();
        }
        else if(Input.GetKey(KeyCode.R))
        {
            Restart();
        }
    }

}  


