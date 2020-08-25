using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]
    private Texture2D[] cursorTexture;

    public ParticleSystem sprayVaccineEffect;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture[0], new Vector2(), CursorMode.Auto);
        sprayVaccineEffect.Stop();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            sprayVaccineEffect.Play();

        if (Input.GetMouseButton(0))
            Cursor.SetCursor(cursorTexture[1], Vector2.zero, CursorMode.Auto);

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorTexture[0], Vector2.zero, CursorMode.Auto);
            sprayVaccineEffect.Stop();
        }
    }
}
