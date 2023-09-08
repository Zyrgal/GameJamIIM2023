using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        ReloadScene.instance.GoToMainMenu();
    }

}
