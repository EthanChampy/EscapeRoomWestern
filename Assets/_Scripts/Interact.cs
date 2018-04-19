using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    private GameObject RaycastedObj;

    private int Morse = 0;
    GameObject ClockDoor;

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
        }

        if (Morse == 10)
        {
            ClockDoor = GameObject.Find("ClockDoor");
            ClockDoor.transform.position = new Vector3(0, 0, 0);
        }
	}
}
