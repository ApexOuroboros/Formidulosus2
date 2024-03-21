using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInteract : MonoBehaviour, IInteractable
{
    Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public string GetText()
    {
        return "Change to random colour";
    }

    public void OnInteract()
    {
        material.color = new Color(Random.value, Random.value, Random.value);
    }
}
