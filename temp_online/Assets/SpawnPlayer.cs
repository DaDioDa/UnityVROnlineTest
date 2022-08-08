using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject SpawnPoint;

    private void Start()
    {
        PhotonNetwork.Instantiate("Player Variant",SpawnPoint.transform.position,Quaternion.identity);
    }
}

