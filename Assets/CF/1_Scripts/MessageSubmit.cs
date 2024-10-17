using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class MessageSubmit : MonoBehaviour
{
    public InputField nameInput;
    public InputField subjectInput;
    public InputField messageInput;

    public GameObject feedBackPopUp;

    public CanvasGroup feedBackPopUpGroup;

    public TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
        feedBackPopUp.transform.DOScale(new Vector3(1f, 1f, 1f), 0.7f).OnUpdate(() => {
            feedBackPopUpGroup.alpha += 0.02f;
        });
    }

    public void Back()
    {
        nameInput.text = string.Empty;
        subjectInput.text = string.Empty;
        messageInput.text = string.Empty;

        feedBackPopUp.transform.DOScale(new Vector3(0.0f, 0.0f, 0.0f), 0.7f).OnUpdate(() =>
        {
            feedBackPopUpGroup.alpha -= 0.02f;
        }).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }


    public void Submit()
    {
        nameInput.text = string.Empty;
        subjectInput.text = string.Empty;
        messageInput.text = string.Empty;
            textMeshPro.transform.DOScale(new Vector3(1f, 1f, 1f), 1f).OnComplete(() =>
            {
                Invoke(nameof(ClosePopUp), 1f);
            });
        
    }

    void ClosePopUp()
    {
        feedBackPopUp.transform.DOScale(new Vector3(0.0f, 0.0f, 0.0f), 0.7f).OnUpdate(() =>
        {
            feedBackPopUpGroup.alpha -= 0.02f;
        }).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
