using UnityEditor;
using System.IO;
using UnityEngine;
//using UnityEngine.Build.Pipeline;
//using UnityEditor.Build.Pipeline;

public class CreateAssetsBundle
{
   /* private static string folderPath = "Assets/StreamingAssets";

    [MenuItem("AssetBundle/Build Asset Bundles")]
    public static void Build()
    {

        Debug.Log("Building start");
        BuildAssetBundles(folderPath, false, CompressionType.Lz4, EditorUserBuildSettings.activeBuildTarget);
        AssetDatabase.Refresh();
    }

    public static bool BuildAssetBundles(string outputPath, bool forceRebuild, bool useChunkBasedCompression, BuildTarget buildTarget)
    {
        CompatibilityAssetBundleManifest manifest = BuildAssetBundles(outputPath, forceRebuild, useChunkBasedCompression ? CompressionType.Lz4 : CompressionType.Lzma, buildTarget);
        return manifest != null;
    }

    public static CompatibilityAssetBundleManifest BuildAssetBundles(string outputPath, bool forceRebuild, CompressionType compressionMode, BuildTarget buildTarget)
    {
        var options = BuildAssetBundleOptions.None;
        switch (compressionMode)
        {
            case CompressionType.None:
                options |= BuildAssetBundleOptions.UncompressedAssetBundle;
                break;
            case CompressionType.Lz4:
                options |= BuildAssetBundleOptions.ChunkBasedCompression;
                break;
        }
        if (forceRebuild)
            options |= BuildAssetBundleOptions.ForceRebuildAssetBundle;

        Directory.CreateDirectory(outputPath);

        return CompatibilityBuildPipeline.BuildAssetBundles(outputPath, options, buildTarget);
    } */
}
