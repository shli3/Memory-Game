using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour {

	public void gameMenuBehavoir(int i){
		switch(i){
		default:
		case(0):
			AddButtons.howManyCards = 12;
			SceneManager.LoadScene("Card_Mat");
			break;
		case(1):
			AddButtons.howManyCards = 14;
			SceneManager.LoadScene("Card_Mat");
			break;
		case(2):
			AddButtons.howManyCards = 16;
			SceneManager.LoadScene("Card_Mat");
			break;
		case(3):
			AddButtons.howManyCards = 18;
			SceneManager.LoadScene("Card_Mat");
			break;
		case(4):
			AddButtons.howManyCards = 20;
			SceneManager.LoadScene("Card_Mat");
			break;
		}
	}
}
