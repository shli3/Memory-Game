using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour {

	[SerializeField]
	private Transform gameMat;
	[SerializeField]
	private GameObject bouton;
	[SerializeField]
	public static int howManyCards = 8; //Set to 8 for testing purposes 

	void Awake(){
		for(int i = 0; i < howManyCards; i++){
			GameObject Card = Instantiate(bouton);
			Card.name = "" + i;
			Card.transform.SetParent(gameMat, false);
		}
	}
}
