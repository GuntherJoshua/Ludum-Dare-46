using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanningMenu : MonoBehaviour {
    public delegate void UnitEventHandler();

    public static event UnitEventHandler onGameStart;

    public void StartPlaying() {
        GameState.PlanningStage = false;
        if (onGameStart != null) onGameStart();
    }
}