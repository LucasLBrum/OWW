using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace T191.Controllers
{
	public class LoadingInterface : MonoBehaviour
	{
		public Text loadingText;			//Referência para o componente de texto da interface de loading

		public void SetLoadingText(float progress)
		{
			//Armazena valor de progresso de carregamento e converte para string
			string percentage = progress.ToString() + "%";
			//Aplica a string no texto da interface
			loadingText.text = percentage;
		}

		public void DisplayLoadedMessage()
		{
			loadingText.text = "Pressione qualquer tecla para continuar...";
		}

		private void OnEnable()
		{
			SceneController.singleton.OnSceneLoaded += DisplayLoadedMessage;
		}

		private void OnDisable()
		{
			SceneController.singleton.OnSceneLoaded -= DisplayLoadedMessage;
		}
	}
}