using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerNetwork : MonoBehaviour
{

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
    private PhotonView PhotonView;
    private int PlayersInGame = 0;
    GameObject defaultSpawnPoint;

    // Use this for initialization
    private void Awake()
    {
      
        Instance = this;
        PhotonView = GetComponent<PhotonView>();

        defaultSpawnPoint = new GameObject("Default SpawnPoint");
        defaultSpawnPoint.transform.position = new Vector3(0, 0.5f, 0);
        defaultSpawnPoint.transform.SetParent(transform, false);


        //Code to change from Login System
        PlayerName = DBManager.username;

        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 30;

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "SceneTest")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGame();
            else
                NonMasterLoadedGame();
    
        }
    }

    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
    }

    private void NonMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(1);
    }
        
    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        PlayersInGame++;
        if (PlayersInGame == PhotonNetwork.playerList.Length)
        {
            print("All players are in the game.");
            PhotonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
        }
    }

    

    [PunRPC]
    private void RPC_CreatePlayer()
    {
        var spawnPoint = GetRandomSpawnPoint();
            
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "NewPlayer"), spawnPoint.position,spawnPoint.rotation,0);
        
    }

    

    Transform GetRandomSpawnPoint()
    {
         var spawnPoints = GetAllObjectsOfTypeInScene<SpawnPoints>();

        if (spawnPoints.Count ==0)
        {
            return defaultSpawnPoint.transform;
        }
        else
        {
            return spawnPoints[Random.Range(0, spawnPoints.Count)].transform;
        }
    }

   

    public static List<GameObject>GetAllObjectsOfTypeInScene<T>()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave)
                continue;

            if (go.GetComponent<T>() != null)
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }
}
