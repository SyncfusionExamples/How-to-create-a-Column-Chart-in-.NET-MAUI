# How-to-create-a-Column-Chart-in-.NET-MAUI
A .NET MAUI Column Chart is a visual representation of changing data that is created with high level of user interactive. This section explains how to create a beautiful .NET MAUI Column Charts

![.NET MAUI Column Chart](https://user-images.githubusercontent.com/13678478/137481351-eed5154b-5161-4dd7-9af9-3a08c13fd65b.png)

## Register the handler.
Syncfusion.Maui.Core nuget is a dependent package for all Syncfusion controls of .NET MAUI. In the MauiProgram.cs file, register the handler for Syncfusion core. For more details refer this link.

## Initialize Chart
Import the SfCartesianChart namespace as shown below.

**[XAML]**

```
xmlns:chart="clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts"
```

**[C#]**

```
using Syncfusion.Maui.Charts;
```
Initialize an empty chart with XAxes and YAxes as shown in the following code sample.

**[XAML]**

```
<chart:SfCartesianChart>

    <chart:SfCartesianChart.XAxes >
        <chart:CategoryAxis/>
    </chart:SfCartesianChart.XAxes>

    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis/>
    </chart:SfCartesianChart.YAxes>

</chart:SfCartesianChart>

```
**[C#]**

```
SfCartesianChart chart = new SfCartesianChart();

//Initializing Primary Axis
CategoryAxis primaryAxis = new CategoryAxis();

chart.XAxes.Add(primaryAxis);

//Initializing Secondary Axis
NumericalAxis secondaryAxis = new NumericalAxis();

chart.YAxes.Add(secondaryAxis);

this.Content = chart;

```

## Initialize view model
Now, let define a simple data model that represents a data point for .NET MAUI Column Chart.

```
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
```

Create a view model class and initialize a list of objects as shown below,

```
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
```

Set the ViewModel instance as the BindingContext of chart; this is done to bind properties of ViewModel to SfCartesianChart.

> Note: Add namespace of ViewModel class in your XAML page if you prefer to set BindingContext in XAML.

**[XAML]**

```
xmlns:viewModel ="clr-namespace:MauiApp"
. . .
<chart:SfCartesianChart>

    <chart:SfCartesianChart.BindingContext>
        <viewModel:ViewModel/>
    </chart:SfCartesianChart.BindingContext>

</chart:SfCartesianChart>
```
**[C#]**

```
SfCartesianChart chart = new SfCartesianChart();
chart.BindingContext = new ViewModel();
```

## How to populate data in .NET MAUI Column Charts
As we are going to visualize the comparison of annual rainfall in the data model, add ColumnSeries to SfCartesianChart.Series property, and then bind the Data property of the above ViewModel to the ColumnSeries.ItemsSource property as shown below.

> Note: Need to set XBindingPath and YBindingPath properties, so that series would fetch values from the respective properties in the data model to plot the series.

**[XAML]**

```
  <chart:SfCartesianChart>
    <chart:SfCartesianChart.BindingContext>
        <viewModel:ViewModel/>
    </chart:SfCartesianChart.BindingContext>
. . .
    <chart:SfCartesianChart.Series>
        <chart:ColumnSeries ItemsSource="{Binding Data}" 
                            XBindingPath="Country" 
                            YBindingPath="Counts" ShowDataLabels="True"/>
    </chart:SfCartesianChart.Series>

</chart:SfCartesianChart> 
```
**[C#]**

```
SfCartesianChart chart = new SfCartesianChart();
chart.BindingContext = new ViewModel();
. . .
var binding = new Binding() { Path = "Data" };
var columnSeries = new ColumnSeries()
{
XBindingPath = "Country ",
YBindingPath = "Counts", 
ShowDataLabels = true
};

columnSeries.SetBinding(ChartSeries.ItemsSourceProperty, binding);
chart.Series.Add(columnSeries);
```
