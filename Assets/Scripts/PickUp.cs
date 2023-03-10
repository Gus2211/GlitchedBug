using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public AudioSource cuboP;
    public AudioSource cuboD;


    public float pickUpRange = 5f;
    public float moveForce = 250f;

    public Transform holdParent;
    private GameObject heldObj;

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Pause.isPaused)
                {
                    return;
                }
                
                if (heldObj == null)
                {                   
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                    {
                        cuboP.Play();
                        PickupObject(hit.transform.gameObject);
                    }
                }
                else
                {
                    DropObject();
                }
            }

            if (heldObj != null)
            {
                MoveObject();
            }
    }


    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }


    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    public void DropObject()
    {
        cuboD.Play();
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
