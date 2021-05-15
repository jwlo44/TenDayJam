using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Vector2 clickTextureCoordinates = Vector2.zero;

    void OnEnable()
    {
        SetCursor();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCursor();
    }

    void OnMouseEnter()
    {
        SetCursor();
    }

    void OnDisable()
    {
        ClearCursor();
    }

    void OnDestroy()
    {
        ClearCursor();
    }

    void SetCursor()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorTexture, clickTextureCoordinates, CursorMode.Auto);
    }

    void ClearCursor()
    {
        Cursor.visible = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
