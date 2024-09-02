using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{// Start is called before the first frame update
    [SerializeField] private KitchenObjectSO KitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;
    public override void Interact(Player player)
    {
        if (HasKitchenObject())
        {
            if (!player.HasKitchenObject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
        else
        {
            if(!player.HasKitchenObject())
            {
                KitchenObject.SpawnKitchebObjectOnParent(KitchenObjectSO,player);
            }
            else
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
                OnPlayerGrabbedObject?.Invoke(this,EventArgs.Empty);
            }
        }
        
       
     }
   
}
