using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorVoidBehavior : MonoBehaviour {

    private SpriteRenderer renderDoorClosed;
    private SpriteRenderer renderDoorOpen;
    
    public bool doorOpen = false;

    public void OpenDoor()
    {
            doorOpen = true;
    }

    private void Start()
    {
        renderDoorClosed = gameObject.GetComponentsInChildren<SpriteRenderer>()[0];
        renderDoorOpen = gameObject.GetComponentsInChildren<SpriteRenderer>()[1];

        renderDoorClosed.enabled = true;
        renderDoorOpen.enabled = false;
    }

    private void Update()
    {
        if (doorOpen)
        {
            renderDoorClosed.enabled = false;
            renderDoorOpen.enabled = true;
        }
        else {
            renderDoorClosed.enabled = true;
            renderDoorOpen.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && doorOpen && Input.GetKeyDown(KeyCode.W))
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
