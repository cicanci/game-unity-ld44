using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private AttributeType _attributeType = default;

    [SerializeField]
    private Character _character = null;

    public void OnClick()
    {
        _character.IncreaseAttribute(_attributeType);
    }
}
