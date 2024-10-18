using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using AsyncImageLibrary;
public class OpenGallery : MonoBehaviour
{
    public Image image1;
    public string remoteImageUrl = "/Test.png";
    [SerializeField] Texture2D texture;
    void Start()
    {
        if (IsImageCorrupted(remoteImageUrl))
        {
            Debug.LogError("Image is corrupted!");
        }
        else
        {
            Debug.Log("Image is valid.");
        }
    }

    bool IsImageCorrupted(string path)
    {
        try
        {
            Texture2D texture = new Texture2D(2, 2);
            byte[] fileData = System.IO.File.ReadAllBytes(path);
            bool success = texture.LoadImage(fileData);

            if (!success)
            {
                Debug.LogError("Error loading image: " + path);
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Debug.Log("Error loading image: " + ex.Message);
            return true;
        }
    }
}

//public class ImageLoader : MonoBehaviour
//{
//    public string imagePath = "Assets/Images/myImage.png";

//    void Start()
//    {
//        if (IsImageCorrupted(imagePath))
//        {
//            Debug.LogError("Image is corrupted!");
//        }
//        else
//        {
//            Debug.Log("Image is valid.");
//        }
//    }

//    bool IsImageCorrupted(string path)
//    {
//        try
//        {
//            Texture2D texture = new Texture2D(2, 2);
//            byte[] fileData = System.IO.File.ReadAllBytes(path);
//            bool success = texture.LoadImage(fileData);

//            if (!success)
//            {
//                Debug.LogError("Error loading image: " + path);
//                return true;
//            }

//            return false;
//        }
//        catch (Exception ex)
//        {
//            Debug.LogError("Error loading image: " + ex.Message);
//            return true;
//        }
//    }
//}