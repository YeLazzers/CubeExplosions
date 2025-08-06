using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            Cube cube;



            if (Physics.Raycast(ray, out raycastHit))
            {
                raycastHit.collider.gameObject.TryGetComponent<Cube>(out cube);
                if (cube != null)
                {
                    Debug.Log("Clicked: " + raycastHit.collider.name);
                    cube.Destroy();
                }

            }
        }
    }
}
