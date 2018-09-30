using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {
	public GameObject optionsCanvas;
	public GameObject creditsCanvas;
	bool usable = true;
	public GameObject[] menuButtons;
	void Start(){
		if(GameObject.Find(optionsCanvas.name)){
			optionsCanvas.SetActive(false);
		}
		if(GameObject.Find(creditsCanvas.name)){
			creditsCanvas.SetActive(false);
		}
	}
	void Update(){
		if(!GameObject.Find(optionsCanvas.name) && !GameObject.Find(creditsCanvas.name)){
			usable = true;
		}
		for(int i=0;i<menuButtons.Length;i++){
			menuButtons[i].GetComponent<Button>().interactable = usable;
		}
	}
  public void StartGame()
    {
    	SceneManager.LoadScene("NewGame");
    }
    public void ExitGame()
    {
    	Application.Quit();
    }
    public void Options()
    {
    	if(!GameObject.Find(optionsCanvas.name)){
    		optionsCanvas.SetActive(true);
    		usable = false;
    	}
    }
    public void Credits()
    {
    	if(!GameObject.Find(creditsCanvas.name)){
    		creditsCanvas.SetActive(true);
    		usable = false;
    	}
    }
}
