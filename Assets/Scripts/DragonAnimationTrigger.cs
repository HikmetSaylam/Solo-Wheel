using UnityEngine;

public class DragonAnimationTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dragon;
    private Animator[] _animator;
    private static readonly int IsOnRoad = Animator.StringToHash("IsOnRoad");

    private void Start()
    {
        _animator = dragon.GetComponents<Animator>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.tag.Equals("Character")) return;
        _animator[0].SetTrigger(IsOnRoad);
    }
}
