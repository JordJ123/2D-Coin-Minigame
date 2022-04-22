using Screen.MenuScreen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screen
{
	public class CreditsScreenController : MonoBehaviour
	{
		private GameObject audioGameObject;
		private MenuSoundController audio;

		private void Awake()
		{
			audioGameObject = GameObject.FindWithTag("Sound");
			if (audioGameObject != null)
			{
				audio = audioGameObject.GetComponent<MenuSoundController>();
			}
		}

		public void DSI()
		{
			if (audio != null) audio.ForwardSound();
			Application.OpenURL("https://0x72.itch.io/16x16-dungeon-tileset");
		}
	
		public void DSII()
		{
			if (audio != null) audio.ForwardSound();
			Application.OpenURL("https://0x72.itch.io/dungeontileset-ii");
		}
		
		public void Font()
        {
            if (audio != null) audio.ForwardSound();
            Application.OpenURL("https://csanyk.itch.io/min-font");
        }
		
		public void GameSounds()
		{
			if (audio != null) audio.ForwardSound();
			Application.OpenURL(
				"https://phoenix1291.itch.io/sound-effects-pack-2");
		}

		public void MenuSounds()
		{
			if (audio != null) audio.ForwardSound();
			Application.OpenURL(
				"https://noahkuehne.itch.io/free-menu-sound-pack-ui-sounds-v2");
		}
	
		public void Return()
		{
			if (audio != null) audio.BackwardSound();
			SceneManager.LoadScene("MenuScreen");
		}
	}	
}
