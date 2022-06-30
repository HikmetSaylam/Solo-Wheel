using System.Collections;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private GameObject meshRenderer;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.tag.Equals("Collider")) return;
        StartCoroutine(ActivateCoroutine());
    }

    private IEnumerator ActivateCoroutine()
    {
        meshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        meshRenderer.SetActive(true);
    }
}
