using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� ����� �Ϸ�Ǹ� ���� ���������� �Ѿ��.
// ��� ����� �Ϸ���� �ʰ�, Timer�� �ð��� 0���ϰ� �Ǹ� ������ ����ȴ�.
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

    // ��� ����� �Ϸ���� �ʰ�, Timer�� �ð��� 0���ϰ� �Ǹ� ������ ����ȴ�.
    public void CheckEndGame()
    {
        if(customers.Length != score && timer.isUpdated)
        {
            Debug.Log("End Game");
            timer.isUpdated = false;
        }
    }

    // ��� ����� �Ϸ�Ǹ� ���� ���������� �Ѿ��.
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
