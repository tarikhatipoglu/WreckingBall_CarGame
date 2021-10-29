using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteSpawner : MonoBehaviour
{
    public Vector3 bounds;
    public float respawnTime;
    public GameObject parachute;

    void Start()
    {
        StartCoroutine(spawnWave());
    }

    private void spawnParachute()
    {
        GameObject A = Instantiate(parachute) as GameObject;
        A.transform.position = new Vector3(Random.Range(-bounds.x -20, bounds.x + 20), 1, Random.Range(-bounds.z - 20, bounds.z + 20));
    }

    IEnumerator spawnWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnParachute();
        }
    }
}
