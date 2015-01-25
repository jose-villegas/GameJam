using UnityEngine;
using System.Collections;

public class AutoRotateMaterial : MonoBehaviour {
	public Texture2D[] TEXTURES;

	// Use this for initialization
	void Start () {
		StartCoroutine ("ANIMATION");
	}
	IEnumerator ANIMATION()
	{
		int index = 0;
		while(GameManager.Instance.GameState == GameManager.GameStatus.Playing)
		{
			if(TEXTURES.Length > 0)
			{
				gameObject.renderer.material.mainTexture = TEXTURES[index];
				index++;
				if(index >= TEXTURES.Length)
					index = 0;
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
