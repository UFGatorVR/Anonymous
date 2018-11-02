using Photon;
using UnityEngine.SceneManagement;
using UnityEngine;

public class photonHandler : Photon.PunBehaviour {

    [SerializeField] private PlayerSpawner spawnScript;
    public ListController roomsList;

    private void Awake()
    {
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
        PhotonNetwork.CreateRoom(text, new RoomOptions { MaxPlayers = 6 }, null);
        roomsList.UpdateList();
    }

    public void JoinOrCreateRoom(string text)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6;
        PhotonNetwork.JoinOrCreateRoom(text, roomOptions, TypedLobby.Default);
        roomsList.UpdateList();
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
