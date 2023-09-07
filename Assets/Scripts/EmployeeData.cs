using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    /*public List<string> LetterToSearchList;
    public List<string> WordToSearchList;
    public List<string> FirstNameList;
    public List<string> LastNameList;
    public List<string> DescriptionsList;
    public List<string> EntrepriseNameList;
    public List<string> ClothList;
    public List<string> AccessoryList;*/

    /*public EntrepriseName entrepriseName;
    public EmployeeClothing employeeClothing;
    public EmployeeAccesory employeeAccesory;*/
    public string employeeLastname;
    public string employeeFirstname;
    public string employeeDescription;
    public string employeeEntreprise;
    public string employeeCloth;
    public string employeeAccessory;

    

    private void Start()
    {
        allCombinaisons.Add(combinaison1);
        allCombinaisons.Add(combinaison2);
        allCombinaisons.Add(combinaison3);
        SetEmployee();
    }

    private void SetEmployee()
    {
        //employeeFirstname = (EmployeeFirstname)Random.Range(0, System.Enum.GetValues(typeof(EmployeeFirstname)).Length);
        /*employeeFirstname = TestingWord.GetRandomEnum<EmployeeFirstname>();
        employeeLastname = TestingWord.GetRandomEnum<EmployeeLastname>();*/
        /*entrepriseName = TestingWord.GetRandomEnum<EntrepriseName>();
        employeeClothing = TestingWord.GetRandomEnum<EmployeeClothing>();
        employeeAccesory = TestingWord.GetRandomEnum<EmployeeAccesory>();*/
    }
}
