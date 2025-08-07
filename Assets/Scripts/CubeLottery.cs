using UnityEngine;

public class CubeLottery : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _rayCaster.OnCubeHitted += TestLuck;
    }

    private void OnDisable()
    {
        _rayCaster.OnCubeHitted -= TestLuck;
    }

    private void TestLuck(Cube cube)
    {
        if (Random.Range(0, 101) <= cube.MultiplyChance)
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