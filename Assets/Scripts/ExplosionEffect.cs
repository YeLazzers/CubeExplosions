using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 0f;
    [SerializeField] private float _explosionForce = 0f;
    [SerializeField] private Cube _cubeController;
    [SerializeField] private ParticleSystem _effect;

    private void OnEnable()
    {
        _cubeController.OnExplode += Explode;
    }

    private void OnDisable()
    {
        _cubeController.OnExplode -= Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
        Instantiate(_effect, transform.position, transform.rotation);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> explodableObjects = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                explodableObjects.Add(hit.attachedRigidbody);

        return explodableObjects;
    }
}
