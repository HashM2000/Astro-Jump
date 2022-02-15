using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
	public delegate void GameDelegate();
	public static event GameDelegate OnGameStarted;
	public static event GameDelegate OnGameOverConfirmed;

	public static GameManager Instance;

    
	public GameObject startPage;
	public GameObject gameOverPage;
	public GameObject countdownPage;
	public Text scoreText;

	enum PageState {
		None,
		Start,
		Countdown,
		GameOver
	}

	int score = 0;
	bool gameOver = true;

	public bool GameOver { get { return gameOver; } }

	void Awake() {
		if (Instance != null) {
			Destroy(gameObject);
		}
		else {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
    // Enables the functions
	void OnEnable() {
		TapController.OnPlayerDied += OnPlayerDied;
		TapController.OnPlayerScored += OnPlayerScored;
		CountdownText.OnCountdownFinished += OnCountdownFinished;
	}
    // Disables the functions
	void OnDisable() {
		TapController.OnPlayerDied -= OnPlayerDied;
		TapController.OnPlayerScored -= OnPlayerScored;
		CountdownText.OnCountdownFinished -= OnCountdownFinished;
	}
    // Function for when the countdown is finished, start the initial score at 0
	void OnCountdownFinished() {
		SetPageState(PageState.None);
		OnGameStarted();
		score = 0;
		gameOver = false;
	}
    // When the player has scored 'score++' = +1 to score
    // Convert score into string
	void OnPlayerScored() {
		score++;
		scoreText.text = score.ToString();
	}
    // When the player has died, save their score
    // Compared their current score to their previous scores
    // If their current score is higher than their previous scores, replace it or set it as their highest score achieved.
    // If they have not beaten their previous scores, keep the highest score the same.
	void OnPlayerDied() {
		gameOver = true;
		int savedScore = PlayerPrefs.GetInt("HighScore");
		if (score > savedScore) {
			PlayerPrefs.SetInt("HighScore", score);
		}
		SetPageState(PageState.GameOver);
	}

	void SetPageState(PageState state) {
		switch (state) {
			case PageState.None:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				break;
			case PageState.Start:
				startPage.SetActive(true);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				break;
			case PageState.Countdown:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(true);
				break;
			case PageState.GameOver:
				startPage.SetActive(false);
				gameOverPage.SetActive(true);
				countdownPage.SetActive(false);
				break;
		}
	}
	// Once the player confirms or clicks the play button to restart from the game over page
    // Reset the score to 0
	public void ConfirmGameOver() {
		SetPageState(PageState.Start);
		scoreText.text = "0";
		OnGameOverConfirmed();
	}
    // When the player clicks the play button, start the countdown.
	public void StartGame() {
		SetPageState(PageState.Countdown);
	}
		
}
