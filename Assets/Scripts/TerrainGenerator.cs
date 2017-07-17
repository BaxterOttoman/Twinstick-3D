using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class TerrainGenerator : MonoBehaviour {
	public int xSize, ySize;

	// Use this for initialization
	void Awake () {
		Generate ();
	}

	private void Generate () {
		Mesh mesh = GetComponent<MeshFilter>().mesh = new Mesh();

        float leftShift = 0.0f - (xSize / 2.0f);
		Vector3[] vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		for (int i = 0, y = 0; y <= ySize; y++) {
			for (int x = 0; x <= xSize; x++, i++) {
				float northHeight = 0;
				if (y > 0) {
					northHeight = vertices [i - xSize].y;
					}
				float westHeight = 0;
				if (x > 0) {
					westHeight = vertices [i - 1].y;
					}
				float heightChange = Random.Range (-0.5f, 0.5f);
                float height = (northHeight + westHeight) / 2 + heightChange;

                vertices[i] = new Vector3(x * 2 - xSize + leftShift, height, y*2 - ySize);
            }
            leftShift += 1.0f;
        }
		int[] triangles = new int[xSize * ySize * 6];
		for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
			for (int x = 0; x < xSize; x++, ti += 6, vi++) {
				triangles[ti] = vi;
				triangles[ti + 3] = triangles[ti + 2] = vi + 1;
				triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
				triangles[ti + 5] = vi + xSize + 2;
			}
		}
		//Make it sharp!
		Vector3[] normals = new Vector3[triangles.Length];
		for(int i=0;i<triangles.Length;i++) {
			normals[i]=vertices[triangles[i]];
			triangles[i]=i;
		}
		//Done making it sharp
		mesh.vertices = normals;
		mesh.triangles = triangles;
		mesh.RecalculateBounds ();
		mesh.RecalculateNormals ();
		MeshCollider meshc = gameObject.GetComponent<MeshCollider>();
		meshc.sharedMesh = mesh;
	}
}