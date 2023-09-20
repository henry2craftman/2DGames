using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 3f;
    [SerializeField] ParticleSystem finishParticle;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            finishParticle.Play();
            audioSource.Play();

            FindFirstObjectByType<PlayerController>().DisableControls();

            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        print("게임 종료~!!");
        SceneManager.LoadScene(0);
    }
}
