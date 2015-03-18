namespace Core.MVC
{
    public abstract class Controller : Notifier
    {
        public virtual void Init()
        {
            RegistEventHandle();
        }

        public abstract void RegistEventHandle();
    }
}