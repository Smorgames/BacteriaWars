using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayVaccine : MonoBehaviour
{
    public Camera mainCamera;

    private void FixedUpdate()
    {
        transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f);
    }
}
