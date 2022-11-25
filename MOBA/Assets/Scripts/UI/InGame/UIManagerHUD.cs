using System.Linq;
using Entities;
using Entities.Champion;
using UnityEngine;

public partial class UIManager
{
    [SerializeField] private ChampionHUD[] championOverlays;

    // Choose the right HUD to show based on the champion the player is playing
    public void InstantiateChampionHUD(int entityIndex)
    {
        var champion = EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<Champion>();
        if (champion == null) return;
        // TODO: How to identify the champion and show the right HUD?
        ChampionHUD championHUD = championOverlays.FirstOrDefault(c => c.name.Contains(champion.name));
        // if (!photonView.isMine) return;
        if (championHUD == null) return;
        var canvasChampion = Instantiate(championHUD, champion.transform);
        canvasChampion.InitHUD(champion);
    }
}