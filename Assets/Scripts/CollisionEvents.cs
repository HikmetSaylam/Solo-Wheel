using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionEvents : MonoSingleton<CollisionEvents>
{
    [SerializeField] private GameObject colliderObject;
    [SerializeField] private float colliderCloseTime;
    private int _health = 5;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Coin")) return;
        _health -= 1;
        if (_health == 0)
            SceneManager.LoadScene("SampleScene");
        StartCoroutine(InitiateHarmEvents());
    }
    
    private IEnumerator InitiateHarmEvents()
    {
        colliderObject.SetActive(false);
        CharacterMovement.Instance.SetSpeed(CharacterMovement.Instance.GetStartSpeed());
        transform.position += new Vector3(0, 0.2f, -CharacterMovement.Instance.GetSpeed() / 10);
        GetComponent<Renderer>().material.color -= new Color(0f, 0f, 0f, 1f);
        yield return new WaitForSeconds(colliderCloseTime);
        GetComponent<Renderer>().material.color += new Color(0f, 0f, 0f, 1f);
        colliderObject.SetActive(true);
    }
}
