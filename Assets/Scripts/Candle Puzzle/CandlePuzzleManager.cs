using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePuzzleManager : MonoBehaviour {
	public int numActivatedCandles = 0;
	Candle[] m_candles;
	bool allCandlesActivated = false;

	// Use this for initialization
	void Start () {
		m_candles = GetComponentsInChildren<Candle>();
	}

	public void TryActivatingCandle(int candleNum)
	{
		if (allCandlesActivated == true)
		{
			return;
		}

		if (candleNum == numActivatedCandles)
		{
			foreach(Candle c in m_candles)
			{
				if (c.candleNum == numActivatedCandles)
				{
					c.ChangeChildFlameSpriteEnabled(true);
					c.ChangeIsActivated(true);
				}
			}
			numActivatedCandles++;
			if (numActivatedCandles == m_candles.Length)
			{
				print("All Candles Activated");
				allCandlesActivated = true;
			}
		}
		else
		{
			foreach (Candle c in m_candles)
			{
				c.ChangeChildFlameSpriteEnabled(false);
				c.ChangeIsActivated(false);
			}
			numActivatedCandles = 0;
		}
	}
}
