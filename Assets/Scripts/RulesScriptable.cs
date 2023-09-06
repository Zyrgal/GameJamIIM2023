using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RulesScriptable : MonoBehaviour
{
    [SerializeField] int nbrRulesToCreate = 3;

    public struct RulesPorteA
    {
        public EntrepriseName entrepriseName;
        public LetterToSeach letter;
    }
    public struct RulesPorteB
    {
        public EmployeeFirstname employeeFirstName;
        public EmployeeLastname employeeLastName;
        public WordToSeach word;

    }
    public struct RulesPorteC
    {
        public EmployeeClothing employeeClothing;
        public EmployeeAccesory employeeAccesory;
    }

    private void Start()
    {
        RulesPorteA rulePorteA = new RulesPorteA();
        RulesPorteB rulePorteB = new RulesPorteB();
        RulesPorteC rulePorteC = new RulesPorteC();

        rulePorteA.letter = (LetterToSeach)Random.Range(0, System.Enum.GetValues(typeof(LetterToSeach)).Length);
        rulePorteA.entrepriseName = (EntrepriseName)Random.Range(0, System.Enum.GetValues(typeof(EntrepriseName)).Length);
    }
}
