// See https://aka.ms/new-console-template for more information


int Level = 1;
string name = "스파르타";
string career = "전사";
int attak = 5;
int shild = 5;
int health = 10;
int gold = 100;

bool Roby = false;


    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
Console.WriteLine();
Console.WriteLine("1. 상태 보기");
Console.WriteLine("2. 인벤토리");
Console.WriteLine("3. 상점");
Console.WriteLine();
Console.WriteLine("원하시는 행동을 입력해주세요.");
int gameloby = int.Parse(Console.ReadLine());



if(gameloby <= 0 && gameloby > 3 )
{
Console.WriteLine("잘못된 입력입니다.");
}

else
{
    if(gameloby == 1)
{
 Console.WriteLine("상태보기 창으로 입장하셨습니다.");

Console.WriteLine("현재 용사님의 정보는 다음과 같습니다.");
Console.WriteLine();

Console.WriteLine();
Console.WriteLine($"레벨 : {Level}");
Console.WriteLine($"이름 : {name}");
Console.WriteLine($"직업 : {career}");
Console.WriteLine($"공격력 : {attak}");
Console.WriteLine($"방어력 : {shild}");
Console.WriteLine($"체력 : {health}");
Console.WriteLine($"골드 : {gold}");

Roby = true;

Console.WriteLine("0 : 시작 화면 돌아가기");

}
else if( gameloby == 2)    
{
    Console.WriteLine("인벤토리에 입장하셨습니다.");
}
else
{
 Console.WriteLine("상점으로 입장하셨습니다.");
}

}

