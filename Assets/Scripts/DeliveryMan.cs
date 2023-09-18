using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryMan : MonoBehaviour
{ 
    [SerializeField] float steerSpeed = 0.1f; // �Ҽ��� 6�ڸ� ���� ǥ��
    [SerializeField] float moveSpeed = 0.1f;
    // double: �Ҽ��� 15�ڸ� 

    // Update is called once per frame
    void Update()
    {
        //           PC1                    PC2
        // Fps:      10fps                  100fps
        // Duration: 0.1s                   0.01s
        // Distance: 1 * 10 * 0.1s = 1      1 * 100 * 0.01 = 1
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
