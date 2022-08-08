using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamDisable : MonoBehaviour
{

    PhotonView view;
    public GameObject cam;

    //�}�l�ɦp�G�O���a�n���}��v��
    private void Awake()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            cam.SetActive(true);
            Debug.Log("Open");
        }
    }
}
