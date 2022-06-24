using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.tag.Equals("Character")) return;
        Destroy(this.gameObject);
    }
}
