using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objPickUp : MonoBehaviour
{
    public GameObject crosshair1, crosshair2;
    public Transform objTransform, camTransform;
    public bool isInteract, isPickedUp;
    public Rigidbody objRigidbody;
    public float throwForce;


    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            isInteract = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("MainCamera"))
        {
            if(isPickedUp == false)
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
        if(isInteract == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                objTransform.parent = camTransform;
                objRigidbody.useGravity = false;
                isPickedUp = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                isPickedUp = false;
            }
            if(isPickedUp == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    objTransform.parent = null;
                    objRigidbody.useGravity = true;
                    objRigidbody.velocity = camTransform.forward * throwForce * Time.deltaTime;
                }
            }
        }
    }
}
