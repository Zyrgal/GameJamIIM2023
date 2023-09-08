using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        foreach (InputMapping mapping in InputManager.Instance._mappings)
        {
            if (Input.GetKeyDown(mapping.keyCode))
            {
                ReloadScene.instance.LoadGameScene();
            }  
        }   
    }
}
