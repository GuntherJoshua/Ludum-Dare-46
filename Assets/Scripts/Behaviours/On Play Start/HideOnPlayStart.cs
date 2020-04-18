using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnPlayStart : MonoBehaviour {
    void Start() {
        PlanningMenu.onGameStart += StartPlaying;
    }

    void StartPlaying() {
        gameObject.SetActive(false);
    }
}