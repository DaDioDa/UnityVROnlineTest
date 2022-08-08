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

    //開房間按鈕
    public void CreateButton()
    {
        PhotonNetwork.CreateRoom("9527");
    }

    //開房間後執行
    public override void OnCreatedRoom()
    {
        StartGame();
    }

    //加入房間按鈕
    public void JoinButton()
    {
        PhotonNetwork.JoinRoom("9527");
    }

    //加入房間後執行
    public override void OnJoinedRoom()
    {
       // StartGame();
    }

    //換場景
    public void StartGame()
    {
        PhotonNetwork.LoadLevel("gameScene");
    }
}
