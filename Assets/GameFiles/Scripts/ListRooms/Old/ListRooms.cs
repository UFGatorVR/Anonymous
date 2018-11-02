using Photon;
using UnityEngine;
using UnityEngine.UI;

public class ListRooms : Photon.MonoBehaviour {

    RoomInfo[] rooms;
    public float widthName, widthPlayers, widthScroll, heightScroll, scrollStartX, scrollStartY;
    public photonHandler pHandler;
    private Vector2 scrollPosition = Vector2.zero;
    public Rect scroll;

    // Use this for initialization
    void Start () {
        rooms = PhotonNetwork.GetRoomList();
        widthName = (float)Screen.width * (float)0.6;
        widthPlayers = (float)Screen.width * (float)0.2;
        widthScroll = (float)Screen.width * (float)0.8;
        heightScroll = (float)Screen.width * (float)0.5;
        scrollStartX = (float)Screen.width * (float)0.4;
        scrollStartY = (float)Screen.width * (float)0.75;
        scroll = new Rect(scrollStartX, scrollStartY, widthScroll, heightScroll);
    }

    public void OnGUI()
    {
        GUI.BeginScrollView(scroll, scrollPosition, new Rect(0, 0, 600, 600));
        foreach (RoomInfo e in rooms)
        {
            GUILayout.BeginHorizontal();
            if ( GUILayout.Button(e.Name, GUILayout.Width(widthName)))
            {
                pHandler.JoinOrCreateRoom(e.Name);
            };
            GUILayout.Label(e.PlayerCount.ToString(), GUILayout.Width(widthName / 5));
            GUILayout.EndHorizontal();
            Debug.Log("Created Button for New Server");
        }
        GUI.EndScrollView();
    }

    private void OnReceivedRoomListUpdate()
    {
        rooms = PhotonNetwork.GetRoomList();
    }
}
