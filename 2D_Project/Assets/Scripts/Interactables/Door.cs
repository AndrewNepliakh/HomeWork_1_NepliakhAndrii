using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
	[SerializeField] private InteractableButton _button;
	
	[SerializeField] private float _speed;
	[SerializeField] private float _altitude;

	private void Start()
	{
		_button.OnInteract += Open;
	}

	public void Open()
	{
		StartCoroutine(OpenRoutine());
	}
	
	private IEnumerator OpenRoutine()
	{
		
		while (transform.position.y < _altitude)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _altitude, transform.position.z), Time.deltaTime * _speed);
			yield return null;
		}
	}
}
