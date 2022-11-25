using GameStates;
using UnityEngine;

public partial class UIManager
{
    [SerializeField] private ChampionHUD[] championOverlays;
    
    public void InstantiateChampionHUD()
    {
        var champion = GameStateMachine.Instance.GetPlayerChampion();
        if (champion == null) return;
        // TODO: How to identify the champion and show the right HUD?
        var canvasIndex = champion.championSo.canvasIndex;
        if (canvasIndex >= championOverlays.Length) canvasIndex = 0;
        ChampionHUD championHUD = championOverlays[canvasIndex];
        if (championHUD == null) return;
        var canvasChampion = Instantiate(championHUD, transform);
        canvasChampion.InitHUD(champion);
    }
}