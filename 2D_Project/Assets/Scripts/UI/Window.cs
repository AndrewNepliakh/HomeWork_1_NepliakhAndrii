using UnityEngine;

namespace UI
{
	public class Window : MonoBehaviour
	{
		protected UIManager _uiManager;

		public void Initialize(UIManager uiManager)
		{
			_uiManager = uiManager;
		}
	}
}