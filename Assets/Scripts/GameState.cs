using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
    public static bool PlanningStage; //TODO make this change depending on state
    private static int firstStageID = 1;

    public static void LoadStage(string name) {
        SceneManager.LoadScene(name);
        SceneManager.LoadScene("PlanMenu", LoadSceneMode.Additive);
    }

    public static void LoadStage(int id) {
        SceneManager.LoadScene(id);
        SceneManager.LoadScene("PlanMenu", LoadSceneMode.Additive);
    }
    
    public static void LoadLatestStage() {
        LoadStage(StageManager.LatestStage + firstStageID); 
    }
}