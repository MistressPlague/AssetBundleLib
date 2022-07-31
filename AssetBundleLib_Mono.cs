using System;
using System.IO;
using System.Linq;
using System.Reflection;
using MelonLoader;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Libraries
{
    public class AssetBundleLib
    {
        /// <summary>
        /// The Loaded AssetBundle, Null By Default
        /// </summary>
        public AssetBundle bundle = null;

        public bool HasLoadedABundle = false;

        public string error = "";

        /// <summary>
        /// Loads An Asset Bundle For Using Data Such As Sprites
        /// </summary>
        /// <param name="resource">The Path To The Embedded Resource File - Example: CVRButtonAPI.Resources.plaguelogo.asset</param>
        /// <returns>True If Successful</returns>
        public bool LoadBundle(string resource)
        {
            if (HasLoadedABundle)
            {
                return true;
            }

            try
            {
                if (string.IsNullOrEmpty(resource))
                {
                    error = "Null Or Empty Resource String!";
                    return false;
                }

                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);

                if (stream != null && stream.Length > 0)
                {
                    var memStream = new MemoryStream((int)stream.Length);

                    stream.CopyTo(memStream);

                    if (memStream.Length > 0)
                    {
                        return LoadBundle(memStream.ToArray());
                    }

                    error = "Null memStream!";
                }
                else
                {
                    error = "Null Stream!";
                }

                var resourcename = resource.Replace(resource.Substring(resource.LastIndexOf(".")), "").Substring(resource.LastIndexOf("."));

                var assetBundle = AssetBundle.GetAllLoadedAssetBundles().First(o => o.name == resourcename);

                assetBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;

                bundle = assetBundle;

                return false;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// Loads An Asset Bundle For Using Data Such As Sprites
        /// </summary>
        /// <param name="resource">The byte[] Of The Embedded Resource File - Example: Properties.Resources.plaguelogo.asset</param>
        /// <returns>True If Successful</returns>
        public bool LoadBundle(byte[] resource)
        {
            if (HasLoadedABundle)
            {
                return true;
            }

            try
            {
                var assetBundle = AssetBundle.LoadFromMemory(resource);

                if (assetBundle != null)
                {
                    assetBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;

                    bundle = assetBundle;

                    HasLoadedABundle = true;

                    return true;
                }

                HasLoadedABundle = true;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }

            return false;
        }

        /// <summary>
        /// Loads An Asset From The Previously Loaded AssetBundle
        /// </summary>
        /// <param name="str">The Internal Name Of The Asset Inside The AssetBundle</param>
        /// <returns>The Asset You Searched For, Null If No AssetBundle Was Previously Loaded</returns>
        public T Load<T>(string str) where T : Object
        {
            try
            {
                if (HasLoadedABundle)
                {
                    var Asset = bundle.LoadAsset(str, typeof(T)) as T;

                    Asset.hideFlags |= HideFlags.DontUnloadUnusedAsset;

                    return Asset;
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

            return null;
        }
    }
}
