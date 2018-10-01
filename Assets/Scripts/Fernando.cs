using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fernando : MonoBehaviour {
	Animator fernandoAnimator;
	public Sprite newColored;
	public GameObject robotHug;
	public GameObject coloredBackground;
	public AudioClip lastSong;

	// Use this for initialization
	void Start()
	{
		fernandoAnimator = GetComponent<Animator>();
		//fernandoAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	void Update()
	{
		if (FindObjectOfType<MaskBehavior>().hasHugged && FindObjectOfType<AudioSource>().time >= 7f)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void TurnToFernando()
	{
		//burnBoxAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		fernandoAnimator.SetTrigger("isFernando");
		Destroy(FindObjectOfType<WispController>().gameObject);
		FindObjectOfType<MaskBehavior>().hasFernandoed = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player") && FindObjectOfType<MaskBehavior>().hasFernandoed)
		{
			Destroy(FindObjectOfType<WitchMovement>().gameObject);
			GetComponent<SpriteRenderer>().enabled = false;
			robotHug.GetComponent<SpriteRenderer>().enabled = true;
			coloredBackground.GetComponent<SpriteRenderer>().sprite = newColored;
			FindObjectOfType<MaskBehavior>().hasFernandoed = false;
			FindObjectOfType<MaskBehavior>().hasHugged = true;
			FindObjectOfType<AudioSource>().clip = lastSong;
			GameObject.Find("MusicDimr").GetComponent<MusicDimr>().active = false;
			FindObjectOfType<AudioSource>().volume = 1.0f;
			FindObjectOfType<AudioSource>().Play();
			FindObjectOfType<AudioSource>().loop = false;
		}
	}
}
