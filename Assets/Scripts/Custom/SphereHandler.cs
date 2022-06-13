using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    private static MeshRenderer rendNeg;
    private static MeshRenderer rendPos;

    static Texture2D texNeg;
    static Texture2D texPos;

    static int screenshotCount = 0;

    [SerializeField] GameObject sphNeg;
    [SerializeField] GameObject sphPos;

    void Start(){
        texNeg = new Texture2D(2, 2);
        texPos = new Texture2D(2, 2);

        if(sphNeg && sphPos){
            Debug.Log("1");
            rendNeg = sphNeg.GetComponent<MeshRenderer>();
            rendPos = sphPos.GetComponent<MeshRenderer>();
        }
        else{
            Debug.Log("0");
        }
    }

    void Update(){
        Debug.Log(sphNeg);
    }

    public static void ScreenshotSuccess(string saveName){ // ideally only MultiCamTool.cs has access to it
        if(screenshotCount > 2) return;

        screenshotCount++;
        
        switch(screenshotCount){
            case 1:
                LoadTexture(saveName, texNeg);
                break;
            case 2:
                LoadTexture(saveName, texPos);
                UpdateSphereTexture();
                break;
            default:
                break;
        }
    }

    static void LoadTexture(string saveName, Texture2D tex){
        var rawData = System.IO.File.ReadAllBytes(saveName);
        tex.LoadImage(rawData);
    }

    static void UpdateSphereTexture(){
        rendNeg.material.mainTexture = texNeg;
        rendPos.material.mainTexture = texPos;
    }
}
