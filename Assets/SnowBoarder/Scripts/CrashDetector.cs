using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 3f;
    [SerializeField] ParticleSystem dustParticle;
    [SerializeField] ParticleSystem crashParticle;
    public bool isGround;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Capsule Collider 2D
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            dustParticle.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            dustParticle.Stop();
        }
    }

    // Circle Collider 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            print("≤–~~~");
            audioSource.Play();
            crashParticle.Play();
            Invoke("ReloadScene", loadDelay);
        }
    }
    void ReloadScene()
    {
        print("∞‘¿” ¡æ∑·~!!");

        SceneManager.LoadScene(0);
    }
}
