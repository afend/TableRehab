using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu_script : MonoBehaviour {
	
	public Canvas LoadScreen;
	public Button PlayGame;
	public Button RetData;
	public Button DelData;

	
	void Start ()		{
		LoadScreen = LoadScreen.GetComponent<Canvas> ();
		PlayGame = PlayGame.GetComponent<Button> ();
		RetData = RetData.GetComponent<Button> ();
		DelData = DelData.GetComponent<Button> ();	
	}
	
	public void Play()
	{
		PlayerPrefs.SetInt("GAMENUM", PlayerPrefs.GetInt("GAMENUM")+1);
		Application.LoadLevel(1);
	}
	
	public void Del()
	{			
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetInt ("GAMENUM", 0);
		System.IO.File.Delete("DATA");
	}
	
	public void Ret()
	{			
	}
}
