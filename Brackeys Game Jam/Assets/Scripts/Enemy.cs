using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    private float distance;
    private Transform player;
    private Rigidbody enemy;
    private GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemy = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent < Transform >();
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 direction = -(transform.position - player.transform.position).normalized;
        enemy.AddForce(direction * speed);
    }
    */
    void Update()
    {
        transform.LookAt(player.transform);
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        transform.position += transform.forward * 1f * Time.deltaTime;
        distance = (player.transform.position.x - transform.position.x) * (player.transform.position.x - transform.position.x) + (player.transform.position.z - transform.position.z) * (player.transform.position.z - transform.position.z);
        if (distance > 225)
        {
            Destroy(gameObject);
        }
        else if (distance < 1)
        {
            game.Death();
        }
    }
}
