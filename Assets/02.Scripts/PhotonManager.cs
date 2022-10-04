using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    // 04f2788e-b8a4-4cb2-b720-8a578d3509de
    // 포톤 서버에 접속할 때 사용할 게임 버전
    private readonly string gameVersion = "1.0";
    // 유저ID
    public string userId = "Zackiller";

    void Awake()
    {
        // 방장이 로딩한 씬을 자동으로 로딩시켜주는 옵션
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.NickName = userId;

        // 포톤서버에 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    // 포톤 서버에 접속완료되었을 때 호출되는 콜백함수(이벤트)
    public override void OnConnectedToMaster()
    {
        Debug.Log("포톤 서버에 접속");

        // 로비에 입장 요청
        PhotonNetwork.JoinLobby();
    }

    // 로비에 입장한 후 호출되는 콜백
    public override void OnJoinedLobby()
    {
        Debug.Log("로비에 입장 완료");

        // 무작위 룸에 입장 요청
        // PhotonNetwork.JoinRandomRoom();
    }

    // 랜덤 조인에 실패 했을 경우에 호출되는 콜백
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"code : {returnCode} , message : {message}");

        // 룸 생성
        PhotonNetwork.CreateRoom("My Room");
    }

    // 룸 생성이 완료된 후 호출되는 콜백
    public override void OnCreatedRoom()
    {
        string roomName = PhotonNetwork.CurrentRoom.Name;
        Debug.Log(roomName + " 생성 완료");
    }

    // 룸에 입장완료된 후에 호출되는 콜백
    public override void OnJoinedRoom()
    {
        Debug.Log("룸에 입장 완료");

        // 방장일 경우에만 베틀필드 씬을 로딩
        if (PhotonNetwork.IsMasterClient == true)
        {
            PhotonNetwork.LoadLevel("BattleField");
        }
        //UnityEngine.SceneManagement.SceneManager.LoadScene("BattleField");

        // 방 입장완료 후 탱크 생성
        // PhotonNetwork.Instantiate("Tank", new Vector3(0, 3.0f, 0), Quaternion.identity, 0);
    }

    public void OnLoginButtonClick()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}
