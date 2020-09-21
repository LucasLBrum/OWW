using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using T191.Controllers;

public class ChangeSceneButton : MonoBehaviour
{
	public void ChangeScene(string sceneName)
	{
		SceneController.singleton.ChangeScene(sceneName);
		if(sceneName == "Florest 1")
		{
			Destroy(Player.singleton.gameObject);
		}
	}

	public void ExitPause()
	{
		Game.singleton.estadoPausado.ExitState();
		Game.singleton.estadoJogando.EnterState();
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
