namespace API.Dtos
{
    public class OrderDto
    {
        public string   BasketId { get; set; }

        public string BuyerEmail {get; set;}

        public string BuyerName { get; set; }
         
         public double lat {get; set;}

         public double lng {get; set;}
         

    }
}