using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTimer : MonoBehaviour
{
    [SerializeField] float finishTime = 15;
    [SerializeField] float checkingTime = 5;
    float timerValue;
    public bool isAnswering;
    public float fillAmount;
    public bool isNextQuestion;

    void Update()
    {
        timerValue -= Time.deltaTime;

        if(isAnswering)
        {
            if(timerValue > 0)
            {
                fillAmount = timerValue / finishTime; // 5 / 10 -> 0.5
            }
            else if(timerValue <= 0)
            {
                isAnswering = false;
                timerValue = checkingTime;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                fillAmount = timerValue / checkingTime; // 5 / 10 -> 0.5
            }
            else if (timerValue <= 0)
            {
                isAnswering = true;
                timerValue = finishTime;
                isNextQuestion = true;
            }
        }

        Debug.Log(isAnswering + ": " + timerValue + " = " + fillAmount);
    }

    public void ResetTimer()
    {
        timerValue = 0;
    }
}
