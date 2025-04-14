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

// 게임 시작화면 만들기.
//골드와 직업 선택, 레벨 변수 선언
int gold = 100;
bool careercheck = false;
int level = 0;

//직업 선택 배열
string[] max = new string[3];

int vcareer = 0;

max[0] = "전사";
max[1] = "마법사";
max[2] = "궁수";


//이름 입력
Console.Write("사용하실 이름이 무엇입니까? : " );
string name = Console.ReadLine();

//직업 선택창.
do
{
Console.WriteLine("다음 사용하실 직업은 무엇입니까?");
Console.WriteLine("1. 전사  2. 마법사  3. 궁수");
string career = Console.ReadLine();

int numcareer = Convert.ToInt32(career);

if(numcareer <= 0 && numcareer > 3)
{
    Console.WriteLine("숫자 1 ~ 3 중에 선택부탁드립니다.");
}
else
{
    for(int i = 0; i < max.Length; i++)
    {
        if(numcareer == 1)
        {
        max[i] = max[0];
        careercheck = true;    
        }

        else if( numcareer == 2)
        {
        max[i] = max[1];
        careercheck = true;
        }

        else 
        {
        max[i] = max[2];
        careercheck = true;
        }
    }
  
 
  
}

}while(!careercheck);

bool reTurn = false;

do{

    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
Console.WriteLine();
Console.WriteLine("1. 상태 보기");
Console.WriteLine("2. 인벤토리");
Console.WriteLine("3. 상점");
Console.WriteLine();
Console.WriteLine("원하시는 행동을 입력해주세요.");
int gameloby = int.Parse(Console.ReadLine());


//123이 아니면 다시 움직이게,
if(gameloby <= 0 && gameloby > 3 )
{
Console.WriteLine("잘못된 입력입니다.");
}

else
{
    if(gameloby == 1)
{
    int[] playerStats = new int[3];

    Random rand = new Random();

    for(int i = vcareer; i < playerStats.Length; i ++)
    {
        playerStats[i] = rand.Next(1,11);
    }
 Console.WriteLine("상태보기 창으로 입장하셨습니다.");

Console.WriteLine("현재 용사님의 정보는 다음과 같습니다.");
Console.WriteLine();

Console.WriteLine();


Console.WriteLine($"레벨 : {level}");
Console.WriteLine($"이름 : {name}");
Console.WriteLine($"직업 : {max[vcareer]}");
Console.WriteLine($"공격력 : {playerStats[0]}");
Console.WriteLine($"방어력 : {playerStats[1]}");
Console.WriteLine($"체력 : {playerStats[2]}");
Console.WriteLine($"골드 : {gold}");



Console.WriteLine("0 : 시작 화면 돌아가기");
Console.WriteLine();
Console.Write("입력 창 : ");

int back = int.Parse(Console.ReadLine());

if(back == 0)
{
    reTurn = false;
}
else
{
    Console.WriteLine("돌아가시려면 0을 눌러주세요");
    reTurn = true;
}


}

else if( gameloby == 2)
{
    Console.WriteLine("인벤토리에 입장하셨습니다.");
    Console.WriteLine($"{name} 님의 보유 중인 아이템을 관리할 수 있습니다.");
    Console.WriteLine();
    Console.WriteLine("[아이템 목록]");
    Console.WriteLine("1. 장비 관리");
    Console.WriteLine("0. 돌아가기");

Console.Write("입력창 :");

int back = int.Parse(Console.ReadLine());
if(back == 1)
{
    Console.WriteLine("장비 관리를 확인 중입니다.");
    int back1 = int.Parse(Console.ReadLine());
}
else if(back == 0)
{
    reTurn = false;
}

}
else if( gameloby == 3)
{
 Console.WriteLine("상점으로 입장하셨습니다.");
}

}

}while(!reTurn);

