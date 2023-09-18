using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPizza;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("이크~");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pizza")
        {
            print("피자 획득~");
            hasPizza = true;
        }

        if(collision.tag == "Customer" && hasPizza == true)
        {
            print("배달이 완료되었습니다!");
            hasPizza = false;
        }
    }

}
