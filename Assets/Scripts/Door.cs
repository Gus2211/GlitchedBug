using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    public AudioSource porta;
    public AudioSource plate;
    

    public float maximumOpening = 9f;
    public float maximumClosing = 0f;
    public float movespeed  = 5f;

    bool pressure = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Player")
        {
            pressure=true; 
            plate.Play();   
        }       
    }

    void OnTriggerExit(Collider col)
    {
        pressure=false;
    }

    void Update()
    {
        if (pressure == true)
        {
            if (door.transform.position.y < maximumOpening)
            {
                
                door.transform.Translate(0f, movespeed * Time.deltaTime, 0f);
                if (porta.isPlaying == false)
                {
                    porta.Play();
                }
            }
        }
        else
        {
            if (Pause.isPaused)
            {
                return;
            }

            if (door.transform.position.y > maximumClosing)
            {
                door.transform.Translate(0f, -movespeed * Time.deltaTime, 0f);
                if (porta.isPlaying == false)
                {
                    porta.Play();
                }
            }
        }
    }
}