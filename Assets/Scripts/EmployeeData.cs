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

/*public enum EmployeeFirstname
{
    Harry,
    Paul
}
public enum EmployeeLastname
{
    Potter,
    Fontaine
}*/
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
    public List<List<int>> allCombinaisons;
    public List<int> combinaison1;
    public List<int> combinaison2;
    public List<int> combinaison3;

    public List<string> FirstName;
    public List<string> LastName;

    public EntrepriseName entrepriseName;
    public EmployeeClothing employeeClothing;
    public EmployeeAccesory employeeAccesory;
    public string employeeLastname;
    public string employeeFirstname;

    private void Start()
    {
        SetEmployee();
    }

    private void SetEmployee()
    {
        //employeeFirstname = (EmployeeFirstname)Random.Range(0, System.Enum.GetValues(typeof(EmployeeFirstname)).Length);
        /*employeeFirstname = TestingWord.GetRandomEnum<EmployeeFirstname>();
        employeeLastname = TestingWord.GetRandomEnum<EmployeeLastname>();*/
        entrepriseName = TestingWord.GetRandomEnum<EntrepriseName>();
        employeeClothing = TestingWord.GetRandomEnum<EmployeeClothing>();
        employeeAccesory = TestingWord.GetRandomEnum<EmployeeAccesory>();
    }

    public void TestIf

    
}
