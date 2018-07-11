using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildAsset
{
    //资源路径
    private const string assetPath = "Res/AssetBundle";
    //ab导出路径
    private const string exportABPath = "Assets/Res/AssetBundleExport";
    //图集文件夹 图集文件夹下面的每个文件夹打一个ab
    private const string atlasPathSuff = "Atlas";
    //需要打包的资源类型
    private const string assetTypes = "(*.png|*.prefab)";

    [MenuItem("Tools/打包相关/BuildAsset", false, 1001)]
    public static void build()
    {
        checkPath();
        markAsset();
        //一键打包
        BuildPipeline.BuildAssetBundles(exportABPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }

    private static void checkPath()
    {
        string path = exportABPath.Replace("Assets/", "");
        if (!Directory.Exists(Path.Combine(Application.dataPath, path)))
        {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, path));
        }
        AssetDatabase.Refresh();
    }


    //标记所有需要打包的资源
    //AssetBundleManifest BuildAssetBundles(string outputPath, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform);
    private static void markAsset()
    {
        string fullPath = getFullPath(assetPath);
        List<string> flst = FileUtils.getAllFolder(fullPath); Directory.GetDirectories(fullPath);
        for (int i = 0; i < flst.Count; i++)
        {
            doMark(flst[i]);
        }
        AssetDatabase.Refresh();
    }
    private static void doMark(string aPath)
    {
        //如果是图集 打包ab比较特殊 需要打包整个文件夹
        string abName = "";
        string[] files = Directory.GetFiles(aPath);
        for (int k = 0; k < files.Length; k++)
        {
            if (files[k].EndsWith(".meta")) continue;
            string assetRpath = getRelativePath(files[k]);
            AssetImporter imp = AssetImporter.GetAtPath(assetRpath);
            if (imp != null)
            {
                abName = aPath.EndsWith(atlasPathSuff) ? getAbName(aPath) : getAbName(files[k]);
                imp.assetBundleName = abName;
                EditorUtility.SetDirty(imp);
            }
            else
            {
                Debug.Log(assetRpath);
            }
        }
    }


    [MenuItem("Assets/打包相关/清理ab标记", false, 5001)]
    public static void clearMark()
    {
        bool isClear = EditorUtility.DisplayDialog("是否清理所有ab标记？", "请确认", "清理", "取消");
        if (isClear)
        {
            UnityEngine.Object[] floderName = Selection.GetFiltered<UnityEngine.Object>(SelectionMode.Assets);
            if (floderName.Length > 0)
            {
                string selectPath = AssetDatabase.GetAssetPath(floderName[0]);
                string full = getFullPath(selectPath);
                List<string> floders = FileUtils.getAllFolder(full);
                for (int i = 0; i < floders.Count; i++)
                {
                    string[] files = Directory.GetFiles(floders[i]);
                    for (int k = 0; k < files.Length; k++)
                    {
                        string assetRpath = getRelativePath(files[k]);
                        AssetImporter imp = AssetImporter.GetAtPath(assetRpath);
                        if (imp != null)
                        {
                            imp.assetBundleName = "";
                            EditorUtility.SetDirty(imp);
                        }
                    }
                }
                AssetDatabase.Refresh();
            }
        }
    }
    [MenuItem("Tools/打包相关/清理所有ab", false, 1002)]
    public static void clearAssetBundle()
    {
        bool isClear = EditorUtility.DisplayDialog("确认清理所有AB？", "请确认", "清理", "取消");
        if (isClear)
        {
            if (Directory.Exists(Path.Combine(Application.dataPath, exportABPath)))
            {
                Directory.Delete(Path.Combine(Application.dataPath, exportABPath));
            }
            AssetDatabase.Refresh();
        }
    }


    //获取完整路径
    private static string getFullPath(string suff)
    {
        if (suff.StartsWith("Assets/"))
        {
            suff = suff.Replace("Assets/", "");
        }
        return Path.Combine(Application.dataPath, suff);
    }
    //根据完整路径获取相对路径
    private static string getRelativePath(string full)
    {
        int index = full.IndexOf("Assets");
        string path = full.Substring(index);
        return path;
    }
    //Atlas abName
    public static string getAbName(string path)
    {
        int index = path.IndexOf("AssetBundle");
        string name = path.Substring(index);
        int suffIndex = name.LastIndexOf(".");
        if (suffIndex > 0)
        {
            name = name.Substring(0, suffIndex);
        }
        return name;
    }
    //获取文件名称
    public static string getOtherAbName(string filePath)
    {
        return Path.GetFileNameWithoutExtension(filePath);
    }
}
