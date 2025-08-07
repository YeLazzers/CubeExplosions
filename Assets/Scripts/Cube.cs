using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _multiplyChance = 100f;

    public float MultiplyChance => _multiplyChance; 

    public void Initialize(Vector3 parentScale, float parentMultiplyChance)
    {
        transform.localScale = parentScale / 2f;
        _multiplyChance = parentMultiplyChance / 2f;
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
