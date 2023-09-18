using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPizza;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("��ũ~");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pizza")
        {
            print("���� ȹ��~");
            hasPizza = true;
        }

        if(collision.tag == "Customer" && hasPizza == true)
        {
            print("����� �Ϸ�Ǿ����ϴ�!");
            hasPizza = false;
        }
    }

}
