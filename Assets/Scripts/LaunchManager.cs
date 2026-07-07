using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject player;

    [Space]
    public Transform spawnPoint;


    void Start()
    {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings(); //to connect server
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

        PhotonNetwork.JoinOrCreateRoom("firstRoom", null, null);
     
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("We are connected and in a room now.");

        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        //_player.GetComponent<PlayerSetup>().IsLocalPlayer();
    } 


}
