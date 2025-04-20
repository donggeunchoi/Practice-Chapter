// See https://aka.ms/new-console-template for more information

//사용자로부터 입력 받기
string name;
string age;

Console.WriteLine("이름이 무엇입니까?");
name = Console.ReadLine();

Console.WriteLine("그렇다면 당신의 나이는 무엇입니까?");
age = Console.ReadLine();

int numberAge = Convert.ToInt32(age);

Console.WriteLine($"당신의 이름은 {name}이고, 나이는 {numberAge}입니다.");


//간단한 사칙연산 계산기 만들기
string number1;
string number2;

Console.WriteLine("첫번째 숫자를 입력해주세요");
number1 = Console.ReadLine();

int num1 = Convert.ToInt32(number1);

Console.WriteLine("두번째 숫자를 입력해주세요.");
number2 = Console.ReadLine();

int num2 = Convert.ToInt32(number2);

int plous = num1 + num2;
int miner = num1 - num2;
int rhqgkrl = num1 * num2;
int sksnrl = num1 % num2;

Console.WriteLine($"결과는 다음과 같습니다. 더하기{plous}, 빼기{miner}, 곱하기{rhqgkrl}, 나누기{sksnrl}");

//온도 계산하기
Console.WriteLine("섭씨온도를 입력해주세요, 화씨 온도로 변환해드릴께요.");
string Temperature = Console.ReadLine();

float cTemperature = Convert.ToInt32(Temperature);

float fTemperature = (cTemperature * 9 / 5) + 32;

Console.WriteLine($"화씨 온도는 : {fTemperature}입니다.");


//bmi 계산하기(수정 필요)

Console.WriteLine(" 본인의 몸무게는 몇입니까?");
string Kgname = Console.ReadLine();

double Kg = Convert.ToInt32(Kgname);

Console.WriteLine(" 그렇다면 본인의 키는 몇인가요?");
string mname = Console.ReadLine();

double cm = Convert.ToInt32(mname);

double cmtwo = (cm / 100);
double BMIm = cmtwo * cmtwo;

double BMI = Kg / BMIm;

Console.WriteLine(BMIm);

Console.WriteLine($"당신의 BMI : {BMI}");

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;


namespace SpartaTownGame
{
// 캐릭터 정보를 저장하는 클래스
    class Character
    {
        public int Level { get; set; } = 1;
        public string Name { get; set; }
        public string Job { get; set; }
        public int AttackPower { get; set; } = 10;
        public int Defense { get; set; } = 5;
        public int Health { get; set; } = 100;
        public int Gold { get; set; } = 0;
        
    }

    // 게임의 흐름을 관리하는 클래스
    class Game
    {
        private Character player;

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

            while(true)
            {
                Console.Write(">> ");
                string jobinput = Console.ReadLine();
                switch(jobinput)
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
        
        
        // 게임 메뉴를 표시하고 사용자 입력을 처리하는 메서드
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
                Console.WriteLine("4. 게임 종료");
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

        // 캐릭터의 상태를 표시하는 메서드
        public void ViewStatus()
        {
            bool viewStatue = true;

            while(viewStatue)
            {
            Console.Clear();
            Console.WriteLine("=== 캐릭터 상태 ===");
            Console.WriteLine($"레벨: {player.Level}");
            Console.WriteLine($"이름: {player.Name}");
            Console.WriteLine($"직업: {player.Job}");
            Console.WriteLine($"공격력: {player.AttackPower}");
            Console.WriteLine($"방어력: {player.Defense}");
            Console.WriteLine($"체력: {player.Health}");
            Console.WriteLine($"Gold: {player.Gold}");

            Console.WriteLine("0. 나가기");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string output = Console.ReadLine();

            int choice;
                if (int.TryParse(output, out choice))
                {
                    switch(choice)
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
        //장시 사용유무에 대한 메서드 선언.
        public interface IEquippable
        {
            void Equip();
            void Unequip();
            bool IsEquipped{get; set;}
        }
        //아이템에 대한 메서드
        public class Item
        {
            public string Name {get;}
            public string Description {get;}
            public int AttackPower{get;}
            public int Defense{get;}
            public bool IsEquipped {get; set;}

            public Item(string name, string description, int attackPower, int defense, bool IsEquipped )
            {
                Name = name;
                Description = description;
                AttackPower = attackPower;
                Defense = defense;
                IsEquipped = false;
            }

            private Item weapons;

            //사용에 대한 메서드
            public void Equip()
            {
                IsEquipped = true;
                Console.WriteLine($"{weapons.Name}을(를) 장착했습니다");
            }

            //해제에 대한 메서드.
            public void Unequip()
            {
                IsEquipped = false;
                Console.WriteLine($"{weapons.Name}을(를) 해제했습니다.");
            }
        }

        
       
        // 인벤토리 기능의 플레이스홀더 메서드
        public void ShowInventory()
        {
            

            bool Showinventory = true;

            while(Showinventory)
            {
            Console.Clear();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine("[아이템 목록]");

            Console.WriteLine("1. 장비 관리");
            Console.WriteLine("0. 나가기");
            
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string output = Console.ReadLine();

            int choice;
                if (int.TryParse(output, out choice))
                {
                    switch(choice)
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

        //장비 관리의 플레이스 홀더 메서드
        public void Equipment()
        {
            bool Equipment = true;

            while(Equipment)
            {
            Console.Clear();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine("[아이템 목록]");

            Console.WriteLine("0. 나가기");
            
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string output = Console.ReadLine();

            int choice;
                if (int.TryParse(output, out choice))
                {
                    switch(choice)
                    {
                        case 0:
                        ShowInventory();
                        break;

                        default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                    }
                }
            }
        }
        
        // 상점 기능의 플레이스홀더 메서드
        public void VisitStore()
        {
            bool visitstore = true;
            while(visitstore)
            {

            Console.Clear();
            Console.WriteLine("상점 오픈 준비 중입니다.");
            
            Console.WriteLine("0. 나가기");
            
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string output = Console.ReadLine();

            int choice;

                if (int.TryParse(output, out choice))
                {
                    switch(choice)
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

        
        // 사용자가 계속 진행할 수 있도록 일시 정지하는 메서드
        private void Pause()
        {
            Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
    } 

    // 프로그램의 시작점
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.DisplayMenu();
        }
    }

}
