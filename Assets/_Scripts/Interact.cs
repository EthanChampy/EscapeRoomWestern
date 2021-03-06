﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    GameObject Player;

    AudioSource PlayerAudio;

    public ParticleSystem Explosion;

    public AudioClip MorseDash;
    public AudioClip MorseDot;
    public AudioClip DoorOpen;
    public AudioClip Click;
    public AudioClip Explode;

    public Text Tooltip;

    public bool PianoPlay = false;
    public bool SafePlay = false;

    bool FirstKey = false;

    private GameObject RaycastedObj;

    private int Morse = 0;
    GameObject ClockDoor;

    bool FuseBool = false;

    GameObject SafeDoor;

    public int GunPuzzle = 0;
    GameObject EscapeDoor;
    GameObject ExpBarrel;
    GameObject ExpD1;
    GameObject ExpD2;
    GameObject Cardy;

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

    public Text SafeText;
    public Image B4F;
    public Image B6F;
    public Image B9F;
    public Image B4T;
    public Image B6T;
    public Image B9T;

    public Image BottleClueImg;
    bool BottleClueAct = false;

    public Image ExpClueImg;
    bool ClueExpAct = false;

    public Image BraiClueImg;
    bool BraiClueAct;

    public Image BraiGuideImg;
    bool BraiGuideAct;

    public Image Safeone;
    bool SafeClueAct;


    [SerializeField] private int raycastLength = 10;
    [SerializeField] private LayerMask LayerMaskInteract;

    void Start()
    {
        PlayerAudio = this.gameObject.GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Tooltip.text = "";
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
                    PlayerAudio.PlayOneShot((Click), 1);
                    RaycastedObj.SetActive(false);
                    Cardy = GameObject.Find("Cardy");
                    Destroy(Cardy, 0f);
                }
            }

            if (hit.collider.CompareTag("Morse"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PlayerAudio.PlayOneShot((MorseDash), 1);
                    Morse += 1;
                    Tooltip.text = "You click the Morse machine " + Morse + " times.";
                }
            }

            if (hit.collider.CompareTag("SafeDoor"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    SafePlay = true;
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    B4F.gameObject.SetActive(true);
                    B6F.gameObject.SetActive(true);
                    B9F.gameObject.SetActive(true);
                    SafeText.gameObject.SetActive(true);
                    Tooltip.text = "Press P to escape.";
                }
            }

            if (hit.collider.CompareTag("Fuse"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    FuseBool = true;
                    Tooltip.text = "You found a fuse.";
                    Destroy(RaycastedObj, 0f);
                }
            }

            if (hit.collider.CompareTag("Gun"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    GunPuzzle += 1;
                    Destroy(RaycastedObj, 0f);
                    Tooltip.text = "You found a gun.";
                }
            }

            if (hit.collider.CompareTag("Barrel"))
            {
                RaycastedObj = hit.collider.gameObject;


                if (Input.GetKeyDown("e") && GunPuzzle == 2 && RaycastedObj.transform.position == new Vector3(-2.616f, 4.85f, -24f))
                {
                    PlayerAudio.PlayOneShot((Explode), 1);
                    Explosion.gameObject.SetActive(true);
                    EscapeDoor = GameObject.Find("ExpDoor");
                    Destroy(EscapeDoor, 0f);
                    ExpBarrel = GameObject.Find("ExpBarrel");
                    Destroy(ExpBarrel, 0f);
                    ExpD1 = GameObject.Find("ExpD1");
                    Destroy(ExpD1, 0f);
                    ExpD2 = GameObject.Find("ExpD2");
                    Destroy(ExpD2, 0f);
                    Tooltip.text = "The TNT explodes.";
                }

                if (Input.GetKeyDown("e") && RaycastedObj.transform.position != new Vector3(-2, 5.35f, -23.8f) && FuseBool == true)
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    RaycastedObj.transform.position = new Vector3(-2.616f, 4.85f, -24f);
                    Tooltip.text = "You need to find a way to ignite this.";
                }

                if (Input.GetKeyDown("e") && RaycastedObj.transform.position != new Vector3(-2, 5.35f, -23.8f) && FuseBool == false)
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    Tooltip.text = "You need to find a fuse.";
                }
            }

            if (hit.collider.CompareTag("Piano"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PianoPlay = true;
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
                    Tooltip.text = "Press P to escape.";
                }
            }

            if (hit.collider.CompareTag("BrokenBottle"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    BottleClueAct = true;
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    BottleClueImg.gameObject.SetActive(true);
                    Tooltip.text = "Press P to escape.";
                }
            }

            if (BottleClueAct == true)
            {
                if (Input.GetKeyDown("p"))
                {
                    Player.GetComponent<FirstPersonController>().enabled = true;
                    BottleClueImg.gameObject.SetActive(false);
                    Tooltip.text = "";
                }
            }

            if (hit.collider.CompareTag("ClueExp"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    ClueExpAct = true;
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    ExpClueImg.gameObject.SetActive(true);
                    Tooltip.text = "Press P to escape.";
                }
            }

            if (ClueExpAct == true)
            {
                if (Input.GetKeyDown("p"))
                {
                    Player.GetComponent<FirstPersonController>().enabled = true;
                    ExpClueImg.gameObject.SetActive(false);
                    Tooltip.text = "";
                }
            }

            if (hit.collider.CompareTag("BraiClue"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    BraiClueAct = true;
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    BraiClueImg.gameObject.SetActive(true);
                    Tooltip.text = "Press P to escape.";
                }
            }

            if (BraiClueAct == true)
            {
                if (Input.GetKeyDown("p"))
                {
                    Player.GetComponent<FirstPersonController>().enabled = true;
                    BraiClueImg.gameObject.SetActive(false);
                    Tooltip.text = "";
                }
            }

            if (hit.collider.CompareTag("Brainting"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    BraiGuideAct = true;
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    BraiGuideImg.gameObject.SetActive(true);
                    Tooltip.text = "Press P to escape.";
                }
            }

            if (BraiGuideAct == true)
            {
                if (Input.GetKeyDown("p"))
                {
                    Player.GetComponent<FirstPersonController>().enabled = true;
                    BraiGuideImg.gameObject.SetActive(false);
                    Tooltip.text = "";
                }
            }

            if (hit.collider.CompareTag("SafeClue"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    PlayerAudio.PlayOneShot((Click), 1);
                    SafeClueAct = true;
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    Safeone.gameObject.SetActive(true);
                    Tooltip.text = "Press P to escape.";
                }
            }

            if (SafeClueAct == true)
            {
                if (Input.GetKeyDown("p"))
                {
                    Player.GetComponent<FirstPersonController>().enabled = true;
                    Safeone.gameObject.SetActive(false);
                    Tooltip.text = "";
                }
            }

            if (hit.collider.CompareTag("FirstDoor"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {

                    if (FirstKey == true)
                    {
                        PlayerAudio.PlayOneShot((Click), 1);
                        RaycastedObj.transform.eulerAngles = new Vector3(-90, 0, -30);
                        Tooltip.text = "You open the door.";
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
                    PlayerAudio.PlayOneShot((Click), 1);
                    FirstKey = true;
                    print("Key Get!");
                    Destroy(RaycastedObj, 0f);
                    Tooltip.text = "You pick up a key.";
                }
            }

            if (hit.collider.CompareTag("Escape"))
            {
                RaycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    SceneManager.LoadScene("WinScreen");
                }
            }
            

        }


        if (Morse == 10)
        {

            ClockDoor = GameObject.Find("ClockDoor");
            ClockDoor.transform.eulerAngles = new Vector3(0, 300, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Escape"))
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    public void PianoEscape()
    {
        PianoPlay = false;
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

    public void BrailEscape()
    {
        SafePlay = false;
        Player.GetComponent<FirstPersonController>().enabled = true;
        B4F.gameObject.SetActive(false);
        B6F.gameObject.SetActive(false);
        B9F.gameObject.SetActive(false);
        SafeText.gameObject.SetActive(false);
        B4T.gameObject.SetActive(false);
        B6T.gameObject.SetActive(false);
        B9T.gameObject.SetActive(false);
    }
}

