
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour {

	public void OnClickStartSync()
    {
        if (!PhotonNetwork.isMasterClient)
            return;
        PhotonNetwork.LoadLevel("SceneTest");
    }

    public void OnClickStartDelayed()
    {
        if (!PhotonNetwork.isMasterClient)
            return;

        PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.room.IsVisible = false;
        PhotonNetwork.LoadLevel("SceneTest");
    }
}
