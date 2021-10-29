using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    private Camera cam;

    public float turnSpeed, speed, lerpValue;
    public LayerMask layer;

    public bool giftBool;
    public GameObject powerBall;
    public GameObject WB;
    public float giftTime;
    private float A, B;

    void Start()
    {
        cam = Camera.main;
        giftBool = false;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Movement();
        }
        else
        {

        }
    }

    void Update()
    {
        PowerUP();
    }

    private void Movement()
    {
        //Camera pozisyonu, mouse'a uyarlanması için
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            //Mouse hitting ground
            Vector3 hitVector = hit.point;
            hitVector.y = transform.position.y;

            //To move character
            transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, hitVector, lerpValue), Time.deltaTime * speed);
            Vector3 newMovePoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);

            //To rotate character
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newMovePoint - transform.position), turnSpeed * Time.deltaTime);
        }
    }

    void PowerUP()
    {
        if(giftBool == true)
        {
            powerBall.SetActive(true);

            powerBall.transform.Rotate(new Vector3(0f, 5f, 0f));

            giftTime -= 1 * Time.deltaTime;
            if (giftTime <= 0)
            {
                giftBool = false;
            }
        }

        if (giftBool == false)
        {
            giftTime = 5f;
            powerBall.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Border")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.gameObject.tag == "PowerUp")
        {
            giftBool = true;
            Debug.Log("Gift!");
            Destroy(other.gameObject);
        }
    }
}
