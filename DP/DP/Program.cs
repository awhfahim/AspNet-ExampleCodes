// See https://aka.ms/new-console-template for more information

int[] arr = new int[49];
for(int i = 0; i < arr.Length; i++)
{
    arr[i] = -1;
}
int ans = 0;
void fun(int n)
{
    if (n < 0) return;
    if (arr[n] != -1)
    {
        ans += arr[n];
        return;
    }
    
    if (n == 0)
    {
        ans++;
        return;
    }
    fun(n-1);
    fun(n-2);
    arr[n] = ans;

}

//fun(45);
Console.WriteLine();

int[] squares = [1, 4, 9, 16];

int f(int n)
{
     if (n < 0) return 0;
    if(n == 0) return 1;
    int total = 0;
    for(int i = 1; i*i <= 13; i++)
    {
        total += f(n - i * i);
    }
    return total;
}

var r = f(13);
Console.WriteLine();