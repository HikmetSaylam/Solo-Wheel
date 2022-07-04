using UnityEngine;
using System.Collections;

public class CollisionEvents : MonoSingleton<CollisionEvents>
{
    [SerializeField] private GameObject colliderObject;
    [SerializeField] private float colliderCloseTime;
    private Color _color;
    private Vector3 _hop;

    private void Start()
    {
        _color = new Color(0f, 0f, 0f, 1f);
        _hop = new Vector3(0, 0.2f, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Coin")) return;
        StartCoroutine(InitiateHarmEvents());
    }
    
    private IEnumerator InitiateHarmEvents()
    {
        HealthBar.Instance.ApplyHitDamage();
        colliderObject.SetActive(false);
        CharacterMovement.Instance.SetSpeed(CharacterMovement.Instance.GetStartSpeed());
        _hop.z = -CharacterMovement.Instance.GetSpeed() / 10;
        transform.position += _hop;
        GetComponent<Renderer>().material.color -= _color;
        yield return new WaitForSeconds(colliderCloseTime);
        GetComponent<Renderer>().material.color += _color;
        colliderObject.SetActive(true);
    }
}
