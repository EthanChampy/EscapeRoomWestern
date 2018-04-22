using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {

    private bool Pa = false;
    private bool Pb = false;
    private bool Pd = false;
    private bool Pe = false;
    private bool Pg = false;

	void Start () {
		
	}
	

	void Update () {
		
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


