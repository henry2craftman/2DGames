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
        finalScoreText.text = "�����մϴ�!\n" + scoreManager.CalculateScore() + "���� ȹ���ϼ̽��ϴ�!";
    }
}
