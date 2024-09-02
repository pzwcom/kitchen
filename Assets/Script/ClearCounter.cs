using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    // Start is called before the first frame update

    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //There is no KitchenObject there
            if (player.HasKitchenObject())
            {
                //Player is carring something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player not carring anything
            }
        }
        else
        {
            //There is a KitchenObject here
            if(player.HasKitchenObject())
            {
                //Player not has something
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }


    }
}
