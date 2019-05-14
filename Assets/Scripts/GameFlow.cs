using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameFlow : MonoBehaviour {

	public TextMeshProUGUI scoreboard;
	[SerializeField]
	private int score;

	[SerializeField]
	private Sprite backI;
	
	public Sprite[] fronts;
	public List<Sprite> usedFronts = new List<Sprite>();

	public List<Button> cards = new List<Button>();

	private bool first, second;
	private int countCorrectGuesses, gameGuesses;
	private int firstIndex, secondIndex;

	private string firstCard, secondCard;

	void Awake(){
		fronts = Resources.LoadAll<Sprite>("Materials/CardFronts");
	}

	void Start () {
		GetButtons();
		AddCards();
		Shuffle(usedFronts);
		AddListeners();
		score = 1000;
		scoreboard.text = "Score: " + score;
		gameGuesses = usedFronts.Count / 2;
	}

	void GetButtons(){
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Card");

		for(int i = 0; i < objects.Length; i++){
			cards.Add(objects[i].GetComponent<Button>());
			cards[i].image.sprite = backI;
		}
	}

	void AddCards(){
		int iter = cards.Count;
		int i = 0;

		for(int j = 0; j < iter; j++){

			if(i == iter/2) i = 0;

			usedFronts.Add(fronts[i]);

			i++;
		}
	}

	void AddListeners(){
		foreach(Button button in cards){
			button.onClick.AddListener(() => PickACard());
		}
	}

	public void PickACard(){
		
		if(!first){

			first = true;
			firstIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			firstCard = usedFronts[firstIndex].name;
			cards[firstIndex].image.sprite = usedFronts[firstIndex];

		}

		else if(!second){

			second = true;
			secondIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			secondCard = usedFronts[secondIndex].name;
			cards[secondIndex].image.sprite = usedFronts[secondIndex];

			StartCoroutine(CheckMatch());
		}
		
	}

	IEnumerator CheckMatch(){

		yield return new WaitForSeconds(1f);

		if(firstCard == secondCard){

			yield return new WaitForSeconds(0.5f);

			cards[firstIndex].interactable = false;
			cards[secondIndex].interactable = false;

			cards[firstIndex].image.color = new Color(0, 0, 0, 0);
			cards[secondIndex].image.color = new Color(0, 0, 0, 0);

			countCorrectGuesses++;

			CheckIfEndGame();
		}

		else{
			
			cards[firstIndex].image.sprite = backI;
			cards[secondIndex].image.sprite = backI;

			score -= 40;
			scoreboard.text = "Score: " + score;
			CheckIfEndGame();

		}

		yield return new WaitForSeconds(0.5f);

		first = second = false;

	}
	
	//the toughest decisions requires the strongest wills
	void CheckIfEndGame(){

		if(countCorrectGuesses == gameGuesses){
			SceneManager.LoadScene("Win");
		}
		if(score == 0){
			SceneManager.LoadScene("Lose");
		}
	}

	void Shuffle(List<Sprite> list){
		for(int i = 0; i < list.Count; i++){
			Sprite temp = list[i];
			int randIndex = Random.Range(i, list.Count);
			list[i] = list[randIndex];
			list[randIndex] = temp;
		}
	}
	
}
