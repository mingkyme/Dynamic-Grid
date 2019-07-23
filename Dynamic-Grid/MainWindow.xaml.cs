using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dynamic_Grid
{
    public partial class MainWindow : Window
    {
        Grid[] grids;
        GridLocation[] gridLocations;
        int index = 1;

        public MainWindow()
        {
            InitializeComponent();

            grids = new Grid[] { XAML_Grid01, XAML_Grid02, XAML_Grid03 };
            gridLocations = new GridLocation[] { new GridLocation(grids[0]), new GridLocation(grids[1]), new GridLocation(grids[2]) };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch(index)
            {
                case 0:
                    GridLocation.SetGridLocation(gridLocations[0], grids[0]);
                    GridLocation.SetGridLocation(gridLocations[1], grids[1]);
                    GridLocation.SetGridLocation(gridLocations[2], grids[2]);
                    break;
                case 1:
                    GridLocation.SetGridLocation(gridLocations[0], grids[1]);
                    GridLocation.SetGridLocation(gridLocations[1], grids[2]);
                    GridLocation.SetGridLocation(gridLocations[2], grids[0]);
                    break;
                case 2:
                    GridLocation.SetGridLocation(gridLocations[0], grids[2]);
                    GridLocation.SetGridLocation(gridLocations[1], grids[0]);
                    GridLocation.SetGridLocation(gridLocations[2], grids[1]);
                    break;
            }
            index++;
            if (index == 3)
            {
                index = 0;
            }
        }
    }
    public class GridLocation
    {
        int row;
        int column;

        int rowSpan;
        int columnSpan;

        public GridLocation(Grid grid)
        {
            column = Grid.GetColumn(grid);
            row = Grid.GetRow(grid);

            rowSpan = Grid.GetRowSpan(grid);
            columnSpan = Grid.GetColumnSpan(grid);
        }
        public GridLocation(int row, int column, int rowSpan, int columnSpan)
        {
            this.row = row;
            this.column = column;

            this.rowSpan = rowSpan;
            this.columnSpan = columnSpan;
        }
        public static void SetGridLocation(GridLocation gridLocation, Grid grid)
        {
            Grid.SetColumn(grid, gridLocation.column);
            Grid.SetRow(grid, gridLocation.row);

            Grid.SetColumnSpan(grid, gridLocation.columnSpan);
            Grid.SetRowSpan(grid, gridLocation.rowSpan);
        }
    }
}
