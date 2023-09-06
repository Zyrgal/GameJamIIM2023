using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LetterToSeach
{
    a,b,c,d,e,f,g,h
}
public enum WordToSeach
{
    economie,juridique
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
    EntrepriseB
}
public enum EmployeeClothing
{
    Cravate,
    Costard
}
public enum EmployeeAccesory
{
    Collier,
    Lunette
}

public class EmployeeData : MonoBehaviour
{
    [Header("Combinaisons")]
    [SerializeField] List<int> combinaison1;
    [SerializeField] List<int> combinaison2;
    [SerializeField] List<int> combinaison3;

    public EntrepriseName entrepriseName;
    public EmployeeClothing employeeClothing;
    public EmployeeAccesory employeeAccesory;
    public EmployeeLastname employeeLastname;
    public EmployeeFirstname employeeFirstname;

    private void Start()
    {
        SetEmployee();
    }

    private void SetEmployee()
    {
        employeeFirstname = (EmployeeFirstname)Random.Range(0, System.Enum.GetValues(typeof(EmployeeFirstname)).Length);
        employeeLastname = (EmployeeLastname)Random.Range(0, System.Enum.GetValues(typeof(EmployeeLastname)).Length);
        entrepriseName = (EntrepriseName)Random.Range(0, System.Enum.GetValues(typeof(EntrepriseName)).Length);
        employeeClothing = (EmployeeClothing)Random.Range(0, System.Enum.GetValues(typeof(EmployeeClothing)).Length);
        employeeAccesory = (EmployeeAccesory)Random.Range(0, System.Enum.GetValues(typeof(EmployeeAccesory)).Length);
    }
}
