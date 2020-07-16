using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RenderTextureTest : MonoBehaviour
{
    public Material mat;
    public RenderTexture text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CommandBuffer command = new CommandBuffer();
        command.name = "WriteTest";
        command.SetRenderTarget(text);
        command.Blit(text, text, mat);

        Graphics.ExecuteCommandBuffer(command);

    }
}
