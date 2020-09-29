using UnityEngine;

public class JumpingState : HeroineBaseState
{
    public Rigidbody rb;
    private Heroine _heroine;
    public GameObject _checkpoint;
    float timer = 0.0f;



    public JumpingState(Heroine heroine)
    {

        rb = GameObject.FindObjectOfType<Rigidbody>();
        _checkpoint=GameObject.FindWithTag("CheckPoint");
        _heroine = heroine;
        Debug.Log("进入跳跃状态！");
        rb.AddForce(Vector3.up*400);
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("已经在跳跃状态中！");
                    

            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("get KeyCode.DownArrow!");

            _heroine.SetHeroineState(new DrivingState(_heroine));
        }

        timer += Time.deltaTime;
        if (timer >=0.3f)
        {
            bool isFloor=Physics.CheckSphere(_checkpoint.transform.position,0.01f,LayerMask.GetMask("Floor"));

            if (isFloor)
            {
                Debug.Log("跳跃结束！");
                _heroine.SetHeroineState(new StandingState(_heroine));
                
                
                return;
                
            }
            
        }    
    }
}
