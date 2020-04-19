using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnPlayStart : MonoBehaviour {
    void Start() {
        GameState.Instance.OnGameStart += StartPlaying;
    }

    void StartPlaying() {
        gameObject.SetActive(false);
    }
}