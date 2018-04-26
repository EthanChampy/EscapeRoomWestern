using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeBrail : MonoBehaviour {

    private bool B4 = false;
    private bool B6 = false;
    private bool B9 = false;

    public Image B4T;
    public Image B6T;
    public Image B9T;

    GameObject PlayerCam;
    GameObject SafeDoor;

    void Start()
    {
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
        SafeDoor = GameObject.Find("SafeDoor");
    }


    void Update ()
    {
        if (Input.GetKeyDown("4"))
        {
            if (B4 == false)
            {
                B4 = true;
                B4T.gameObject.SetActive(true);
            }
            else
            {
                B4 = false;
                B6 = false;
                B9 = false;

                B4T.gameObject.SetActive(false);
                B6T.gameObject.SetActive(false);
                B9T.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown("6"))
        {
            if (B4 == true && B6 == false)
            {
                B6 = true;
                B6T.gameObject.SetActive(true);
            }
            else
            {
                B4 = false;
                B6 = false;
                B9 = false;

                B4T.gameObject.SetActive(false);
                B6T.gameObject.SetActive(false);
                B9T.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown("9"))
        {
            if (B4 == true && B6 == true)
            {
                B9 = true;
                B9T.gameObject.SetActive(true);
                SafeDoor.transform.eulerAngles = new Vector3(-90, 0, -17);
                PlayerCam.GetComponent<Interact>().Tooltip.text = "The safe opens.";
                PlayerCam.GetComponent<Interact>().Invoke("BrailEscape", 0f);
            }

            else
            {
                B4 = false;
                B6 = false;
                B9 = false;

                B4T.gameObject.SetActive(false);
                B6T.gameObject.SetActive(false);
                B9T.gameObject.SetActive(false);
            }
        }

        if (Input.GetKey("1") || Input.GetKey("2") || Input.GetKey("3") || Input.GetKey("5") || Input.GetKey("7") || Input.GetKey("8") || Input.GetKey("0"))
        {
            B4 = false;
            B6 = false;
            B9 = false;

            B4T.gameObject.SetActive(false);
            B6T.gameObject.SetActive(false);
            B9T.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown("p"))
        {
            PlayerCam.GetComponent<Interact>().Invoke("BrailEscape", 0f);
        }

    }
}
