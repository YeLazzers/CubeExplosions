using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _minChild = 2;
    [SerializeField] private int _maxChild = 7;
    
    public void SpawnChilds(Cube cube)
    {
        Vector3 cubePosition = cube.transform.position;
        Vector3 cubeScale = cube.transform.localScale;
        int childCount = Random.Range(_minChild, _maxChild);

        for (int i = 0; i < childCount; i++)
        {
            var newCube = Instantiate(_cubePrefab, cubePosition, Quaternion.identity, transform);
            newCube.GetComponent<Cube>().Initialize(cubeScale, cube.MultiplyChance);
        }
    }

    public void Destroy(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
