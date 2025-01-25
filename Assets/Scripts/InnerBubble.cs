using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<PlayerManager>();
        if (player) {
            player.toggleSpeedDampening(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<PlayerManager>();
        if (player) {
            player.toggleSpeedDampening(false);
        }
    }
}
