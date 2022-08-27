using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    private Transform player;
    private Rigidbody enemy;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
