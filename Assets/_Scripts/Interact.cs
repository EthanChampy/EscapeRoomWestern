using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    private GameObject RaycastedObj;

    private int Morse = 0;
    GameObject ClockDoor;

    private bool SafeKey = true;
    GameObject SafeDoor;

    private int GunPuzzle = 0;
    GameObject EscapeDoor;
    GameObject ExpBarrel;

    [SerializeField] private int raycastLength = 10;
    [SerializeField] private LayerMask LayerMaskInteract;

    void Update()
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

            if (hit.collider.CompareTag("Gun") || hit.collider.CompareTag("Bullet"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    GunPuzzle += 1;
                    Destroy(RaycastedObj, 0f);
                    print(GunPuzzle);
                }
            }

            if (hit.collider.CompareTag("Barrel"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e") && GunPuzzle == 2 && RaycastedObj.transform.position == new Vector3(-2, 5.35f, -23.8f))
                {
                    EscapeDoor = GameObject.Find("ExpDoor");
                    Destroy(EscapeDoor, 0f);
                    ExpBarrel = GameObject.Find("ExpBarrel");
                    Destroy(ExpBarrel, 0f);
                    print("Winner");
                }

                if (Input.GetKeyDown("e") && RaycastedObj.transform.position != new Vector3(-2, 5.35f, -23.8f))
                {
                    RaycastedObj.transform.position = new Vector3(-2, 5.35f, -23.8f);
                    print(GunPuzzle);
                }
            }


            if (Morse == 10)
            {
                ClockDoor = GameObject.Find("ClockDoor");
                ClockDoor.transform.eulerAngles = new Vector3(0, 300, 0);
            }
        }

    }
}
