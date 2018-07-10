using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildAsset  {

    [MenuItem("Tools/打包相关/BuildAsset",false,1001)]
    public static void build() {

    }
    //所有需要标记的资源总路径
    private const string abPath = "";
    //图集文件夹 图集文件夹下面的每个文件夹打一个ab
    private const string atlasPath = "";
    //标记所有需要打包的资源
    private static void markAsset() {
        //BuildPipeline.BuildAssetBundle
    }

    

}
