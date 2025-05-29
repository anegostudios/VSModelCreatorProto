using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

namespace VSMC
{
    [System.Serializable]
    public class ShapeElementFace
    {

        /// <summary>
        /// The texture of the face.
        /// </summary>
        public string Texture;

        [DoNotSerialize()]
        public string ResolvedTexture;

        /// <summary>
        /// The UV array of the face.
        /// </summary>
        public float[] Uv;

        public EnumReflectiveMode ReflectiveMode;

        public sbyte[] WindMode;

        public sbyte[] WindData;

        /// <summary>
        /// The rotation of the face.
        /// </summary>
        public float Rotation;

        /// <summary>
        /// The glow on the face.
        /// </summary>
        public int Glow;

        /// <summary>
        /// Whether or not the element is enabled.
        /// </summary>
        public bool Enabled = true;

        [DoNotSerialize]
        public int textureIndex;

        public void ResolveTexture(Dictionary<string, string> textures)
        {
            //This essentially just finds the texture index based on the loaded textures.
            //Remove the # from the start of the texture.
            ResolvedTexture = Texture.Substring(1);
            int index = 0;
            foreach (var pair in textures)
            {
                if (pair.Key.Equals(ResolvedTexture, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    textureIndex = index;
                    return;
                }
                index++;
            }
            //No texture found - Use first texture as default.
            Debug.LogWarning("No texture found for element with texture " + ResolvedTexture);
            textureIndex = 0;
        }


    }
}