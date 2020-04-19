using System;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * The status of the game. Follows a singleton pattern, meaning only one instance of this object should
 * ever exist. The reason we don't use static here is because static fields don't get reset on object
 * deletion, which means we need to take extra measures when resetting the scene.
 */
public class GameState : MonoBehaviour {
    public static GameState Instance;

    public double percentRocksToWin = 50;

    public event UnitEventHandler OnGameWin;
    public event UnitEventHandler OnGameLose;
    public event UnitEventHandler OnGameStart;

    [NonSerialized] public int RocksDead = 0; //TODO increment
    [NonSerialized] public bool PlanningStage = true;
    public static int LatestStage => PlayerPrefs.GetInt("latestStage", 1);

    private const int FirstStageId = 1;

    void Start() {
        Instance = this;
        if (SceneManager.GetActiveScene().buildIndex > LatestStage)
            PlayerPrefs.SetInt("latestStage", LatestStage + 1);
    }

    //TODO run inside the win box script
    private void Update() {
        var rocksEntered = 0.0; //TODO use box's script
        if (percentRocksToWin > rocksEntered / RockSpawner.TotalSpawns) OnGameWin?.Invoke();
        //lose once it's impossible to reach percent of rocks required for win
        //TODO get rocksAlive
        // if ((rocksAlive + rocksEntered) / RockSpawner.TotalSpawns < percentRocksToWin) OnGameLose?.Invoke();
    }

    public void StartPlaying() {
        Instance.PlanningStage = false;
        if (OnGameStart != null) OnGameStart();
    }

    public static void LoadStage(string name) {
        SceneManager.LoadScene(name);
        SceneManager.LoadScene("PlanMenu", LoadSceneMode.Additive);
    }

    public static void LoadStage(int id) {
        SceneManager.LoadScene(id);
        SceneManager.LoadScene("PlanMenu", LoadSceneMode.Additive);
    }

    /** Loads the stage the player has not yet beaten. */
    public static void LoadLatestStage() {
        LoadStage(LatestStage + FirstStageId);
    }
}