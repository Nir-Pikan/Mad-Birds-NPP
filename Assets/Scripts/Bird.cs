using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500;
    

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        
        if (_birdWasLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }


        if (transform.position.y > 30 ||
            transform.position.y < -7 ||
            transform.position.x > 30 ||
            transform.position.x < -20 ||
            _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

    }

    private void OnMouseDown()
    {
        if (_birdWasLaunched)
            return;
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        if (_birdWasLaunched)
            return;
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
        FindObjectOfType<AudioManager>().Play("Sling");
    }

    private void OnMouseDrag()
    {
        if (_birdWasLaunched)
            return;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        double distanceFromInit = Math.Sqrt(Math.Pow(newPosition.x - _initialPosition.x, 2) + Math.Pow(newPosition.y - _initialPosition.y, 2));
        if (newPosition.x > _initialPosition.x)
            return;
        if(distanceFromInit > 3.5)
        {
            float normaX = (float)((newPosition.x / distanceFromInit) * 3.5);
            float normaY = (float)((newPosition.y / distanceFromInit) * 3.5);
            transform.position = new Vector3(normaX,normaY);
        }
        else
            transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
