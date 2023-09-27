using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int correctAnswer = 0;
    int questionCount = 0;

    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }

    public void IncrementCorrectAnswer()
    {
        correctAnswer++;
    }

    public int GetQuestionCount()
    {
        return questionCount;
    }

    public void IncrementQuetionCount()
    {
        questionCount++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctAnswer / (float)questionCount * 100); // 3 / 4 = 0.75 * 100 -> 75%
    }
}
