using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuizKing
{
    public class GameManager : MonoBehaviour
    {
        Quiz quiz;
        EndScreen endScreen;

        private void Start()
        {
            quiz = FindObjectOfType<Quiz>();
            endScreen = FindObjectOfType<EndScreen>();

            quiz.gameObject.SetActive(true);
            endScreen.gameObject.SetActive(false);
        }

        void Update()
        {
            if(quiz.isComplete)
            {
                endScreen.gameObject.SetActive(true);
                endScreen.ShowFinalScore();
                quiz.gameObject.SetActive(false);
            }
        }

        public void OnReplayClickedEvent()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
