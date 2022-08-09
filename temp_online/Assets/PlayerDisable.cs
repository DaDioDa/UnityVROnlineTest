using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisable : MonoBehaviour
{

    PhotonView view;
    public GameObject cam;
    public GameObject Crosshair;

    //開始時如果是本地要打開攝影機
    private void Awake()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            cam.SetActive(true);
            Crosshair.SetActive(true);
            Debug.Log("Open");
        }
    }
}
