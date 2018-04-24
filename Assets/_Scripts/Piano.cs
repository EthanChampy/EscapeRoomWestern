using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {

    private bool Pa = false;
    private bool Pb = false;
    private bool Pd = false;
    private bool Pe = false;
    private bool Pg = false;

    GameObject PlayerCam;

    void Start()
    {
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update ()
    {
        if (Input.GetKey("w"))
        {
            Pb = true;
        }

        if (Input.GetKey("q"))
        {
            if (Pb == true)
            {
                Pa = true;
            }
            else
            {
                Pa = false;
                Pb = false;
                Pd = false;
                Pe = false;
                Pg = false;
            }
        }

        if (Input.GetKey("r"))
        {
            if (Pb == true && Pa == true)
            {
                Pd = true;
            }

            else
            {
                Pa = false;
                Pb = false;
                Pd = false;
                Pe = false;
                Pg = false;
            }
        }

        if (Input.GetKey("u"))
        {
            if (Pb == true && Pa == true && Pd == true)
            {
                Pg = true;
            }

            else
            {
                Pa = false;
                Pb = false;
                Pd = false;
                Pe = false;
                Pg = false;
            }
        }

        if (Input.GetKeyDown("t"))
        {
            if (Pb == true && Pa == true && Pd == true && Pg == true)
            {
                Pe = true;
                print("You Found A Bullet!");
                PlayerCam.GetComponent<Interact>().GunPuzzle += 1;
                PlayerCam.GetComponent<Interact>().Invoke("PianoEscape", 0f);
            }

            else
            {
                Pa = false;
                Pb = false;
                Pd = false;
                Pe = false;
                Pg = false;
            }
        }

        if (Input.GetKey("e") || Input.GetKey("y"))
        {
            Pa = false;
            Pb = false;
            Pd = false;
            Pe = false;
            Pg = false;
        }

        if (Input.GetKeyDown("p"))
        {
            PlayerCam.GetComponent<Interact>().Invoke("PianoEscape", 0f); 
        }
    }









    public void PressB()
    {
        Pb = true;
    }

    public void PressA()
    {
        if (Pb == true)
        {
            Pa = true;
        }

        else
        {
            Pa = false;
            Pb = false;
            Pd = false;
            Pe = false;
            Pg = false;
        }
    }

    public void PressD()
    {
        if (Pb == true && Pa == true)
        {
            Pd = true;
        }

        else
        {
            Pa = false;
            Pb = false;
            Pd = false;
            Pe = false;
            Pg = false;
        }
    }

    public void PressG()
    {
        if (Pb == true && Pa == true && Pd == true)
        {
            Pg = true;
        }

        else
        {
            Pa = false;
            Pb = false;
            Pd = false;
            Pe = false;
            Pg = false;
        }
    }

    public void PressE()
    {
        if (Pb == true && Pa == true && Pd == true && Pg == true)
        {
            Pe = true;
            print("Piano Puzzle Complete");
        }

        else
        {
            Pa = false;
            Pb = false;
            Pd = false;
            Pe = false;
            Pg = false;
        }
    }

    public void PressOther()
    {
        Pa = false;
        Pb = false;
        Pd = false;
        Pe = false;
        Pg = false;
    }
}


