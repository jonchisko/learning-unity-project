using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UiHealthComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject damageTextObject;

    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = damageTextObject.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Assert(textMesh != null);
    }

    public void OnObjectDamaged(int amount)
    {
        textMesh.text = $"-{amount}";
        damageTextObject.SetActive(true);
    }
}
