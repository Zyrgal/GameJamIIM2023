using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiveScoreText : MonoBehaviour
{
    void Start()
    {
        ScoreManager.instance.SetScoretext(this.GetComponent<TextMeshProUGUI>());
    }
}
