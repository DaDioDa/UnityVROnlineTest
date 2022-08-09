using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisable : MonoBehaviour
{

    PhotonView view;
    public GameObject cam;
    public GameObject Crosshair;

    //�}�l�ɦp�G�O���a�n���}��v��
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
