using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public struct Porte
{
    public Rule rule;
    public EnumRule enumRule;
    public int id;
}

public class RulesScriptable : MonoBehaviour
{
    public static RuleFunc[] dailyRules = new RuleFunc[5] 
    { 
        new RuleFunc(EnumRule.letter,InitLetterRule,ValidateLetterRule,InitEmployeLetter),
        new RuleFunc(EnumRule.word,InitWordRule,ValidateWordRule,InitEmployeLetter),
        new RuleFunc(EnumRule.entrepriseName,InitEntrepriseRule,ValidateEntrepriseRule,InitEmployeLetter),
        new RuleFunc(EnumRule.employeeCloth,InitClothingRule,ValidateClothingRule, InitEmployeLetter),
        new RuleFunc(EnumRule.employeeAccessory,InitAccessoryRule,ValidateAccessoryRule, InitEmployeLetter)
    };

    public static List<int> alreadyChoosenLetterIndex = new List<int>();
    public static List<int> alreadyChoosenWordIndex = new List<int>();
    public static List<int> alreadyChoosenEntrepriseIndex = new List<int>();
    public static List<int> alreadyChoosenClothIndex = new List<int>();
    public static List<int> alreadyChoosenAccessoryIndex = new List<int>();

    /*public Rule rulePorteA = new Rule();
    public Rule rulePorteB = new Rule();
    public Rule rulePorteC = new Rule();

    EnumRule porteA = new EnumRule();
    EnumRule porteB = new EnumRule();
    EnumRule porteC = new EnumRule();*/

    List<Porte> porteList = new List<Porte>();

