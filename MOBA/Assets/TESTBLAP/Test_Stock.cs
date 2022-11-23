using System.Collections;
using System.Collections.Generic;
using Entities.Inventory;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Test_Stock : MonoBehaviour
{
    [SerializeField] private List<Image> ShopItemImagesUI;

    IEnumerator InitUIShop()
    {
        //yield return new WaitUntil(() => PhotonNetwork.CountOfPlayers == 2);
        yield return new WaitForSeconds(3);
        for (int a = 0; a < ItemCollectionManager.allItems.Count; a++)
        {
            ShopItemImagesUI[a].sprite = ItemCollectionManager.allItems[a].SpriteOfItem;
            ShopItemImagesUI[a].gameObject.AddComponent<Button>().onClick.AddListener(() => BuyItem(ItemCollectionManager.allItems[a]));
        }
    }
    
    public void BuyItem(ItemSO item)
    {
        UIManager.Instance.OnClickOnItem(item);
        Debug.Log(item.referenceName);
    }
    
    void Start()
    {
        StartCoroutine(InitUIShop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
