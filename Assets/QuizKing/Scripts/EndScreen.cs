using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = "√‡«œ«’¥œ¥Ÿ!\n" + scoreManager.CalculateScore() + "¡°¿ª »πµÊ«œºÃΩ¿¥œ¥Ÿ!";
    }
}
