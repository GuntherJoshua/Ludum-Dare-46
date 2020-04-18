using UnityEngine;

public class PlanningMenu : MonoBehaviour {
    public delegate void UnitEventHandler();

    public static event UnitEventHandler onGameStart;

    public void StartPlaying() {
        GameState.PlanningStage = false;
        if (onGameStart != null) onGameStart();
    }

    private void OnDestroy() {
        //we make sure to clear events like this, otherwise nonexistent objects will have their events called after
        // a scene reload
        onGameStart = null;
    }
}