using System.Collections;
using System.Collections.Generic;
using Entities.Champion;
using Entities.Inventory;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.UI;

public class Test_Stock : MonoBehaviour
{
    [SerializeField] private List<StockPanel> ShopItemImagesUI;

    [SerializeField] private Champion Champion;
    
    [System.Serializable]
    public class StockPanel
    {
        public Image slotImage;
        public Button buttonShop;
    }

    private IEnumerator InitUIShop()
    {
        //yield return new WaitUntil(() => PhotonNetwork.CountOfPlayers == 2);
        yield return new WaitForSeconds(0.5f);
        for (byte a = 0; a < ItemCollectionManager.allItems.Count; a++)
        {
            ShopItemImagesUI[a].slotImage.sprite = ItemCollectionManager.allItems[a].sprite;
            var a1 = a;
            ShopItemImagesUI[a].buttonShop.onClick.AddListener(() => BuyItem(a1));
        }
    }
    
    public void BuyItem(byte indexItem)
    {
        UIManager.Instance.OnClickOnItem(indexItem);
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
