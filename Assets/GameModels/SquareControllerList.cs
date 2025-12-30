using System.Collections.Generic;
using GameObjects.Squares;
using UnityEngine;

namespace GameModels
{
    public class SquareControllerList : MonoBehaviour
    {
        public readonly List<SquareController> SquareComponents = new();
    }
}
