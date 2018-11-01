using Photon;
using UnityEngine;
using UnityEngine.UI;

public class ListRooms : Photon.MonoBehaviour {

    RoomInfo[] rooms;
    float widthName, widthPlayers;
    public photonHandler pHandler;

    // Use this for initialization
    void Start () {
        rooms = PhotonNetwork.GetRoomList();
        widthName = (float)Screen.width * (float)0.6;
        widthPlayers = (float)Screen.width * (float)0.2;
    }

    public void OnGUI()
    {
        foreach (RoomInfo e in rooms)
        {
            GUILayout.BeginHorizontal();
            if ( GUILayout.Button(e.Name, GUILayout.Width(widthName)))
            {
                pHandler.JoinOrCreateRoom(e.Name);
            };
            GUILayout.Label(e.PlayerCount.ToString(), GUILayout.Width(widthName));
            GUILayout.EndHorizontal();
            Debug.Log("Created Button for New Server");
        }
    }

    private void OnReceivedRoomListUpdate()
    {
        rooms = PhotonNetwork.GetRoomList();
    }
}
