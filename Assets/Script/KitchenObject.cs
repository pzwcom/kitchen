using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]private KitchenObjectSO kitchenObjectSO;
    public IKitchenObjectParent kitchenObjectParent;
    public KitchenObjectSO GetKitchenObjectSO() { return kitchenObjectSO; } 
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;
        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.Log("IKitchenObjectParent already has a KitchenObject");
        }
        kitchenObjectParent.SetKitchenObject(this);
        
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetKitchenObjectParent()
    {

        return this.kitchenObjectParent;
    }
    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject() ;
        Destroy(gameObject);
    }
    public static void SpawnKitchebObjectOnParent(KitchenObjectSO kitchenObject,IKitchenObjectParent kitchenObjectParent)
    {
        //ͨ��SO�ļ�����transform
        Transform kitchenObjectTransform =Instantiate(kitchenObject.prefab);
        //ͨ�����ɵ�transform�е�kitchenobject�Ľű��ļ�
        KitchenObject kitchenObejct=kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObejct.SetKitchenObjectParent(kitchenObjectParent);
    }
}
