using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SheetData : MonoBehaviour
{
    public TextMeshProUGUI employeeName;
    public TextMeshProUGUI entreprise;
    public TextMeshProUGUI info;

    public List<Image> symbolCombo1 = new List<Image>();
    public List<Image> symbolCombo2 = new List<Image>();
    public List<Image> symbolCombo3 = new List<Image>();

    public bool choosen = false;

    private void Start()
    {
        if (!choosen)
            HideSheet();
    }

    public void DisplaySheet()
    {
        gameObject.SetActive(true);
    }

    public void HideSheet()
    {
        gameObject.SetActive(false);
    }
}
