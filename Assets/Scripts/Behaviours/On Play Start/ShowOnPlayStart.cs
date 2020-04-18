using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnPlayStart : MonoBehaviour {
    void Start() {
        gameObject.SetActive(false);
        PlanningMenu.onGameStart += StartPlaying;
    }

    void StartPlaying() {
        gameObject.SetActive(true);
    }
}