using System.Collections;
using System.Collections.Generic;
using Entities.Inventory;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.UI;

public class Test_Stock : MonoBehaviour
{
    [SerializeField] private List<StockPanel> ShopItemImagesUI;

    [System.Serializable]
    public class StockPanel
    {
        public Image slotImage;
        public Button buttonShop;
    }

    private IEnumerator InitUIShop()
    {
        //yield return new WaitUntil(() => PhotonNetwork.CountOfPlayers == 2);
        yield return new WaitForSeconds(3);
        for (int a = 0; a < ItemCollectionManager.allItems.Count; a++)
        {
            ShopItemImagesUI[a].slotImage.sprite = ItemCollectionManager.allItems[a].sprite;
            ShopItemImagesUI[a].buttonShop.onClick.AddListener(() => BuyItem(ItemCollectionManager.allItems[a]));
        }
    }
    
    public void BuyItem(ItemSO item)
    {
        UIManager.Instance.OnClickOnItem(item);
    }
    
    private void Start()
    {
        StartCoroutine(InitUIShop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
