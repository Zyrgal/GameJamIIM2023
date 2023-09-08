using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputPanel : MonoBehaviour
{
    public static PlayerInputPanel Instance;

    [SerializeField] private List<Image> imageList = new List<Image>();
    [SerializeField] Sprite baseSprite;

    private void Awake()
    {
        Instance = this;
    }

    public void AddImageToPanel(Sprite sprite, int index)
    {
        imageList[index].sprite = sprite;
    }

    public void ClearPanel()
    {
        foreach (Image image in imageList)
        {
            image.sprite = baseSprite;
        }
    }
}
