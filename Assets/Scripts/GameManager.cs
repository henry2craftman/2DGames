using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 배달이 완료되면 다음 스테이지로 넘어간다.
// 모든 배달이 완료되지 않고, Timer의 시간이 0이하가 되면 게임이 종료된다.
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    Timer timer;
    public int score;
    int stage;
    [SerializeField] GameObject[] customers;
    [SerializeField] GameObject[] stages;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        if (timer == null)
            return;
    }

    // 모든 배달이 완료되지 않고, Timer의 시간이 0이하가 되면 게임이 종료된다.
    public void CheckEndGame()
    {
        if(customers.Length != score && timer.isUpdated)
        {
            Debug.Log("End Game");
            timer.isUpdated = false;
        }
    }

    // 모든 배달이 완료되면 다음 스테이지로 넘어간다.
    public void CheckNextStage()
    {
        Debug.Log("Next Stage");

        if (customers.Length == score)
        {
            GoNextStage();
        }
    }

    private void GoNextStage()
    {
        score = 0;

        stages[stage].SetActive(false);

        stage++;

        stages[stage].SetActive(true);
    }
}
