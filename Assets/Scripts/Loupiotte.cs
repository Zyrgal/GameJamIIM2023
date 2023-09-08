using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loupiotte : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }
}
