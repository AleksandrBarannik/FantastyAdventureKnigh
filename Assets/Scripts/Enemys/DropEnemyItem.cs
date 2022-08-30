using System;
using UnityEngine;

namespace Enemys
{
    [Serializable]
    public class DropEnemyItem
    {
        public string name = "Item";
        public GameObject prefab;
        public int count;
    }
}
