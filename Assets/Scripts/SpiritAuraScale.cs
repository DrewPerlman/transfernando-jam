using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAuraScale : MonoBehaviour {

    public float radius = 0.5f;

	void Start () {

	}
	
	void Update () {
        Vector3 mouseScreen = Input.mousePosition;
        Vector2 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 aura = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector2 difference = mouse - aura;
        // difference vector between the mouse and the center of the object

        Vector3 auraScale = transform.localScale;
        if (difference.magnitude / 6.0f > radius) {

            auraScale.x = radius / 2.0f;
            auraScale.y = radius / 2.0f;
        } 
        else {
            auraScale.x = radius * 2 - difference.magnitude / 4.0f;
            auraScale.y = radius * 2 - difference.magnitude / 4.0f;
        }

        transform.localScale = auraScale;

    }
}
