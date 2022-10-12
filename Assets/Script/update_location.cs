using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class update_location : MonoBehaviour
{
	[SerializeField] Text textCity;

	void Start()
	{
		StartCoroutine("DetectCountry");
	}

	IEnumerator DetectCountry()
	{
		UnityWebRequest request = UnityWebRequest.Get("https://extreme-ip-lookup.com/json/?key=8kS5WlETmPgmGIWJBKI4");
		request.chunkedTransfer = false;
		yield return request.Send();

		if (request.isNetworkError)
		{
			textCity.text = "error : " + request.error;
		}
		else
		{
			if (request.isDone)
			{
				Country res = JsonUtility.FromJson<Country>(request.downloadHandler.text);
				
				textCity.text = res.city;
				
			}
		}
	}
}