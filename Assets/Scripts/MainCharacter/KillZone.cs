using System;
using Common.Menu;
using UnityEngine;
using Utilites;

namespace MainCharacter
{
	[RequireComponent(typeof(TriggerHandler))]
	public class KillZone : MonoBehaviour
	{
		private TriggerHandler _triggerHandler;
		private void Awake()
		{
			_triggerHandler = GetComponent<TriggerHandler>();
			
			_triggerHandler.onTriggerEnter.AddListener(LoadScreenLose);
		}

		public void LoadScreenLose()
		{
			GameStatusWindow.Instance.EnableLoseScreen();
		}
	
	}
}