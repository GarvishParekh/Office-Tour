using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using DG.Tweening;
public class VideoDiscriptionScaleAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, 1164f), 4f);
    }
}
