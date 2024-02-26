using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using NonPlayableCharacter;
class Program{

    static KeyValuePair<string, int> parseFoodInfo(string s){
        Stack<int> startPositions = new();

        int mode = 0;
        string key="";
        int value=0;

        for(int endPosition = 0;endPosition<s.Length;endPosition++){
            if(s[endPosition] == '('){
                startPositions.Push(endPosition+1);
            }
            if(s[endPosition] == ')'){
                int startPosition = startPositions.Pop();
                if(mode==0)
                    key = s.Substring(startPosition,endPosition-startPosition);
                else{
                    string substr = s.Substring(startPosition,endPosition-startPosition);
                    Console.WriteLine(substr);
                    bool status = int.TryParse(substr, out value);
                    if (status){
                        return new KeyValuePair<string,int>(key,value);
                    }
                }
                mode = 1;
            }
        }
        return new KeyValuePair<string,int>(key,value);
    }
    static void Main(){

        Monster monster1 = new(69);
        Monster monster2 = new(68);
        Monster monster3 = new(67);
        Monster monster4 = new(66);
        Blacksmith blacksmith1 = new(50);
        Swordsman swordsman1 = new(100);

        var foodHealthPoints = new Dictionary<string, int>(){
            {"apple",25},
            {"poison",-20},
            {"nasigoreng",50}
        }; // to be populated by configs
        var food = parseFoodInfo("(orange) (100)");
        foodHealthPoints.Add(food.Key,food.Value);

        foreach(var kv in foodHealthPoints){
            Console.WriteLine(kv.Key + kv.Value);
        }

        foreach(NPC npc in NPC.GetAll()){
            Console.WriteLine(npc.GetStatus());
        }

        blacksmith1.Die();
        monster2.Eat(foodHealthPoints["poison"]);
        monster2.Eat(foodHealthPoints["poison"]);
        monster2.Eat(foodHealthPoints["poison"]);
        monster2.Eat(foodHealthPoints["poison"]);
        Console.WriteLine("After blacksmith1 died");

        foreach(NPC npc in NPC.GetAll()){
            Console.WriteLine(npc.GetStatus());
        }

    }
}




namespace NonPlayableCharacter
{

    public class NPC
    {
        private static uint _countNPC = 0;
        private static LinkedList<NPC>? _allNPC;
        protected int healthPoint;
        private uint _NPCID;

        protected string type = "";

        public string GetStatus(){
            return _NPCID.ToString()+" "+type+" HP:"+healthPoint.ToString();
        }

        public void Eat(int foodHP){
            this.healthPoint += foodHP;
            if (this.healthPoint<=0){
                this.Die();
            }
        }

        public NPC(int initHealth)
        {
            _countNPC++;
            _NPCID = _countNPC;
            healthPoint = initHealth;

            _allNPC ??= new();
            _allNPC.AddLast(this);
        }

        public int GetHealth()
        {
            return healthPoint;
        }

        public bool Die()
        {
            if (_allNPC is null)
            {
                return false;
            }
            else
            {
                return _allNPC.Remove(this);
            }
        }

        public static LinkedList<NPC> GetAll()
        {
            return _allNPC ?? [];
        }
        public static uint GetCount()
        {
            return _countNPC;
        }
    }

    public class Monster : NPC
    {
        public Monster(int initHealth) : base(initHealth)
        {
            this.type = "Monster";
        }
    }

    public class Blacksmith : NPC
    {
        public Blacksmith(int initHealth) : base(initHealth)
        {
            this.type = "Blacksmith";
        }
    }
    public class Swordsman : NPC
    {
        public Swordsman(int initHealth) : base(initHealth)
        {
            this.type = "Swordsman";
        }
    }
}