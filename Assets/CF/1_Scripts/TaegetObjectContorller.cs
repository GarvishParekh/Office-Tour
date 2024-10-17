using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zappar;

public class TaegetObjectContorller : MonoBehaviour
{
    [SerializeField] private int id;

    [Header("Jeffery's Properties")]
    [SerializeField] private GameObject[] affectedObjects;
    [SerializeField] private Animator jeffAnimator;
    [SerializeField] private AudioSource jeffAudioSource;
    [SerializeField] private float endTime = 57f;

    [Header("Set at Runtime")]
    [SerializeField] private int curIndex;
    [SerializeField] private int nextIndex;
    [SerializeField] private float totalPlayTime;
    [SerializeField] private float currentTime;

    [Header("Peaople's Properties")]
    [SerializeField] private PersonData[] personsData;

    // [SerializeField] private Transform cameraTransform;
    // [SerializeField] private Text text;
    // public Matrix4x4 campos;

    bool canStart = true;
   public bool isPaused = true;
    bool canHideLast = true;

    private void Start()
    {
        totalPlayTime = jeffAudioSource.clip.length;
        SetAffectedObjects(false);
        HideAllPersonCards();
    }

    private void OnEnable()
    {
        
          Events.onImageTargetFound += HandleImageTargetFound;
          Events.onImageTargetLost += HandleImageTargetLost;
    }

    private void OnDisable()
    {
       Events.onImageTargetFound -= HandleImageTargetFound;
        Events.onImageTargetLost -= HandleImageTargetLost;
    }

    

    // private void Update()
    // {
    //     RotateTowardsCamera();
    // }

    private void HandleImageTargetFound(int otherId)
    {
       
            if (isPaused == false)
                return;

            isPaused = false;
            PlayAnimation();

        
    }

    private void HandleImageTargetLost(int otherId)
    {
        if (isPaused == false)
        {
            isPaused = true;
            PauseAnimation();
        }
    }

    private void PlayAnimation()
    {
        SetAffectedObjects(true);

        if (canStart)
        {
            StartCoroutine(nameof(PlaybackTimer));
            // RotateTowardsCamera();
            canStart = false;
        }

        jeffAnimator.Play("Base Layer.Scene", 0, currentTime / totalPlayTime);

        jeffAudioSource.time = currentTime;
        jeffAudioSource.Play();

        ShowPersonAtIndex(curIndex, true);
    }

    private void PauseAnimation()
    {
        jeffAudioSource.Stop();
        SetAffectedObjects(false);

        HidePersonAtIndex(curIndex, true);
    }

    private void StopAnimation()
    {
        jeffAudioSource.Stop();
    }

    private void SetAffectedObjects(bool enabled)
    {
        int length = affectedObjects.Length;

        for (int i = 0; i < length; i++)
        {
            affectedObjects[i].SetActive(enabled);
        }
    }

    private void HideAllPersonCards()
    {
        for (int i = 0; i < personsData.Length; i++)
        {
            personsData[i].Hide(true);
        }
    }

    private IEnumerator PlaybackTimer()
    {
        currentTime = 0f;
        curIndex = -1;
        nextIndex = 0;

        while (currentTime < totalPlayTime)
        {
            if (isPaused)
            {
                yield return null;
            }
            else
            {
                if (nextIndex < personsData.Length && currentTime >= personsData[nextIndex].showAfterTime)
                {
                    ShowPersonAtIndex(nextIndex);
                    curIndex = nextIndex;
                    nextIndex++;
                }

                if(currentTime >= endTime && canHideLast)
                {
                    canHideLast = false;
                    HidePersonAtIndex(curIndex);
                }

                currentTime += Time.deltaTime;
                yield return null;
            }
        }

        StopAnimation();
        // HidePersonAtIndex(curIndex);

        canStart = true;
        canHideLast = true;
    }

    // private void RotateTowardsCamera()
    // {
    //     // Vector3 lookPosition = cameraTransform.position;
    //     // lookPosition.y = transform.position.y;
    //     // transform.rotation = Quaternion.LookRotation(lookPosition);

    //     Vector3 from = transform.position;
    //     from.y = 0f;
    //     Vector3 to = cameraTransform.position;
    //     to.y = 0f;
    //     Vector3 dir = to - from;

    //     float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

    //     transform.localRotation = Quaternion.Euler(0, angle, 0);

    //     campos = ZapparCamera.Instance.GetCameraPose;


    //     text.text = $"Camera :\n  pos - {cameraTransform.position}\n  rot - {cameraTransform.rotation.eulerAngles}" +
    //                 $"\nTarget :\n  pos - {transform.parent.position}\n  rot - {transform.parent.rotation.eulerAngles}" +
    //                 $"\nTarget Object :\n  pos - {transform.position}\n  rot - {transform.rotation.eulerAngles}" + 
    //                 $"\nCamMetrix : {campos.GetRow(0)}\n{campos.GetRow(1)}\n{campos.GetRow(2)}\n{campos.GetRow(3)}\n";

    // }

    private void ShowPersonAtIndex(int index, bool isImmidiate = false)
    {
        if (index < 0)
            return;

        if (index > 0)
            HidePersonAtIndex(index - 1, isImmidiate);

        personsData[index].Show(isImmidiate);
    }

    private void HidePersonAtIndex(int index, bool isImmidiate = false)
    {
        if (index < 0)
            return;

        personsData[index].Hide(isImmidiate);
    }

    private void OnApplicationFocus(bool isFocused)
    {
        if (!isFocused)
            HandleImageTargetLost(id);

        // Debug.Log("Focused : " + isFocused);
    }

#if UNITY_EDITOR

    bool imageFound = false;

    [ContextMenu("ToggleImageTarget")]
    private void ToggleImageTarget()
    {
        imageFound = !imageFound;

        if (imageFound)
            HandleImageTargetFound(id);
        else
            HandleImageTargetLost(id);
    }
#endif
}

[System.Serializable]
public struct PersonData
{
    [SerializeField] private string name;
    public Animation animation;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float showAfterTime;

    public void Show(bool isImmidiate)
    {
        if (isImmidiate)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
        else
        {
            animation.Play("show");
        }
    }

    public void Hide(bool isImmidiate)
    {
        if (isImmidiate)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0);
            spriteRenderer.enabled = false;
        }
        else
        {
            animation.Play("hide");
        }
    }

   
}

