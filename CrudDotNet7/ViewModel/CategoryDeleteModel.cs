namespace CrudDotNet7.ViewModel
{
    public class CategoryDeleteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Display { get; set; }
        public string Brand { get; set; }
        public Boolean IsFavorite { get; set; }

        public Boolean IsPacket { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

       
    }
}
