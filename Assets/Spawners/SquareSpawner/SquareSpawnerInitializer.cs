using Sisus.Init;
using GameManagers;
using UI;
using UnityEngine;
using GameObjects.Square;

namespace Spawners.SquareSpawner
{
	/// <summary>
	/// Initializer for the <see cref="SquareSpawner"/> component.
	/// </summary>
	internal sealed class SquareSpawnerInitializer : Initializer<SquareSpawner, GameManager, GameUI, Transform, Transform, SquareController>
	{
		#if UNITY_EDITOR
		/// <summary>
		/// This section can be used to customize how the Init arguments will be drawn in the Inspector.
		/// <para>
		/// The Init argument names shown in the Inspector will match the names of members defined inside this section.
		/// </para>
		/// <para>
		/// Any PropertyAttributes attached to these members will also affect the Init arguments in the Inspector.
		/// </para>
		/// </summary>
		private sealed class Init
		{
			public GameManager gameManager = default;
			public GameUI gameUI = default;
			public Transform topLeft = default;
			public Transform bottomRight = default;
			public SquareController squareController = default;
		}
		#endif
	}
}
