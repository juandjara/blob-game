using UnityEngine;

public class PickBlob : MonoBehaviour
{
    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<PlayerManager>();
        if (player) {
            player.gameObject.transform.localScale += new Vector3(1f, 1f, 0);
            GameManager.instance.addBlob();
            Destroy(gameObject);
        }
    }
}
