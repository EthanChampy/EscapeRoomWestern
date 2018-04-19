using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    private GameObject RaycastedObj;

    private int Morse = 0;
    GameObject ClockDoor;

    private bool SafeKey = true;
    GameObject SafeDoor;

    [SerializeField] private int raycastLength = 10;
    [SerializeField] private LayerMask LayerMaskInteract;

   void Update ()
    {
        RaycastHit hit;
        Vector3 Forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, Forward, out hit, raycastLength, LayerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Object"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    RaycastedObj.SetActive(false);
                }
            }

            if (hit.collider.CompareTag("Morse"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    Morse += 1;
                    print("Click");
                }
            }

            if (hit.collider.CompareTag("SafeDoor"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e") && SafeKey == true)
                {
                    SafeDoor = GameObject.Find("SafeDoor");
                    SafeDoor.transform.eulerAngles = new Vector3(-90, 0, -17);
                }
            }
        }

        if (Morse == 10)
        {
            ClockDoor = GameObject.Find("ClockDoor");
            ClockDoor.transform.eulerAngles = new Vector3(0, 300, 0);
        }
	}
}
