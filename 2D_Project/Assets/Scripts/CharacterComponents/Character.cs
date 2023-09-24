using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
	public bool IsDead { get; set; }
	public bool IsOnLadder { get; set; }
}
