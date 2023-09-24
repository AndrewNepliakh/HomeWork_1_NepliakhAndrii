using UnityEngine;

public class InputController : MonoBehaviour
{
	public KeyCode KeyCode => _keyCode;

	private KeyCode _keyCode;

	private void Update()
	{
		ReadKey();
	}

	private void ReadKey()
	{
		_keyCode = KeyCode.None;
		
		if (Input.GetKey(KeyCode.W))
		{
			_keyCode = KeyCode.W;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			_keyCode = KeyCode.S;
		}

		if (Input.GetKey(KeyCode.A))
		{
			_keyCode = KeyCode.A;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			_keyCode = KeyCode.D;
		}

		if (Input.GetKey(KeyCode.Space))
		{
			_keyCode = KeyCode.Space;
		}
		
		if (Input.GetKey(KeyCode.RightShift))
		{
			_keyCode = KeyCode.RightShift;
		}
		
		if (Input.GetKey(KeyCode.Escape))
		{
			_keyCode = KeyCode.Escape;
		}
	}
}