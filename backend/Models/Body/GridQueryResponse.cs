namespace webapi.Models
{
    public class GridQueryResponse<T>
    {
        public int TotalRows { get; set; }
        public IEnumerable<T> Rows { get; set; }
    }
}