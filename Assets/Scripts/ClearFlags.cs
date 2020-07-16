using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ClearFlags : MonoBehaviour
{
    private Camera cam;

    public RenderTexture camtex;
    public RenderTexture save;
    public RenderTexture temp;
    public Material mat;

   
    void Awake()
    {
        cam = GetComponent<Camera>();
        save.Release();
    }



    void Update()
    {

        CommandBuffer command = new CommandBuffer();
        command.name = "Save";
        command.Blit(save, temp);
        mat.SetTexture("_PrevTexture", temp);

        command.Blit(camtex, save, mat);

        Graphics.ExecuteCommandBuffer(command);
    }
}
