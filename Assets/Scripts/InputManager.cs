using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputSymbol {
    Diminuer,
    Augmenter,
    Inactif,
    Actif,
    Refuser,
    Accepter,
    Question,
    Surprise,
    Stop,
    Recommencer,
    Boucler,
    Batiment,
    Outils,
    Argent,
    Mecanisme,
    Temps,
    Danger,
    Aimer,
    Deplacement,
    Pointer,
    Parler,
    Toucher,
    Musique,
    Voir
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
    [SerializeField] private InputMapping[] _mappings;
    private List<InputSymbol> _symbolsTyped = new List<InputSymbol>();
    public RulesScriptable rulesScriptable;

    private void Update()
    {
        foreach(InputMapping mapping in _mappings)
        {
            if(Input.GetKeyDown(mapping.keyCode))
            {
                _symbolsTyped.Add(mapping.symbol);
                Debug.Log("Symbole tapé = " + mapping.symbol);

                if(_symbolsTyped.Count > 1)
                {
                    GoToDoor();
                    // Appeler ici la fonction qui vérifie si les symboles sont bons dans les rules
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
