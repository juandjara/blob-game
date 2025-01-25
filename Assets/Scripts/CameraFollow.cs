using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    
    public bool UnlockCamera = false;
    public bool LockCamera = false;

    
    public bool lockX;
    public bool lockY;
    public float decay = 3.5f;
    
    private float playerX;
    private float playerY;
 
    void Update ()
    {
        if (UnlockCamera)
        {
            UnlockCamera = false;
            unlockCamera();
        }
        if (LockCamera)
        {
            LockCamera = false;
            lockCamera();
        }
        
        //playerX = player.position.x;
        //playerY = player.position.y;
        playerX = expDecay(playerX,  player.position.x, decay, Time.deltaTime);
        playerY = expDecay(playerY,  player.position.y, decay, Time.deltaTime);

        if (lockX)
        {
            playerX = 0;
        }
        if (lockY)
        {
            playerY = 0;
        }
        transform.position = new Vector3 (playerX + offset.x, playerY + offset.y, transform.position.z); // Camera follows the player with specified offset position
    }

    float expDecay(float a, float b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }

    public void unlockCamera()
    {
        lockX = false;
        lockY = false;
    }
    
    public void lockCamera()
    {
        lockX = true;
        lockY = true;
    }




}
