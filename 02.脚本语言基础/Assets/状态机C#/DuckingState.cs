using UnityEngine;

public class DuckingState : HeroineBaseState
{
    private Heroine _heroine;
    public GameObject _player;
    public Rigidbody rb;

    public DuckingState(Heroine heroine)
    {

        _heroine = heroine;
        Debug.Log("进入下蹲状态！");
        _player = GameObject.FindWithTag("Player");
        _player.transform.localScale = new Vector3 (1.41f, 0.5f, 1.41f);
        _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y-0.5f, _player.transform.position.z);
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("已经在下蹲状态中！");
            return;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("get GetKeyUp.UpArrow!");
            _heroine.SetHeroineState(new StandingState(_heroine));
        }
    }
}
