using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

	[SerializeField] private Transform target;
	
	[SerializeField] [Range(0.01f,1f)]
	
	private float smoothSpeed = 0.13f;
	
	[SerializeField] private Vector3 offset;
	
	private Vector3 velocity = Vector3.zero;
	
    // Start is called before the first frame update
	
	//Make the camera follow the player at a slight offset
	private void LateUpdate(){
		Vector3 cameraPosition = target.position + offset;
		transform.position = Vector3.SmoothDamp(transform.position,cameraPosition,ref velocity,smoothSpeed);
	}
}
