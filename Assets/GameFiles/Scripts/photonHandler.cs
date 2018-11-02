using Photon;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class photonHandler : Photon.PunBehaviour {

    [SerializeField] private PlayerSpawner spawnScript;
    public ListController roomsList;
    public byte maxPlayers = 6;
    public ButtonListControl rooms;

    private void Awake()
    {
        PhotonNetwork.autoJoinLobby = true;
        DontDestroyOnLoad(this.transform);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        var temp = PhotonVoiceNetwork.Client;
        
    }

    public void LoadScene()
    {
        PhotonNetwork.LoadLevel("Environment");
    }

    public void CreateNewRoom(string text)
    {
        PhotonNetwork.CreateRoom(text, new RoomOptions { MaxPlayers = maxPlayers }, null);
      
    }

    public void JoinOrCreateRoom(string text)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        PhotonNetwork.JoinOrCreateRoom(text, roomOptions, null);
       
    }

    public override void OnReceivedRoomListUpdate()
    {
        rooms.rooms = PhotonNetwork.GetRoomList();
        rooms.UpdateList();
    }

    public override void OnJoinedRoom()
    {
        LoadScene();
        Debug.Log("We are connected to the room.");   
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Environment")
        {
            spawnScript.SpawnPlayer();
        }
       
    }


}
