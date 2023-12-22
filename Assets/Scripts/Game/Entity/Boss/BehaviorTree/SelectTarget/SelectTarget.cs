
public class SelectTarget: ActionNode
{
    
    private ICanSelectTarget e;
    public override void OnInit()
    {
        e = context.GetComponent<Entity>() as ICanSelectTarget;
    }
    
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
 
    }

    protected override State OnUpdate()
    {
        e.DoSelectTarget();
        return State.Success;
    }
}
