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
            transform.GetComponentInChildren<Camera>().enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine)
        {
            //Handle our movement/camera
            selfPosition = transform.position;
        }
        else
        {
            //Handle other's movement/camera
            transform.position = selfPosition;
        }
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            selfPosition = (Vector3)stream.ReceiveNext();
        }
    }

}
