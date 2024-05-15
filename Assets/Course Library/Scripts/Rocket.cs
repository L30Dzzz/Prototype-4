using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;
    public bool homing;
    private GameObject[] enemy;
    public Rigidbody homingRb;

    
    void Awake()
    {
        homingRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, enemy[0].transform.position, 1 * Time.deltaTime, 0);
        transform.position = Vector3.MoveTowards(transform.position, enemy[0].transform.position, speed * Time.deltaTime);
    }
}
