using System.Collections.ObjectModel;

namespace ColumnChartDemo.ViewModel
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model("Korea",39),
                new Model("India",20),
                new Model("Africa",  61),
                new Model("China",65),
                new Model("France",45),
            };
        }
    }


    public class Model
    {
        public string Country { get; set; }

        public double Counts { get; set; }

        public Model(string name , double count)
        {
            Country = name;
            Counts = count;
        }
    }

}
