using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Interact : MonoBehaviour
{
    GameObject Player;

    private GameObject RaycastedObj;

    private int Morse = 0;
    GameObject ClockDoor;

    private bool SafeKey = true;
    GameObject SafeDoor;

    private int GunPuzzle = 0;
    GameObject EscapeDoor;
    GameObject ExpBarrel;

    public Button PianoA;
    public Button PianoB;
    public Button PianoC;
    public Button PianoD;
    public Button PianoE;
    public Button PianoF;
    public Button PianoG;

    [SerializeField] private int raycastLength = 10;
    [SerializeField] private LayerMask LayerMaskInteract;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
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

            if (hit.collider.CompareTag("Piano"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    PianoA.gameObject.SetActive(true);
                    PianoB.gameObject.SetActive(true);
                    PianoC.gameObject.SetActive(true);
                    PianoD.gameObject.SetActive(true);
                    PianoE.gameObject.SetActive(true);
                    PianoF.gameObject.SetActive(true);
                    PianoG.gameObject.SetActive(true);
                    Cursor.visible = true;
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
