using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnumRule
{
    letter = 0,
    word,
    entrepriseName,
    employeeCloth,
    employeeAccessory
}

public enum LetterToSeach
{
    a, b
}
public enum WordToSeach
{
    economie, juridique, batiment, controleur
}

public enum EmployeeFirstname
{
    Harry,
    Paul
}
public enum EmployeeLastname
{
    Potter,
    Fontaine
}
public enum EntrepriseName
{
    EntrepriseA,
    EntrepriseB,
    EntrepriseC,
    EntrepriseD
}
public enum EmployeeClothing
{
    Cravate,
    Costard,
    Chapeau,
    TeeShirt
}
public enum EmployeeAccesory
{
    Collier,
    Lunette,
    Bague,
    Piercing
}

public class EmployeeData : MonoBehaviour
{
    [Header("Combinaisons")]
    public List<List<InputSymbol>> allCombinaisons = new List<List<InputSymbol>>();
    public List<InputSymbol> combinaison1 = new List<InputSymbol>();
    public List<InputSymbol> combinaison2 = new List<InputSymbol>();
    public List<InputSymbol> combinaison3 = new List<InputSymbol>();

    public string employeeLastname = null;
    public string employeeFirstname = null;
    public string employeeDescription = null;
    public string employeeEntreprise = null;
    public string employeeCloth = null;
    public string employeeAccessory = null;

    [SerializeField] List<GameObject> everyWearedObject;
    [SerializeField] List<GameObject> everyHead;

    [SerializeField] public SheetData sheetData;

    int combinaisonCount = 6;

    private void Start()
    {
        RandomiseCombinaison(combinaison1);
        RandomiseCombinaison(combinaison2);
        RandomiseCombinaison(combinaison3);

        allCombinaisons.Add(combinaison1);
        allCombinaisons.Add(combinaison2);
        allCombinaisons.Add(combinaison3);
        SetEmployee();
        SetEmployeeVisual();
        SetSheetData();
    }

    public void RandomiseCombinaison(List<InputSymbol> combinaisonToRandomise)
    {
        combinaisonToRandomise.Clear();
        
        for (int i = 0; i < combinaisonCount; i++)
        {
            combinaisonToRandomise.Add(new InputSymbol());
            System.Array A = System.Enum.GetValues(typeof(InputSymbol));
            InputSymbol V = (InputSymbol)A.GetValue(UnityEngine.Random.Range(0, A.Length));
            combinaisonToRandomise[i] = V;
        }
    }

    private void SetEmployee()
    {
        if (employeeLastname != null)
        {
            employeeLastname = DataList.instance.savedLastNameList[Random.Range(0, DataList.instance.savedLastNameList.Count)];
        }
        if (employeeFirstname != null)
        {
            employeeFirstname = DataList.instance.savedFirstNameList[Random.Range(0, DataList.instance.savedFirstNameList.Count)];
        }
        if (employeeDescription != null)
        {
            employeeDescription = DataList.instance.savedDescriptionsList[Random.Range(0, DataList.instance.savedDescriptionsList.Count)];
        }
        if (employeeEntreprise != null)
        {
            employeeEntreprise = DataList.instance.savedEntrepriseNameList[Random.Range(0, DataList.instance.savedEntrepriseNameList.Count)];
        }
        if (employeeCloth != null)
        {
            employeeCloth = DataList.instance.savedClothList[Random.Range(0, DataList.instance.savedClothList.Count)];
        }
        if (employeeAccessory != null)
        {
            employeeAccessory = DataList.instance.savedAccessoryList[Random.Range(0, DataList.instance.savedAccessoryList.Count)];
        }
    }

    private void SetEmployeeVisual()
    {
        foreach (var item in everyWearedObject)
        {
            if (item.name == employeeCloth)
            {
                item.SetActive(true);
            }

            if (item.name == employeeAccessory)
            {
                item.SetActive(true);
            }
        }

        everyHead[Random.Range(0, everyHead.Count)].SetActive(true);
    }

    public void SetSheetData()
    {
        sheetData.employeeName.text = employeeFirstname + " " + employeeLastname;
        sheetData.entreprise.text = employeeEntreprise;
        sheetData.info.text = employeeDescription;

        for (int i = 0; i < sheetData.symbolCombo1.Count; i++)
        {
            sheetData.symbolCombo1[i].GetComponent<Image>().sprite = GetSprite(combinaison1[i]);
            sheetData.symbolCombo2[i].GetComponent<Image>().sprite = GetSprite(combinaison2[i]);
            sheetData.symbolCombo3[i].GetComponent<Image>().sprite = GetSprite(combinaison3[i]);
        }
    }

    private Sprite GetSprite(InputSymbol input)
    {
        for (int i = 0; i < InputManager.Instance.pictoSprites.Count; i++)
        {
            if (input.ToString() == InputManager.Instance.pictoSprites[i].name)
            {
                return InputManager.Instance.pictoSprites[i];
            }
        }
        return null;
    }
}
