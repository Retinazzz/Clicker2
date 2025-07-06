using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform healthBarFill; // ������ ������� ��������
    [SerializeField] private float maxWidth = 200f; // ������������ ������
    [SerializeField] private Artifact _artifact;
    public void UpdateHealth(float percentage)
    {
        // ������������ ����� ������
        float width = maxWidth * (percentage);

        // ������ ������
        healthBarFill.sizeDelta = new Vector2(
            Mathf.Clamp(width, 0, maxWidth),
            healthBarFill.sizeDelta.y
        );
        healthBarFill.localScale = new Vector3(-1, 1, 1);
    }
    private void Update()
    {
        UpdateHealth((float)_artifact._currenthp/_artifact._fullhp);
    }
}