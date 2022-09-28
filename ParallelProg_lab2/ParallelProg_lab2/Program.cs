using System.Threading;
using System.Diagnostics;

int iterations = 100000;
int[] threads_count = new int[] { 1, 2, 4 };


foreach (var thread in threads_count)
{
    Stopwatch time = new Stopwatch();
    int shift = iterations - (((int)iterations / thread) * thread);
    int start_i = 0;

    time.Start();
    for (int i = 0; i < thread; i++)
    {
        int end_i = start_i + ((int)iterations / thread) + shift;
        Thread threads = new Thread(() => Hrucoin(start_i, end_i ));
        //time.Start();
        threads.Start();
        threads.Join();
        //time.Stop();
        shift = 0;
        start_i = end_i;
    }
    time.Stop();
    Console.WriteLine($"{thread}: {time.Elapsed.Milliseconds}");
}

static void Hrucoin(int start, int end)
{
    double hrucoins = 0;
    for (int i = start; i < end; i++)
    {
        hrucoins += 0.01;
    }
    Console.WriteLine(hrucoins);
}