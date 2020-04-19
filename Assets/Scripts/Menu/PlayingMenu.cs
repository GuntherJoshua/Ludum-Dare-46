using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingMenu : MonoBehaviour
{
    public void Restart() {
        GameState.LoadStage(SceneManager.GetActiveScene().buildIndex);
    }
}
