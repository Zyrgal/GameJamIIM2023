using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputSymbol {
    Undefined = -1,
    Symbol1 = 0,
    Symbol2,
}

[Serializable]
public class InputMapping {
    public InputSymbol symbol;
    public KeyCode keyCode;
}


public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] private InputMapping[] _mappings;

    public bool GetKeyDown(InputSymbol symbol)
    {
        foreach(InputMapping mapping in _mappings)
        {
            if(mapping.symbol == symbol)
            {
                return Input.GetKeyDown(mapping.keyCode);
            }
        }

        return false;
    }
 
    private enum InputType
    {
        PC,
        Console
    }

    private void Awake()
    {
        Instance = this;
    }

}
