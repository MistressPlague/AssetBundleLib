# IL2CPPAssetBundle
A Simple Library For IL2CPP Asset Loading
# Example
```csharp
if (new IL2CPPAssetBundle() is var LogoBundle && LogoBundle.LoadBundle("YourNameSpace.ResourcesOrFolderName.FileNameOfEmbeddedResource.asset")) // This If Also Checks If It Successfully Loaded As To Prevent Further Exceptions
{
    var SpriteAsset = LogoBundle.Load<Sprite>("InternalAssetBundleAssetName");
}
