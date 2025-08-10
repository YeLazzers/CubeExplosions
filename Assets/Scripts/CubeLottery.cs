using System.Collections.Generic;
using UnityEngine;

public class CubeLottery : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _rayCaster.OnCubeHitted += TryMultiply;
    }

    private void OnDisable()
    {
        _rayCaster.OnCubeHitted -= TryMultiply;
    }

    private void TryMultiply(Cube cube)
    {
        if (Random.value <= cube.MultiplyChance)
        {
            List<Rigidbody> cubeRbs = new();

            _spawner.SpawnChilds(cube).ForEach((childCube) => {
                if (childCube.TryGetComponent(out Rigidbody rb))
                {
                    _exploder.Explode(cube.transform, rb);
                }
            });
        } else
        {
            _exploder.Explode(cube.transform);
        }

            _spawner.Destroy(cube);
    }
}