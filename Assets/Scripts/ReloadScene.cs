using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public static ReloadScene instance;
    private RulesScriptable rulesScriptable;
    public bool needToUpgradeDifficulty = false;

    private void Awake()
    {
        if (instance != null) 
        {
            Destroy(this);
            Destroy(this.gameObject);
        }

        instance = this;
    }

    public void Start()
    {
        if (needToUpgradeDifficulty)
        {
            UpgradeDifficulty();
        }

        rulesScriptable = GameObject.Find("RulesManager").GetComponent<RulesScriptable>();
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        Destroy(ScoreManager.instance.gameObject);
        SceneManager.LoadScene(0);
    }

    public void UpgradeDifficulty()
    {
        rulesScriptable.rulesCount += 3;
        rulesScriptable.spawnedEmployeeCount += 5;
        rulesScriptable.spawnTimer -= 1f;
    }
}
