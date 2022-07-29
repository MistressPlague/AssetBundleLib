# AssetBundleLib
A Simple Library For Asset Loading
# Example
```csharp
if (new AssetBundleLib() is var Bundle && Bundle.LoadBundle("YourNameSpace.ResourcesOrFolderName.FileNameOfEmbeddedResource.asset")) // This If Also Checks If It Successfully Loaded As To Prevent Further Exceptions
{
    var AssetObj = Bundle.Load<Sprite>("InternalAssetBundleAssetName");
}
else
{
    MelonLogger.Error($"Failed Loading Bundle: {Bundle.error}");
}
