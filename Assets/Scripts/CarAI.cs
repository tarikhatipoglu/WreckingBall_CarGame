using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public Rigidbody rb;

    public bool wrecked;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");
        wrecked = false;
    }

    void Update()
    {
        if(wrecked == false)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.speed = 0;
            agent.angularSpeed = 0;
            agent.GetComponent<NavMeshAgent>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Enemy car damaged, it's vulnerable now");
            wrecked = true;
            rb.AddForce(-transform.forward * 5000);
            rb.useGravity = true;
        }
    }
}
