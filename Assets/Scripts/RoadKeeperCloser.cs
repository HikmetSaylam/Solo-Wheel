using System.Collections;
using UnityEngine;

public class RoadKeeperCloser : MonoBehaviour
{
    [SerializeField] private GameObject keeper;

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.tag.Equals("Character")) return;
        StartCoroutine(CloseKeeper());

    }

    private IEnumerator CloseKeeper()
    {
        yield return new WaitForSeconds(0.5f);
        keeper.SetActive(false);
        yield return new WaitForSeconds(3);
        keeper.SetActive(true);
    }
}
