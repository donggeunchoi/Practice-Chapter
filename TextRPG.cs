// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Dynamic;
using System.Security;


namespace SpartaTownGame
{
    // 캐릭터 정보를 저장하는 클래스
    class Character
    {
        public int Level { get; set; } = 01;
        public string Name { get; set; }
        public string Job { get; set; }
        public int AttackPower { get; set; } = 10;
        public int Defense { get; set; } = 5;
        public int Health { get; set; } = 100;
        public int Gold { get; set; } = 1500;


    }
    //장시 사용유무에 대한 메서드 선언.
    public interface IEquippable
    {
        void Equip();
        void Unequip();
        bool IsEquipped { get; set; }
        string Getstatus();
    }
    class Item : IEquippable
    {
        //자동 프로퍼티 실행.
        public string Name { get; }
        public string Description { get; }
        public int AttackPower { get; }
        public int Defense { get; }
        public int Gold { get; }
        public bool IsEquipped { get; set; }

        //생성자 
        public Item(string name, string description, int attackPower, int defense, int gold)
        {
            Name = name;
            Description = description;
            AttackPower = attackPower;
            Defense = defense;
            Gold = gold;
            IsEquipped = false;
        }



        //장착에 대한 메서드
        public void Equip()
        {
            if (!IsEquipped)
            {
                IsEquipped = true;
                Console.WriteLine($"{Name}을(를) 장착했습니다");
            }
            else
            {
                Console.WriteLine($"{Name}은(는) 이미 장착되어 있습니다.");
            }

        }

        //해제에 대한 메서드.
        public void Unequip()
        {
            if (IsEquipped)
            {
                IsEquipped = false;
                Console.WriteLine($"{Name}을(를) 해제했습니다.");
            }
            else
            {
                Console.WriteLine($"{Name}은(는) 이미 해제 상태입니다.");
            }

        }
        // 상태 반환 메서드
        public string Getstatus()
        {
            return IsEquipped ? "[E]" : " ";
        }

    }

    //인벤토리 클래스
    class Inventory
    {
        public List<Item> Items { get; }
        //웨폰이라는 무기 목록을 저장할 리스트를 만들었어요.


        //인벤토리를 생성합시다.
        public Inventory()
        {
            //웨폰은 새로은 리스트를 만듭니다.
            Items = new List<Item>();

        }

        //무기 리스트를 반환하는 메서드가 필요.
        public List<Item> GetWeapons()
        {
            return Items;
        }
        //아이템 구매 메서드.
        public void PurchaseItem(Item item)
        {
            Items.Add(item);
            Console.WriteLine($"{item.Name}을(를) 인벤토리에 추가했습니다.");
        }
        // 아이템 소유 여부 확인 메서드
        public bool selectedItem(Item item)
        {
            return Items.Contains(item);
        }
        //아이템 판매 메서드.
        public void SaleItem(Item item)
        {
            Items.Remove(item);
            Console.WriteLine($"{item.Name}을(를) 인벤토리에 뺐습니다.");
        }

    }

    class Store
    {
        private Character player = new Character();
        private List<Item> storeItem = new List<Item>();
        private Inventory inventory = new Inventory();

        public Store()
        {
            storeItem = new List<Item>();
            itemmake();

        }


