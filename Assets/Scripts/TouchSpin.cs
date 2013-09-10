/// 
/// Rotate tutorial.
/// Copyright 2011 revelopment.co.uk
/// Created by Carlos Revelo
/// 2011
/// 
/// 
/// 
/// 

using UnityEngine;
using System.Collections;

public class TouchSpin : MonoBehaviour {

 [SerializeField]
	float 	_speed = 1f;
	
	bool _canRotate = false;

	Transform _cachedTransform;
	
	public bool CanRotate
	{
		get { return _canRotate; } 
		
		private set { _canRotate = value; } 
	}

	
	void Start () {

		//Make reference to transform
		_cachedTransform = transform;

	}

	

	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
 
			//Switch through touch events
			switch(Input.GetTouch(0).phase)

			{
				case TouchPhase.Began:	
					if(VerifyTouch(touch))
						CanRotate = true;
				break;

				case TouchPhase.Moved:	
					if(CanRotate)
						RotateObject(touch);
				break;
				case TouchPhase.Ended:	
					CanRotate = false;
				break;

			}
 
		}

	}
	
	/// 
	/// Verifies the touch.
	/// 
	/// 
	/// The touch.
	/// 
	/// 
	/// If set to true touch.
	/// 
	bool VerifyTouch(Touch touch)
	{
		Ray ray = Camera.main.ScreenPointToRay(touch.position);
        	RaycastHit hit ;
		
		//Check if there is a collider attached already, otherwise add one on the fly
		if(collider == null)
			gameObject.AddComponent(typeof(BoxCollider));
		
       		if (Physics.Raycast (ray, out hit)) 
		{
			if(hit.collider.gameObject == this.gameObject)
				return true;
		}
		return false;
	}
	

	
	/// 
	/// Rotates the object.
	/// 
	/// 
	/// Touch.
	/// 
	void RotateObject(Touch touch)
	{
		_cachedTransform.Rotate(new Vector3(touch.deltaPosition.y, -touch.deltaPosition.x,0)*_speed, Space.World);
	}	

}
