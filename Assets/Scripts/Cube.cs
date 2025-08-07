using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private float _multiplyChance = 1f;

    public float MultiplyChance => _multiplyChance;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(Vector3 parentScale, float parentMultiplyChance)
    {
        transform.localScale = parentScale / 2f;
        _multiplyChance = parentMultiplyChance / 2f;
        _renderer.material.color = Random.ColorHSV();
    }
}
