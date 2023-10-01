using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerBall : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rb; 
	[SerializeField] private float _maxSpeed;
	[SerializeField] private float _maxDistance; 
	private bool _isMoving;
	private Vector2 _destination;
	private float _currentSpeed;
	
	 
	private void Awake()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}
	
	private void Start()
	{
		Touch.onFingerMove += OnFingerMoveHandler;
		Touch.onFingerUp += OnFingerUpHandler;
		Touch.onFingerDown += OnFingerDownHandler;
	}
	
	private void FixedUpdate()
	{
		if (!_isMoving) return;
		
		Vector3 lookDir = Camera.main.ScreenToWorldPoint(_destination) - transform.position;
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(_destination);
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0f, 0f, angle);
		
		var distance = Vector2.Distance(mousePosition, transform.position);
		if (distance <= _maxDistance)
		{
			_rb.velocity = Vector2.zero;
			return;
		}
		
		_rb.velocity = _currentSpeed * transform.right;
	}

	private void OnFingerDownHandler(Finger finger)
	{
		_isMoving = true;
		_currentSpeed = _maxSpeed;
	}
	
	private void OnFingerMoveHandler(Finger finger)
	{
		_destination = finger.screenPosition;
	}
	
	private void OnFingerUpHandler(Finger finger)
	{
		if (this == null)
		{
			return;
		}
		_isMoving = false;
		_currentSpeed = 0;
		_rb.velocity = _currentSpeed * transform.right;
	}
}
