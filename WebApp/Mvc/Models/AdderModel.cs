namespace SitefinityWebApp.Mvc.Models
{
    public class AdderModel
    {
        public int A { get; set; }

        public int B { get; set; }

        public int Sum()
        {
            return this.A + this.B;
        }
    }
}