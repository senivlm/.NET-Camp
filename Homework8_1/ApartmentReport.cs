using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_1
{
    class ApartmentReport
    {
        private uint apartmentNumber;
        private string ownerName;
        private uint inputIndicator;
        private uint outputIndicator;
        private DateTime firstMonth;
        private DateTime secondMonth;
        private DateTime thirdMonth;
        private uint amountOfPayment;



        public ApartmentReport(uint apartmentNumber, string ownerName, uint inputIndicator,uint outputIndicator, 
            DateTime firstMonth, DateTime secondMonth, DateTime thirdMonth, uint amountOfPayment)
        {
            this.apartmentNumber = apartmentNumber;
            this.ownerName = ownerName;
            this.inputIndicator = inputIndicator;
            this.outputIndicator = outputIndicator;
            this.firstMonth = firstMonth;
            this.secondMonth = secondMonth;
            this.thirdMonth = thirdMonth;
            this.amountOfPayment = amountOfPayment;
        }

        public uint ApartmentNumber { get => apartmentNumber; }
        public string OwnerName { get => ownerName; }
        public uint InputIndicator { get => inputIndicator; }
        public uint OutputIndicator { get => outputIndicator; }
        public DateTime FirstMonth { get => firstMonth; }
        public DateTime SecondMonth { get => secondMonth; }
        public DateTime ThirdMonth { get => thirdMonth; }
        public uint AmountOfPayment { get => amountOfPayment; }

        public static List<ApartmentReport> operator+(ApartmentReport apartment1, ApartmentReport apartment2)
        {
            List<ApartmentReport> unionApartments = new();
            unionApartments.Add(apartment1);
            unionApartments.Add(apartment2);
            return unionApartments;
        }

        public override string ToString()
        {
            return $"Number of apartment: {ApartmentNumber}, owner: {OwnerName}, input and output indicators: ({InputIndicator}, {OutputIndicator})";
        }
    }
}
