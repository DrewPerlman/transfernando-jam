using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSideBehavior : MonoBehaviour {

    private SpriteRenderer renderDoorClosed;
    private SpriteRenderer renderDoorOpen;
    private BoxCollider2D doorCollision;
    
    public bool doorOpen = false;
    public bool needToPressW = false;

    public void OpenDoor()
    {
            doorOpen = true;
    }

    private void Start()
    {
        renderDoorClosed = gameObject.GetComponentsInChildren<SpriteRenderer>()[0];
        renderDoorOpen = gameObject.GetComponentsInChildren<SpriteRenderer>()[1];
        doorCollision = gameObject.GetComponents<BoxCollider2D>()[1];

        renderDoorClosed.enabled = true;
        renderDoorOpen.enabled = false;
    }

    private void Update()
    {
        if (doorOpen)
        {
            doorCollision.enabled = false;
            renderDoorClosed.enabled = false;
            renderDoorOpen.enabled = true;
        }
        else {
            doorCollision.enabled = true;
            renderDoorClosed.enabled = true;
            renderDoorOpen.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(needToPressW){
            if (collision.CompareTag("Player") && doorOpen && Input.GetKeyDown(KeyCode.W))
            {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else {
            if (collision.CompareTag("Player") && doorOpen)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
