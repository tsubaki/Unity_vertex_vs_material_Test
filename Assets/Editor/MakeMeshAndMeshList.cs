using UnityEngine;
using System.Collections;

public class MakeMeshAndMeshList : MonoBehaviour
{
	[SerializeField]
	GameObject prefab;
	public int x, y;
	
	[ContextMenu("Create Mesh")]
	void CreateCubes ()
	{
		GameObject parent = new GameObject ("mesh list");
		MeshListManager meshList = parent.AddComponent<MeshListManager>();
		
		float halfX = x /2;
		float halfY = y /2;
		
		for (int i=0; i< x; i++) {
			for (int j=0; j<y; j++) {
				GameObject obj = Instantiate(prefab) as GameObject;
				obj.transform.parent = parent.transform;
				Transform meshTransform = obj.transform;
				meshTransform.localPosition = new Vector3(i - halfX, j - halfY, 0);
				Debug.Log(meshTransform.localPosition);
				meshList.meshList.Add (obj);
			}
		}
	}
}
