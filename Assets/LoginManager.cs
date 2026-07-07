using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField usernameInputField; // UI InputField
    public Button continueButton;
    public GameObject firstPanel;
    public GameObject secondPanel;

    void Start()
    {       
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings(); //to connect server
        continueButton.interactable = false;
    }

    public void OnUsernameChanged()
    {
        continueButton.interactable = !string.IsNullOrEmpty(usernameInputField.text);
    }

    public override void OnConnectedToMaster() //will work when connected to server
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected to server.");

        PhotonNetwork.JoinLobby(); //to enter lobby
    }



    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        Debug.Log("We are in the lobby now.");

    }

    public void OnClickContinue()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // Kullanýcý adýný belirle
            PhotonNetwork.NickName = usernameInputField.text;
            firstPanel.SetActive(false);
            secondPanel.SetActive(true);           
        }
    }

    public void OnSelectedTeacher()
    {
        PhotonNetwork.JoinOrCreateRoom("firstRoom", null, null);

    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("We are connected and in a room now.");
     
        PhotonNetwork.LoadLevel("SampleScene");
    }


}
