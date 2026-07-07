using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup1 : MonoBehaviourPunCallbacks
{

    [SerializeField]
    GameObject FPSCameraL;

    [SerializeField]
    GameObject FPSCameraR;

    // Start is called before the first frame update
    void Start()
    {

        if (photonView.IsMine)
        {

            transform.GetComponent<MovementController>().enabled = true;
            FPSCameraL.GetComponent<Camera>().enabled = true;
            FPSCameraR.GetComponent<Camera>().enabled = true;

        }
        else
        {
            transform.GetComponent<MovementController>().enabled = false;
            FPSCameraL.GetComponent<Camera>().enabled = false;
            FPSCameraR.GetComponent<Camera>().enabled = false;
        }

    }
}