        public void itemmake()
        {
            storeItem.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 5, 1000));
            storeItem.Add(new Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9, 0));
            storeItem.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 15, 3500));
            storeItem.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 0, 600));
            storeItem.Add(new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 0, 1500));
            storeItem.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, 0));
            storeItem.Add(new Item("스파르타의 화살", "스파르타의 전사들이 사용했다는 전설의 활입니다.", 5, 0, 200));
            storeItem.Add(new Item("나무 지팡이", "나무인가 돌인가 무게감에서 나타나는 중후한 마법지팡이", 5, 0, 500));
        }
        public List<Item> GetItems()
        {
            return storeItem;
        }


        //아이템 구매 메서드.
        public void Purchase(Character player, Item item, Inventory inventory)
        {

            if (!storeItem.Contains(item))
            {
                Console.WriteLine("아이템이 상점에 없습니다.");
            }

            else if (inventory.selectedItem(item))
            {
                Console.WriteLine("이미 소지하고 있는 아이템입니다.");
                return;
            }

            else if (player.Gold < item.Gold)
            {
                Console.WriteLine("골드가 부족합니다.");
                return;
            }

            inventory.PurchaseItem(item);
            player.Gold -= item.Gold;
            player.AttackPower += item.AttackPower;
            player.Defense += item.Defense;
            storeItem.Remove(item);
            Console.WriteLine($"{item.Name}을(를) 구매하였습니다.");
        }

        public void SaleItem(Character player, Item item, Inventory inventory)
        {
            Console.WriteLine();
            item.Unequip();
            inventory.SaleItem(item);
            player.Gold += item.Gold * 85 / 100;
            player.AttackPower -= item.AttackPower;
            player.Defense -= item.Defense;
            
            storeItem.Add(item);
            Console.WriteLine($"{item.Name}을(를) 판매하였습니다.");
        }

    }
    class Dungeon
    {
        
        public string Name { get; set; }
        public int RecommendDefence { get; set; }
        public int BaseReward { get; set; }

        //던전 생성자? 생성?
        public Dungeon(string name, int recommendDefence, int baseReward)
        {
            Name = name;
            RecommendDefence = recommendDefence;
            BaseReward = baseReward;
        }


    }
        // 게임의 흐름을 관리하는 클래스
    class Game
    {
        private Character player = new Character();
        private Inventory inventory = new Inventory();
        private Store store = new Store();
    

         // 생성자: 캐릭터 이름을 입력받아 생성
        public Game()
        {
            Console.Write("캐릭터의 이름을 입력해주세요: ");
            player = new Character();
            player.Name = Console.ReadLine();

            Console.WriteLine("\n직업을 선택해주세요.");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 궁수");

            while (true)
            {
                Console.Write(">> ");
                string jobinput = Console.ReadLine();
                switch (jobinput)
                {
                    case "1":
                        player.Job = "전사";
                        player.AttackPower += 5;
                        player.Defense += 3;
                        break;
                    case "2":
                        player.Job = "마법사";
                        player.AttackPower += 7;
                        player.Defense += 1;
                        break;
                    case "3":
                        player.Job = "궁수";
                        player.AttackPower += 6;
                        player.Defense += 2;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                        continue;
                }
                break;
            }
            Console.WriteLine($"\n{player.Name} 님, {player.Job} 직업으로 생성하셨습니다.");
        }

        public void DisplayMenu()
        {
            bool displaymenu = true;

            while (displaymenu)
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 휴식");
                Console.WriteLine("5. 던전 입장");
                Console.WriteLine("6. 게임 종료하기");
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

               string input = Console.ReadLine();
                int choice;

                // 입력이 정수인지 확인
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ViewStatus();
                            break;
                        case 2:
                            ShowInventory();
                            break;
                        case 3:
                            VisitStore();
                            break;
                        case 4:
                            resting();
                            break;
                        case 5:
                            dungeon();
                            break;    
                        case 6:
                            Console.WriteLine("게임을 종료합니다. 감사합니다!");
                            Pause();
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    displaymenu = true;
                }
            }
        }

        public void dungeon()
        {
            Dungeon easy = new Dungeon("쉬운 던전", 5, 1000);
            Dungeon normal = new Dungeon("일반 던전", 11, 1500);
            Dungeon hard = new Dungeon("어려운 던전", 17, 2000);

            bool dungeon = true;
            
            while (dungeon)
            {
                Console.Clear();
                Console.WriteLine("[던전입장]");
                Console.WriteLine();
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

                Console.WriteLine("1. 쉬운 던전   | 방어력 5 이상 권장");
                Console.WriteLine("2. 일반 던전   | 방어력 11 이상 권장");
                Console.WriteLine("3. 어려운 던전  | 방어력 17 이상 권장");

                Console.WriteLine("0. 나가기");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string output = Console.ReadLine();

                int choice;
                if (int.TryParse(output, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AttemptDungeonRun(player, easy);
                            break;
                        case 2:
                            AttemptDungeonRun(player, normal);
                            break;
                        case 3:
                            AttemptDungeonRun(player, hard);
                            break;
                        case 0:
                            DisplayMenu();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                            break;            
                    }
                }
            }
        }
        //던전 시도 메서드.        
        static void AttemptDungeonRun(Character player, Dungeon dungeon)
        {
            Random random = new Random();
            bool success = true;

            if (player.Defense < dungeon.RecommendDefence)
            {
                int chance = random.Next(100);
                if (chance < 40)
                {
                    success = false;
                }
            }

            if (!success)
            {
                //던전 실패
                Console.WriteLine("던전 실패");
                Console.WriteLine("보상을 받지 못했습니다.");
                int Healthno = player.Health / 2;
                player.Health -= Healthno;
                Console.WriteLine($"체력이 {player.Health + Healthno}에서 {Healthno}로 감소했습니다.");
            }
            else
            {
                //던전 클리어.
                Console.WriteLine("축하합니다. 던전 클리어");
                Console.WriteLine($"{dungeon.Name}을 클리어 했습니다.");

                //체력소모계산.
                //방어어려움.설정 = player방어력 - 던전의 추천방어력.
                int defenseDifference = player.Defense - dungeon.RecommendDefence;
                //최소범위 설정.
                int minloss = 20 + defenseDifference;
                //최대범위 설정.
                int maxloss = 35 + defenseDifference;
                //마이너스 방지.
                if (minloss < 0)
                {
                    minloss = 0;
                }
                if (maxloss < 0)
                {
                    maxloss = 0;
                }
                //체력 깍이는 수준. = 랜덤(최소에서, 최대에 +1)
                int healthconsumption = random.Next(minloss, maxloss + 1);
                player.Health -= healthconsumption;

                //골드 계산
                //골드는. 던전의 보상.
                int totalGold = dungeon.BaseReward;
                int additionalpersent = random.Next(player.AttackPower, (player.AttackPower * 2) + 1);
                double additional = totalGold * (additionalpersent / 100.0d);
                totalGold += (int)additional;
                player.Gold += totalGold;

                //결과
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {player.Health + healthconsumption} -> {player.Health}");
                Console.WriteLine($"골드 {player.Gold - totalGold} G -> {player.Gold}G");
            }
        }
        // 캐릭터의 상태를 표시하는 메서드
        public void ViewStatus()
        {

            bool viewStatue = true;

            while (viewStatue)
            {
                Console.Clear();
                Console.WriteLine("=== 캐릭터 상태 ===");
                Console.WriteLine($"Lv. {player.Level}");
                Console.WriteLine($"이름: {player.Name}");
                Console.WriteLine($"Chad ( {player.Job} )");
                Console.WriteLine($"공격력: {player.AttackPower}");
                Console.WriteLine($"방어력: {player.Defense} ");
                Console.WriteLine($"체력: {player.Health} ");
                Console.WriteLine($"Gold: {player.Gold}");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string output = Console.ReadLine();

                int choice;
                if (int.TryParse(output, out choice))
                {
                    switch (choice)
                    {
                        case 0:
                            DisplayMenu();
                            break;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
        }

            // 인벤토리 기능의 눈으로 볼 수 있게 만드는 메서드
        public void ShowInventory()
        {

            bool Showinventory = true;

            //불러오기.
            List<Item> weapons = inventory.GetWeapons();

            while (Showinventory)
            {
                Console.Clear();
                Console.WriteLine("보유 중인 아이템을 확인 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");

                if (inventory.Items.Count == 0)
                {
                    Console.WriteLine("소지한 아이템이 없습니다.");
                }
                else
                {
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Item item = weapons[i];
                        Console.WriteLine($"{i + 1} {item.Getstatus()} 아이템 이름 : {item.Name} / {item.Description} / 공격력 : {item.AttackPower} / 방어력 : {item.Defense} ");
                    }
                }

                Console.WriteLine("1. 장비 관리");
                Console.WriteLine("0. 나가기");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string output = Console.ReadLine();

                int choice;
                if (int.TryParse(output, out choice))
                {
                    switch (choice)
                    {
                        case 0:
                            DisplayMenu();
                            break;

                        case 1:
                            Equipment();
                            break;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
        }

        public void Equipment()
        {

            bool Equipment = true;

            while (Equipment)
            {
                Console.Clear();
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

                Console.WriteLine("[아이템 목록]");

                List<Item> weapons = inventory.GetWeapons();

                if (weapons.Count == 0)
                {
                    Console.WriteLine("소지한 아이템이 없습니다.");
                }
                else
                {
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Item item = weapons[i];
                        Console.WriteLine($"{i + 1} {item.Getstatus()} 아이템 이름 : {item.Name} / {item.Description} / 공격력 : {item.AttackPower} / 방어력 : {item.Defense} ");
                    }
                }

                Console.WriteLine("0. 나가기");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string output = Console.ReadLine();

                int choice;
                if (int.TryParse(output, out choice))
                {
                    if (choice == 0)
                    {
                        ShowInventory();
                    }
                    else if (choice > 0 && choice <= weapons.Count)
                    {
                        Item selectedItem = weapons[choice - 1];
                        if (!selectedItem.IsEquipped)
                        {
                            selectedItem.Equip();
                        }
                        else
                        {
                            selectedItem.Unequip();
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
        }

        // 상점 기능의 플레이스홀더 메서드
        public void VisitStore()
        {

            bool visitstore = true;
            while (visitstore)
            {

                Console.Clear();
                Console.WriteLine($"보유 골드 : {player.Gold}");
                Console.WriteLine("1. 구매하기");
                Console.WriteLine("2. 판매하기");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string output = Console.ReadLine();

                int choice;

                if (int.TryParse(output, out choice))
                {
                    if (choice == 0)
                    {
                        visitstore = false;
                    }
                    else if (choice == 1)
                    {
                        Buy();
                    }
                    else if (choice == 2)
                    {
                        Sale();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
        }

        //구매창를 위한 메서드.
        public void Buy()
        {
            bool buy = true;

            while (buy)
            {
                Console.Clear();
                Console.WriteLine($"보유 골드 : {player.Gold}");
                Console.WriteLine("[상품 목록]");
                Console.WriteLine();

                List<Item> storeItems = store.GetItems();

                for (int i = 0; i < storeItems.Count; i++)
                {
                    Item item = storeItems[i];
                    Console.WriteLine($"-{i + 1} {item.Name} / {item.Description} / 공격력 : {item.AttackPower} / 방어력 : {item.Defense} / 필요 골드 : {item.Gold}");
                }

                Console.WriteLine("구매할 아이템의 이름을 입력하세요");

                Console.WriteLine("0. 나가기");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string output = Console.ReadLine();

                int choice;

                if (int.TryParse(output, out choice))
                {
                    if (choice == 0)
                    {
                        buy = false;
                    }
                    else if (choice > 0 && choice <= storeItems.Count)
                    {
                         Item selectedItem = storeItems[choice - 1];
                        store.Purchase(player ,selectedItem, inventory);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
                
            }
        }
        //판매창를 위한 메서드.
        public void Sale()
        {
            bool sale = true;
            while (sale)
            {
                Console.Clear();
                 Console.WriteLine($"보유 골드 : {player.Gold}");
                Console.WriteLine("[판매할 물품]");

                List<Item> weapons = inventory.GetWeapons();

                if (weapons.Count == 0)
                {
                    Console.WriteLine("판매할 아이템이 없습니다.");
                }
                else
                {
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Item item = weapons[i];
                        Console.WriteLine($"{i + 1} {item.Getstatus()} 아이템 이름 : {item.Name} / {item.Description} / 공격력 : {item.AttackPower} / 방어력 : {item.Defense} ");
                    }
                }
                Console.WriteLine("0. 나가기");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string output = Console.ReadLine();

                int choice;

                if (int.TryParse(output, out choice))
                {
                    if (choice == 0)
                    {
                        sale = false;
                    }
                    else if (choice > 0 && choice <= weapons.Count)
                    {
                         Item selectedItem = weapons[choice - 1];
                        store.SaleItem(player ,selectedItem, inventory);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            
            }
        }
        public void resting()
        {
            bool resting = true;
            while (resting)
            {
                Console.WriteLine($"500 G를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)");

                Console.WriteLine();
                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string output = Console.ReadLine();

                int choice;
                if (int.TryParse(output, out choice))
                {
                    switch (choice)
                    {
                        case 0:
                            DisplayMenu();
                            break;

                        case 1:
                            if (player.Gold <= 0)
                            {
                                Console.WriteLine("골드가 부족합니다.");
                                break;
                            }
                            else
                            {
                                player.Gold -= 500;
                                player.Health = 100;
                                Console.WriteLine("체력이 100이 되었습니다.");
                            }
                            break;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }

            }
        }

        private void Pause()
        {
            Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
        class Program
        {
            static void Main(string[] args)
            {
                Game game = new Game();
                game.DisplayMenu();

            }
        }
    }
}

