using UnityEditor;

namespace Editor
{
    /// <summary>
    /// Class for building asset bundles
    /// </summary>
    public class CreateAssetBundles
    {
        [MenuItem("Assets/Build AssetBundles")]
        private static void BuildAllAssetBundles()
        {
            BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None,
                BuildTarget.StandaloneWindows64);
        }
    }
}