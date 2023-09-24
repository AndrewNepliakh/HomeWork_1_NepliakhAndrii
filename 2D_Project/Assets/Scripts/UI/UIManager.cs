using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public enum WindowType
{
	Info,
	Tutorial
}

public class UIManager : MonoBehaviour
{
	[SerializeField] private InfoWindow _infoWindowPrefab;
	[SerializeField] private List<Window> _windows;
	[SerializeField] private Transform _canvas;

	private InfoWindow _infoWindow;
	private Window _currentWindow;

	private void Awake()
	{
		_infoWindow = Instantiate(_infoWindowPrefab, _canvas);
		_infoWindow.gameObject.SetActive(false);
	}
	
	public void Show(WindowType type)
	{
		Close();
		Window windowPrefab = _windows.Find(x => x.name.Remove(x.name.Length - 6)== type.ToString());
		_currentWindow = Instantiate(windowPrefab, _canvas);
		_currentWindow.Initialize(this);
	}

	public void Show(string message)
	{
		Close();
		_infoWindow.SetMessage(message);
		_infoWindow.gameObject.SetActive(true);
	}
	
	public IEnumerator Show(string message, float timeToClose)
	{
		Close();
		Show(message);
		yield return new WaitForSeconds(timeToClose);
		Close();
	}
	
	public void Close()
	{
		_infoWindow?.gameObject.SetActive(false);
		_currentWindow?.gameObject.SetActive(false);
	}
	
}