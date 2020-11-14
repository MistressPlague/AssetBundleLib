# IL2CPPAssetBundle
A Simple Library For IL2CPP Asset Loading
# Example
```csharp
IL2CPPAssetBundle LogoBundle = new IL2CPPAssetBundle();

if (LogoBundle.LoadBundle("YourNameSpace.ResourcesOrFolderName.FileNameOfEmbeddedResource.asset")) // This If Also Checks If It Successfully Loaded As To Prevent Further Exceptions
{
    var SpriteAsset = LogoBundle.Load<Sprite>("InternalAssetBundleAssetName");
}
