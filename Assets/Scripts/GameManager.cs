using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.Playables;
using UnityEngine.UI;
using Zappar;

public class GameManager : MonoBehaviour
{
    /*
    [SerializeField] string assetName = "Asset Name";
    [SerializeField] string URL = "Server URL";
    [SerializeField] Transform tabletTransform;
    [SerializeField] string[] shaders;

    */
    [DllImport("__Internal")]
    private static extern void ShowAlertPlugin();

    [SerializeField] string skyboxURl;
    [SerializeField] Material skyboxMaterial;
    [SerializeField] GameObject VideoPDFViewerParent,intellifyOfficeModel,PanaromicParent;
    [SerializeField] Button[] cardButtons;
    [SerializeField] PlayableDirector playableDirector;
    [Serializable]
    public class assetBundleClass
    {
        public string assetName = "Asset Name";
        public string assetPath = "Asset Path";
        public string URL = "Server URL";
        public Transform parentTransform;
        public int siblingIndex = 0;
        public string shader = string.Empty;
    }

    [SerializeField]
    assetBundleClass[] assetBundleInfo;

    [SerializeField]
    GameObject[] glasses;

    int currentGlasses = 0;

    /*

    IEnumerator Start()
    {
        while (!Caching.ready)
            yield return null;

        foreach (assetBundleClass assetBundle in assetBundleInfo)
        {
            //PrepareAssets(assetBundle.assetPath, assetBundle.shader, assetBundle.URL, assetBundle.parentTransform,assetBundle.siblingIndex);
        }
    }
    */

    private void Awake()
    {
        //playableDirector.RebuildGraph();
    }

    private void Start()
    {
        //SetSkybox();
        //StartCoroutine(GetTexture(skyboxURl));
    }

   
    void PrepareAssets(string assetPath, string shaderName, string URL, Transform parent, int siblingIndex)
    {
        StartCoroutine(LoadBundle(URL, bundle => {
            if (!bundle)
            {
                //if not null
                Debug.Log("Assets Bundle Not found");
            }
            else
            {
                Debug.Log(bundle);

                foreach(string name in bundle.GetAllAssetNames())
                {
                    Debug.Log(name);
                }
                
                GameObject asset = Instantiate(bundle.LoadAsset<GameObject>(assetPath), parent);

                if (!shaderName.Equals(string.Empty))
                {
                    asset.GetComponent<Renderer>().sharedMaterial.shader = Shader.Find(shaderName);
                }

                asset.transform.SetSiblingIndex(siblingIndex);
                Debug.Log(asset.transform.GetSiblingIndex());
                //asset.GetComponent<Renderer>().sharedMaterial.color = Color.green;
            }
        }));
    }

    IEnumerator LoadBundle(string URL, UnityAction<AssetBundle> callback)
    {
        
        //#if UNITY_WEBGL && !UNITY_EDITOR
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(URL);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            // Get downloaded asset bundle
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            callback(bundle);

            bundle.Unload(true);
            Debug.Log("Asset Bundle Downloaded");
        }

        /*#else
        var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(path);
        yield return assetBundleCreateRequest;
        callback(assetBundleCreateRequest.assetBundle);
        #endif*/
    }

    /*
    public void showVideoPlayer()
    {
        tabletTransform.GetChild(1).gameObject.SetActive(true);
    }

    public void hideVideoPlayer()
    {
        tabletTransform.GetChild(1).gameObject.SetActive(false);

    }

    */



    public void OpenURL()
    {
        ShowAlertPlugin();
    }

    public void Reset()
    {
        //hideVideoPlayer();
        VideoPDFViewerParent.SetActive(false);
        PanaromicParent.SetActive(false);
        intellifyOfficeModel.SetActive(true);

    }

    public void SwitchToFrontCamera()
    {
        ZapparCamera.Instance.SwitchToFrontCameraMode();
        ZapparCamera.Instance.MirrorCamera = true;
    }


    public void SwitchToRearCamera()
    {
        ZapparCamera.Instance.SwitchToRearCameraMode();
        ZapparCamera.Instance.MirrorCamera = false;
    }


   

    public void ChangeGlasses()
    {
        if (currentGlasses < 2)
        {
            currentGlasses++;
        }
        else
        {
            currentGlasses = 0;
        }

        switch (currentGlasses)
        {
            case 0:
                glasses[0].SetActive(true);
                glasses[1].SetActive(false);
                glasses[2].SetActive(false);
                break;
            case 1:
                glasses[0].SetActive(false);
                glasses[1].SetActive(true);
                glasses[2].SetActive(false);
                break;
            case 2:
                glasses[0].SetActive(false);
                glasses[1].SetActive(false);
                glasses[2].SetActive(true);
                break;
        }
    }


    public void ShowPanaromic()
    {
        ZapparCamera.Instance.ToggleActiveCamera(true);

    }

    public void HidePanaromic()
    {
        ZapparCamera.Instance.ToggleActiveCamera(false);
    }


    IEnumerator GetTexture(string URL)
    {

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(URL);

        yield return request.SendWebRequest();

       

        Debug.Log("Done");

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            long status = request.responseCode;
            string errorMessage = request.error;
            Debug.Log($"<color=red>Error in fetching texture {status} : {errorMessage}</color>");
            yield  return null;
        }
        else
        {
            Debug.Log("Download Start");
            Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            //Debug.Log(myTexture.width +" "+ myTexture.height);
            Debug.Log("Download Done");
            skyboxMaterial.mainTexture = myTexture;
            Debug.Log(RenderSettings.skybox.name);
            yield return new WaitForSeconds(1f);
            RenderSettings.skybox = skyboxMaterial;
            yield return new WaitForSeconds(1f);
            Debug.Log(RenderSettings.skybox.name);
            

        }

    }


    [SerializeField] GameObject parent, intellifyOffice, planeParent, office2, office4, Theintellifyoffice, Tree, vehicle, cardsParent;


    public void StartSequence()
    {
        StartCoroutine(OnFound());
    }

    IEnumerator OnFound()
    {
        yield return new WaitForSeconds(0.1f);
        parent.SetActive(true);
        planeParent.SetActive(true);
    }

    public void ResetSequence()
    {

    }
}
