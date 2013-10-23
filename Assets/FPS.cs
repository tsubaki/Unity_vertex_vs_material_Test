using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour
{
	private float oldTime;
	private int frame = 0;
	public float frameRate = 0f;
	private const float INTERVAL = 0.5f; // この時間おきにFPSを計算して表示させる

	void Update ()
	{
		frame++;
		float time = Time.realtimeSinceStartup - oldTime;
		if (time >= INTERVAL) {
			// この時点でtime秒あたりのframe数が分かる
			// time秒を1秒あたりに変換したいので、frame数からtimeを割る
			frameRate = frame / time;
			oldTime = Time.realtimeSinceStartup;
			frame = 0;
		}
	}
}
