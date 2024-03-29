using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputSymbol {
    PictoA,
    PictoB,
    PictoC,
    PictoD,
    PictoE,
    PictoF,
    PictoG,
    PictoH,
    PictoI,
    PictoJ,
    PictoK,
    PictoL,
    PictoM,
    PictoN,
    PictoO,
    PictoP,
    PictoQ,
    PictoR,
    PictoS,
    PictoT,
    PictoU,
    PictoV,
    PictoW,
    PictoX,
    PictoY,
    PictoZ
}

[Serializable]
public class InputMapping {
    public InputSymbol symbol;
    public KeyCode keyCode;
}


public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] public List<Sprite> pictoSprites = new List<Sprite>();
    [SerializeField] public InputMapping[] _mappings;
    private List<InputSymbol> _symbolsTyped = new List<InputSymbol>();
    public RulesScriptable rulesScriptable;

    private void Update()
    {
        foreach(InputMapping mapping in _mappings)
        {
            if(Input.GetKeyDown(mapping.keyCode))
            {
                _symbolsTyped.Add(mapping.symbol);
                if (PlayerInputPanel.Instance != null)
                {
                    PlayerInputPanel.Instance.AddImageToPanel(pictoSprites[(int)mapping.symbol], _symbolsTyped.Count - 1);
                }
                Debug.Log("Symbole tap� = " + mapping.symbol);

                if(_symbolsTyped.Count > 5)
                {
                    GoToDoor();
                    _symbolsTyped.Clear();
                    PlayerInputPanel.Instance.ClearPanel(); 
                    // Appeler ici la fonction qui v�rifie si les symboles sont bons dans les rules
                }   
            }
        }
    }


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

    public void GoToDoor()
    {
        rulesScriptable.CheckChoosenDoor(_symbolsTyped);
    }

}
