using UnityEngine;

public class NormalFood : Food  
{
    public override void OnEat(SnakeHead snake)
    {
        snake.Grow();
        base.OnEat(snake);
    }
}

