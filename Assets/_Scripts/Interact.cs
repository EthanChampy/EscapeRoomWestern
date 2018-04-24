using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Interact : MonoBehaviour
{
    GameObject Player;

    bool FirstKey = false;

    private GameObject RaycastedObj;

    private int Morse = 0;
    GameObject ClockDoor;

    private bool SafeKey = true;
    GameObject SafeDoor;

    public int GunPuzzle = 0;
    GameObject EscapeDoor;
    GameObject ExpBarrel;
    GameObject ExpD1;
    GameObject ExpD2;

    public Button PianoA;
    public Button PianoB;
    public Button PianoC;
    public Button PianoD;
    public Button PianoE;
    public Button PianoF;
    public Button PianoG;

    public Text PQ;
    public Text PW;
    public Text PE;
    public Text PR;
    public Text PT;
    public Text PY;
    public Text PU;

    public Image BottleClueImg;
    bool BottleClueAct = false;

    public Image ExpClueImg;
    bool ClueExpAct = false;


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

            if (hit.collider.CompareTag("Gun"))
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

                if (Input.GetKeyDown("e") && GunPuzzle == 2 && RaycastedObj.transform.position == new Vector3(-2.616f, 4.85f, -24f))
                {
                    EscapeDoor = GameObject.Find("ExpDoor");
                    Destroy(EscapeDoor, 0f);
                    ExpBarrel = GameObject.Find("ExpBarrel");
                    Destroy(ExpBarrel, 0f);
                    ExpD1 = GameObject.Find("ExpD1");
                    Destroy(ExpD1, 0f);
                    ExpD2 = GameObject.Find("ExpD2");
                    Destroy(ExpD2, 0f);
                    print("Winner");
                }

                if (Input.GetKeyDown("e") && RaycastedObj.transform.position != new Vector3(-2, 5.35f, -23.8f))
                {
                    RaycastedObj.transform.position = new Vector3(-2.616f, 4.85f, -24f);
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
                    PQ.gameObject.SetActive(true);
                    PW.gameObject.SetActive(true);
                    PE.gameObject.SetActive(true);
                    PR.gameObject.SetActive(true);
                    PT.gameObject.SetActive(true);
                    PY.gameObject.SetActive(true);
                    PU.gameObject.SetActive(true);
                }
            }

            if (hit.collider.CompareTag("BrokenBottle"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    BottleClueAct = true;
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    BottleClueImg.gameObject.SetActive(true);
                }
            }

            if (BottleClueAct == true)
            {
                if (Input.GetKeyDown("p"))
                {
                    Player.GetComponent<FirstPersonController>().enabled = true;
                    BottleClueImg.gameObject.SetActive(false);
                }
            }

            if (hit.collider.CompareTag("ClueExp"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    ClueExpAct = true;
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    ExpClueImg.gameObject.SetActive(true);
                }
            }

            if (ClueExpAct == true)
            {
                if (Input.GetKeyDown("p"))
                {
                    Player.GetComponent<FirstPersonController>().enabled = true;
                    ExpClueImg.gameObject.SetActive(false);
                }
            }

            if (hit.collider.CompareTag("FirstDoor"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {

                    if (FirstKey == true)
                    {
                        RaycastedObj.transform.eulerAngles = new Vector3(-90, 0, -30);
                        print("Door Open!");
                    }
                    else
                    {

                    }
                }
            }

            if (hit.collider.CompareTag("FirstKey"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    FirstKey = true;
                    print("Key Get!");
                }
            }

        }

        if (Morse == 10)
        {
            ClockDoor = GameObject.Find("ClockDoor");
            ClockDoor.transform.eulerAngles = new Vector3(0, 300, 0);
        }
    }



    public void PianoEscape()
    {
        Player.GetComponent<FirstPersonController>().enabled = true;
        PianoA.gameObject.SetActive(false);
        PianoB.gameObject.SetActive(false);
        PianoC.gameObject.SetActive(false);
        PianoD.gameObject.SetActive(false);
        PianoE.gameObject.SetActive(false);
        PianoF.gameObject.SetActive(false);
        PianoG.gameObject.SetActive(false);
        PQ.gameObject.SetActive(false);
        PW.gameObject.SetActive(false);
        PE.gameObject.SetActive(false);
        PR.gameObject.SetActive(false);
        PT.gameObject.SetActive(false);
        PY.gameObject.SetActive(false);
        PU.gameObject.SetActive(false);
    }
}

