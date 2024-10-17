using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermanage : MonoBehaviour
{
    public GameObject gameObject1;
    public void OnTargetFound()
    {
        if (!gameObject1.activeInHierarchy)
        {
            gameObject1.SetActive(true);
          
          
        }
    }
}
