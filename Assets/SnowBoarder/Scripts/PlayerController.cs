using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    Rigidbody2D rb2D;
    [SerializeField] SurfaceEffector2D surfaceEffector;
    [SerializeField] float boostSpeed = 20;
    [SerializeField] float baseSpeed;
    [SerializeField] float jumpPower = 20;
    [SerializeField] ParticleSystem boostParticle;
    [SerializeField] ParticleSystem jumpParticle;
    private bool canMove = true;
    AudioSource audioSource;
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        baseSpeed = surfaceEffector.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();

            BoostPlayer();

            JumpPlayer();
        }
    }

    private void RotatePlayer()
    {
        // GetKey를 이용, KeyCode에서 Left, Right Arrow
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmount * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }

    void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector.speed = boostSpeed;
            boostParticle.Play();
        }
        else
        {
            surfaceEffector.speed = baseSpeed;
            boostParticle.Stop();
        }
    }

    // 스페이스바를 누르면 플레이어가 점프 파워만큼 점프한다.
    private void JumpPlayer()
    {
        if (GetComponent<CrashDetector>().isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Vector2 jumpDir = -transform.right * jumpPower;
                Vector2 jumpDir = Vector2.up * jumpPower;
                rb2D.AddForce(jumpDir);
                jumpParticle.Play();
            }
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
