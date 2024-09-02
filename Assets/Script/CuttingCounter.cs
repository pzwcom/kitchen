using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cutKichenObjectSOArray;
    private int cuttingProgress = 0;
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
            if (player.HasKitchenObject())
            {
                //Player not has something
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject())
        {
            //KitchenObjectSO outputKitchenObjectSO=Getou
            //if there is KitchenObject here 
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            //判断物体是否能够切片的同时输出物体所需要切的最大时间
            if (JudgeIfInCuttingRecipe(GetKitchenObject(),out int maxProgess))
            {
                cuttingProgress++;
                if (cuttingProgress >= maxProgess)
                {
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchebObjectOnParent(outputKitchenObjectSO, this);
                    cuttingProgress = 0;
                }
               
            }
            
        }
    }
    private bool JudgeIfInCuttingRecipe(KitchenObject kitchenObject,out int maxProgess)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cutKichenObjectSOArray)
        {
            if (cuttingRecipeSO.input == kitchenObject.GetKitchenObjectSO())
            {
                maxProgess = cuttingRecipeSO.cuttingProgressMax;
                return true;
            }
        }
        maxProgess = 0;
        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach(CuttingRecipeSO cuttingRecipeSO in cutKichenObjectSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {   
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }
}
