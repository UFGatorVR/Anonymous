using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstanceController : MonoBehaviour {

    public PhotonView photonView;
    public Vector3 selfPosition;

    // Use this for initialization
    void Start () {
        if (photonView.isMine)
        {
            GetComponent<PhotonVoiceRecorder>().enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine)
        {
            //Handle our movement/camera
        }
        else
        {
            //Handle other's movement/camera
        }
    }
}
