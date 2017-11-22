using UnityEngine;
using System.Collections;

[System.Serializable]
public class GridLayout {
    //https://answers.unity.com/answers/1005987/view.html
    public RowData[] grid;
    public GridLayout() {
        grid = new RowData[10];
    }
    public GridLayout(int size) {
        grid = new RowData[size];
        for(int i = 0; i < grid.Length; i++) {
            grid[i].row = new bool[size];
        }
    }
	
}
[System.Serializable]
public class HexGridLayout : GridLayout {
    public HexGridLayout() : base() {
    }
    public HexGridLayout(int size) : base(size) {
    }
}
[System.Serializable]
public struct RowData {
    public bool[] row;
}