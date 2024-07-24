namespace RadioBrowserSharp.Models
{
    public class ListStationsParams
    {
        public OrderType OrderType { get; set; } = OrderType.Name;
        public bool Reverser { get; set; }
        public uint Offset { get; set; } = 0;

        public uint Limit { get; set; } = 100000;

        public bool HideBroken { get; set; } = false;

        public string ToUrl()
        {
            return $"?order={OrderType}&reverse={Reverser}&offst={Offset}&limit={Limit}&hidebroken={HideBroken}";
        }
    }
}
