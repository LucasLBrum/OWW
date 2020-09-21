using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

namespace T191.Controllers
{
	public class SceneController : MonoBehaviour
	{
		public event Action OnSceneLoaded;

		public static SceneController singleton { get; private set; }

		public string startSceneName = "Scene1";
		public string sceneToLoad = null;

		public bool activateScene = false;

		private void Awake()
		{
			if(singleton == null && singleton != this)
			{
				singleton = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}

		private IEnumerator Start()
		{
			//Carregar a cena determinada como cena inicial
			yield return LoadAndSetActive(startSceneName);
		}

		//Função pública acessada por outras classes para a troca de cena

		public void ChangeScene(string sceneName)
		{
			sceneToLoad = sceneName;

			StartCoroutine(SwitchScenes(sceneName));
		}

		//Função que descarrega a cena atual e troca para uma cena nova

		private IEnumerator SwitchScenes(string sceneName)
		{
			//Descarregar a cena atual
			yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
			//Trocar para a cena de loading (transição)
			yield return LoadAndSetActive("LoadingScene");
			//Carregar a cena do parâmetro, e esperar pela ativação
			StartCoroutine(LoadAndWaitForActivation(sceneName));
		}

		//Função que faz o carregamento
		private IEnumerator LoadAndSetActive(string sceneName)
		{			
			//Carrega a cena de maneira assíncrona
			yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
			//Armazena a cena que vai ser carregada em uma referência
			Scene loadedScene = SceneManager.GetSceneByName(sceneName);
			//Define a cena carregada como a cena ativa
			SceneManager.SetActiveScene(loadedScene);
		}

		private IEnumerator UnloadAndActiveNewScene(Scene sceneToUnload, Scene newScene)
		{
			//Descarregar a cena "sceneToUnload" do parâmetro
			yield return SceneManager.UnloadSceneAsync(sceneToUnload);
			//Ativar a cena carregada
			SceneManager.SetActiveScene(newScene);
		}

		private IEnumerator LoadAndWaitForActivation(string sceneName)
		{
			//Criar um objeto que receberá uma operação assíncrona
			AsyncOperation async;
			//Armazena a função de troca de cena neste objeto, utilizando o nome da cena e o modo de carregamento dos parâmetros
			async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
			//Bloqueia o ativamento da cena
			async.allowSceneActivation = false;
			//Enquanto a operação não estiver concluída...
			while (!async.isDone)
			{
				//Mostrar na interface o progresso da operação de carregamento
				LoadingManager.singleton.loadingInterface.SetLoadingText(async.progress);
				//Se o progresso for igual ou maior que 90%...
				if (async.progress >= 0.9f)
				{
					//Se o jogador apertou qualquer tecla...
					if (Input.anyKeyDown)
					{
						//if(sceneName == "Florest")
						//Game.singleton.loadState.LoadPlaying();
						//Permitir a ativação da cena
						async.allowSceneActivation = true;
						//Armazenar uma referência para a cena de loading(transição)
						Scene loadingScene = SceneManager.GetActiveScene();
						//Armazenar uma referência para a cena que foi carregada
						Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
						//Descarregar cena de loading, e tornar a cena carregada como ativa
						yield return UnloadAndActiveNewScene(loadingScene, newScene);
					}
				}

				yield return null;
			}			
		}
	}
}