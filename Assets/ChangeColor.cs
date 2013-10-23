using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeColor : MonoBehaviour
{

	MeshListManager meshList = null;
	List<float> meshRandomCount = new List<float> ();
	public bool isMarkDynamic = false;
	
	public enum MeshUpdateType
	{
		VERTEX,
		VERTEXCACHE,
		MATERIAL,
		MATERIALCACHE,
	}
	
	public MeshUpdateType meshUpdateType = MeshUpdateType.MATERIAL;
	Dictionary<int, Mesh> meshCache = new Dictionary<int, Mesh> ();
	Dictionary<int, Material> materialCache = new Dictionary<int, Material> ();
	
	void Start ()
	{
		meshList = FindObjectOfType (typeof(MeshListManager)) as MeshListManager;
		
		for (int i=0; i<meshList.meshList.Count; i++) {
			meshRandomCount.Add (Random.Range (0.0f, 5f));
		}
	}
	
	void Update ()
	{
		int count = 0;
		foreach (GameObject obj in meshList.meshList) {
			float size = Mathf.Abs (Mathf.Cos (Time.time + meshRandomCount [count]));
			Color color = new Color (size, size, size, size);
			
			switch (meshUpdateType) {
			case MeshUpdateType.MATERIAL:
				UpdateMaterial (obj, color);
				break;
				
			case MeshUpdateType.VERTEX:
				UpdateMesh (obj, color);
				break;
				
			case MeshUpdateType.VERTEXCACHE:
				UpdateMeshWithCache (obj, size);
				break;
			
			case MeshUpdateType.MATERIALCACHE:
				UpdateMaterialCache (obj, size);
				break;
			}
			count ++;
		}
	}
	
	void UpdateMesh (GameObject obj, Color32 color)
	{
		MeshFilter filter = obj.GetComponent<MeshFilter> ();
		Mesh mesh = filter.mesh;
		
		if (isMarkDynamic)
			mesh.MarkDynamic ();

		Color32[] colors = new Color32[mesh.vertices.Length];
			
		for (int i=0; i<colors.Length; i++) {
			colors [i] = color;
		}
		 mesh.colors32 = colors;
		//filter.sharedMesh = mesh;
	}

	void UpdateMeshWithCache (GameObject obj, float size)
	{
		MeshFilter filter = obj.GetComponent<MeshFilter> ();
		
		int count = (int)(size * 10);
		
		if (meshCache.ContainsKey (count)) {
			filter.sharedMesh = meshCache [count];
			return;
		}

		Mesh mesh = filter.mesh;
		if (isMarkDynamic)
			mesh.MarkDynamic ();
		
		Color color = new Color (size, size, size, size);
		Color32[] colors = new Color32[mesh.vertices.Length];
			
		for (int i=0; i<colors.Length; i++) {
			colors [i] = color;
		}
		mesh.colors32 = colors;
		
		meshCache.Add (count, mesh);
	}
	
	void UpdateMaterial (GameObject obj, Color32 color)
	{
		obj.renderer.material.color = color;
	}
	
	void UpdateMaterialCache (GameObject obj, float size)
	{
		int count = (int)(size * 10);
		if (materialCache.ContainsKey (count)) {
			obj.renderer.material = materialCache [count];
			return;
		}
		
		Color color = new Color (size, size, size, size);
		obj.renderer.material.color = color;
		materialCache.Add (count, obj.renderer.material);
	}
	
}
