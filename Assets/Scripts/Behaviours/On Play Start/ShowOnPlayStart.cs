using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnPlayStart : MonoBehaviour {
    void Start() {
        gameObject.SetActive(false);
        GameState.Instance.OnGameStart += StartPlaying;
    }

    void StartPlaying() {
        gameObject.SetActive(true);
    }
}