using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;

    public IEnumerator Start()
    {
        textScore.text = "Score actuel :  " + ScoreManager.instance.currentScore;
        yield return new WaitForSeconds(3f);
        ReloadScene.instance.needToUpgradeDifficulty = true;
        ReloadScene.instance.LoadGameScene();

    }

}
