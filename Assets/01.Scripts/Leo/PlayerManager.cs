using MKDir;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public Player Player { get; private set; }
    public Transform PlayerTransform => Player.transform;
    public PlayerAnimation PlayerAnimation { get; set; }
    public Health PlayerHealth { get; set; }
    
    

    protected override void Awake()
    {
        Player = FindObjectOfType<Player>();
        PlayerAnimation = Player.GetComponent<PlayerAnimation>();
        PlayerHealth = Player.GetComponent<Health>();
    }
}