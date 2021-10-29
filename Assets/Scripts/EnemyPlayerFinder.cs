using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerFinder : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

        if (enemies.Length == 0)
        {
            Debug.Log("You win");
        }
    }
}
