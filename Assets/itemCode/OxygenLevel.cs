using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class OxygenLevel : MonoBehaviour
{
    HashSet<Atmosphere> _oxygenSources = new HashSet<Atmosphere>();

    [SerializeField][Range(0, 1)] float _oxygen = 1f;
    [SerializeField][Min(0)] float _oxygenReplenishment = 0.05f;
    [SerializeField][Min(0)] float _oxygenConsumption = 0.05f;
    [SerializeField] AnimationCurve _oxygenLevelViability = new AnimationCurve(new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 3.3f, 0));
    const float k_breathing_tick_rate = 1f / 3f;

    void OnEnable()
    {
        // This will create a custom Update-like function that will be called repeatedly.
        // I'm not using Update because breathing don't have to be calculated every time a frame is drawn (just wasteful)
        InvokeRepeating(nameof(Tick_Breathing), time: k_breathing_tick_rate, repeatRate: k_breathing_tick_rate);
    }
    void OnTriggerEnter(Collider other)
    {
        var comp = other.GetComponent<Atmosphere>();
        if (comp != null)
            _oxygenSources.Add(comp);
    }
    void OnTriggerExit(Collider other)
    {
        var comp = other.GetComponent<Atmosphere>();
        if (comp != null)
            _oxygenSources.Remove(comp);
    }
#if UNITY_EDITOR
    void OnDrawGizmos ()
    {
        Gizmos.color = Color.white;
        Vector3 pos = transform.position;
        foreach( var source in _oxygenSources )
            Gizmos.DrawLine( pos , source.transform.position );
    }
#endif
    void Tick_Breathing()
    {
        // in cases when atmo volumes overlap - pick the better one:
        float oxygenAround = 0f;
        foreach (var volume in _oxygenSources)
            oxygenAround = Mathf.Max(oxygenAround, volume.oxygenLevel);

        // breathing:
        float oxygenIntake = _oxygenReplenishment * k_breathing_tick_rate * _oxygenLevelViability.Evaluate(oxygenAround);
        _oxygen = Mathf.Clamp01(_oxygen + oxygenIntake);

        // oxygen consumption:
        float oxygenConsumed = _oxygenConsumption * k_breathing_tick_rate * (1f - oxygenAround);
        _oxygen = Mathf.Clamp01(_oxygen - oxygenConsumed);

        if (!(_oxygen > 0))
            OnAsphyxiation();
    }
    void OnAsphyxiation()
    {
        Debug.Log($"{gameObject.name} is x__x (asphyxiation)", gameObject);
        gameObject.SetActive(false);
    }
}
