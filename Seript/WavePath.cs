using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WavePath : MonoBehaviour {
	/// <summary>
	/// Enumerates over all points
	/// </summary>
	public IEnumerator<Transform> GetPathEnumeratorForward() {
		for (var i = 0; i < transform.childCount; ++i) {//取得下一個節點物件
			yield return transform.GetChild(i);
		}
	}

	public Transform FirstPoint {//找起始點
		get {
			if (transform.childCount == 0) {//沒東西
				return null;
			}

			return transform.GetChild(0);
		}
	}

	public void OnDrawGizmos() {
		if (transform.childCount < 2) {//單點不成線
			return;
		}

		for (var i = 1; i < transform.childCount; ++i) {//劃出輔助線
			Gizmos.DrawLine (transform.GetChild(i-1).position, transform.GetChild(i).position);
		}
	}
}
