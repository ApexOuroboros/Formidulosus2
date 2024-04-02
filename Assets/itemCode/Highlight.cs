using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    private Color colour = Color.white;

    private List<Material> materials;

    private void Awake()
    {
        materials = new List<Material>();
        foreach (var r in renderers)
        {
            materials.AddRange(new List<Material>(r.materials));
        }
    }

    public void ToggleHighlight(bool val)
    {
        if (val)
        {
            foreach (var m in materials)
            {
                m.EnableKeyword("_EMISSION");
                m.SetColor("_EmissionColor",  colour);
            }
        }
        else
        {
            foreach(var m in materials)
            {
                m.DisableKeyword("_EMISSION");
            }
        }
    }

}
