using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Item> itemsForSale = new List<Item>();
    public AudioClip buySFX;
    public AudioClip sellSFX;

    public bool BuyItem(Item item, Inventory playerInventory, Currency playerCurrency)
    {
        if (playerCurrency.gold >= item.price)
        {   
            GetComponent<AudioSource>().PlayOneShot(buySFX);
            playerInventory.AddItem(item);
            playerCurrency.RemoveGold(item.price);
            itemsForSale.Remove(item);
            return true;
        }
        return false;
    }

    public void SellItem(Item item, Inventory playerInventory, Currency playerCurrency)
    {
        playerInventory.RemoveItem(item);
        int sellPrice = item.price;
        playerCurrency.AddGold(item.price);
        itemsForSale.Add(item);
        GetComponent<AudioSource>().PlayOneShot(sellSFX);
    }
}


