namespace Core
{
    public interface ICollectable<out T>
    {
        T Collect();
    }
}
