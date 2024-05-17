using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;
    public bool homing;
    Transform enemy;
    public Rigidbody homingRb;
    
    void Awake()
    {
        homingRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(enemy !=null)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
            transform.LookAt(enemy);
        }
    }

    // Lanunches rocket
    public void LaunchRockets(Transform enemyPos)
    {  
        enemy = enemyPos;
        Destroy(gameObject, 5);
    }

    // Destroys rocket and enemy
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
