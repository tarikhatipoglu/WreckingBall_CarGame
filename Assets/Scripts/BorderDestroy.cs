using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arena1")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Arena2")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Arena3")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Arena4")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Shield")
        {
            Destroy(other.gameObject);
        }
    }
}
