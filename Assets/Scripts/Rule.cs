using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void InitDelegate(Rule rule);
public delegate void InitEmployeeDelegate(Rule rule, EmployeeData employeeData);
public delegate bool ValidateDelegate(Rule rule, EmployeeData employeeData);
//public delegate void TestDelegate();
public class RuleFunc
{
    public EnumRule enumRules;
    public InitDelegate initFunction;
    public ValidateDelegate validFunction;
    public InitEmployeeDelegate initEmployee;

    public RuleFunc(EnumRule enumRules, InitDelegate initFunction, ValidateDelegate validFunction, InitEmployeeDelegate initEmployee)
    {
        this.enumRules = enumRules;
        this.initFunction = initFunction;
        this.validFunction = validFunction;
        this.initEmployee = initEmployee;
    }
    //public TestDelegate testBadRules;
}

[Serializable]
public class Rule
{
    public string letter;
    public string word;
    public string entrepriseName;
    public string employeeClothing;
    public string employeeAccesory;

    /*public LetterToSeach letter;
    public WordToSeach word;
    public EntrepriseName entrepriseName;
    public EmployeeClothing employeeClothing;
    public EmployeeAccesory employeeAccesory;*/

    public override string ToString()
    {
        return $"{letter.ToString()} - {word.ToString()}";
    }
}
