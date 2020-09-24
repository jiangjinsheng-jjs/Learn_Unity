using UnityEngine;

public class TestHeroine : MonoBehaviour
{
    private Heroine _heroine;
    
    // 初始化调用，先执行
    

    void Start()
    {
    
    _heroine = new Heroine();
    }

    // 每帧调用一次
    void Update()
    {
        _heroine.Update();
    }
}
