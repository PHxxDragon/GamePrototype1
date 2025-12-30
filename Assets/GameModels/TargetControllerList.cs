using System.Collections.Generic;
using GameObjects.Targets;
using UnityEngine;

namespace GameModels
{
    public class TargetControllerList: MonoBehaviour
    {
        public readonly List<TargetController> TargetComponents = new();
    }
}
