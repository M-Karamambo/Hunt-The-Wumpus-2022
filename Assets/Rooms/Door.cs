using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public string playerTag = "Player";

    // Room Variables
    public RoomGen roomLoader;
    public int roomConnectedTo;

    // Door UI
    public GameObject doorUIPanel;

    [SerializeField]
    private bool canPressE = false;

    void Awake()
    {
        // Set Room Loader (not in prefab)
        roomLoader = GameObject.FindWithTag("RoomMain").GetComponent<RoomGen>();

        doorUIPanel.GetComponent<TextMeshPro>().SetText(roomConnectedTo.ToString());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // If hit by player
        if (col.gameObject.tag == playerTag)
        {  
            // Can Press E
            canPressE = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Opposite of on Trigger Enter
        if (col.gameObject.tag == playerTag)
        {
            canPressE = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If they can press E and do
        if (canPressE && Input.GetKey(KeyCode.E))
        {
            // Load the next room
            roomLoader.LoadRoom(roomConnectedTo);
        }
    }
}
