using System.Windows.Forms;

namespace ControlVar2AB
{
    public partial class Form1 : Form
    {
        private List<Country> countries;
        private List<Accommodation> accommodations;
        private IEnumerable<dynamic> result;

        public Form1()
        {
            InitializeComponent();
      
            var countryFilePath = "countries.txt";
            countries = File.ReadLines(countryFilePath)
                .Select(line => line.Split(','))
                .Select(parts => new Country { Id = int.Parse(parts[0]), Name = parts[1] })
                .ToList();

            var accommodationFilePath = "accommodations.txt";
            accommodations = File.ReadLines(accommodationFilePath)
                .Select(line => line.Split(','))
                .Select(parts => new Accommodation
                {
                    AccommodationType = parts[0],
                    Id = int.Parse(parts[1]),
                    Name = parts[2],
                    Price = decimal.Parse(parts[3])
                })
                .ToList();

           
            cmbGroupBy.Items.Add("AccommodationType"); // сортировка по инд
          
            cmbGroupBy.Items.Add("Price"); // сортировка по цене
      





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sortBy = cmbGroupBy.SelectedItem.ToString();

            result = from c in countries
                     join a in accommodations on c.Id equals a.Id
                     orderby a.AccommodationType ascending
                     select new
                     {
                         AccommodationType = a.AccommodationType,
                         Count = accommodations.Count(a2 => a2.AccommodationType == a.AccommodationType),
                         Accommodations = accommodations.Where(a2 => a2.AccommodationType == a.AccommodationType).ToList()
                     };

            dataGridViewResult.DataSource = result.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string groupBy = cmbGroupBy.SelectedItem.ToString();

            // Выборка данных с группировкой
            result = from c in countries
                     join a in accommodations on c.Id equals a.Id
                     group a by a.GetType().GetProperty(groupBy).GetValue(a) into grp
                     select new
                     {
                         GroupName = grp.Key.ToString(),
                         Count = grp.Count(),
                         Accommodations = grp.ToList()
                     };

            // Преобразование результатов для отображения в DataGridView
            var formattedResult = result.SelectMany<dynamic, dynamic, dynamic>(grp => grp.Accommodations, (grp, a) => new
            {
                AccommodationId = a.Id,
                HotelName = a.Name,
                Country = countries.FirstOrDefault(c => c.Id == a.Id)?.Name,
                Count = grp.Count,
                Price = a.Price
            }).OrderBy(x => x.AccommodationId); // Сортировка по идентификатору путевки

            // Дополнительная сортировка по цене и количеству
            if (groupBy == "Price")
            {
                formattedResult = formattedResult.OrderBy(x => x.Price);
            }
          

            dataGridViewResult.DataSource = formattedResult.ToList();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DeleteSelectedRecord()
        {
            if (dataGridViewResult.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewResult.SelectedRows[0];
                int accommodationId = Convert.ToInt32(selectedRow.Cells["AccommodationId"].Value);

                Accommodation accommodationToDelete = accommodations.FirstOrDefault(a => a.Id == accommodationId);
                if (accommodationToDelete != null)
                {
                    accommodations.Remove(accommodationToDelete);
                    RefreshDataGridView();
                }
            }
        }

        private void RefreshDataGridView()
        {
            string groupBy = cmbGroupBy.SelectedItem.ToString();

            var formattedResult = result.SelectMany<dynamic, dynamic, dynamic>(grp => grp.Accommodations, (grp, a) => new
            {
                AccommodationId = a.Id,
                HotelName = a.Name,
                Country = countries.FirstOrDefault(c => c.Id == a.Id)?.Name,
                Count = grp.Count,
                Price = a.Price
            }).OrderBy(x => x.AccommodationId);

            if (groupBy == "Price")
            {
                formattedResult = formattedResult.OrderBy(x => x.Price);
            }

            dataGridViewResult.DataSource = formattedResult.ToList();
        }




        private void buttonDelet_Click(object sender, EventArgs e)
        {
            DeleteSelectedRecord();

        }

    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Accommodation
    {
        public string AccommodationType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}