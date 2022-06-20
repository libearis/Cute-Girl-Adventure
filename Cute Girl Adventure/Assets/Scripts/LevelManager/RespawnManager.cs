using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;
    public CinemachineVirtualCameraBase cam;

    public GameObject playerPrefab;
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

    }

    public void Respawn()
    {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }
}
