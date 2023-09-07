using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatronGauge : MonoBehaviour
{
    public static PatronGauge Instance;
    public Image gauge;

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
    }

    public void BossSatisfiedGaugeImpact()
    {
        gauge.fillAmount -= 0.05f;
    }

}
