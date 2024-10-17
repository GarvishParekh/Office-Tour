using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Marker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Content content = new Content();

        Form form = new Form();

        form.isActive = true;
        form.markerID = "1";

        UiLabel title = new UiLabel();
        title.labelTxt = "FeedBack";

        form.titleTxt = title;


        UiLabel discriptionTxt = new UiLabel();
        discriptionTxt.labelTxt = "Hello";

        form.discriptionTxt = discriptionTxt;

        HyperLink hyperLink = new HyperLink();
        hyperLink.labelTxt = "PrivacyPolicy";
        hyperLink.Url = "";

        form.privacyPolicy = hyperLink;

        SubmitButton submitButton = new SubmitButton();
        submitButton.labelTxt = "Submit";

        form.submitButton = submitButton;
        
        
        content.forms.Add(form);
         

        ImageGallery imageGallery = new ImageGallery();

        imageGallery.isActive = true;
        imageGallery.markerID = "2";

        ImageDetail imageDetail = new ImageDetail();
        imageDetail.discription = "Hello";
        imageDetail.imageUrl = "";

        imageGallery.galleryImage = new List<ImageDetail>();
        imageGallery.galleryImage.Add(imageDetail);
        content.imageGallery.Add(imageGallery);

        VideoGallery videoGallery = new VideoGallery();

        videoGallery.isActive = true;
        videoGallery.markerID = "3";

        VideoDetails videoDetail = new VideoDetails();
        videoDetail.discription = "Hello";
        videoDetail.VideoUrl = "";

        videoGallery.galleryVideo = new List<VideoDetails>();
        videoGallery.galleryVideo.Add(videoDetail);

        content.videoGallery.Add(videoGallery);
         

        string json = JsonUtility.ToJson(content);

        Debug.Log(json);

    }
}

[System.Serializable]
public class Content
{
    public List<Form> forms = new List<Form>();
    public List<ImageGallery> imageGallery = new List<ImageGallery>();
    public List<VideoGallery> videoGallery = new List<VideoGallery>();

}


[System.Serializable]
public class Form
{
    public bool isActive;
    public string markerID;
    public UiLabel titleTxt;

    public UiLabel discriptionTxt;
    public HyperLink privacyPolicy;
    public SubmitButton submitButton;
}


[System.Serializable]
public class UiLabel
{
    public string labelTxt;
    public int size;
}

[System.Serializable]
public class SubmitButton
{
    public string labelTxt;
    public int size;
}

[System.Serializable]
public class HyperLink
{
    public string labelTxt;
    public string Url;
}

[System.Serializable]
public class ImageGallery
{
    public bool isActive;
    public string markerID;
    public UiLabel titleTxt;

    public List<ImageDetail> galleryImage;
    
}

[System.Serializable]
public class ImageDetail
{
    public string discription;
    public string imageUrl;
}

[System.Serializable]
public class VideoGallery
{
    public bool isActive;
    public string markerID;
    public UiLabel titleTxt;

    public List<VideoDetails> galleryVideo;

}

[System.Serializable]
public class VideoDetails
{
    public string discription;
    public string VideoUrl;
}