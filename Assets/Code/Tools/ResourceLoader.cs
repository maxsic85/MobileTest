﻿using UnityEngine;
namespace Snake.Tools
{
    public static class ResourceLoader
    {
        public static GameObject LoadPrefab(ResourcePath path)
        {
            return Resources.Load<GameObject>(path.PathResource);
        }
    }
}