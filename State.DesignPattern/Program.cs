using System;

namespace State.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modified = new ModifiedState();
            DeletedState deleted = new DeletedState();
            modified.DoAction(context);
            deleted.DoAction(context);
            var lastProcess = context.GetState().ToString();
            Console.WriteLine("Last Process:" + lastProcess);
            Console.ReadLine();
        }
    }

    interface IState
    {
        void DoAction(Context context);
        string ToString();
    }
    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State Modified");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Modified";
        }
    }
    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State deleted");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
    class Context
    {
        public IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }
        public IState GetState()
        {
            return _state;
        }
    }
}
