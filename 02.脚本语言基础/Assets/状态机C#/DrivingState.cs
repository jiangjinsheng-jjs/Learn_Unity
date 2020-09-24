using UnityEngine;

public class DrivingState : HeroineBaseState
{
    private Heroine _heroine;
    public GameObject _checkpoint;
    public Rigidbody rb;
    float timer = 0.0f;

    public DrivingState(Heroine heroine)
    {
        _heroine = heroine;
        rb = GameObject.FindObjectOfType<Rigidbody>();
        _checkpoint = GameObject.FindWithTag("CheckPoint");
        Debug.Log("进入下冲状态！");
        rb.AddForce(-Vector3.up * 600);
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("get KeyCode.UpArrow!");
            
            _heroine.SetHeroineState(new StandingState(_heroine));
        }

        timer += Time.deltaTime;
        if (timer >= 0.3f)
        {
            bool isFloor = Physics.CheckSphere(_checkpoint.transform.position, 0.01f, LayerMask.GetMask("Floor"));

            if (isFloor)
            {
                Debug.Log("跳跃结束！");
                _heroine.SetHeroineState(new StandingState(_heroine));


                return;

            }

        }
    }
}
