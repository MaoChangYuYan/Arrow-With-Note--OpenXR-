using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// 箭袋
/// </summary>
public class Quiver : XRBaseInteractable
{
    public GameObject arrowPrefab = null;

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(CreateAndSelectArrow);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(CreateAndSelectArrow);
    }

   /// <summary>
    /// 手选择箭袋时，实例化箭预制体，强制手抓取箭
    /// </summary>
    /// <param name="args"></param>
    private void CreateAndSelectArrow(SelectEnterEventArgs args)
    {
        // Create arrow, force into interacting hand
        Arrow arrow = CreateArrow(args.interactor.transform);
        interactionManager.ForceSelect(args.interactor, arrow);
    }

    private Arrow CreateArrow(Transform orientation)
    {
        // Create arrow, and get arrow component
        GameObject arrowObject = Instantiate(arrowPrefab, orientation.position, orientation.rotation);
        return arrowObject.GetComponent<Arrow>();
    }
}
