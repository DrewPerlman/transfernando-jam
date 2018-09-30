using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {
	public int candleNum;
	bool isActivated = false;
	CandlePuzzleManager m_candlePuzzleManager;
	SpriteRenderer m_childFlameSprite;

	// Use this for initialization
	void Start () {
		m_candlePuzzleManager = GetComponentInParent<CandlePuzzleManager>();
		m_childFlameSprite = transform.Find("FlameSprite").GetComponent<SpriteRenderer>();
		m_childFlameSprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TryActivate()
	{
		if (!isActivated)
		{
			m_candlePuzzleManager.TryActivatingCandle(candleNum);
		}
	}

	public void ChangeIsActivated(bool activate)
	{
		isActivated = activate;
	}

	public void ChangeChildFlameSpriteEnabled(bool enable)
	{
		m_childFlameSprite.enabled = enable;
	}
}
