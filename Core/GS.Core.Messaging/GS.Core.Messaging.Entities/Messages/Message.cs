namespace GS.Core.Messaging.Entities.Messages
{
    public class Message<T>
    {
        public string Key { get; set; }
        public T Value { get; set;}
    }
}