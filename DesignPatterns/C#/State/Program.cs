using System;

namespace State
{
    public enum ProgramType
    {
        Cotton,
        Linen,
        Normal
    }

    public class Context
    {
        public Context(bool lidOpen, bool tapOpened, int spinSpeed, ProgramType type, int waterTemperature, int duration)
        {
            LidOpen = lidOpen;
            WaterTapOpened = tapOpened;
            SpinSpeed = spinSpeed;
            ProgramType = type;
            WaterTemperature = waterTemperature;
            Duration = duration;
        }
        public State CurrentState { set; get; }
        public void Next()
        {
            CurrentState.GoNext();
        }

        public bool LidOpen { set; get; }
        public bool WaterTapOpened { set; get; }
        public int SpinSpeed {set;get;}
        public ProgramType ProgramType { set; get; }
        public int WaterTemperature { set; get; }
        public int Duration { set; get; }
    }

    public abstract class State
    {
        protected Context m_context;
        public abstract void GoNext();
    }

    public class ProgramStart : State
    {
        public ProgramStart(Context context)
        {
            m_context = context;
        }
        public override void GoNext()
        {
            Console.WriteLine($"Program started. Expected to finish in {m_context.Duration} minutes.");
            m_context.CurrentState = new InitialChecks(m_context);
        }
    }

    public class Null : State
    {
        public Null(Context context)
        {
            m_context = context;
        }
        public override void GoNext(){}
    }

    public class ProgramStopped : State
    {
        public ProgramStopped(Context context)
        {
            m_context = context;
        }
        public override void GoNext()
        {
            Console.WriteLine("Program stopped.");
            m_context.CurrentState = new Null(m_context);
        }
    }

    public class Errors : State
    {
        public Errors(Context context)
        {
            m_context = context;
        }
        public override void GoNext()
        {
            Console.WriteLine("Errors occurred.");
            m_context.CurrentState = new ProgramStopped(m_context);
        }
    }

    public class WashingCycle : State
    {
        public WashingCycle(Context context)
        {
            m_context = context;
        }
        public override void GoNext()
        {
            if (m_context.SpinSpeed > 500 && m_context.ProgramType == ProgramType.Linen)
            {
                Console.WriteLine($"Speed to high for program type { m_context.ProgramType}");
                m_context.CurrentState = new Errors(m_context);
            }
            else
            {
                Console.WriteLine($"Washing cycle started, program: \"{m_context.ProgramType}\", water temperature: {m_context.WaterTemperature} degrees.");
                m_context.CurrentState = new RinceCycle(m_context);
            }
        }
    }

    public class RinceCycle : State
    {
        public RinceCycle(Context context)
        {
            m_context = context;
        }
        public override void GoNext()
        {
            Console.WriteLine("Rince cycle running.");
            m_context.CurrentState = new SpinCycle(m_context);
        }
    }

    public class SpinCycle : State
    {
        public SpinCycle(Context context)
        {
            m_context = context;
        }
        public override void GoNext()
        {
            Console.WriteLine($"Spin cycle running at {m_context.SpinSpeed} rot/min.");
            m_context.CurrentState = new ProgramStopped(m_context);
        }
    }

    public class InitialChecks : State
    {
        public InitialChecks(Context context)
        {
            m_context = context;
        }
        public override void GoNext()
        {
            Console.WriteLine("Performing initial checks.");
            if(m_context.LidOpen == true)
            {
                m_context.CurrentState = new Errors(m_context);
            } else if (m_context.WaterTapOpened == false)
            {
                m_context.CurrentState = new Errors(m_context);
            } else
            {
                m_context.CurrentState = new WashingCycle(m_context);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(false, true, 1000, ProgramType.Linen, 30, 45);
            context.CurrentState = new ProgramStart(context);
            while (!(context.CurrentState is Null))
            {
                context.Next();
            }
            Console.ReadKey();
         }
    }
}
