using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    
    public void SpawnChilds(Cube cube)
    {
        Vector3 cubePosition = cube.transform.position;
        Vector3 cubeScale = cube.transform.localScale;
        int childCount = Random.Range(2, 7);

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
