/****************************************************文件：AutoSetTextureUISprite.cs作者：haitao.li日期：2023/01/16 20:02:50功能：Nothing*****************************************************//****************************************************
文件：AutoSetTextureUISprite.cs
作者：haitao.li
日期：2023/01/13 13:45:58
功能：自动压缩图片格式
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEditor.Profiling;
using UnityEngine;

public class AutoSetTextureUISprite : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter textureIm = assetImporter as TextureImporter;
        if (textureIm != null)
        {
            if (IsFirstImport(textureIm))
            {
                textureIm.textureType = TextureImporterType.Sprite;
                var settingAndroid = textureIm.GetPlatformTextureSettings("Android");
                settingAndroid.overridden = true;
                settingAndroid.format = TextureImporterFormat.ASTC_6x6;
                textureIm.SetPlatformTextureSettings(settingAndroid);
            
                var settingIos = textureIm.GetPlatformTextureSettings("iOS");
                settingIos.overridden = true;
                settingIos.format = TextureImporterFormat.ASTC_6x6;
                textureIm.SetPlatformTextureSettings(settingIos);
            }
        }
    }
    
    //贴图不存在、meta文件不存在、图片尺寸发生修改需要重新导入
    bool IsFirstImport(TextureImporter importer)
    {
        (int width, int height) = GetTextureImporterSize(importer);
        Texture tex = AssetDatabase.LoadAssetAtPath<Texture2D>(assetPath);
        bool hasMeta = File.Exists(AssetDatabase.GetAssetPathFromTextMetaFilePath(assetPath));
        return tex == null || !hasMeta || (tex.width != width && tex.height != height);
    }
 
    //获取导入图片的宽高
    (int, int) GetTextureImporterSize(TextureImporter importer)
    {
        if (importer != null)
        {
            object[] args = new object[2];
            MethodInfo mi = typeof(TextureImporter).GetMethod("GetWidthAndHeight", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(importer, args);
            return ((int)args[0], (int)args[1]);
        }
        return (0, 0);
    }

}