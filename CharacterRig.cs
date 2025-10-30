using UnityEngine;

namespace Walkabout.Player
{
    [DisallowMultipleComponent]
    public class CharacterRig : MonoBehaviour, ICharacterRig
    {
        [SerializeField] Transform head;
        [SerializeField] Transform viewPivot;
        public Transform Body => transform;
        public Transform Head => head;
        public Transform ViewPivot => viewPivot;

        void OnValidate()
        {
            if (head == null)
                head = transform.Find("Head");
            if (head == null)
                Debug.LogError("No head found automatically as child of CharacterRig", this);
            if (viewPivot == null)
                viewPivot = head;
        }
    }
    /// <summary>
    /// Represents an character with body, head, and eye line transforms.
    /// </summary>
    /// <remarks>The ICharacterRig interface provides access to key transforms that define the agent's physical
    /// representation and orientation in a scene. Implementations may use these transforms for positioning, animation,
    /// or interaction logic.
    /// 
    /// If you are using a CharacterController component, position your mesh
    /// such that the feet are at (height/2) - skinwidth or it will float.
    /// </remarks>
    public interface ICharacterRig
    {
        Transform Body { get; }
        Transform ViewPivot { get; }
        Transform Head { get; }
    }

}
