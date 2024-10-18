using UnityEngine;

public class BallPlayer : MonoBehaviour
{
	//+n text
	[SerializeField] GameObject coinNumPrefab;

	CoinManager coinsManager;

	void Start ()
	{
		//find the CoinsManager
		coinsManager = FindObjectOfType<CoinManager>();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//check if player collides with a coin
		if (other.CompareTag ("coin")) {
			//Add coins 7
			coinsManager.AddCoins (other.transform.position, 7);

			Destroy (other.gameObject);

			//Show (+7) number
			Destroy (Instantiate (coinNumPrefab, other.transform.position, Quaternion.identity), 1f);
		}
	}
}
