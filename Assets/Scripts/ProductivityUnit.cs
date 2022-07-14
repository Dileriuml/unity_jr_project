using UnityEngine;

public class ProductivityUnit : Unit
{
    [SerializeField]
    private ResourcePile currentPile = null;

    [SerializeField]
    private float productivityMultiplier = 2;

	public ProductivityUnit()
	{
	}

    protected override void BuildingInRange()
    {
        if (currentPile == null && m_Target is ResourcePile targetPile)
        {
            currentPile = targetPile;
            currentPile.ProductionSpeed *= productivityMultiplier;
        }
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    private void ResetProductivity()
    {
        if (currentPile != null)
        {
            currentPile.ProductionSpeed /= productivityMultiplier;
            currentPile = null;
        }
    }
}