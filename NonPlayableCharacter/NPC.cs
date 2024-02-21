namespace NonPlayableCharacter;

public class Monster : NPC{
    public Monster(int initHealth) : base(initHealth) {
        ;
    }
}

public class Blacksmith : NPC{
    public Blacksmith(int initHealth) : base(initHealth) {
        ;
    }
}
public class Swordsman : NPC{
    public Swordsman(int initHealth) : base(initHealth) {
        ;
    }
}

public class NPC
{
    private static int _countNPC = 0;
    private static List<NPC>? _allNPC;
    protected int healthPoint;

    public NPC(int initHealth){
        if (_allNPC is null){
            _allNPC = [];
        }
        _countNPC++;
        _allNPC.Add(this);
        healthPoint = initHealth;
    }

    public int GetHealth(){
        return healthPoint;
    }

    public static List<NPC> GetAll(){
        return _allNPC;
    }
    public static int GetCount(){
        return _countNPC;
    }
}
