using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pik_UP : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject currentObject;
    bool canPickUP;
    public GameObject knopka;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) PickUP();
        if (canPickUP == true)
        {
            knopka.SetActive(true);
        }
        else
        {
            knopka.SetActive(false);
        }
        
    }

    void PickUP()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Object")
            {
                if (canPickUP) Drop();

                currentObject = hit.transform.gameObject;
                currentObject.GetComponent<Rigidbody>().isKinematic = true;
                currentObject.transform.parent = transform;
                currentObject.transform.localPosition = Vector3.zero;
                currentObject.transform.localEulerAngles = new Vector3(10f, 0, 0);
                canPickUP = true;
            }
        }
    }

    public void Drop()
    {
        currentObject.transform.parent = null;
        currentObject.GetComponent<Rigidbody>().isKinematic = false;
        canPickUP = false;
        currentObject = null;
    }
}
