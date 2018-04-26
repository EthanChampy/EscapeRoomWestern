using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {

    private bool Pa = false;
    private bool Pb = false;
    private bool Pd = false;
    private bool Pe = false;
    private bool Pg = false;

    public AudioClip A;
    public AudioClip B;
    public AudioClip C;
    public AudioClip D;
    public AudioClip E;
    public AudioClip F;
    public AudioClip G;

    AudioSource ThisAudioSource;

    GameObject PlayerCam;

    void Start()
    {
        ThisAudioSource = this.gameObject.GetComponent<AudioSource>();
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update ()
    {
        if (PlayerCam.GetComponent<Interact>().PianoPlay == true)
        {
            if (Input.GetKeyDown("w"))
            {
                Pb = true;
                ThisAudioSource.PlayOneShot(B);
            }

            if (Input.GetKeyDown("q"))
            {
                if (Pb == true)
                {
                    Pa = true;
                    ThisAudioSource.PlayOneShot(A, 1);
                }
                else
                {
                    Pa = false;
                    Pb = false;
                    Pd = false;
                    Pe = false;
                    Pg = false;
                    ThisAudioSource.PlayOneShot(A);
                }
            }

            if (Input.GetKeyDown("r"))
            {
                if (Pb == true && Pa == true)
                {
                    Pd = true;
                    ThisAudioSource.PlayOneShot(D);
                }

                else
                {
                    Pa = false;
                    Pb = false;
                    Pd = false;
                    Pe = false;
                    Pg = false;
                    ThisAudioSource.PlayOneShot(D);
                }
            }

            if (Input.GetKeyDown("u"))
            {
                if (Pb == true && Pa == true && Pd == true)
                {
                    Pg = true;
                    ThisAudioSource.PlayOneShot(G);
                }

                else
                {
                    Pa = false;
                    Pb = false;
                    Pd = false;
                    Pe = false;
                    Pg = false;
                    ThisAudioSource.PlayOneShot(G);
                }
            }

            if (Input.GetKeyDown("t"))
            {
                if (Pb == true && Pa == true && Pd == true && Pg == true)
                {
                    Pe = true;
                    PlayerCam.GetComponent<Interact>().Tooltip.text = "You find a bullet in the piano.";
                    PlayerCam.GetComponent<Interact>().GunPuzzle += 1;
                    ThisAudioSource.PlayOneShot(E);
                    PlayerCam.GetComponent<Interact>().Invoke("PianoEscape", 0f);
                }

                else
                {
                    Pa = false;
                    Pb = false;
                    Pd = false;
                    Pe = false;
                    Pg = false;
                    ThisAudioSource.PlayOneShot(E);
                }
            }

            if (Input.GetKeyDown("e"))
            {
                ThisAudioSource.PlayOneShot(C);
                Pa = false;
                Pb = false;
                Pd = false;
                Pe = false;
                Pg = false;
            }

            if (Input.GetKeyDown("y"))
            {
                ThisAudioSource.PlayOneShot(F);
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


