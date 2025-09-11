namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class ResturantLayout
    {
        public int[,] Layout { get; set; }

        public ResturantLayout(int row, int colum)
        {
            Layout = new int[row, colum];
        }
    }
}
