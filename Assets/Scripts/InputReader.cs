using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    public UnityAction OnLeftMousePressed;
    public Vector3 MousePosition => Input.mousePosition;

    private readonly int MouseLeftButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseLeftButton))
        {
            OnLeftMousePressed?.Invoke();
        }
    }
}
