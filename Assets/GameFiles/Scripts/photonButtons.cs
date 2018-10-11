using Photon;
using UnityEngine;
using UnityEngine.UI;

public class photonButtons : Photon.MonoBehaviour
{
    public InputField createRoomInput, joinRoomInput;

    public photonHandler pHandler;

    public void OnClickJoinRoom()
    {
        pHandler.JoinOrCreateRoom(joinRoomInput.text);
    }

    public void OnClickCreateRoom()
    {
        if (createRoomInput.text.Length >= 1)
        {
            Debug.Log("Creating a room");
            pHandler.CreateNewRoom(createRoomInput.text);
        }
    }

}
