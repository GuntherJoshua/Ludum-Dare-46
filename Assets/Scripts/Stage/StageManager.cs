using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
    public static int LatestStage => PlayerPrefs.GetInt("stage", 1);

    void Start() {
        if (SceneManager.GetActiveScene().buildIndex > LatestStage)
            PlayerPrefs.SetInt("latestStage", LatestStage + 1);
    }
}