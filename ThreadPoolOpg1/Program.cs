using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ThreadPoolOpg1
{
    public class ProcessClass
    {
        public void Process(object callback)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {

                }
            }
        }

        public void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        public void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem( new WaitCallback(Process));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProcessClass pc = new ProcessClass();
            Stopwatch mywatch = new Stopwatch();

            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();

            pc.ProcessWithThreadPoolMethod();
            mywatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());

            mywatch.Reset();

            Console.WriteLine("Thread Execution");
            mywatch.Start();
            pc.ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());

            //Start() method:
            //the system changes the state of the thread to running, meaning its activated

            //Sleep() method:
            //The thread sleeps for an amount of miliseconds

            //Suspend() method:
            //The thread gets suspended, but the thread is allowed to reach a "safe point" before it is actually suspended.

            //Resume() method:
            //Resumes a suspended thread

            //Abort() method:
            //The thread gets terminated via an abort exception

            //Join() method:
            //Joins the main thread with the instance the method its called upon, meaning the main thread will wait on the joined thread.
        }
    }
}