    [SerializeField] int employeeNbrToSpawn;
    [SerializeField] GameObject employeeToSpawn;

    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            var porte = new Porte();
            int randomRuleType = Random.Range(0, 1); //5 pour le nbr de type d'enum dans "Rule"
            porte.enumRule = DefineRuleType(randomRuleType);
            porte.rule = new Rule();
            dailyRules[(int)porte.enumRule].initFunction(porte.rule);
            porteList.Add(porte);
        }

        for (int i = 0; i < employeeNbrToSpawn; i++)
        {
            GameObject instantiateEmployee = Instantiate(employeeToSpawn.transform, new Vector3((-8 + (i * 1.125f)), 0, 0), Quaternion.identity).gameObject;
            int random = Random.Range(0, porteList.Count);
            dailyRules[(int)porteList[random].enumRule].initEmployee(porteList[random].rule, instantiateEmployee.GetComponent<EmployeeData>());
        }


    }

    public static void InitEmployeLetter(Rule rule, EmployeeData employee)
    {
        //Chercher un nom dans la liste, regarder si la lettre et dedans et sinon chercher un autre ect ...
        /*employee.FirstName
        rule.letter*/
    }

    public void UI_DebugRule()
    {
        Debug.Log("rulePorteA letter = " + rulePorteA);
        /*Debug.Log("rulePorteA word = " + rulePorteA.word);
        Debug.Log("rulePorteA entreprise = " + rulePorteA.entrepriseName);
        Debug.Log("rulePorteA cloth = " + rulePorteA.employeeClothing);
        Debug.Log("rulePorteA accessory = " + rulePorteA.employeeAccesory);*/

        Debug.Log("rulePorteB letter = " + rulePorteB);
        /*Debug.Log("rulePorteB word = " + rulePorteB.word);
        Debug.Log("rulePorteB entreprise = " + rulePorteB.entrepriseName);
        Debug.Log("rulePorteB cloth = " + rulePorteB.employeeClothing);
        Debug.Log("rulePorteB accessory = " + rulePorteB.employeeAccesory);*/

        Debug.Log("rulePorteC letter = " + rulePorteC);
        /*Debug.Log("rulePorteC word = " + rulePorteC.word);
        Debug.Log("rulePorteC entreprise = " + rulePorteC.entrepriseName);
        Debug.Log("rulePorteC cloth = " + rulePorteC.employeeClothing);
        Debug.Log("rulePorteC accessory = " + rulePorteC.employeeAccesory);*/
    }

    public EnumRule DefineRuleType(int randomRuleType)
    {
        //return (EnumRule)randomRuleType;
        if (randomRuleType == 0)
        {
            return EnumRule.letter;
        }
        else if (randomRuleType == 1)
        {
            return EnumRule.word;
        }
        else if (randomRuleType == 2)
        {
            return EnumRule.entrepriseName;
        }
        else if (randomRuleType == 3)
        {
            return EnumRule.employeeCloth;
        }
        else if (randomRuleType == 4)
        {
            return EnumRule.employeeAccessory;
        }

        Debug.Log("Setting Rule issue");
        return EnumRule.letter;

    }

    public static void InitLetterRule(Rule rule)
    {
        //tirer au sort la lettre à trouver

        System.Array A = System.Enum.GetValues(typeof(LetterToSeach));
        int random = UnityEngine.Random.Range(0, A.Length);

        /*while (alreadyChoosenLetterIndex.Contains(random))
        {
            random = UnityEngine.Random.Range(0, A.Length);
        }*/

        Debug.Log("list index letter count = " + alreadyChoosenLetterIndex.Count);

        if (alreadyChoosenLetterIndex.Contains(random))
        {
            Debug.LogError("Index already taken");
            return;
        }

        alreadyChoosenLetterIndex.Add(random);

        LetterToSeach chossenLetter = (LetterToSeach)A.GetValue(random);

        rule.letter = chossenLetter;
    }

    public static bool ValidateLetterRule(Rule rule, EmployeeData employee) //
    {
        string name = employee.employeeFirstname;
        if (name.Contains(rule.letter.ToString()))
        {
            return true;
        }
        return false;
    }

    public static void InitWordRule(Rule rule)
    {
        //tirer au sort la lettre à trouver
        System.Array A = System.Enum.GetValues(typeof(WordToSeach));
        int random = UnityEngine.Random.Range(0, A.Length);

        while (alreadyChoosenWordIndex.Contains(random))
        {
            random = UnityEngine.Random.Range(0, A.Length);
        }

        alreadyChoosenWordIndex.Add(random);

        WordToSeach chossenWord = (WordToSeach)A.GetValue(random);

        rule.word = chossenWord;

        //rule.word = TestingWord.GetRandomEnum<WordToSeach>();
    }

    public static bool ValidateWordRule(Rule rule, EmployeeData employee)
    {
        string name = employee.name; // A voir pour remplacer par la description plutot 
        if (name.Contains(rule.word.ToString()))
        {
            return true;
        }
        return false;
    }

    public static void InitEntrepriseRule(Rule rule)
    {
        //tirer au sort la lettre à trouver
        System.Array A = System.Enum.GetValues(typeof(EntrepriseName));
        int random = UnityEngine.Random.Range(0, A.Length);

        while (alreadyChoosenEntrepriseIndex.Contains(random))
        {
            random = UnityEngine.Random.Range(0, A.Length);
        }

        alreadyChoosenEntrepriseIndex.Add(random);

        EntrepriseName choosenEntreprise = (EntrepriseName)A.GetValue(random);

        rule.entrepriseName = choosenEntreprise;
        //rule.entrepriseName = TestingWord.GetRandomEnum<EntrepriseName>();
    }

    public static bool ValidateEntrepriseRule(Rule rule, EmployeeData employee) //
    {
        string name = employee.entrepriseName.ToString();
        if (name.Contains(rule.entrepriseName.ToString()))
        {
            return true;
        }
        return false;
    }

    public static void InitClothingRule(Rule rule)
    {
        //tirer au sort la lettre à trouver
        System.Array A = System.Enum.GetValues(typeof(EmployeeClothing));
        int random = UnityEngine.Random.Range(0, A.Length);

        while (alreadyChoosenClothIndex.Contains(random))
        {
            random = UnityEngine.Random.Range(0, A.Length);
        }

        alreadyChoosenClothIndex.Add(random);

        EmployeeClothing choosenCloth = (EmployeeClothing)A.GetValue(random);

        rule.employeeClothing = choosenCloth;
        //rule.employeeClothing = TestingWord.GetRandomEnum<EmployeeClothing>();
    }

    public static bool ValidateClothingRule(Rule rule, EmployeeData employee) //
    {
        string name = employee.employeeClothing.ToString();
        if (name.Contains(rule.employeeClothing.ToString()))
        {
            return true;
        }
        return false;
    }

    public static void InitAccessoryRule(Rule rule)
    {
        System.Array A = System.Enum.GetValues(typeof(EmployeeAccesory));
        int random = UnityEngine.Random.Range(0, A.Length);

        while (alreadyChoosenAccessoryIndex.Contains(random))
        {
            random = UnityEngine.Random.Range(0, A.Length);
        }

        alreadyChoosenAccessoryIndex.Add(random);

        EmployeeAccesory choosenAccessory = (EmployeeAccesory)A.GetValue(random);

        rule.employeeAccesory = choosenAccessory;
        //rule.employeeAccesory = TestingWord.GetRandomEnum<EmployeeAccesory>();
    }

    public static bool ValidateAccessoryRule(Rule rule, EmployeeData employee)
    {
        string name = employee.employeeAccesory.ToString();
        if (name.Contains(rule.employeeAccesory.ToString()))
        {
            return true;
        }
        return false;
    }

    public void CheckChoosenDoor(List<char> playerInput, EmployeeData employee)
    {
        bool isValid = false;
        bool foundDoor = false;

        for (int i = 0; i < porteList.Count; i++)
        {
            if (playerInput.Equals(employee.allCombinaisons[i]))
            {
                isValid = dailyRules[(int)porteList[i].enumRule].validFunction(porteList[i].rule, employee);
                foundDoor = true;
                break;
            }
        }

        if (!foundDoor)
        {
            isValid = false; //Le joueur à tapé un mauvais mdp
        }

        if (isValid)
        {
            //La porte bonne porte
        }
        else
        {
            //La mauvaise
        }
    }
}
