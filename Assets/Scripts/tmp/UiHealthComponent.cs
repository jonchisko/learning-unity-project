using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UiHealthComponent : MonoBehaviour
{
    class PoolTextObject
    {
        public GameObject damageTextObject;
        public TextMeshProUGUI textMesh;
    }

    [SerializeField]
    private int poolSize = 5;
    [SerializeField]
    private GameObject damageTextObject;
    [SerializeField]
    private GameObject spawnPosition;

    private List<PoolTextObject> poolTextObjects;

    private void Awake()
    {
        poolTextObjects = new List<PoolTextObject>(poolSize);
        CreatePool();
    }

    public void OnObjectDamaged(int amount)
    {
        PoolTextObject poolTextObject = GetFreeInPool();
        if (poolTextObject == null) return;

        poolTextObject.textMesh.text = $"-{amount}";
        poolTextObject.damageTextObject.SetActive(true);
    }

    private void CreatePool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(damageTextObject, spawnPosition.transform);
            gameObject.SetActive(false);
            gameObject.transform.SetParent(spawnPosition.transform, false);

            PoolTextObject poolTextObject = new PoolTextObject
            {
                damageTextObject = gameObject,
                textMesh = gameObject.GetComponentInChildren<TextMeshProUGUI>()
            };

            poolTextObjects.Add(poolTextObject);
        }
    }

    private PoolTextObject GetFreeInPool()
    {
        foreach(var poolTextObject in poolTextObjects)
        {
            if (!poolTextObject.damageTextObject.activeSelf) return poolTextObject;
        }
        return null;
    }
}
