using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    public GameObject crosshair1, crosshair2;
    public Transform objTransform, camTransform;
    public bool isInteract, isPickup;
    public Rigidbody objRigidbody;
    public float throwForce;

    void Start()
    {
        objRigidbody.useGravity = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            isInteract = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(isPickup == false)
            {
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                isInteract = false;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isInteract == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                objTransform.parent = camTransform;
                objRigidbody.useGravity = false;
                isPickup = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                isPickup=false;
            }
            if(isPickup == true)
            {
                if(Input.GetMouseButtonDown(1))
                {
                    objTransform.parent = null;
                    objRigidbody.useGravity = true;
                    objRigidbody.velocity = camTransform.forward * throwForce * Time.deltaTime;
                    isPickup = false;
                }
            }
        }
    }
}
