using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public readonly List<SquareController> SquareComponents = new();
    public readonly List<TargetController> TargetComponents = new();
}
