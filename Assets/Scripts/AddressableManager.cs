using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : MonoBehaviour
{
    [SerializeField]
    private AssetReference swordAssetReference;


    IResourceLocator swordObject;

    // Start is called before the first frame update
    void Start()
    {
        Addressables.InitializeAsync().Completed += AddressablesManager_Completed;
    }

    private void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        swordAssetReference.InstantiateAsync();
        swordObject = obj.Result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
