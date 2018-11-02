using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomClass {

    public Button roomName;
    public Text currPlayers;
    public Text maxPlayers;

    public RoomClass (string serverName, string currentPlayers, string maximumPlayers)
    {
        roomName.GetComponentInChildren<Text>().text = serverName;
        currPlayers.text = currentPlayers;
        maxPlayers.text = maximumPlayers;
    }
}
