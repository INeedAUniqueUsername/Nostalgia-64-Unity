using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour {
    public Transform hex;
    public float width = 0.5f;
    public float height = 0.6f;
    public HexGridLayout data = new HexGridLayout(25);
    void Start() {
        int center = 12;
        for(int y = 0; y < data.grid.Length; y++) {
            bool[] row = data.grid[y].row;
            for (int x = 0; x < row.Length; x++) {
                if(row[x]) {
                    int y_offset = center - y;
                    int x_offset = x - center;
                    Vector2 position = new Vector2(
                        x_offset * width + (Mathf.Abs(y_offset) % 2 == 0 ? width / 2 : 0),
                        y_offset * height / 2);
                    Transform h = Instantiate(hex, gameObject.transform);
                    h.transform.localPosition = position;
                }
            }
        }
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.white;
        int center = 12;
        for (int y = 0; y < data.grid.Length; y++) {
            bool[] row = data.grid[y].row;
            for (int x = 0; x < row.Length; x++) {
                if (row[x]) {
                    int y_offset = center - y;
                    int x_offset = x - center;
                    Vector2 position = transform.position + new Vector3(
                        x_offset * width + (Mathf.Abs(y_offset) % 2 == 0 ? width / 2 : 0),
                        y_offset * height / 2);
                    Helper.DrawHexagon(position, 90, height / 2.5f);
                }
            }
        }
    }

}
