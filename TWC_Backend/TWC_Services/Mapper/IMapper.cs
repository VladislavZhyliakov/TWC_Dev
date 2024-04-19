namespace TWC_Services.Mapper
{
    public interface IMapper<T, V>
    {
        public V Map(T data);
        public T Unmap(V data);
    }
}
