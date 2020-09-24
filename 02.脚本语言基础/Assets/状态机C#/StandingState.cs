
using UnityEngine;

public class StandingState : HeroineBaseState
{
    private Heroine _heroine;
    public GameObject _player;

    public StandingState(Heroine heroine)
    {
        _heroine = heroine;
        Debug.Log("进入站立状态！");
        _player = GameObject.FindWithTag("Player");
        _player.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        _player.transform.position = new Vector3(_player.transform.position.x, 0.5f, _player.transform.position.z);
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("get KeyCode.UpArrow!");
            _heroine.SetHeroineState(new JumpingState(_heroine));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("get KeyCode.DownArrow!");
            _heroine.SetHeroineState(new DuckingState(_heroine));
        }
    }
}
