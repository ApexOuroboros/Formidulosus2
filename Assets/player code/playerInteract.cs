using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

interface IInteractable
{
    void OnInteract();
    string GetText();
}

public class playerInteract : MonoBehaviour
{
    public Camera Camera;
    public float interactRange = 2f;

    public GameObject interactUI;
    public TextMeshProUGUI interactText;

    private void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray r = Camera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false; 

        if(Physics.Raycast(r, out hit, interactRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                hitSomething = true;
                interactText.text = interactable.GetText();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.OnInteract();
                }
            }
            
        }

        interactUI.SetActive(hitSomething);
    }
}
