using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class Atmosphere : MonoBehaviour
{
    [Range(0, 1)] public float oxygenLevel = 1.0f;

    #if UNITY_EDITOR

    void OnValidate()
    {
        var collider = GetComponent<BoxCollider>();
        if(!collider.isTrigger)
        {
            Debug.LogWarning("make me a trigger human!", gameObject);
        }
    }

    void OnDrawGizmos()
    {
        var collider = GetComponent<BoxCollider>();
        if( collider!=null )
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = oxygenLevel<1 ? Color.black : Color.white;
            Gizmos.DrawWireCube( collider.center , collider.size );
            Gizmos.color = new Color{ r=1f , g=1f , b=1f , a=0.05f };
            Gizmos.DrawCube( collider.center , collider.size );
        }
    }
    #endif

}
