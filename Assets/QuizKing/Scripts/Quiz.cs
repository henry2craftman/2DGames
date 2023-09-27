using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions;
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    private int correctAnswerIndex;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite answerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    QuizTimer timer;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreManager scoreManager;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

    AudioSource audioSource;
    [SerializeField] List<AudioClip> audioClips;

    void Start()
    {
        timer = FindObjectOfType<QuizTimer>();
        scoreManager = FindObjectOfType<ScoreManager>();

        progressBar.maxValue = questions.Count;
        progressBar.value = 0;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillAmount;

        if(timer.isNextQuestion)
        {
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }

            timer.isNextQuestion = false;
            GetNextQuestion();
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    public void OnAnswerClickedEvent(int index)
    {
        Image buttonImage;

        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "정답입니다!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = answerSprite;
            scoreManager.IncrementCorrectAnswer();

            audioSource.clip = audioClips[0];
        }
        else
        {
            questionText.text = "땡! 틀렸습니다.";
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = answerSprite;

            audioSource.clip = audioClips[1];
        }

        SetButtonState(false);
        timer.ResetTimer();
        scoreText.text = "Score: " + scoreManager.CalculateScore() + "%";
        audioSource.Play();
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            SetButtonState(true);

            SetDefualtButtonSprites();

            GetRandomQuestion();

            DisplayQuestion();

            scoreManager.IncrementQuetionCount();

            progressBar.value++;
        }
    }

    void GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomIndex];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    private void SetDefualtButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image button = answerButtons[i].GetComponent<Image>();
            button.sprite = defaultSprite;
        }
    }
}
