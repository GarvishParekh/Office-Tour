using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField]
    Material unlit, dissolveUnlit;

    [SerializeField]
    MeshRenderer terrain;

    [SerializeField]
    GameObject cardParent;

    public void changeMatToUnlit()
    {
        //terrain.material = unlit;
    }

    public void ChangeMatToDissolve()
    {
        //terrain.material = dissolveUnlit;
    }

    public void ShowCardParent()
    {
        cardParent.SetActive(true);
    }

    public void HideCardParent()
    {
        cardParent.SetActive(false);
    }
}
