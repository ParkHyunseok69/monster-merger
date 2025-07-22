class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<Monster>> monsters = new Dictionary<string,  List<Monster>>();
        string name;
        int level;
        int health;
        int attack;
        string continueProgram = "Y";

        while (continueProgram == "Y")
        {
            Console.WriteLine("Pick your action:\n 1. Add and Remove Monster\n 2. Show Monsters\n 3. Merge Monsters");
            int choice = Convert.ToInt16(Console.ReadLine());

            switch (choice)
            {
                case 1: //Add and Remove Monsters
                    string continueAdd = "Y";
                    while (continueAdd == "Y")
                    {
                        Console.WriteLine("Pick your action:\n 1. Add A Monster\n 2. Remove A Monster");
                        string addorRemove = Console.ReadLine()!;
                        if (addorRemove == "1")
                        {
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("Type the name and level of your monster: ");
                            Console.Write("Name: ");
                            name = Console.ReadLine()!;
                            Console.Write("Level: ");
                            level = Convert.ToInt16(Console.ReadLine());
                            health = level * 10;
                            attack = level + 5;
                            Monster m = new Monster(name, level, health, attack);
                            if (monsters.ContainsKey(name))
                            {
                                monsters[name].Add(m);
                            }
                            else
                            {
                                monsters[name] = new List<Monster> { m };
                            }
                        }
                        else if (addorRemove == "2")
                        {
                            Console.Write("Delete by type or index (type/index): ");
                            string typeorIndex = Console.ReadLine()!;
                            foreach (KeyValuePair<string, List<Monster>> entry in monsters)
                            {
                                string monsterName = entry.Key;
                                List<Monster> monsterLists = entry.Value;

                                Console.WriteLine($"--- {monsterName} ---");
                                for (int i = 0; i < monsterLists.Count(); i++)
                                {
                                    Console.WriteLine($"[{i}] {monsterLists[i]}");
                                }
                            }
                            if (typeorIndex == "type")
                            {
                                Console.Write("Monster Type: ");
                                string nameRemoveType = Console.ReadLine()!;
                                if (monsters.ContainsKey(nameRemoveType))
                                {
                                    monsters.Remove(nameRemoveType);
                                    Console.WriteLine("Removed successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Monster type doesn't exist");
                                }
                                
                            }
                            else if (typeorIndex == "index")
                            {
                                Console.Write("Monster Type: ");
                                string nameRemoveIndex = Console.ReadLine()!;
                                Console.Write("Monster Index: ");
                                int indexRemove = Convert.ToInt16(Console.ReadLine()) - 1;
                                List<Monster> monsterList = monsters[nameRemoveIndex];
                                if (indexRemove > monsterList.Count())
                                {
                                    for (int i = 0; i < monsterList.Count(); i++)
                                    {
                                        if (i == indexRemove)
                                        {
                                            monsterList.RemoveAt(i);
                                            Console.WriteLine("Removed successfully!");
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Index more than the number of monsters!");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input (Only type or index)!");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input (Only 1 or 2)!");
                        }
                        

                        Console.Write("Do you want to continue adding or removing monsters?(Y/N):");
                        continueAdd = Console.ReadLine()!;
                        Console.WriteLine("-----------------------");
                    }
                    break;

                case 2: // Show Monsters
                    Console.WriteLine("Pick your action:\n 1. Show All\n 2. Show a specific monster");
                    int continueShow = Convert.ToInt16(Console.ReadLine());
                    if (continueShow == 1)
                    {
                        foreach (KeyValuePair<string, List<Monster>> entry in monsters)
                        {
                            string monsterName = entry.Key;
                            List<Monster> monsterList = entry.Value;

                            Console.WriteLine($"--- {monsterName} ---");
                            for (int i = 0; i < monsterList.Count(); i++)
                            {
                                Console.WriteLine($"[{i}] {monsterList[i]}");
                            }
                        }
                    }
                    else if (continueShow == 2)
                    {
                        Console.Write("Which Monster you want to show?");
                        string key = Console.ReadLine()!;
                        if (monsters.ContainsKey(key))
                        {
                            foreach (Monster m in monsters[key])
                            {
                                Console.WriteLine(m);
                            }
                        }
                        else
                        {
                            Console.WriteLine("That monster does not exist.!");
                        }
                    }
                    break;
                case 3: //Merge Monsters
                    Console.WriteLine("Merging Instructions: Needs to be same Level and type.");
                    Console.WriteLine("Pick the monster you want to merge by index.");
                    foreach (KeyValuePair<string, List<Monster>> entry in monsters)
                    {
                        string monsterName = entry.Key;
                        List<Monster> monsterList = entry.Value;

                        Console.WriteLine($"--- {monsterName} ---");
                        for (int i = 0; i < monsterList.Count(); i++)
                        {
                            Console.WriteLine($"[{i}] {monsterList[i]}");
                        }
                    }
                    Console.Write("Pick which monster you want to merge: ");
                    string user_input = Console.ReadLine()!;
                    if (monsters.ContainsKey(user_input) && monsters[user_input].Count >= 2)
                    {
                        List<Monster> monsterList = monsters[user_input];
                        int index1 = -1;
                        int index2 = -1;
                        for (int i = 0; i < monsterList.Count(); i++)
                        {
                            for (int j = i + 1; j < monsterList.Count(); j++)
                            {
                                if (monsterList[i].Level == monsterList[j].Level)
                                {
                                    index1 = i;
                                    index2 = j;

                                    Monster m = monsterList[index1];
                                    int newLevel = m.Level + 1;
                                    int newHealth = 10 + (newLevel * 15);
                                    int newAttack = 5 + (newLevel * 2);
                                    Monster evolved_m = new Monster(user_input, newLevel, newHealth, newAttack);
                                    if (index1 > index2)
                                    {
                                        monsterList.RemoveAt(index1);
                                        monsterList.RemoveAt(index2);
                                    }
                                    else
                                    {
                                        monsterList.RemoveAt(index2);
                                        monsterList.RemoveAt(index1);
                                    }
                                    monsterList.Add(evolved_m);
                                    Console.WriteLine($"Merged two level {m.Level} {user_input}s into one level {newLevel}!");
                                }

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough monsters of that name to merge.!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
            Console.Write("Do you want to continue the program?(Y/N):");
            continueProgram = Console.ReadLine()!;
            Console.WriteLine("-----------------------");

        }
    }
}


class Monster
{
    public string Name;
    public int Level;
    public int Health;
    public int Attack;

    public Monster(string name, int level, int health, int attack)
    {
        Name = name;
        Level = level;
        Health = health;
        Attack = attack;
    }

    public override string ToString()
    {
        return $"Name: {Name} Lv.{Level} | HP: {Health} | ATK: {Attack}";
    }
}


