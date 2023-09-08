using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loupiotte : MonoBehaviour
{
    public static Loupiotte Instance;

    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }

    public void ChangeLoupiotteColor(Color color)
    {
        spriteRenderer.color = color;
        StartCoroutine("ChangeColorCoroutine");
    }

    private IEnumerator ChangeColorCoroutine()
    {
        yield return new WaitForSeconds(3f);
        spriteRenderer.color = Color.white;
    }   
}
