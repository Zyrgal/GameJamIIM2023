using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lose : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;

    IEnumerator Start()
    {
        textScore.text = "Votre score :  " + ScoreManager.instance.currentScore;
        yield return new WaitForSeconds(3f);
        ReloadScene.instance.GoToMainMenu();
    }

}
