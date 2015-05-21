using UnityEngine;

public class MObject : MonoBehaviour {
	public Category category;
	public int id;
	public int x;
	public int y;
	
	public enum Category {
		NONE,
		PLAYER,
		ENEMY
	}

	public void SetUp(JSONObject jsonObject) {
		category = GetCategory (jsonObject.GetField ("category").str);
		id = (int)jsonObject.GetField ("id").n;
		x = (int)jsonObject.GetField ("pos").list [0].n;
		y = (int)jsonObject.GetField ("pos").list [1].n;
	}

	public void updatePos (int _x, int _y) {
		x = _x;
		y = _y;
	}

	void FixedUpdate() {
		transform.position = new Vector3 (x + 0.5f, 0.0f, y + 0.5f);
	}
	
	public static Category GetCategory(string category) {
		switch (category) {
		case "user":
			return Category.PLAYER;
		case "enemy":
			return Category.ENEMY;
		default:
			return Category.NONE;
		}
	}
}
