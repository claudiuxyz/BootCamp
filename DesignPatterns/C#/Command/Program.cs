using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    //------------ Receiver-------------
    public class Light
    {
        private bool state = false;

        public void SwitchOff()
        {
            state = false;
            OnStateChange();
        }

        public void SwitchOn()
        {
            state = true;
            OnStateChange();
        }

        public void OnStateChange()
        {
            Console.WriteLine(String.Format("Light is {0}",state?"On":"Off"));
        }
    }

    //------------- Commands -------------------
    public abstract class Command
    {
        public abstract void Execute();
        protected Light m_light;
    }

    public class LightOffCommand : Command
    {
        public LightOffCommand(Light light)
        {
            m_light = light;
        }
        public override void Execute()
        {
            m_light.SwitchOff();
        }
    }

    public class LightOnCommand : Command
    {
        public LightOnCommand(Light light)
        {
            m_light = light;
        }
        public override void Execute()
        {
            m_light.SwitchOn();
        }
    }
    //----------- Invoker --------------------
    public class RemoteControl
    {
        public void  PushButton(Command command)
        {
            command.Execute();
        }
    }
    //------------- Client --------------------
    class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light();
            LightOffCommand lightOff = new LightOffCommand(light);
            LightOnCommand lightOn = new LightOnCommand(light);

            RemoteControl remoteControl = new RemoteControl();

            remoteControl.PushButton(lightOn);
            remoteControl.PushButton(lightOff);

            Console.ReadKey();
        }
    }
}
