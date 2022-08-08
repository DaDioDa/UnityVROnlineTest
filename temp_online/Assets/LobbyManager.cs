using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Canvas.SetActive(true);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    //�}�ж����s
    public void CreateButton()
    {
        PhotonNetwork.CreateRoom("9527");
    }

    //�}�ж������
    public override void OnCreatedRoom()
    {
        StartGame();
    }

    //�[�J�ж����s
    public void JoinButton()
    {
        PhotonNetwork.JoinRoom("9527");
    }

    //�[�J�ж������
    public override void OnJoinedRoom()
    {
       // StartGame();
    }

    //������
    public void StartGame()
    {
        PhotonNetwork.LoadLevel("gameScene");
    }
}
