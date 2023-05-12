/****************************************************文件：AssetsAuto.cs作者：haitao.li日期：2023/01/16 20:00:45功能：Nothing*****************************************************/using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.U2D;

// 将图片拖入Image文件夹自动压缩纹理为指定方式
public class AssetsAuto : AssetPostprocessor
{

    // 导入声音前
    void OnPreprocessAudio()
    {
        AudioImporter audioImporter = (AudioImporter)assetImporter;
    }

    // 导入动画前
    void OnPreprocessAnimation()
    {
        ModelImporter modelImporter = (ModelImporter)assetImporter;
        
    }

    // 导入贴图前
    [System.Obsolete]
    void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        if (textureImporter.assetPath.Contains("Texture") || textureImporter.assetPath.Contains("Resources_moved/Image"))
        {
            textureImporter.textureType = TextureImporterType.Sprite;
            // textureImporter.mipmapEnabled = false;
            // // 设置不同平台纹理压缩格式
            // textureImporter.SetPlatformTextureSettings("iPhone", 2048, TextureImporterFormat.ASTC_RGBA_6x6, 0, true);
            // Debug.Log(assetImporter.assetPath);
            // string[] sArray = assetImporter.assetPath.Split('/');
            // if (sArray.Length < 2)
            // {
            //     LogError("Auto Set PackingTag Error Path: " + assetImporter.assetPath);
            // }
            // textureImporter.spritePackingTag = sArray[sArray.Length - 2];

        }


    }


    // 导入贴图前
    void OnPostprocessMaterial()
    {
    }
    
    // 导入声音后
    void OnpostProcessAudio(AudioClip clip)
    {

    }

    // 导入材质后
    void OnPostprocessMaterial(Material material)
    {
    }

    // 导入精灵后
    void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
    {

    }

    // 导入贴图后
    void OnPostprocessTexture(Texture2D texture)
    {

    }

}
