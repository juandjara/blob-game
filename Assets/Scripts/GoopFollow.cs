using UnityEngine;

public class GoopFollow : MonoBehaviour
{
    public Transform player;
    private float playerX;
    private float playerY;
    public float decay = 3.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerX = 0;
        playerY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerX = expDecay(playerX,  player.position.x, decay, Time.deltaTime);
        playerY = expDecay(playerY,  player.position.y, decay, Time.deltaTime);
        transform.position = new Vector2 (playerX, playerY);
    }
    float expDecay(float a, float b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
