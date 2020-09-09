using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T191.Controllers
{
	public class LoadingManager : MonoBehaviour
	{
		public LoadingInterface loadingInterface { get; private set; }

		public static LoadingManager singleton { get; private set; }

		private void Awake()
		{
			if(singleton == null && singleton != this)
			{
				singleton = this;				
			}
			else
			{
				Debug.LogWarning("Já existe uma instância de " + this.name);

				Destroy(gameObject);
			}

			loadingInterface = GetComponent<LoadingInterface>();
		}
	}
}