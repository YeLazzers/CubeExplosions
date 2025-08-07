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
            _spawner.SpawnChilds(cube);
        }
        else
        {
            _exploder.Explode(cube.transform);
        }
        _spawner.Destroy(cube);
    }
}