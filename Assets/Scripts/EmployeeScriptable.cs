using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Employee", menuName = "ScriptableObjects/Employee", order = 1)]
public class EmployeeScriptable : ScriptableObject
{
    [Header("Name")]
    [SerializeField] string employeeName;
    [Header("Entreprise")]
    [SerializeField] string entrepriseName;
    [Header("Description")]
    [SerializeField] string description;

    [Header("Combinaisons")]
    [SerializeField] string combinaison1;
    [SerializeField] string combinaison2;
    [SerializeField] string combinaison3;
}
