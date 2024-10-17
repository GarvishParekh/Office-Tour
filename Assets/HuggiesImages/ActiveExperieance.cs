using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveExperieance : MonoBehaviour
{
    public GameObject infoPopUp;
    public void OnTargetFound()
    {
        if(!infoPopUp.activeInHierarchy)
            infoPopUp.SetActive(true);
    }
}
