using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatronGauge : MonoBehaviour
{
    public static PatronGauge Instance;
    public Image gauge;
    [SerializeField] GameObject losePanel;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void BossAngriedGaugeImpact()
    {
        gauge.fillAmount += 0.1f;
        CheckIfLoose();
    }

    public void BossSatisfiedGaugeImpact()
    {
        gauge.fillAmount -= 0.05f;
    }

    public void CheckIfLoose()
    {
        if (gauge.fillAmount >= 1)
        {
            losePanel.SetActive(true);
        }
    }

}
