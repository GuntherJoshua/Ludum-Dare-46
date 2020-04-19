using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {
    public string levelName;
    
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(() => StartLevel(b));
    }

    void StartLevel(Button e) {
        GameState.LoadStage(levelName);
    }
}
