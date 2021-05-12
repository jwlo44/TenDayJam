using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Vector2 clickTextureCoordinates = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        SetCursor();
    }

    void OnMouseEnter()
    {
        SetCursor();
    }

    void SetCursor()
    {
        Cursor.SetCursor(cursorTexture, clickTextureCoordinates, CursorMode.Auto);
    }
}
