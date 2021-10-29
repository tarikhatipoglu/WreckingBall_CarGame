using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBG_Area : MonoBehaviour
{
    public float time, divide, A, waitForSeconds;

    public Color start, end;

    void Update()
    {
        waitForSeconds -= 1 * Time.deltaTime;

        if(waitForSeconds < 0)
        {
            waitForSeconds = 0f;

            time -= 1 * Time.deltaTime;
            A = time / divide;

            GetComponent<Renderer>().material.color = Color.Lerp(end, start, A);

            if (time <= 0)
            {
                time = 0f;

                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
