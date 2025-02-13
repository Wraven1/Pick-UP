using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class Dvish : MonoBehaviour
{
    Rigidbody rb;
    public bool isGrounded;
    public bool brosil;
    public Transform hand;
    private bool isChildOfHand = false;

    void Update()
    {
        // Проверяем, является ли этот объект дочерним объектом Hand
        if (transform.parent == hand)
        {
            if (!isChildOfHand)
            {
                isChildOfHand = true;
                GetComponent<BoxCollider>().enabled = false;
                isGrounded = false;
            }
        }
        else
        {
            if (isChildOfHand)
            {
                isChildOfHand = false;
                GetComponent<BoxCollider>().enabled = true;
                isGrounded = true;
            }
        } 
    }

        
        public void Dvigat()
        {
            if (isGrounded == false)
            {

                GetComponent<BoxCollider>().enabled = true;
                rb = GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 100f);
            }
        }
}
