using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoScaleAnimation : MonoBehaviour
{

    private void Awake()
    {
      
    }


    private void OnEnable()
    {
        transform.localScale = new Vector3(.8f, .8f, .8f);
        transform.DOScale(Vector3.one, 1f);
    }
}
