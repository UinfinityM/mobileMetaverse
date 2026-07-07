using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;


public class GameSceneManager : MonoBehaviourPunCallbacks
{
    public GameObject player;


    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {

            Vector3 spawnPoint = new Vector3(Random.Range(3.9f, 5.9f), 0f, Random.Range(-2.1f, 2.1f));
            GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint, Quaternion.identity);

            PhotonView playerPhotonView = _player.GetComponent<PhotonView>();

            // Oyuncu prefab'ýnda PlayerNameController kontrolü yap
            PlayerNameController nameController = _player.GetComponent<PlayerNameController>();

            // PhotonView sahibiyse kullanýcý adýný ayarla ve RPC çaðýr
            if (playerPhotonView.IsMine && nameController != null)
            {
                playerPhotonView.RPC("UpdatePlayerName", RpcTarget.OthersBuffered, PhotonNetwork.NickName);
            }

        }
    }


}
