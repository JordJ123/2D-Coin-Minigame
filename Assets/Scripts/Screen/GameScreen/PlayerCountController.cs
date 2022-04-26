using Player;
using Screen.MenuScreen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screen.GameScreen
{
	public class PlayerCountController : MonoBehaviour
    {
        [SerializeField] private bool isTwoPlayers;
    	[SerializeField] private GameObject playerOne1P;
    	[SerializeField] private GameObject playerOne2P;
    	[SerializeField] private GameObject playerTwo2P;
    	
    	public static int playerOnePoints { private set; get; }
    	public static int playerTwoPoints { private set; get; }
    
    	private void Awake()
    	{
    		if (ModeSelectController.IsTwoPlayers())
    		{
    			isTwoPlayers = true;
    		}
    		if (!isTwoPlayers)
    		{
    			OnePlayerMode();
    		}
    		else
    		{
    		    TwoPlayerMode();
    		}
    	}
    
    	private void OnePlayerMode()
    	{
    		Destroy(GameObject.Find("2P User Interface"));
    		Destroy(playerOne2P);
    		Destroy(GameObject.Find("2P Player Two"));
    	}
    
    	private void TwoPlayerMode()
    	{
    		Destroy(GameObject.Find("1P User Interface"));
    		Destroy(playerOne1P);
    	}
    
    	public void SetEndPoints()
    	{
    		if (!isTwoPlayers)
    		{
    			playerOnePoints = playerOne1P.GetComponent<PointController>()
    				.GetPointsValue();
    		}
    		else
    		{
    			playerOnePoints = playerOne2P.GetComponent<PointController>()
    				.GetPointsValue();
    			playerTwoPoints = playerTwo2P.GetComponent<PointController>()
    				.GetPointsValue();
    		}
			PointController.Reset();
			PowerUp.SpawnController.Reset();
    		SceneManager.LoadScene("DeathScreen");
    	}
    }
}
