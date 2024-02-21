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
    private static int _countNPC;
    private static List<NPC> _allNPC;
    protected int healthPoint;

    public NPC(int initHealth){
        if (_countNPC == 0){
            _allNPC = new List<NPC>();
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
