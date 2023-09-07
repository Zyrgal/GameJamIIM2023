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

    }
}
