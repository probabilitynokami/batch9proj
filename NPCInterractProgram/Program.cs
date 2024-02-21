// See https://aka.ms/new-console-template for more information
using NonPlayableCharacter;

Monster monster1 = new(69);
Monster monster2 = new(68);
Monster monster3 = new(67);
Monster monster4 = new(66);
Blacksmith blacksmith1 = new(50);
Swordsman swordsman1 = new(100);

Console.WriteLine("total npcs: "+NPC.GetCount());

var npcs = NPC.GetAll();

foreach(NPC npc in npcs){
    Console.WriteLine(npc.GetHealth());
}

