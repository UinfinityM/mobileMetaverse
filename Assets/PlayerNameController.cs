using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerNameController : MonoBehaviour
{
    public TMP_Text usernameText;

    public void SetUsername(string username)
    {
        usernameText.text = username;
    }

    [PunRPC]
    public void UpdatePlayerName(string newName)
    {
        SetUsername(newName);
    }
}
