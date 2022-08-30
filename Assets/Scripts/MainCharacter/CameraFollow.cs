using UnityEngine;

namespace MainCharacter
{
	public class CameraFollow : MonoBehaviour {
		public GameObject player;
		void Update() {
			transform.position = new Vector3 (player.transform.position.x+4, player.transform.position.y +3, transform.position.z);
		}

	}
}
