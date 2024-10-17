using UnityEngine;
using Zappar;

public class ImageTrackerController : MonoBehaviour
{
    [SerializeField] private int id;

    [SerializeField] ZapparImageTrackingTarget imageTracking;

    private void Awake() {
      //  imageTracking = GetComponent<Zappar.ZapparImageTrackingTarget>();
    }

    private void OnEnable()
    {
 
        imageTracking.OnSeenEvent.AddListener(OnSeenEvent);
        imageTracking.OnNotSeenEvent.AddListener(OnHideEvent);
    }

    private void OnDisable() {
        imageTracking.OnSeenEvent.RemoveListener(OnSeenEvent);
       imageTracking.OnNotSeenEvent.RemoveListener(OnHideEvent);
    }

    public void OnSeenEvent()
    {
        Events.onImageTargetFound?.Invoke(id);
    }

    public void OnHideEvent()
    {
        Events.onImageTargetLost?.Invoke(id);
    }
}
