using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiAnimation : MonoBehaviour
{
    [SerializeField]
    private LeanTweenType inType;
    [SerializeField]
    float duration;
    [SerializeField]
    float delay;

    [SerializeField]
    private UnityEvent onCompleteTween = new UnityEvent();
    [SerializeField]
    CanvasGroup canvasGroup;

    private Vector3 currentPos;

    private void Awake()
    {
        currentPos = transform.position;
    }

    public void OnEnable()
    {
        transform.localScale = new Vector3(0, 0, 0);
        transform.position = currentPos;
        canvasGroup.alpha = 100;   

        LeanTween.scale(gameObject, new Vector3(2, 2, 2), duration).setDelay(delay).setOnComplete(OnCompleteTween).setEase(inType);
        LeanTween.moveY(gameObject, 1, duration).setDelay(delay);
        LeanTween.alphaCanvas(canvasGroup, 0, duration).setDelay(delay);
    }

    public void OnCompleteTween()
    {
        gameObject.SetActive(false);
        onCompleteTween?.Invoke();
    }
}
