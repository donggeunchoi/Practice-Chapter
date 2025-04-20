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
