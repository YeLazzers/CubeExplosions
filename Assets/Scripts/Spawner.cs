using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _minChild = 2;
    [SerializeField] private int _maxChild = 7;
    
    public List<Cube> SpawnChilds(Cube cube)
    {
        Vector3 cubePosition = cube.transform.position;
        Vector3 cubeScale = cube.transform.localScale;
        int childCount = Random.Range(_minChild, _maxChild);

        List<Cube> cubes = new();

        for (int i = 0; i < childCount; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, cubePosition, Quaternion.identity, transform);
            newCube.Initialize(cubeScale, cube.MultiplyChance);

            cubes.Add(newCube);
        }

        return cubes;
    }

    public void Destroy(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
