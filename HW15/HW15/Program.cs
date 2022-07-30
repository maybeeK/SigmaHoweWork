namespace HW15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            int[] numbers = new int[4] { 1, 2, 3, 4 };
            string[] stringList = new string[6] { "1", "2a", "3ab", "4", "5ab", "qwer" };
            string nf = "Not found";
            string[] result = numbers
                .Select(n => $"{n} - {stringList.FirstOrDefault(x => Char.IsDigit(x[0]) && x.Length == n) ?? nf}")
                .ToArray();
            #endregion
            #region Task 2
            string[] stringList2 = new string[6] { "QWE", "ASD", "EBE", "QWFGREG", "FWEFWEEWWFEWE", "G" };
            string[] result2 = stringList2.Select(x => x[0])
                .ToHashSet()
                .Select(x => $"{x} - {stringList2.Where(w => w[0] == x).Sum(x => x.Length)}")
                .OrderByDescending(x => int.Parse(x.Split(' ')[2]))
                .ThenBy(x => (int)x.Split(' ')[0][0])
                .ToArray();
            #endregion
            #region Task 3
            List<Student> nameList = new List<Student>() {
                new Student("Name1", 1, 2004),
                new Student("Name2", 1, 2003),
                new Student("Name3", 2, 2003),
                new Student("Name4", 2, 2005),
                new Student("Name5", 3, 2005),
                new Student("Name6", 1, 2006)
            };
            List<int> years = new List<int>() { 2003, 2004, 2005, 2006, 2007 };
            List<string> result3 = years
                .Select(y => $"Year: {y} - Schools: {nameList.Where(x => x.Year == y).Select(x => x.SchoolNumber).ToHashSet().Count}")
                .OrderBy(x => int.Parse(x.Split(' ')[4]))
                .ThenBy(x => int.Parse(x.Split(' ')[1]))
                .ToList();
            #endregion
            #region Task 4
            List<Suplier> suplierList = new List<Suplier>()
            {
                new Suplier(1, 2000, "Street1"),
                new Suplier(2, 2001, "Street1"),
                new Suplier(3, 2002, "Street1"),
                new Suplier(4, 2003, "Street1"),
                new Suplier(5, 2002, "Street1"),
                new Suplier(6, 2004, "Street1"),
                new Suplier(7, 2001, "Street1"),
            };
            List<SupplierDiscount> supplierDiscountList = new List<SupplierDiscount>()
            {
                new SupplierDiscount(1, "Shop1", 30),
                new SupplierDiscount(2, "Shop2", 60),
                new SupplierDiscount(3, "Shop2", 40),
                new SupplierDiscount(4, "Shop1", 30),
                new SupplierDiscount(5, "Shop3", 70),
                new SupplierDiscount(6, "Shop2", 60),
                new SupplierDiscount(7, "Shop3", 30),
            };
            List<string> maxDiscountOwnerStringList = supplierDiscountList
                .Select(x => x.ShopName)
                .ToHashSet()
                .ToList()
                .Select(x => $"{x} {supplierDiscountList.Where(s => s.ShopName == x).OrderByDescending(x=> x.Discount).ThenBy(x=>x.Id).First().Discount}")
                .ToList()
                .Select(x=>$"{x} {supplierDiscountList.First(s=> s.ShopName==x.Split(' ')[0] && int.Parse(x.Split(' ')[1]) == s.Discount).Id}")
                .ToList();
            List<MaxDiscountOwner> maxDiscountOwnerList = new();
            foreach (var item in maxDiscountOwnerStringList)
            {
                maxDiscountOwnerList.Add(MaxDiscountOwner.Parse(item));
            }

            #endregion
        }
    }
    internal class Student
    {
        public string SurName { get; set; }
        public int SchoolNumber { get; set; }
        public int Year { get; set; }
        public Student(string name, int number, int year)
        {
            SurName = name;
            SchoolNumber = number;
            Year = year;
        }
        public Student()
        {

        }
    }
    internal class Suplier
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Street { get; set; }
        public Suplier(int id, int year, string street)
        {
            Id = id;
            Year = year;
            Street = street;
        }
        public Suplier()
        {

        }
    }
    internal class SupplierDiscount
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public double Discount { get; set; }
        public SupplierDiscount(int id, string shop, double discount)
        {
            Id = id;
            ShopName = shop;
            Discount = discount;
        }
        public SupplierDiscount()
        {

        }
    }
    internal class MaxDiscountOwner
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public static MaxDiscountOwner Parse(string str)
        {
            string[] line = str.Split(' ');
            return new MaxDiscountOwner(int.Parse(line[2]), line[0]);
        }
        public MaxDiscountOwner(int id, string shop)
        {
            Id = id;
            ShopName = shop;
        }
        public MaxDiscountOwner()
        {

        }
    }
}